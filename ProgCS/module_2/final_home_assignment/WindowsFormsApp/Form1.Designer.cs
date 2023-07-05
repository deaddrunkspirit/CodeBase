namespace WindowsFormsApp
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
            this.FirstPlayerShips = new System.Windows.Forms.ListBox();
            this.SecondPlayerShips = new System.Windows.Forms.ListBox();
            this.buttonBatt1 = new System.Windows.Forms.Button();
            this.buttonDest1 = new System.Windows.Forms.Button();
            this.buttonBatt2 = new System.Windows.Forms.Button();
            this.buttonDest2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonCargo1 = new System.Windows.Forms.Button();
            this.buttonCargo2 = new System.Windows.Forms.Button();
            this.buttonAttack = new System.Windows.Forms.Button();
            this.creditsPlayer2 = new System.Windows.Forms.Label();
            this.creditsPlayer1 = new System.Windows.Forms.Label();
            this.turn = new System.Windows.Forms.Label();
            this.phaseName = new System.Windows.Forms.Label();
            this.shipInfo = new System.Windows.Forms.Button();
            this.giveCargo = new System.Windows.Forms.Button();
            this.messageBox = new System.Windows.Forms.TextBox();
            this.ammoChoice = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.restartButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // FirstPlayerShips
            // 
            this.FirstPlayerShips.BackColor = System.Drawing.Color.AliceBlue;
            this.FirstPlayerShips.Font = new System.Drawing.Font("Constantia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FirstPlayerShips.ForeColor = System.Drawing.Color.RoyalBlue;
            this.FirstPlayerShips.FormattingEnabled = true;
            this.FirstPlayerShips.ItemHeight = 24;
            this.FirstPlayerShips.Location = new System.Drawing.Point(106, 168);
            this.FirstPlayerShips.Name = "FirstPlayerShips";
            this.FirstPlayerShips.Size = new System.Drawing.Size(287, 220);
            this.FirstPlayerShips.TabIndex = 0;
            // 
            // SecondPlayerShips
            // 
            this.SecondPlayerShips.BackColor = System.Drawing.Color.AliceBlue;
            this.SecondPlayerShips.Font = new System.Drawing.Font("Constantia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SecondPlayerShips.ForeColor = System.Drawing.Color.RoyalBlue;
            this.SecondPlayerShips.FormattingEnabled = true;
            this.SecondPlayerShips.ItemHeight = 24;
            this.SecondPlayerShips.Location = new System.Drawing.Point(884, 168);
            this.SecondPlayerShips.Name = "SecondPlayerShips";
            this.SecondPlayerShips.Size = new System.Drawing.Size(287, 220);
            this.SecondPlayerShips.TabIndex = 1;
            // 
            // buttonBatt1
            // 
            this.buttonBatt1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.buttonBatt1.Font = new System.Drawing.Font("Algerian", 12F);
            this.buttonBatt1.Location = new System.Drawing.Point(106, 416);
            this.buttonBatt1.Name = "buttonBatt1";
            this.buttonBatt1.Size = new System.Drawing.Size(289, 90);
            this.buttonBatt1.TabIndex = 2;
            this.buttonBatt1.Text = "Pick Battleship";
            this.buttonBatt1.UseVisualStyleBackColor = false;
            this.buttonBatt1.Click += new System.EventHandler(this.buttonBatt1_Click);
            // 
            // buttonDest1
            // 
            this.buttonDest1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.buttonDest1.Font = new System.Drawing.Font("Algerian", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDest1.Location = new System.Drawing.Point(106, 512);
            this.buttonDest1.Name = "buttonDest1";
            this.buttonDest1.Size = new System.Drawing.Size(289, 90);
            this.buttonDest1.TabIndex = 3;
            this.buttonDest1.Text = "Pick Destroyer";
            this.buttonDest1.UseVisualStyleBackColor = false;
            this.buttonDest1.Click += new System.EventHandler(this.buttonDest1_Click);
            // 
            // buttonBatt2
            // 
            this.buttonBatt2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.buttonBatt2.Font = new System.Drawing.Font("Algerian", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBatt2.Location = new System.Drawing.Point(884, 416);
            this.buttonBatt2.Name = "buttonBatt2";
            this.buttonBatt2.Size = new System.Drawing.Size(289, 90);
            this.buttonBatt2.TabIndex = 4;
            this.buttonBatt2.Text = "Pick Battleship";
            this.buttonBatt2.UseVisualStyleBackColor = false;
            this.buttonBatt2.Click += new System.EventHandler(this.buttonBatt2_Click);
            // 
            // buttonDest2
            // 
            this.buttonDest2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.buttonDest2.Font = new System.Drawing.Font("Algerian", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDest2.Location = new System.Drawing.Point(884, 512);
            this.buttonDest2.Name = "buttonDest2";
            this.buttonDest2.Size = new System.Drawing.Size(289, 90);
            this.buttonDest2.TabIndex = 5;
            this.buttonDest2.Text = "Pick Destroyer";
            this.buttonDest2.UseVisualStyleBackColor = false;
            this.buttonDest2.Click += new System.EventHandler(this.buttonDest2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Constantia", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(102, 140);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "First player credits: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Constantia", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Navy;
            this.label2.Location = new System.Drawing.Point(880, 140);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "Second player credits:";
            // 
            // buttonCargo1
            // 
            this.buttonCargo1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.buttonCargo1.Font = new System.Drawing.Font("Algerian", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCargo1.Location = new System.Drawing.Point(106, 608);
            this.buttonCargo1.Name = "buttonCargo1";
            this.buttonCargo1.Size = new System.Drawing.Size(289, 90);
            this.buttonCargo1.TabIndex = 8;
            this.buttonCargo1.Text = "Pick Cargo";
            this.buttonCargo1.UseVisualStyleBackColor = false;
            this.buttonCargo1.Click += new System.EventHandler(this.buttonCargo1_Click);
            // 
            // buttonCargo2
            // 
            this.buttonCargo2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.buttonCargo2.Font = new System.Drawing.Font("Algerian", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCargo2.Location = new System.Drawing.Point(884, 608);
            this.buttonCargo2.Name = "buttonCargo2";
            this.buttonCargo2.Size = new System.Drawing.Size(289, 90);
            this.buttonCargo2.TabIndex = 9;
            this.buttonCargo2.Text = "Pick Cargo";
            this.buttonCargo2.UseVisualStyleBackColor = false;
            this.buttonCargo2.Click += new System.EventHandler(this.buttonCargo2_Click);
            // 
            // buttonAttack
            // 
            this.buttonAttack.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.buttonAttack.Font = new System.Drawing.Font("Algerian", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAttack.Location = new System.Drawing.Point(477, 544);
            this.buttonAttack.Name = "buttonAttack";
            this.buttonAttack.Size = new System.Drawing.Size(333, 108);
            this.buttonAttack.TabIndex = 13;
            this.buttonAttack.Text = "Attack";
            this.buttonAttack.UseVisualStyleBackColor = false;
            this.buttonAttack.Click += new System.EventHandler(this.buttonAttack_Click);
            // 
            // creditsPlayer2
            // 
            this.creditsPlayer2.AutoSize = true;
            this.creditsPlayer2.Font = new System.Drawing.Font("Constantia", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.creditsPlayer2.ForeColor = System.Drawing.Color.Navy;
            this.creditsPlayer2.Location = new System.Drawing.Point(1093, 140);
            this.creditsPlayer2.Name = "creditsPlayer2";
            this.creditsPlayer2.Size = new System.Drawing.Size(56, 17);
            this.creditsPlayer2.TabIndex = 14;
            this.creditsPlayer2.Text = "credits2";
            // 
            // creditsPlayer1
            // 
            this.creditsPlayer1.AutoSize = true;
            this.creditsPlayer1.Font = new System.Drawing.Font("Constantia", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.creditsPlayer1.ForeColor = System.Drawing.Color.Navy;
            this.creditsPlayer1.Location = new System.Drawing.Point(315, 140);
            this.creditsPlayer1.Name = "creditsPlayer1";
            this.creditsPlayer1.Size = new System.Drawing.Size(53, 17);
            this.creditsPlayer1.TabIndex = 15;
            this.creditsPlayer1.Text = "credits1";
            // 
            // turn
            // 
            this.turn.AutoSize = true;
            this.turn.Font = new System.Drawing.Font("Constantia", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.turn.ForeColor = System.Drawing.Color.Navy;
            this.turn.Location = new System.Drawing.Point(549, 78);
            this.turn.Name = "turn";
            this.turn.Size = new System.Drawing.Size(34, 17);
            this.turn.TabIndex = 16;
            this.turn.Text = "turn";
            // 
            // phaseName
            // 
            this.phaseName.AutoSize = true;
            this.phaseName.Font = new System.Drawing.Font("Constantia", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phaseName.ForeColor = System.Drawing.Color.Navy;
            this.phaseName.Location = new System.Drawing.Point(549, 14);
            this.phaseName.Name = "phaseName";
            this.phaseName.Size = new System.Drawing.Size(44, 17);
            this.phaseName.TabIndex = 17;
            this.phaseName.Text = "phase";
            // 
            // shipInfo
            // 
            this.shipInfo.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.shipInfo.Font = new System.Drawing.Font("Algerian", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.shipInfo.Location = new System.Drawing.Point(552, 190);
            this.shipInfo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.shipInfo.Name = "shipInfo";
            this.shipInfo.Size = new System.Drawing.Size(162, 108);
            this.shipInfo.TabIndex = 18;
            this.shipInfo.Text = "Ship info";
            this.shipInfo.UseVisualStyleBackColor = false;
            this.shipInfo.Click += new System.EventHandler(this.shipInfo_Click);
            // 
            // giveCargo
            // 
            this.giveCargo.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.giveCargo.Font = new System.Drawing.Font("Algerian", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.giveCargo.Location = new System.Drawing.Point(552, 306);
            this.giveCargo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.giveCargo.Name = "giveCargo";
            this.giveCargo.Size = new System.Drawing.Size(162, 108);
            this.giveCargo.TabIndex = 30;
            this.giveCargo.Text = "Give cargo";
            this.giveCargo.UseVisualStyleBackColor = false;
            this.giveCargo.Click += new System.EventHandler(this.giveCargo_Click);
            // 
            // messageBox
            // 
            this.messageBox.BackColor = System.Drawing.Color.AliceBlue;
            this.messageBox.Font = new System.Drawing.Font("Constantia", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.messageBox.ForeColor = System.Drawing.Color.RoyalBlue;
            this.messageBox.Location = new System.Drawing.Point(1213, 61);
            this.messageBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.messageBox.Multiline = true;
            this.messageBox.Name = "messageBox";
            this.messageBox.Size = new System.Drawing.Size(368, 591);
            this.messageBox.TabIndex = 31;
            // 
            // ammoChoice
            // 
            this.ammoChoice.Font = new System.Drawing.Font("Constantia", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ammoChoice.Location = new System.Drawing.Point(700, 428);
            this.ammoChoice.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ammoChoice.Name = "ammoChoice";
            this.ammoChoice.Size = new System.Drawing.Size(67, 23);
            this.ammoChoice.TabIndex = 33;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.Control;
            this.label4.Font = new System.Drawing.Font("Constantia", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label4.Location = new System.Drawing.Point(426, 431);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(195, 17);
            this.label4.TabIndex = 35;
            this.label4.Text = "Amount you want to transfer: ";
            // 
            // restartButton
            // 
            this.restartButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.restartButton.Font = new System.Drawing.Font("Algerian", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.restartButton.Location = new System.Drawing.Point(106, 14);
            this.restartButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.restartButton.Name = "restartButton";
            this.restartButton.Size = new System.Drawing.Size(146, 90);
            this.restartButton.TabIndex = 36;
            this.restartButton.Text = "Restart";
            this.restartButton.UseVisualStyleBackColor = false;
            this.restartButton.Click += new System.EventHandler(this.restartButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Constantia", 15F);
            this.label3.ForeColor = System.Drawing.Color.Navy;
            this.label3.Location = new System.Drawing.Point(1303, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(149, 31);
            this.label3.TabIndex = 37;
            this.label3.Text = "Message box";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1614, 786);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.restartButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ammoChoice);
            this.Controls.Add(this.messageBox);
            this.Controls.Add(this.giveCargo);
            this.Controls.Add(this.shipInfo);
            this.Controls.Add(this.phaseName);
            this.Controls.Add(this.turn);
            this.Controls.Add(this.creditsPlayer1);
            this.Controls.Add(this.creditsPlayer2);
            this.Controls.Add(this.buttonAttack);
            this.Controls.Add(this.buttonCargo2);
            this.Controls.Add(this.buttonCargo1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonDest2);
            this.Controls.Add(this.buttonBatt2);
            this.Controls.Add(this.buttonDest1);
            this.Controls.Add(this.buttonBatt1);
            this.Controls.Add(this.SecondPlayerShips);
            this.Controls.Add(this.FirstPlayerShips);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ship battle";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox FirstPlayerShips;
        private System.Windows.Forms.ListBox SecondPlayerShips;
        private System.Windows.Forms.Button buttonBatt1;
        private System.Windows.Forms.Button buttonDest1;
        private System.Windows.Forms.Button buttonBatt2;
        private System.Windows.Forms.Button buttonDest2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonCargo1;
        private System.Windows.Forms.Button buttonCargo2;
        private System.Windows.Forms.Button buttonAttack;
        private System.Windows.Forms.Label creditsPlayer2;
        private System.Windows.Forms.Label creditsPlayer1;
        private System.Windows.Forms.Label turn;
        private System.Windows.Forms.Label phaseName;
        private System.Windows.Forms.Button shipInfo;
        private System.Windows.Forms.Button giveCargo;
        private System.Windows.Forms.TextBox messageBox;
        private System.Windows.Forms.TextBox ammoChoice;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button restartButton;
        private System.Windows.Forms.Label label3;
    }
}

