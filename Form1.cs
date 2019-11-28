using Common.Tools.Parsers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindStickPlot
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public class WindRecord
        {
            public DateTime Date;
            public double Strength;
            public double Direction;

            public double x;
            public double rad;
            public double x2;
            public double y;
            public override string ToString()
            {
                return $"{Date}:{Direction}={Strength}";
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            string fn = SrcFilename;
            try
            {
                if (!Read(fn)) return;
                if (!PrepareData(false)) return;
                if (!RenderData()) return;
            }
            catch (Exception exc)
            {
                MessageBox.Show("Ошибка " + exc.Message);
                return;
            }
        }

        WindRecord[] Data = null;
        private bool Read(string fn)
        {
            ExcelTableReader reader = new ExcelTableReader();

            if (!reader.Read(fn))
            {
                MessageBox.Show("Не удалось прочитать файл " + fn);
                return false;
            }

            int c = 0;
            if(reader.Pages.Count>1)
            {
                string mes = string.Format("Файл '{0}' содержит более одной закладки. Прочитать данные из первой закладки='{1}'?", Path.GetFileName(fn), reader.Pages[0].Name);
                if (MessageBox.Show(mes, "", MessageBoxButtons.OKCancel) != DialogResult.OK) return false;
            }
            c = 0;

            DataTable table = reader.Pages[c].Table;
            if (table.Columns.IndexOf("date") == -1)
            {
                MessageBox.Show("Не найдена колонка date");
                return false;
            }
            if (table.Columns.IndexOf("direction") == -1)
            {
                MessageBox.Show("Не найдена колонка direction");
                return false;
            }
            if (table.Columns.IndexOf("strength") == -1)
            {
                MessageBox.Show("Не найдена колонка strength");
                return false;
            }

            List<WindRecord> data = new List<WindRecord>();
            List<string> errors = new List<string>();

            foreach (DataRow row in table.Rows)
            {
                var item = new WindRecord();
                if (!DateTime.TryParse(row["date"].ToString(), out DateTime dt))
                {
                    errors.Add("invalid date:" + row["date"].ToString());
                    continue;
                }
                item.Date = dt;

                if (!double.TryParse(row["direction"].ToString(), out double direction))
                {
                    errors.Add("invalid direction:" + row["direction"].ToString());
                    continue;
                }
                item.Direction = direction;

                if (!double.TryParse(row["strength"].ToString(), out double strength))
                {
                    errors.Add("invalid strength:" + row["strength"].ToString());
                    continue;
                }
                item.Strength = strength;
                data.Add(item);
            }

            Data = data.ToArray();


            return true;
        }

        int InterpolateMultiplier = 2;
        private WindRecord[] InterpolateData(WindRecord[] src)
        {
            List<WindRecord> result = new List<WindRecord>();
            for (int c = 0; c < src.Length; c++)
            {
                var item = src[c];
                result.Add(item);
                if( c < src.Length-1)
                {
                    var nextItem = src[c+1];
                    var intervalMinutes = (nextItem.Date - item.Date).TotalMinutes;
                    for (int i = 1; i < InterpolateMultiplier; i ++ )
                    {
                        double ratio = (double)i / InterpolateMultiplier;
                        var interDate = item.Date.AddMinutes(intervalMinutes* ratio);
                        var interDirection = item.Direction + (nextItem.Direction - item.Direction) * ratio;
                        var interS = item.Strength + (nextItem.Strength - item.Strength) * ratio;
                        var iterpolated = new WindRecord() { Date = interDate, Direction = interDirection, Strength = interS };
                        result.Add(iterpolated);
                    }
                }
            }
            return result.ToArray();
        }

        private bool PrepareData(bool updateDates)
        {
            int beginDateIndex = 0;
            DateTime prevDate = DateTime.MinValue;
            for (int c = 0; c < Data.Length; c++)
            {
                var curDate = Data[c].Date;

                if (curDate == prevDate)
                {
                    continue;
                }

                if (beginDateIndex + 1 < c)
                {
                    var stepMinutes = 1440 / (c - beginDateIndex);
                    for (int d = beginDateIndex; d < c; d++)
                    {
                        Data[d].Date = Data[d].Date.AddMinutes(stepMinutes * (d - beginDateIndex));
                    }
                }

                beginDateIndex = c;
                prevDate = curDate;
            }

            if (updateDates)
            {
                this.textBoxBeginDate.Text = this.Data.First().Date.ToString("dd.MM.yyyy");
                this.textBoxEndDate.Text = this.Data.Last().Date.ToString("dd.MM.yyyy");

                var maxWindStrength = this.Data.Max(x => x.Strength);
                this.textBoxStrength.Text = maxWindStrength.ToString();
            }

            int renderedNorthDirection = int.Parse(this.textBoxNorthDirection.Text);
            this.northDirectionAngle = -renderedNorthDirection + 90;

            this.InterpolateMultiplier = int.Parse(this.textBoxInterpolateMultiplier.Text);
            this.canvasWidth = int.Parse(this.textBoxWidth.Text);

            return true;
        }


        int canvasWidth = 2000;
        int canvasHeight = 400;
        static int MARGIN = 200;
        int maxStrengthLen = MARGIN;
        double northDirectionAngle = 90;

        private bool RenderData()
        {
            DateTime beginDate = DateTime.Parse(this.textBoxBeginDate.Text);
            DateTime endDate = DateTime.Parse(this.textBoxEndDate.Text).AddHours(23);

            var selectedData = Data.Where(x => x.Date >= beginDate && x.Date <= endDate).ToArray();
            var renderingData = InterpolateData(selectedData);

            var maxWindStrength = double.Parse(this.textBoxStrength.Text);

            var totalMinutes = (endDate - beginDate).TotalMinutes;
            var pixelXperMinute = (canvasWidth - 2 * MARGIN) / totalMinutes;
            var pixelYperStrength = maxStrengthLen / maxWindStrength;

            for (int c = 0; c < renderingData.Length; c++)
            {
                var item = renderingData[c];

                item.x = pixelXperMinute * (item.Date - beginDate).TotalMinutes;
                item.rad = (northDirectionAngle - item.Direction) * Math.PI / 180;
                item.y = (pixelYperStrength * item.Strength) * Math.Sin(item.rad);
                var x_shift = (pixelYperStrength * item.Strength) * Math.Cos(item.rad);
                item.x2 = item.x + x_shift;
            }

            Image bmp = new Bitmap(canvasWidth, canvasHeight);
            Graphics g = Graphics.FromImage(bmp);
            var penAxis = new Pen(Color.Black);
            var pen = new Pen(Color.Blue);
            int G1_X0 = MARGIN;
            int G1_Y0 = MARGIN;
            g.DrawLine(penAxis, new Point(G1_X0, G1_Y0), new Point(canvasWidth - MARGIN, G1_Y0));

            for (int i = 0; i < renderingData.Length; i++)
            {
                var item = renderingData[i];
                g.DrawLine(pen, new Point(G1_X0 + (int)item.x, G1_Y0), new Point(G1_X0 + (int)item.x2, G1_Y0 - (int)item.y));
            }


            var penNorth = new Pen(Color.Red);
            var northrad = (northDirectionAngle - 0) * Math.PI / 180;
            var xNorth = Math.Cos(northrad) * 100;
            var yNorth = Math.Sin(northrad) * 100;
            int northX = 180;
            g.DrawLine(penNorth, new Point(northX, G1_Y0), new Point(northX + (int)xNorth, G1_Y0- (int)yNorth));
            int radius = 5;
            g.DrawEllipse(penNorth, northX - radius, G1_Y0 - radius, radius * 2, radius * 2);

            var penStrength = new Pen(Color.Green);
            g.DrawLine(penStrength, new Point(G1_X0, G1_Y0), new Point(G1_X0, G1_Y0 - maxStrengthLen));
            g.DrawLine(penStrength, new Point(canvasWidth - MARGIN, G1_Y0), new Point(canvasWidth - MARGIN, G1_Y0 - maxStrengthLen));

            g.Dispose();

            string resultFileName = string.Format("{0}_{1}_{2}_N{3}_x{4}.bmp", Path.GetFileNameWithoutExtension(SrcFilename), beginDate.ToString("dd-MM-yyyy"), endDate.ToString("dd-MM-yyyy"), this.textBoxNorthDirection.Text, InterpolateMultiplier);
            string fn = Path.Combine(Path.GetDirectoryName(SrcFilename), resultFileName);
            bmp.Save(fn);

            System.Diagnostics.Process.Start(fn);
            return true;
        }

        private void textBoxExcelFilename_Click(object sender, EventArgs e)
        {
            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.textBoxExcelFilename.Text = this.openFileDialog1.FileName;
                if (!Read(SrcFilename)) return;
                if (!PrepareData(true)) return;

            }
        }

        public string SrcFilename => this.textBoxExcelFilename.Text;

        private void Form1_Load(object sender, EventArgs e)
        {
            this.textBoxExcelFilename.Text = @"C:\temp\wind\wind.xlsx";
            if (!Read(SrcFilename)) return;
            if (!PrepareData(true)) return;

        }
    }
}
