using System;

namespace ConverterApp
{
    class LengthConverter : Conversion
    {
        // Metoda koja realizuje konverziju feet u metre. Dobijeni rezultat se zaokružuje na 3 decimale.

        public double Convert(double feet)
        {
            return Math.Round(feet * 0.3048, 3);
        }
    }
}
