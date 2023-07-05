using System.Windows;

namespace FractalDrawingApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void fractalList_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            var drawingWindow = new DrawingWindow(fractalList.SelectedIndex);
            drawingWindow.Show();
            Close();
        }
    }
}