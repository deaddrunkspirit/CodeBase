namespace Task4
{
    partial class Form2
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
            this.sampleSizeLabel = new System.Windows.Forms.Label();
            this.averageLabel = new System.Windows.Forms.Label();
            this.xMinLabel = new System.Windows.Forms.Label();
            this.xMaxLabel = new System.Windows.Forms.Label();
            this.deviationLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // sampleSizeLabel
            // 
            this.sampleSizeLabel.AutoSize = true;
            this.sampleSizeLabel.Location = new System.Drawing.Point(85, 50);
            this.sampleSizeLabel.Name = "sampleSizeLabel";
            this.sampleSizeLabel.Size = new System.Drawing.Size(178, 25);
            this.sampleSizeLabel.TabIndex = 0;
            this.sampleSizeLabel.Text = "Размер выборки: ";
            // 
            // averageLabel
            // 
            this.averageLabel.AutoSize = true;
            this.averageLabel.Location = new System.Drawing.Point(85, 172);
            this.averageLabel.Name = "averageLabel";
            this.averageLabel.Size = new System.Drawing.Size(195, 25);
            this.averageLabel.TabIndex = 1;
            this.averageLabel.Text = "Среднее значение: ";
            // 
            // xMinLabel
            // 
            this.xMinLabel.AutoSize = true;
            this.xMinLabel.Location = new System.Drawing.Point(85, 135);
            this.xMinLabel.Name = "xMinLabel";
            this.xMinLabel.Size = new System.Drawing.Size(65, 25);
            this.xMinLabel.TabIndex = 2;
            this.xMinLabel.Text = "xMin: ";
            // 
            // xMaxLabel
            // 
            this.xMaxLabel.AutoSize = true;
            this.xMaxLabel.Location = new System.Drawing.Point(85, 95);
            this.xMaxLabel.Name = "xMaxLabel";
            this.xMaxLabel.Size = new System.Drawing.Size(71, 25);
            this.xMaxLabel.TabIndex = 3;
            this.xMaxLabel.Text = "xMax: ";
            // 
            // deviationLabel
            // 
            this.deviationLabel.AutoSize = true;
            this.deviationLabel.Location = new System.Drawing.Point(85, 213);
            this.deviationLabel.Name = "deviationLabel";
            this.deviationLabel.Size = new System.Drawing.Size(354, 25);
            this.deviationLabel.TabIndex = 4;
            this.deviationLabel.Text = "Среднее квадратичное отклонение: ";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(748, 323);
            this.Controls.Add(this.deviationLabel);
            this.Controls.Add(this.xMaxLabel);
            this.Controls.Add(this.xMinLabel);
            this.Controls.Add(this.averageLabel);
            this.Controls.Add(this.sampleSizeLabel);
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Оценки характеристик";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label sampleSizeLabel;
        public System.Windows.Forms.Label averageLabel;
        public System.Windows.Forms.Label xMinLabel;
        public System.Windows.Forms.Label xMaxLabel;
        public System.Windows.Forms.Label deviationLabel;
    }
}