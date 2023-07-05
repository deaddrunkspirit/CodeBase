using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Task2Lib;

namespace Task2
{
    public partial class Form1 : Form
    {
        private ElectronicQueue<Person> eq;

        public Form1()
        {
            InitializeComponent();
            eq = new ElectronicQueue<Person>();
            eq.AddToElectronicQueue(new Person("Jabba", "Hutt", 604));
            eq.AddToElectronicQueue(new Person("Wedge", "Antille", 25));
            eq.AddToElectronicQueue(new Person("Han", "Solo", 33));
            eq.AddToElectronicQueue(new Person("Leia", "Organa", 23));
            eq.AddToElectronicQueue(new Person("Lando", "Calrissian", 35));
            eq.AddToElectronicQueue(new Person("Anakin", "Skywalker", 46));
            timer1.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (int.TryParse(ageTextBox.Text, out int age))
                return;
            timer1.Enabled = true;
            eq.AddToElectronicQueue(new Person(nameTextBox.Text, lastNameTextBox.Text, age));
            timer1.Enabled = true;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                label4.Text = eq.CallFromElectronicQueue();
                SystemSounds.Exclamation.Play();
                eq.DeleteFromElectronicQueue();
            }
            catch (ArgumentException ex)
            {
                timer1.Enabled = false;
                MessageBox.Show(ex.Message);
            }
        }
    }
}