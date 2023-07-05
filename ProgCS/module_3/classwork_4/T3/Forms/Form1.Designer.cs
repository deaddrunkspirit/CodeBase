namespace Task3Forms
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lengthLabel = new System.Windows.Forms.Label();
            this.radiusLabel = new System.Windows.Forms.Label();
            this.beadsCountLabel = new System.Windows.Forms.Label();
            this.lengthTextBox = new System.Windows.Forms.TextBox();
            this.radiusTextBox = new System.Windows.Forms.TextBox();
            this.beadsCountTextBox = new System.Windows.Forms.TextBox();
            this.drawButton = new System.Windows.Forms.Button();
            this.changeLengthButton = new System.Windows.Forms.Button();
            this.changeBeadsCountButton = new System.Windows.Forms.Button();
            this.changeRadiusButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(554, 56);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(745, 601);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(756, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Current chain";
            // 
            // lengthLabel
            // 
            this.lengthLabel.AutoSize = true;
            this.lengthLabel.Location = new System.Drawing.Point(58, 38);
            this.lengthLabel.Name = "lengthLabel";
            this.lengthLabel.Size = new System.Drawing.Size(72, 25);
            this.lengthLabel.TabIndex = 2;
            this.lengthLabel.Text = "Length";
            // 
            // radiusLabel
            // 
            this.radiusLabel.AutoSize = true;
            this.radiusLabel.Location = new System.Drawing.Point(393, 38);
            this.radiusLabel.Name = "radiusLabel";
            this.radiusLabel.Size = new System.Drawing.Size(72, 25);
            this.radiusLabel.TabIndex = 3;
            this.radiusLabel.Text = "Radius";
            // 
            // beadsCountLabel
            // 
            this.beadsCountLabel.AutoSize = true;
            this.beadsCountLabel.Location = new System.Drawing.Point(226, 38);
            this.beadsCountLabel.Name = "beadsCountLabel";
            this.beadsCountLabel.Size = new System.Drawing.Size(121, 25);
            this.beadsCountLabel.TabIndex = 4;
            this.beadsCountLabel.Text = "Beads count";
            // 
            // lengthTextBox
            // 
            this.lengthTextBox.Location = new System.Drawing.Point(63, 79);
            this.lengthTextBox.Name = "lengthTextBox";
            this.lengthTextBox.Size = new System.Drawing.Size(138, 29);
            this.lengthTextBox.TabIndex = 5;
            this.lengthTextBox.TextChanged += new System.EventHandler(this.lengthTextBox_TextChanged);
            // 
            // radiusTextBox
            // 
            this.radiusTextBox.Location = new System.Drawing.Point(398, 79);
            this.radiusTextBox.Name = "radiusTextBox";
            this.radiusTextBox.Size = new System.Drawing.Size(138, 29);
            this.radiusTextBox.TabIndex = 6;
            this.radiusTextBox.TextChanged += new System.EventHandler(this.radiusTextBox_TextChanged);
            // 
            // beadsCountTextBox
            // 
            this.beadsCountTextBox.Location = new System.Drawing.Point(231, 79);
            this.beadsCountTextBox.Name = "beadsCountTextBox";
            this.beadsCountTextBox.Size = new System.Drawing.Size(138, 29);
            this.beadsCountTextBox.TabIndex = 7;
            this.beadsCountTextBox.TextChanged += new System.EventHandler(this.beadsCountTextBox_TextChanged);
            // 
            // drawButton
            // 
            this.drawButton.Location = new System.Drawing.Point(323, 314);
            this.drawButton.Name = "drawButton";
            this.drawButton.Size = new System.Drawing.Size(175, 106);
            this.drawButton.TabIndex = 8;
            this.drawButton.Text = "Draw";
            this.drawButton.UseVisualStyleBackColor = true;
            // 
            // changeLengthButton
            // 
            this.changeLengthButton.Location = new System.Drawing.Point(63, 138);
            this.changeLengthButton.Name = "changeLengthButton";
            this.changeLengthButton.Size = new System.Drawing.Size(138, 77);
            this.changeLengthButton.TabIndex = 9;
            this.changeLengthButton.Text = "Change length";
            this.changeLengthButton.UseVisualStyleBackColor = true;
            this.changeLengthButton.Click += new System.EventHandler(this.changeLengthButton_Click);
            // 
            // changeBeadsCountButton
            // 
            this.changeBeadsCountButton.Location = new System.Drawing.Point(231, 138);
            this.changeBeadsCountButton.Name = "changeBeadsCountButton";
            this.changeBeadsCountButton.Size = new System.Drawing.Size(138, 77);
            this.changeBeadsCountButton.TabIndex = 10;
            this.changeBeadsCountButton.Text = "Change beads count";
            this.changeBeadsCountButton.UseVisualStyleBackColor = true;
            this.changeBeadsCountButton.Click += new System.EventHandler(this.changeBeadsCountButton_Click);
            // 
            // changeRadiusButton
            // 
            this.changeRadiusButton.Location = new System.Drawing.Point(398, 138);
            this.changeRadiusButton.Name = "changeRadiusButton";
            this.changeRadiusButton.Size = new System.Drawing.Size(138, 77);
            this.changeRadiusButton.TabIndex = 11;
            this.changeRadiusButton.Text = "Change radius";
            this.changeRadiusButton.UseVisualStyleBackColor = true;
            this.changeRadiusButton.Click += new System.EventHandler(this.changeRadiusButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1359, 839);
            this.Controls.Add(this.changeRadiusButton);
            this.Controls.Add(this.changeBeadsCountButton);
            this.Controls.Add(this.changeLengthButton);
            this.Controls.Add(this.drawButton);
            this.Controls.Add(this.beadsCountTextBox);
            this.Controls.Add(this.radiusTextBox);
            this.Controls.Add(this.lengthTextBox);
            this.Controls.Add(this.beadsCountLabel);
            this.Controls.Add(this.radiusLabel);
            this.Controls.Add(this.lengthLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lengthLabel;
        private System.Windows.Forms.Label radiusLabel;
        private System.Windows.Forms.Label beadsCountLabel;
        private System.Windows.Forms.TextBox lengthTextBox;
        private System.Windows.Forms.TextBox radiusTextBox;
        private System.Windows.Forms.TextBox beadsCountTextBox;
        private System.Windows.Forms.Button drawButton;
        private System.Windows.Forms.Button changeLengthButton;
        private System.Windows.Forms.Button changeBeadsCountButton;
        private System.Windows.Forms.Button changeRadiusButton;
    }
}

