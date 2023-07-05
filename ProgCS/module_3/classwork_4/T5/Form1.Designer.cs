namespace Task5
{
    partial class DrawCircleForm
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
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.RadiusLabel = new System.Windows.Forms.Label();
            this.InputRadius = new System.Windows.Forms.TextBox();
            this.ChangeRadiusButton = new System.Windows.Forms.Button();
            this.checkBoxBlue = new System.Windows.Forms.CheckBox();
            this.checkBoxGreen = new System.Windows.Forms.CheckBox();
            this.checkBoxRed = new System.Windows.Forms.CheckBox();
            this.ColorListLabel = new System.Windows.Forms.Label();
            this.checkBoxYellow = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(646, 79);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(539, 432);
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            // 
            // RadiusLabel
            // 
            this.RadiusLabel.AutoSize = true;
            this.RadiusLabel.Location = new System.Drawing.Point(133, 79);
            this.RadiusLabel.Name = "RadiusLabel";
            this.RadiusLabel.Size = new System.Drawing.Size(72, 25);
            this.RadiusLabel.TabIndex = 1;
            this.RadiusLabel.Text = "Radius";
            // 
            // InputRadius
            // 
            this.InputRadius.Location = new System.Drawing.Point(212, 79);
            this.InputRadius.Name = "InputRadius";
            this.InputRadius.Size = new System.Drawing.Size(160, 29);
            this.InputRadius.TabIndex = 2;
            // 
            // ChangeRadiusButton
            // 
            this.ChangeRadiusButton.Location = new System.Drawing.Point(138, 145);
            this.ChangeRadiusButton.Name = "ChangeRadiusButton";
            this.ChangeRadiusButton.Size = new System.Drawing.Size(252, 168);
            this.ChangeRadiusButton.TabIndex = 4;
            this.ChangeRadiusButton.Text = "Draw";
            this.ChangeRadiusButton.UseVisualStyleBackColor = true;
            this.ChangeRadiusButton.Click += new System.EventHandler(this.ChangeRadiusButton_Click);
            // 
            // checkBoxBlue
            // 
            this.checkBoxBlue.AutoSize = true;
            this.checkBoxBlue.Location = new System.Drawing.Point(444, 176);
            this.checkBoxBlue.Name = "checkBoxBlue";
            this.checkBoxBlue.Size = new System.Drawing.Size(73, 29);
            this.checkBoxBlue.TabIndex = 5;
            this.checkBoxBlue.Text = "Blue";
            this.checkBoxBlue.UseVisualStyleBackColor = true;
            this.checkBoxBlue.Click += new System.EventHandler(this.checkBoxBlue_CheckedChanged);
            // 
            // checkBoxGreen
            // 
            this.checkBoxGreen.AutoSize = true;
            this.checkBoxGreen.Location = new System.Drawing.Point(444, 212);
            this.checkBoxGreen.Name = "checkBoxGreen";
            this.checkBoxGreen.Size = new System.Drawing.Size(88, 29);
            this.checkBoxGreen.TabIndex = 6;
            this.checkBoxGreen.Text = "Green";
            this.checkBoxGreen.UseVisualStyleBackColor = true;
            this.checkBoxGreen.Click += new System.EventHandler(this.checkBoxGreen_CheckedChanged);
            // 
            // checkBoxRed
            // 
            this.checkBoxRed.AutoSize = true;
            this.checkBoxRed.Location = new System.Drawing.Point(444, 248);
            this.checkBoxRed.Name = "checkBoxRed";
            this.checkBoxRed.Size = new System.Drawing.Size(69, 29);
            this.checkBoxRed.TabIndex = 7;
            this.checkBoxRed.Text = "Red";
            this.checkBoxRed.UseVisualStyleBackColor = true;
            this.checkBoxRed.Click += new System.EventHandler(this.checkBoxRed_CheckedChanged);
            // 
            // ColorListLabel
            // 
            this.ColorListLabel.AutoSize = true;
            this.ColorListLabel.Location = new System.Drawing.Point(444, 145);
            this.ColorListLabel.Name = "ColorListLabel";
            this.ColorListLabel.Size = new System.Drawing.Size(193, 25);
            this.ColorListLabel.TabIndex = 8;
            this.ColorListLabel.Text = "Select custom colour";
            // 
            // checkBoxYellow
            // 
            this.checkBoxYellow.AutoSize = true;
            this.checkBoxYellow.Location = new System.Drawing.Point(444, 284);
            this.checkBoxYellow.Name = "checkBoxYellow";
            this.checkBoxYellow.Size = new System.Drawing.Size(91, 29);
            this.checkBoxYellow.TabIndex = 9;
            this.checkBoxYellow.Text = "Yellow";
            this.checkBoxYellow.UseVisualStyleBackColor = true;
            this.checkBoxYellow.Click += new System.EventHandler(this.checkBoxYellow_CheckedChanged);
            // 
            // DrawCircleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1254, 811);
            this.Controls.Add(this.checkBoxYellow);
            this.Controls.Add(this.ColorListLabel);
            this.Controls.Add(this.checkBoxRed);
            this.Controls.Add(this.checkBoxGreen);
            this.Controls.Add(this.checkBoxBlue);
            this.Controls.Add(this.ChangeRadiusButton);
            this.Controls.Add(this.InputRadius);
            this.Controls.Add(this.RadiusLabel);
            this.Controls.Add(this.pictureBox);
            this.Name = "DrawCircleForm";
            this.Text = "Draw Circle";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Label RadiusLabel;
        private System.Windows.Forms.TextBox InputRadius;
        private System.Windows.Forms.Button ChangeRadiusButton;
        private System.Windows.Forms.CheckBox checkBoxBlue;
        private System.Windows.Forms.CheckBox checkBoxGreen;
        private System.Windows.Forms.CheckBox checkBoxRed;
        private System.Windows.Forms.Label ColorListLabel;
        private System.Windows.Forms.CheckBox checkBoxYellow;
    }
}

