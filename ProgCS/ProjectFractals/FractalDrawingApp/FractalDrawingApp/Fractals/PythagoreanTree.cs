using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace FractalDrawingApp.Fractals
{
    public class PythagoreanTree : Fractal
    {   //угол наклона итерации
        public double angle = Math.PI / 2;
        //Углы наклона ветвей
        public double ang1 = Math.PI / 3;

        public double ang2 = Math.PI / 10;
        //Параметры
        public double coefficent = .7;

        private double a = 200;

        private Point startPoint;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="coefficent">параметр</param>
        /// <param name="startPoint">начальная точка отрисовки</param>
        /// <param name="a">параметр</param>
        /// <param name="angle">угол итерации</param>
        /// <param name="ang1">угол ветви</param>
        /// <param name="ang2">угол ветви</param>
        /// <param name="drawingArea">холст</param>
        /// <param name="recursionDepth">максимальный уровень рекурсии</param>
        /// <param name="currentDepth">текущий уровень рекурсии</param>
        /// <param name="startColor">начальный цвет</param>
        /// <param name="endColor">конечный цвет</param>
        public PythagoreanTree(double coefficent, Point startPoint, double a, double angle,
            double ang1, double ang2, Canvas drawingArea, int recursionDepth, int currentDepth, Color startColor, Color endColor) :
            base(drawingArea, recursionDepth, currentDepth, startColor, endColor)
        {
            this.coefficent = coefficent;
            this.ang1 = ang1;
            this.ang2 = ang2;
            this.a = a;
            this.startPoint = startPoint;
            this.angle = angle;
        }

        /// <summary>
        /// Данный метод рисует фрактал Дерево Пифагора
        /// </summary>
        internal override void Draw()
        {
            //Рекурсивно вызываем функцию отрисовки и рисуем фрактал
            if (currentDepth <= recursionDepth)
            {
                a *= coefficent;
                double newX = Math.Round(startPoint.X + a * Math.Cos(angle)),
                       newY = Math.Round(startPoint.Y - a * Math.Sin(angle));
                Line line = new Line()
                {
                    X1 = startPoint.X,
                    Y1 = startPoint.Y,
                    X2 = newX,
                    Y2 = newY
                };
                if (currentDepth == 0) { line.Stroke = new SolidColorBrush(startColor); }
                else { line.Stroke = new SolidColorBrush(GetCurrentColor()); }
                drawingArea.Children.Add(line);

                PythagoreanTree branch1 = new PythagoreanTree(coefficent, new Point(newX, newY), a, angle + ang1,
                    ang1, ang2, drawingArea, recursionDepth, currentDepth + 1, startColor, endColor),
                            branch2 = new PythagoreanTree(coefficent, new Point(newX, newY), a, angle - ang2,
                    ang1, ang2, drawingArea, recursionDepth, currentDepth + 1, startColor, endColor);
                branch1.Draw();
                branch2.Draw();
            }
            else
                return;
        }
    }
}