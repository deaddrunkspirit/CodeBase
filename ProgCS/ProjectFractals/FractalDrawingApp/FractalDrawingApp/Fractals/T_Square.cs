using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace FractalDrawingApp.Fractals
{
    class TSquare : Fractal
    {
        //4 вершины квадрата
        Point A, B, C, D;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="A">1 вершина</param>
        /// <param name="B">2 вершина</param>
        /// <param name="C">3 вершина</param>
        /// <param name="D">4 вершина</param>
        /// <param name="drawingArea">холст</param>
        /// <param name="recursionDepth">максимальный уровень рекурсии</param>
        /// <param name="currentDepth">текущий уровень рекурсии</param>
        /// <param name="startColor">начальный цвет</param>
        /// <param name="endColor">конечный цвет</param>
        internal TSquare(Point A, Point B, Point C, Point D,
            Canvas drawingArea, int recursionDepth, int currentDepth, Color startColor, Color endColor) :
            base(drawingArea, recursionDepth, currentDepth, startColor, endColor)
        {
            this.A = A;
            this.B = B;
            this.C = C;
            this.D = D;
        }

        /// <summary>
        /// Данный метод отрисовывает фрактал Т-Квадрат
        /// </summary>
        internal override void Draw()
        {
            //Сначала изображаем начальный квадар
            if (currentDepth == 0)
            {
                var points = new PointCollection { A, B, C, D, A };
                Polygon square1 = new Polygon()
                {
                    Points = points,
                    Fill = new SolidColorBrush(startColor),
                };
                drawingArea.Children.Add(square1);
                //1 раз рекурсивно вызываем отрисовку
                TSquare square2 = new TSquare(A, B, C, D, drawingArea, recursionDepth, currentDepth + 1, startColor, endColor);
                square2.Draw();
            }
            //Рекурсивно отрисовываем фрактал 
            if (currentDepth != 0 && currentDepth <= recursionDepth)
            {
                Point midPoint = MidPoint(A, C);
                Point ANew = MidPoint(midPoint, A);
                Point BNew = MidPoint(midPoint, B);
                Point CNew = MidPoint(midPoint, C);
                Point DNew = MidPoint(midPoint, D);
                Point AHalf = MidPoint(A, B);
                Point BHalf = MidPoint(B, C);
                Point CHalf = MidPoint(C, D);
                Point DHalf = MidPoint(A, D);

                var points1 = new PointCollection { ANew, BNew, CNew, DNew, ANew };
                Polygon square10 = new Polygon()
                {
                    Points = points1,
                    Fill = new SolidColorBrush(GetCurrentColor()),
                };
                drawingArea.Children.Add(square10);

                TSquare square2 = new TSquare(A, AHalf, midPoint, DHalf, drawingArea, recursionDepth, currentDepth + 1, startColor, endColor);
                TSquare square3 = new TSquare(AHalf, B, BHalf, midPoint, drawingArea, recursionDepth, currentDepth + 1, startColor, endColor);
                TSquare square4 = new TSquare(BHalf, C, CHalf, midPoint, drawingArea, recursionDepth, currentDepth + 1, startColor, endColor);
                TSquare square5 = new TSquare(CHalf, D, DHalf, midPoint, drawingArea, recursionDepth, currentDepth + 1, startColor, endColor);
                square2.Draw();
                square3.Draw();
                square4.Draw();
                square5.Draw();
            }
        }

        /// <summary>
        /// Данный метод находит среднюю точку между
        /// двум другими
        /// </summary>
        /// <param name="point1"></param>
        /// <param name="point2"></param>
        /// <returns></returns>
        private static Point MidPoint(Point point1, Point point2)
                => new Point((point1.X + point2.X) / 2, (point1.Y + point2.Y) / 2);
    }
}
