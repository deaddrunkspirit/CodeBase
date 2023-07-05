using System.Drawing;
using System.Windows.Forms;

namespace Task5
{
    public class CircleVizualizator
    {
        public Circle _circle;

        public PictureBox _trg;

        private readonly Pen _pen = new Pen(Color.Black, 3);

        public CircleVizualizator(PictureBox pictureBox, Circle circle)
        {
            _trg = pictureBox;
            _circle = circle;

            circle.OnRadiusChanged += () =>
            {
                _trg.Refresh();
                Draw();
            };
        }

        private void Draw()
            => _trg.CreateGraphics().DrawEllipse(_pen, 0, 0, _circle.Radius, _circle.Radius);

        public void Refresh()
            => _trg.CreateGraphics().Clear(Color.Silver);

        public Color PenColor
        {
            set => _pen.Color = value;
        }
    }
}