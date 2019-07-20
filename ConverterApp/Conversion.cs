namespace ConverterApp
{
    interface Conversion
    {
        /* 
            definisanje metode za konverziju koja ima jedan prosleđeni parametar - unos korisnika. Metoda se
            implementira u klasama LengthConverter i MassConverter.
        */

        double Convert(double input);
    }
}
