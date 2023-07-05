using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task3
{
    public partial class Form1 : Form
    {
        public static int _counter;

        private static Random rnd = new Random();

        public Form1()
        {
            InitializeComponent();
            MouseEnter += (sender, e) => Text = "My Form " + _counter++;
            MouseClick += (sender, e) => BackColor = Color.Red;
            MouseEnter += (sender, e) => BackColor = DefaultBackColor;
            MouseDoubleClick += (sender, e) =>
            {
                Width = rnd.Next(100, 1001);
                Height = rnd.Next(100, 1001);
            };
        }
    }
}
