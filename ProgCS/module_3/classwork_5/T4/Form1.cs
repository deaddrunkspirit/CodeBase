using System;
using System.Threading;
using System.Windows.Forms;

namespace Task4
{
    public partial class Form1 : Form
    {
        private Estimates estimates = new Estimates();

        private Form2 form2 = new Form2();

        private Random rnd = new Random();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 1000; i++, Thread.Sleep(20))
            {
                estimates.Add(Math.Round(rnd.NextDouble(), 3));
                form2.sampleSizeLabel.Text = $"Размер выборки: {estimates.Count}";
                form2.averageLabel.Text = $"Среднее значение: {estimates.Average}";
                form2.deviationLabel.Text =
                    $"Среднее квадратичное отклонение: {estimates.Deviation}";
                form2.xMinLabel.Text = $"Минимум: {estimates.XMin}";
                form2.xMaxLabel.Text = $"Максимум: {estimates.XMax}";
                form2.Refresh();
                form2.Show();
            }
        }
    }
}