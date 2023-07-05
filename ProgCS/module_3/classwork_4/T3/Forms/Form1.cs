using System;
using System.Drawing;
using System.Windows.Forms;
using Task3Lib;

namespace Task3Forms
{
    public partial class Form1 : Form
    {
        private Chain _chain = new Chain(1000, 5);
        private Pen _pen = new Pen(Color.Green);

        private double _newLength;
        private int _newBeadsCount;
        private double _newRadius;

        public Form1()
        {
            InitializeComponent();
            radiusTextBox.Text = "200";
            lengthTextBox.Text = "1000";
            beadsCountTextBox.Text = "5";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            changeLengthButton.Enabled = false;
            changeRadiusButton.Enabled = false;
            changeBeadsCountButton.Enabled = false;
            radiusTextBox.Text = _chain.Beads[0].Radius.ToString("f3");
            beadsCountTextBox.Text = _chain.BeadsCount.ToString();
            lengthTextBox.Text = _chain.Length.ToString("f3");
            Draw(_chain.Beads[0].Radius, _chain.BeadsCount, _chain.Length);
        }

        public void Draw(double radius, int beadsCount, double length)
        {
            pictureBox1.Refresh();
            for (int i = 0; i < beadsCount; i++)
            {
                pictureBox1.CreateGraphics().DrawEllipse(_pen, (float)(radius * i),
                    100, (float)radius, (float)radius);
            }
        }

        private void drawButton_Click(object sender, EventArgs e)
        {
            Draw(_chain.Beads[0].Radius, _chain.BeadsCount, _chain.Length);
            drawButton.Enabled = false;
        }

        private void lengthTextBox_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(lengthTextBox.Text, out _newLength) || _newLength <= 0)
                changeLengthButton.Enabled = true;
            else
                changeLengthButton.Enabled = false;
        }

        private void beadsCountTextBox_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(beadsCountTextBox.Text, out _newBeadsCount)
                || _newBeadsCount <= 0)
                changeBeadsCountButton.Enabled = true;
            else
                changeBeadsCountButton.Enabled = false;
        }

        private void radiusTextBox_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(radiusTextBox.Text, out _newRadius) || _newRadius <= 0)
                changeRadiusButton.Enabled = true;
            else
                changeRadiusButton.Enabled = false;
        }

        private void changeLengthButton_Click(object sender, EventArgs e)
        {
            drawButton.Enabled = true;
            _chain.Length = _newLength;
            beadsCountTextBox.Text = $"{_chain.BeadsCount}";
            radiusTextBox.Text = $"{_chain.Beads[0].Radius}";
        }

        private void changeBeadsCountButton_Click(object sender, EventArgs e)
        {
            drawButton.Enabled = true;
            _chain.BeadsCount = _newBeadsCount;
            radiusTextBox.Text = $"{_chain.Beads[0].Radius:f3}";
            lengthTextBox.Text = $"{_chain.Length:f3}";
        }

        private void changeRadiusButton_Click(object sender, EventArgs e)
        {
            drawButton.Enabled = true;
            _chain.Radius(_newRadius);
            beadsCountTextBox.Text = $"{_chain.BeadsCount}";
            lengthTextBox.Text = $"{_chain.Length:f3}";
        }
    }
}