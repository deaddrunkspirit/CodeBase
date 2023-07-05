using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace FractalDrawingApp.Fractals
{
    public class SierpinskiTriangle : Fractal
    {
        /// <summary>
        /// Вершины треугольника
        /// </summary>
        private Point top, right, left;

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="top">верхняя вершина</param>
        /// <param name="right">правая вершина</param>
        /// <param name="left">левая вершина</param>
        /// <param name="drawingArea">холст</param>
        /// <param name="recursionDepth">максимальный уровень рекурсии</param>
        /// <param name="currentDepth">текущий уровень рекурсии</param>
        /// <param name="startColor">начальный цвет</param>
        /// <param name="endColor">конечный цвет</param>
        public SierpinskiTriangle(Point top, Point right, Point left,
            Canvas drawingArea, int recursionDepth, int currentDepth,Color startColor, Color endColor)
            : base(drawingArea, recursionDepth, currentDepth, startColor,endColor)
        {
            this.top = top;
            this.right = right;
            this.left = left;
        }

        /// <summary>
        /// Данный метод рисует треугольник Серпинского на холсте
        /// </summary>
        internal override void Draw()
        {
            //Сначала рисуем основной треугольник
            if (currentDepth==0)
            {
                var points = new PointCollection { top, right, left, top };
                var polyLine = new Polyline
                {
                    Points = points,
                    Stroke = new SolidColorBrush(startColor)
                };
                drawingArea.Children.Add(polyLine);

                //Затем вызываем 1 раз рекурсивно отрисовку
                SierpinskiTriangle triangle1 = new SierpinskiTriangle(top, right, left,
                    drawingArea, recursionDepth, currentDepth + 1, startColor, endColor);
                triangle1.Draw();
                
            }
            //Рекуррентно отрисовываем все треугольники
            if(currentDepth!=0&&currentDepth<=recursionDepth)
            {

                Point leftMid = MidPoint(top, left);
                Point rightMid = MidPoint(top, right);
                Point topMid = MidPoint(left, right);

                var points = new PointCollection { topMid, rightMid, leftMid, topMid };
                var polyLine = new Polyline
                {
                    Points = points,
                    Stroke = new SolidColorBrush(GetCurrentColor())
                };
                drawingArea.Children.Add(polyLine);

                SierpinskiTriangle triangle1 = new SierpinskiTriangle(top, leftMid, rightMid,
                    drawingArea, recursionDepth, currentDepth + 1, startColor, endColor),
                                  triangle2 = new SierpinskiTriangle(leftMid, left, topMid,
                    drawingArea, recursionDepth, currentDepth + 1, startColor, endColor),
                                  triangle3 = new SierpinskiTriangle(rightMid, topMid, right,
                    drawingArea, recursionDepth, currentDepth + 1, startColor, endColor);
                triangle1.Draw();
                triangle2.Draw();
                triangle3.Draw();

            }
        }

        /// <summary>
        /// Данный метод рассчитывает среднюю
        /// точку между двумя другими
        /// </summary>
        /// <param name="point1">first point</param>
        /// <param name="point2">second point</param>
        /// <returns></returns>
        private static Point MidPoint(Point point1, Point point2)
            => new Point((point1.X + point2.X) / 2, (point1.Y + point2.Y) / 2);
    }
}