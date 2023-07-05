using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task5
{
    public partial class DrawCircleForm : Form
    {
        private int _radius;

        private CircleVizualizator _vizualizator;

        public DrawCircleForm()
        {
            InitializeComponent();
            _vizualizator = new CircleVizualizator(pictureBox, new Circle(200));
        }

        private void ChangeRadiusButton_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(InputRadius.Text, out _radius) || _radius <= 0)
            {
                MessageBox.Show("Wrong input!");
                InputRadius.Text = string.Empty;
                InputRadius.Focus();
                return;
            }
            _vizualizator._circle.Radius = _radius;
        }

        private void checkBoxYellow_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckedCount() == 1 && checkBoxYellow.Checked)
                _vizualizator.PenColor = Color.Yellow;
            else
            {
                SetUnchecked();
                MessageBox.Show("Choose ONE color!");
            }
        }

        private void checkBoxRed_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckedCount() == 1 && checkBoxRed.Checked)
                _vizualizator.PenColor = Color.Red;
            else
            {
                SetUnchecked();
                MessageBox.Show("Choose ONE color!");
            }
        }

        private void checkBoxGreen_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckedCount() == 1 && checkBoxGreen.Checked)
                _vizualizator.PenColor = Color.Green;
            else
            {
                SetUnchecked();
                MessageBox.Show("Choose ONE color!");
            }
        }

        private void checkBoxBlue_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckedCount() == 1 && checkBoxBlue.Checked)
                _vizualizator.PenColor = Color.Blue;
            else
            {
                SetUnchecked();
                MessageBox.Show("Choose ONE color!");
            }
        }

        private void SetUnchecked()
        {
            checkBoxYellow.Checked = false;
            checkBoxRed.Checked = false;
            checkBoxGreen.Checked = false;
            checkBoxBlue.Checked = false;
        }

        private int CheckedCount()
        {
            int countCheckedBoxex = 0;
            if (checkBoxBlue.Checked)
                countCheckedBoxex++;
            if (checkBoxRed.Checked)
                countCheckedBoxex++;
            if (checkBoxYellow.Checked)
                countCheckedBoxex++;
            if (checkBoxGreen.Checked)
                countCheckedBoxex++;
            return countCheckedBoxex;
        }
    }
}