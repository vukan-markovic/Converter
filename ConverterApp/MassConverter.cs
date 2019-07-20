using System;

namespace ConverterApp
{
    class MassConverter : Conversion
    {
        // Metoda koja realizuje konverziju funti u kilograme. Dobijeni rezultat se zaokružuje na 3 decimale.

        public double Convert(double pounds)
        {
            return Math.Round(pounds * 0.45359237, 3);
        }
    }
}
