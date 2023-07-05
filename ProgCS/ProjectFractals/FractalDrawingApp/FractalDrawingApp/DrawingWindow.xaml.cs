using FractalDrawingApp.Fractals;
using System;
using System.IO;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace FractalDrawingApp
{
    public partial class DrawingWindow : Window
    {
        /// <summary>
        /// Fractal to draw
        /// </summary>
        private Fractal fractal;

        /// <summary>
        /// Height of drawing area
        /// </summary>
        private readonly double height;

        /// <summary>
        /// Both angles of pythagprean tree
        /// </summary>
        private int firstAngle, secondAngle;

        /// <summary>
        /// Scaling coefficent for pythagorean tree
        /// </summary>
        private double coefficent;

        /// <summary>
        /// Width of drawing area
        /// </summary>
        private readonly double width;

        /// <summary>
        /// Identity number of fractal
        /// </summary>
        private readonly int id;

        /// <summary>
        /// Count of iterations to draw fractal
        /// </summary>
        private int recursionDepth;

        Color startColor, endColor;

        /// <summary>
        /// This constructor creates a Drawing window and draws fractal
        /// in specified drawing area
        /// </summary>
        /// <param name="id">fractal id</param>
        public DrawingWindow(int id)
        {
            try
            {
                this.id = id;
                InitializeComponent();
                if (id == 0)
                {
                    recursionDepthSlider.Value = 10;
                    recursionDepthSlider.Maximum = 14;
                    firstAngle = 30;
                    secondAngle = 45;
                    coefficent = 65;
                    firstAngleSlider.Value = 30;
                    secondAngleSlider.Value = 45;
                    coefficentSlider.Value = 65;
                }
                else
                {
                    recursionDepthSlider.Value = 2;
                    firstAngleSlider.IsEnabled = false;
                    firstAngleTextBox.IsEnabled = false;
                    secondAngleSlider.IsEnabled = false;
                    secondAngleTextBox.IsEnabled = false;
                    firstLabel.IsEnabled = false;
                    coefficentSlider.IsEnabled = false;
                    coefficentTextBox.IsEnabled = false;
                    coefficentLabel.IsEnabled = false;
                    secondLabel.IsEnabled = false;
                }
                startColorPicker.SelectedColor = Colors.Red;
                endColorPicker.SelectedColor = Colors.Green;
                startColor = Colors.Red;
                endColor = Colors.Green;
                height = drawingArea.Height - 10;
                width = drawingArea.Width - 10;
                ChooseFractal(this.id);
                fractal?.Draw();
            }
            catch(Exception ex) { MessageBox.Show(ex.Message);
                MessageBox.Show(ex.StackTrace) ;
            }
        }

        /// <summary>
        /// This method initialize one of avaliabe fractals
        /// </summary>
        /// <param name="id">number of fractal user choosed</param>
        private void ChooseFractal(int id)
        {
            switch (id)
            {
                case 0:
                    fractal = new PythagoreanTree(coefficent / 100, new Point(drawingArea.Width / 2,
                        drawingArea.Height), 200, Math.PI / 2, firstAngle * Math.PI / 180,
                        secondAngle * Math.PI / 180, drawingArea, recursionDepth, 0,startColor,endColor);
                    break;

                case 1:
                    fractal = new SierpinskiTriangle(
                        new Point(10, height), new Point(width, height),
                        new Point(width / 2, height - width * Math.Sqrt(3) / 2),
                        drawingArea, recursionDepth, 0,startColor,endColor);
                    break;

                case 2:
                    fractal = new TriangleCenterOfMass(
                        new Point(width / 2, height - width * Math.Sqrt(3) / 2),
                        new Point(width, height),
                        new Point(10, height),
                        drawingArea, recursionDepth, 0,startColor,endColor);
                    break;
                case 3:
                    fractal = new TSquare(new Point(10, height), new Point(10, height - width * Math.Sqrt(3) / 2),
                        new Point(width, height - width * Math.Sqrt(3) / 2), new Point(width, height),
                        drawingArea, recursionDepth, 0, startColor, endColor
                        );
                    break;

                default:
                    MessageBox.Show("Invald fractal. Please choose something avaliable!");
                    break;
            }
        }

        /// <summary>
        /// This EventHandler method change first angle of pythagorean tree both ways
        /// from slider to textbox and reverse
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event arguments</param>
        private void firstAngleSlider_ValueChanged(object sender,
            RoutedPropertyChangedEventArgs<double> e)
        {
            firstAngle = (int)firstAngleSlider.Value;
            if (firstAngleTextBox != null)
                firstAngleTextBox.Text = firstAngleSlider.Value.ToString();
            drawingArea.Children.Clear();
            ChooseFractal(id);
            fractal?.Draw();
        }

        /// <summary>
        /// This EventHandler method change second angle of pythagorean tree both ways
        /// from slider to textbox and reverse
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event arguments</param>
        private void secondAngleSlider_ValueChanged(object sender,
            RoutedPropertyChangedEventArgs<double> e)
        {
            secondAngle = (int)secondAngleSlider.Value;
            if (secondAngleTextBox != null)
                secondAngleTextBox.Text = secondAngleSlider.Value.ToString();
            drawingArea.Children.Clear();
            ChooseFractal(id);
            fractal?.Draw();
        }

        /// <summary>
        /// This method redraws fractal with changed recursionDepth value
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event arguments</param>
        private void recursionDepth_ValueChanged(object sender,
            RoutedPropertyChangedEventArgs<double> e)
        {
            recursionDepth = (int)recursionDepthSlider.Value;
            recursionDepthTextBox.Text = recursionDepthSlider.Value.ToString();
            drawingArea.Children.Clear();
            ChooseFractal(id);
            fractal?.Draw();
        }

        /// <summary>
        /// This EventHandler method change the coefficent
        /// which scale pythagorean tree branches
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event arguments</param>
        private void coefficentSlider_ValueChanged(object sender,
            RoutedPropertyChangedEventArgs<double> e)
        {
            coefficent = coefficentSlider.Value;
            if (coefficentTextBox != null)
                coefficentTextBox.Text = coefficentSlider.Value.ToString();
            drawingArea.Children.Clear();
            ChooseFractal(id);
            fractal?.Draw();
        }

        /// <summary>
        /// This button navigates to window with choosing fractal
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event arguments</param>
        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }

        /// <summary>
        /// This method saves fractal as a png image
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            string path = @"../../../Fractal.png";
            FileStream fs = new FileStream(path, FileMode.Create);
            RenderTargetBitmap bmp = new RenderTargetBitmap((int)drawingArea.ActualWidth + 100,
                (int)drawingArea.ActualHeight + 100, 1 / 96, 1 / 96, PixelFormats.Pbgra32);
            bmp.Render(drawingArea);
            BitmapEncoder encoder = new PngBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(bmp));
            encoder.Save(fs);
            fs.Close();
        }

        private void Zoom_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ScrollZoom.Height = drawingArea.Height/Zoom.Value;
            ScrollZoom.Width = drawingArea.Width/Zoom.Value;
            drawingArea.Children.Clear();
            ChooseFractal(id);
            fractal?.Draw();

        }

        private void startColor_ValueChanged(object sender, EventArgs e)
        {
            startColor = (Color)startColorPicker.SelectedColor;
            drawingArea.Children.Clear();
            ChooseFractal(id);
            fractal?.Draw();
        }

        /// <summary>
        /// Данный евент хэндлер нужен для изменения конечного цвета 
        /// отрисовки фрактала
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void endColor_ValueChanged(object sender, EventArgs e)
        {
            endColor = (Color)endColorPicker.SelectedColor;
            drawingArea.Children.Clear();
            ChooseFractal(id);
            fractal?.Draw();
        }
    }
}