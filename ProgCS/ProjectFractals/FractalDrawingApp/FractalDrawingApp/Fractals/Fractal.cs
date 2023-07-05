using System.Windows.Controls;
using System.Windows.Media;

namespace FractalDrawingApp.Fractals
{
    public abstract class Fractal
    {
        //Холст, на котором будут изображены фракталы
        public Canvas drawingArea;
        //Начальный и конечный цвета
        protected Color startColor, endColor;
        //Максимальный уровень рекурсии
        protected int recursionDepth;
        //Текущий уровень рекурсии
        protected int currentDepth;

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="drawingArea">Холст</param>
        /// <param name="recursionDepth">Уровень рекурсии</param>
        /// <param name="currentDepth">текущий уровень рекурсии</param>
        /// <param name="startColor">Начальный цвет</param>
        /// <param name="endColor">Конечный цвет</param>
        protected Fractal(Canvas drawingArea, int recursionDepth, int currentDepth, Color startColor, Color endColor)
        {
            this.drawingArea = drawingArea;
            this.recursionDepth = recursionDepth;
            this.currentDepth = currentDepth;
            this.startColor = startColor;
            this.endColor = endColor;
        }

        //Абстрактный класс для отрисовки фрактала
        internal abstract void Draw();

        /// <summary>
        /// Данный метод вычисляет промежуточный цвет 
        /// для отрисовки по текущему уровню рекурсии,
        /// а также начальному и конечному цвету
        /// </summary>
        /// <returns></returns>
        protected Color GetCurrentColor()
        {
            if (recursionDepth == 0) return startColor;
            if (recursionDepth == 1) return endColor;
            byte aCurrent = (byte)(startColor.A + (double)((endColor.A - startColor.A) * (currentDepth) / (recursionDepth)));
            byte rCurrent = (byte)(startColor.R + (double)((endColor.R - startColor.R) * (currentDepth) / (recursionDepth)));
            byte bCurrent = (byte)(startColor.B + (double)((endColor.B - startColor.B) * (currentDepth) / (recursionDepth)));
            byte gCurrent = (byte)(startColor.G + (double)((endColor.G - startColor.G) * (currentDepth) / (recursionDepth)));
            return Color.FromArgb(aCurrent, rCurrent, gCurrent, bCurrent);

        }
    }
}