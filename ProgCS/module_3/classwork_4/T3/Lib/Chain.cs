using System;
using System.Collections.Generic;

namespace Task3Lib
{
    public class Chain
    {
        private List<Bead> _beads;

        private double _length;

        private int _beadsCount;

        /// <param name="length">Length of the chain</param>
        /// <param name="n">Count of beads in the chain</param>
        public Chain(double length, int beadsCount)
        {
            _beads = new List<Bead>();
            BeadsCount = beadsCount;
            Length = length;
            CreateBeads();
        }

        public List<Bead> Beads { get => _beads; }

        public int BeadsCount
        {
            get { return _beadsCount; }
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException
                        ("Count of beads can't be 0 or negative");
                _beadsCount = value;
                OnChainNumChanged(new ChainLenChangedEventArgs(_length / _beadsCount));
            }
        }

        public double Length
        {
            get { return _length; }
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException
                        ("Chain length can't be 0 or negative");
                _length = value;
                OnChainLenChanged(new ChainLenChangedEventArgs(_length / _beadsCount));
            }
        }

        public void Radius(double radius)
        {
            BeadsCount = (int)(Length / radius);
            CreateBeads();
        }

        public void CreateBeads()
        {
            for (int i = 0; i < _beadsCount; i++)
            {
                var bead = new Bead(_length / _beadsCount);
                _beads.Add(bead);
                ChainLenChangedEvent += bead.OnChainLenChangedHandler;//добавим обработчик бусины
                ChainNumChangedEvent += bead.OnChainLenChangedHandler;
            }
        }

        public event EventHandler<ChainLenChangedEventArgs> ChainLenChangedEvent;

        public event EventHandler<ChainLenChangedEventArgs> ChainNumChangedEvent;

        public event EventHandler<ChainRadChangedEventArgs> ChainRadChangedEvent;

        protected virtual void OnChainLenChanged(ChainLenChangedEventArgs e)
        {
            ChainLenChangedEvent?.Invoke(this, e);
        }

        protected virtual void OnChainNumChanged(ChainLenChangedEventArgs e)
        {
            ChainNumChangedEvent?.Invoke(this, e);
        }

        protected virtual void OnChainRadChanged(ChainRadChangedEventArgs e)
        {
            ChainRadChangedEvent?.Invoke(this, e);
        }

        public override string ToString()
            => $"Bead radius:\t{_beads[0].Radius:f2}\nBeads count:\t{_beadsCount}\n" +
            $"Chain length:\t{_length}\n";
    }
}