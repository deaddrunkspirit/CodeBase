using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task1
{
    public partial class Form1 : Form
    {
        private string result;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Text = "Form1_Load";
            result += "\r\nLoad";
            MessageBox.Show("Event Load");
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            Text = "Form1_Activated";
            result += "\r\nActivated";
        }

        private void Form1_Deactivate(object sender, EventArgs e)
        {
            Text = "Form1_Deactivate";
            result += "\r\nDeactivate";
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            Text = "Form1_Resize";
            result += "\r\nResize";
            MessageBox.Show("Event Resize");
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Text = "Form1_FormClosed";
            result = "Events in Form life: " + result;
            MessageBox.Show(result + "\r\nFormClosed");
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Text = "Form1_FormClosing";
            result += "\r\nFormClosing";
            MessageBox.Show("Event FormClosing");
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Text = "Form1_Paint";
            result += "\r\nPaint";
            MessageBox.Show("Event Paint");
        }
    }
}