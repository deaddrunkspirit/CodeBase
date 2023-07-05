using System;

namespace Task6Lib
{
    public class Plant
    {
        private double _growth;
        private double _photosensivity;
        private double _frostresistance;

        /// <summary>
        /// This constructor with 3 parametr creates 
        /// an instant of Plant type
        /// </summary>
        /// <param name="growth">growth of the plant</param>
        /// <param name="photosens">photosentivity of the plant</param>
        /// <param name="frostresist">frostresistance of the plant</param>
        public Plant(double growth, double photosens, double frostresist)
        {
            if (photosens < 0 || photosens > 100 || frostresist < 0 || frostresist > 100)
                throw new ArgumentException
                    ("Photosentivity and frostresistance must be in [0, 100]");
            _growth = growth;
            _photosensivity = photosens;
            _frostresistance = frostresist;
        }

        /// <summary>
        /// This property returns growth of the plant
        /// </summary>
        public double Growth => _growth;

        /// <summary>
        /// This property returns frostresistance of the plant
        /// </summary>
        public double FrostResist => _frostresistance;

        /// <summary>
        /// This property returns photosensivity of the plant
        /// </summary>
        public double PhotoSens => _photosensivity;

        /// <summary>
        /// This method converts Plant type to String
        /// </summary>
        /// <returns></returns>
        public override string ToString() 
            => $"\nGrowth:\t\t\t{Growth:f3}\nPhotosensivity:" +
            $"\t\t{PhotoSens:f3}\nFrostresistanse:\t{FrostResist:f3}\n";
    }
}
