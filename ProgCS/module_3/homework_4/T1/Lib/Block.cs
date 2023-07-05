using System;

namespace Task1Lib
{
    public class Block
    {
        public Rectangle _base;

        public double _height;

        public Block(Rectangle _base, double height)
        {
            this._base = _base;
            _height = height;
        }

        public Rectangle Base => _base;

        public double Height => _height;

        public double Volume => Base.Area * Height;

        public void OnChangeRectangleSideEventHandler(object sender,
            ChangeRectangleSideEventArgs e)
        {
            double oldSideA = _base.SideA, oldSideB = _base.SideB;
            _height = _base.Area / (oldSideA * oldSideB);
            Console.WriteLine($"\nChanged block:\n{this}");
        }

        public override string ToString()
            => $"Block\nBase: {Base}\nHeight: {Height:f3}\nVolume: {Volume:f3}";
    }
}