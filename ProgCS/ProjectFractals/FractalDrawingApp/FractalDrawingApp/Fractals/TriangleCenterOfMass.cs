using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace FractalDrawingApp.Fractals
{
    internal class TriangleCenterOfMass : Fractal
    {
        //Вершины треугольника
        private Point top, right, left;

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="top">Верхняя вершина</param>
        /// <param name="right">Правая вершина</param>
        /// <param name="left">Левая вершина</param>
        /// <param name="drawingArea">холст</param>
        /// <param name="recursionDepth">максимальный уровень рекурсии</param>
        /// <param name="currentDepth">текущий уровень рекурсии</param>
        /// <param name="startColor">начальный цвет</param>
        /// <param name="endColor">конечный цвет</param>
        public TriangleCenterOfMass(Point top, Point right, Point left,
            Canvas drawingArea, int recursionDepth, int currentDepth, Color startColor, Color endColor)
            : base(drawingArea, recursionDepth, currentDepth, startColor, endColor)
        {
            this.top = top;
            this.right = right;
            this.left = left;
        }

        /// <summary>
        /// Данный метод рисует фрактал Центр Масс Треугольника
        /// </summary>
        internal override void Draw()
        {
            //Сначала рисуем основной треугольник
            if (currentDepth == 0)
            {

                var line1 = new Line
                {
                    X1 = top.X,
                    X2 = right.X,
                    Y1 = top.Y,
                    Y2 = right.Y,
                    Stroke = new SolidColorBrush(startColor)
                };
                var line2 = new Line
                {
                    X1 = right.X,
                    X2 = left.X,
                    Y1 = right.Y,
                    Y2 = left.Y,
                    Stroke = new SolidColorBrush(startColor)
                };
                var line3 = new Line
                {
                    X1 = left.X,
                    X2 = top.X,
                    Y1 = left.Y,
                    Y2 = top.Y,
                    Stroke = new SolidColorBrush(startColor)
                };

                drawingArea.Children.Add(line1);
                drawingArea.Children.Add(line2);
                drawingArea.Children.Add(line3);

                // Затем 1 раз рекурсивно вызываем функцию отрисовки 
                TriangleCenterOfMass triangle_param = new TriangleCenterOfMass(top, right, left,
                drawingArea, recursionDepth, currentDepth + 1, startColor, endColor);
                triangle_param.Draw();
            }
            //Рекурсивно отрисовываем фрактал
            if (currentDepth != 0 && currentDepth <= recursionDepth)
            {

                Point massPoint = Mass(this.left, this.top, this.right);

                var line4 = new Line
                {
                    X1 = top.X,
                    X2 = massPoint.X,
                    Y1 = top.Y,
                    Y2 = massPoint.Y,
                    Stroke = new SolidColorBrush(GetCurrentColor())
                };
                var line5 = new Line
                {
                    X1 = right.X,
                    X2 = massPoint.X,
                    Y1 = right.Y,
                    Y2 = massPoint.Y,
                    Stroke = new SolidColorBrush(GetCurrentColor())
                };
                var line6 = new Line
                {
                    X1 = left.X,
                    X2 = massPoint.X,
                    Y1 = left.Y,
                    Y2 = massPoint.Y,
                    Stroke = new SolidColorBrush(GetCurrentColor())
                };

                drawingArea.Children.Add(line4);
                drawingArea.Children.Add(line5);
                drawingArea.Children.Add(line6);

                TriangleCenterOfMass triangle1 = new TriangleCenterOfMass(massPoint, right, left,
                    drawingArea, recursionDepth, currentDepth + 1, startColor, endColor),
                                  triangle2 = new TriangleCenterOfMass(massPoint, left, top,
                    drawingArea, recursionDepth, currentDepth + 1, startColor, endColor),
                                  triangle3 = new TriangleCenterOfMass(massPoint, top, right,
                    drawingArea, recursionDepth, currentDepth + 1, startColor, endColor);
                triangle1.Draw();
                triangle2.Draw();
                triangle3.Draw();
            }
        }

        /// <summary>
        /// Данный метод находит точку массы треугольника
        /// </summary>
        /// <param name="left">левая вершина</param>
        /// <param name="top">верхняя вершина</param>
        /// <param name="right">правая вершина</param>
        /// <returns></returns>
        private static Point Mass(Point left, Point top, Point right)
        {
            double massX = left.X + ((top.X - left.X) + (right.X - left.X)) / 3;
            double massY = left.Y + ((top.Y - left.Y) + (right.Y - left.Y)) / 3;
            return new Point(massX, massY);
        }


    }
}