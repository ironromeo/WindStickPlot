namespace WindStickPlot
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonOK = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.textBoxExcelFilename = new System.Windows.Forms.TextBox();
            this.textBoxBeginDate = new System.Windows.Forms.TextBox();
            this.textBoxEndDate = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxNorthDirection = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxInterpolateMultiplier = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxWidth = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxStrength = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(502, 12);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(199, 55);
            this.buttonOK.TabIndex = 0;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // textBoxExcelFilename
            // 
            this.textBoxExcelFilename.Location = new System.Drawing.Point(160, 12);
            this.textBoxExcelFilename.Name = "textBoxExcelFilename";
            this.textBoxExcelFilename.Size = new System.Drawing.Size(336, 20);
            this.textBoxExcelFilename.TabIndex = 1;
            this.textBoxExcelFilename.Click += new System.EventHandler(this.textBoxExcelFilename_Click);
            // 
            // textBoxBeginDate
            // 
            this.textBoxBeginDate.Location = new System.Drawing.Point(160, 38);
            this.textBoxBeginDate.Name = "textBoxBeginDate";
            this.textBoxBeginDate.Size = new System.Drawing.Size(82, 20);
            this.textBoxBeginDate.TabIndex = 2;
            // 
            // textBoxEndDate
            // 
            this.textBoxEndDate.Location = new System.Drawing.Point(160, 64);
            this.textBoxEndDate.Name = "textBoxEndDate";
            this.textBoxEndDate.Size = new System.Drawing.Size(82, 20);
            this.textBoxEndDate.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Файл EXCEL";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Дата начала";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Дата конец";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 109);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Направление СЕВЕРА";
            // 
            // textBoxNorthDirection
            // 
            this.textBoxNorthDirection.Location = new System.Drawing.Point(160, 106);
            this.textBoxNorthDirection.Name = "textBoxNorthDirection";
            this.textBoxNorthDirection.Size = new System.Drawing.Size(100, 20);
            this.textBoxNorthDirection.TabIndex = 7;
            this.textBoxNorthDirection.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 137);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(141, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "интерполяция(множитель)";
            // 
            // textBoxInterpolateMultiplier
            // 
            this.textBoxInterpolateMultiplier.Location = new System.Drawing.Point(160, 137);
            this.textBoxInterpolateMultiplier.Name = "textBoxInterpolateMultiplier";
            this.textBoxInterpolateMultiplier.Size = new System.Drawing.Size(56, 20);
            this.textBoxInterpolateMultiplier.TabIndex = 9;
            this.textBoxInterpolateMultiplier.Text = "10";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 168);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "ширина(пикселей)";
            // 
            // textBoxWidth
            // 
            this.textBoxWidth.Location = new System.Drawing.Point(160, 168);
            this.textBoxWidth.Name = "textBoxWidth";
            this.textBoxWidth.Size = new System.Drawing.Size(56, 20);
            this.textBoxWidth.TabIndex = 11;
            this.textBoxWidth.Text = "2000";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 195);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(92, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "макс сила ветра";
            // 
            // textBoxStrength
            // 
            this.textBoxStrength.Location = new System.Drawing.Point(160, 195);
            this.textBoxStrength.Name = "textBoxStrength";
            this.textBoxStrength.Size = new System.Drawing.Size(56, 20);
            this.textBoxStrength.TabIndex = 13;
            this.textBoxStrength.Text = "10";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(707, 450);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBoxStrength);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBoxWidth);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxInterpolateMultiplier);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxNorthDirection);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxEndDate);
            this.Controls.Add(this.textBoxBeginDate);
            this.Controls.Add(this.textBoxExcelFilename);
            this.Controls.Add(this.buttonOK);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox textBoxExcelFilename;
        private System.Windows.Forms.TextBox textBoxBeginDate;
        private System.Windows.Forms.TextBox textBoxEndDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxNorthDirection;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxInterpolateMultiplier;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxWidth;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxStrength;
    }
}

