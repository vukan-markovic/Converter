using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using System.Linq;

namespace ConverterApp
{
    public partial class Converter : Form
    {
        // Deklaracija i inizijalicazija potrebnih objekata i promenljivih.

        Graphics graph;
        RectangleF[] arrayOfButtons = new RectangleF[11];
        Rectangle rectConvertButton;
        Rectangle rectInput;
        Rectangle rectOutput;
        Rectangle cleanButton;
        MassConverter mC = new MassConverter();
        LengthConverter lC = new LengthConverter();
        EventArgs eA = new EventArgs();
        float numbersSpace = 3; 
        int numberOfCommas = 0;
        string input = "", output = "";
        object obj = new object();
        
        public Converter()
        {
            /* 
               Inicijalizacija komponenti i podešavanje boje pozadine forme, pošto se nalazi u konstruktoru
               izvršava se prilikom svakog pokretanja forme.
            */

            InitializeComponent();
            BackColor = (Brushes.BlueViolet as SolidBrush).Color;
        }

        /* 
           Menjanje naziva labela u zavisnosti od odabrane opcije, tj. čekiranog radio button- a.
           Nazivi labela će biti "pounds" i "kg" za konverziju mase i "feet" i "m" za konverziju dužine.
        */

        private void radioButtonMass_CheckedChanged(object sender, EventArgs e)
        {
            lblPoundsFeet.Text = "pounds";
            lblKgM.Text = "kg";
        }

        private void radioButtonLength_CheckedChanged(object sender, EventArgs e)
        {
            lblPoundsFeet.Text = "feet";
            lblKgM.Text = "m";
        }

        /* 
           Metoda koja realizuje menjanje boje dugmića prilikom klika na njih, unos brojeva u kvadrat za unos
           na osnovu odabranih dugmića i upis konvertovane vrednosti u kvadrat za izlaz. Metoda će se pozivati
           klikom miša na formu.
        */

        private void Converter_MouseClick(object sender, MouseEventArgs e)
        {
            /* 
               Prolazimo kroz niz dugmića i proveravamo da li neki od njih sadrži klik miša i ako da koji.
               Kliknuto dugme prvo bojimo u plavo a tekst u njemu u belo, zatim pauziramo program na 100
               milisekundi (Thread.Sleep(100)) kako bi dobili "blink" efekat i potom vraćamo boje dugmeta
               na prethodne vrednosti.
            */

            for (int i = 0; i < 11; i++)
            {
                if (arrayOfButtons[i].Contains(e.X, e.Y))
                {
                    graph.FillEllipse(Brushes.Blue, arrayOfButtons[i].X + 0.5f, arrayOfButtons[i].Y + 0.5f, arrayOfButtons[i].Width - 1, arrayOfButtons[i].Height - 1);

                    if (i == 9)
                    {
                        graph.DrawString("0", new Font(FontFamily.GenericSansSerif, 8, FontStyle.Bold), Brushes.White, arrayOfButtons[i].X + 10, arrayOfButtons[i].Y + 10);
                    }
                    else if (i == 10)
                    {
                        graph.DrawString(",", new Font(FontFamily.GenericSansSerif, 8, FontStyle.Bold), Brushes.White, arrayOfButtons[i].X + 10, arrayOfButtons[i].Y + 10);
                    }
                    else
                    {
                        graph.DrawString((i + 1).ToString(), new Font(FontFamily.GenericSansSerif, 8, FontStyle.Bold), Brushes.White, arrayOfButtons[i].X + 10, arrayOfButtons[i].Y + 10);
                    }

                    Thread.Sleep(100);

                    graph.FillEllipse(Brushes.BlueViolet, arrayOfButtons[i].X + 0.5f, arrayOfButtons[i].Y + 0.5f, arrayOfButtons[i].Width - 1, arrayOfButtons[i].Height - 1);

                    if (i == 9)
                    {
                        graph.DrawString("0".ToString(), new Font(FontFamily.GenericSansSerif, 8, FontStyle.Bold), Brushes.Black, arrayOfButtons[i].X + 10, arrayOfButtons[i].Y + 10);
                    }
                    else if (i == 10)
                    {
                        graph.DrawString(",".ToString(), new Font(FontFamily.GenericSansSerif, 8, FontStyle.Bold), Brushes.Black, arrayOfButtons[i].X + 10, arrayOfButtons[i].Y + 10);
                    }
                    else
                    {
                        graph.DrawString((i + 1).ToString(), new Font(FontFamily.GenericSansSerif, 8, FontStyle.Bold), Brushes.Black, arrayOfButtons[i].X + 10, arrayOfButtons[i].Y + 10);
                    }

                    /* 
                       Vršimo upis odabranih brojeva klikom na dugmad u kvadrat namenjen za prikaz unosa. Pri
                       tome vršimo proveru da li je broj odabranih brojeva manji od 13 jer toliko brojeva može
                       da stane u kvadrat za unos. Ukoliko korisnik proba da unese više prikazujemo mu odgovarajuće obaveštenje.
                    */

                    if (input.Length <= 13)
                    {
                        if (i == 9)
                            input += 0;
                        else if (i == 10)
                            input += ',';
                        else
                            input += (i + 1);

                        graph.DrawString(input[input.Length - 1].ToString(), new Font(FontFamily.GenericSansSerif, 8, FontStyle.Bold), Brushes.Black, rectInput.X + numbersSpace, rectInput.Y + 6);
                        numbersSpace += 6;
                    }
                    else
                    {
                        MessageBox.Show("Maksimalan broj cifara je unet!", "Obaveštenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }

            /* 
               Ukoliko je kliknuto na dugme za konverziju vršimo upis konvertovane vrednosti u kvadrat za prikaz
               izlaza pri tome proveravajući da polje za unos nije prazno. Ako jeste obaveštavamo korisnika da
               mora uneti neki broj kako bi izvršio konverziju. Ukoliko je dužina konvertovane vrednosti duža od 13
               upisujemo samo prvih 13 brojeva, ostatak odbacujemo (jer u kvadrat može da stane najviše 13 brojeva).
               Takođe vršimo proveru da li broj zareza 0 (ako je ceo broj) ili 1 (ako je decimalni broj). Ako nije
               obaveštavamo korisnika da mora uneti pravilan broj kako bi izvršili konverziju.
            */

            if (rectConvertButton.Contains(e.X, e.Y))
            {
                numberOfCommas = input.Count(x => x == ',');

                if (input != "" && (numberOfCommas == 1 || numberOfCommas == 0))
                {
                    graph.Clear(this.BackColor);
                    Draw(obj, eA);
                    numbersSpace = 3;

                    foreach(char c in input)
                    {
                        graph.DrawString(c.ToString(), new Font(FontFamily.GenericSansSerif, 8, FontStyle.Bold), Brushes.Black, rectInput.X + numbersSpace, rectInput.Y + 6);
                        numbersSpace += 6;
                    }
                    
                    if (radioButtonLength.Checked)
                    {  
                        output = lC.Convert(Convert.ToDouble(input.Replace(',', '.'))).ToString();
                        graph.DrawString(output.Substring(0, output.Length <= 13 ? output.Length : 13).Replace('.', ','), new Font(FontFamily.GenericSansSerif, 8, FontStyle.Bold), Brushes.Black, rectOutput.X + 3, rectOutput.Y + 6);
                    }
                    else
                    {   
                        output = mC.Convert(Convert.ToDouble(input.Replace(',', '.'))).ToString();
                        graph.DrawString(output.Substring(0, output.Length <= 13 ? output.Length : 13).Replace('.', ','), new Font(FontFamily.GenericSansSerif, 8, FontStyle.Bold), Brushes.Black, rectOutput.X + 3, rectOutput.Y + 6);
                    }
                }
                else
                {
                    MessageBox.Show("Morate uneti neki pravilan broj kako bi izvršili konverziju!", "Obaveštenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            /* 
               Ako se klikne dugme C za "Clean" (čišćenje) dolazi do brisanja brojeva iz oba polja, radi
               novog unosa brojeva iz početka.
             */

            if(cleanButton.Contains(e.X, e.Y))
            {
                graph.Clear(this.BackColor);
                Draw(obj, eA);
                numbersSpace = 3;
                input = "";
            }
        }

        // Metoda koja vrši iscrtavanje dugmića i kvadrata za prikaz brojeva.

        private void Draw(object sender, EventArgs e)
        {
            int buttonsSpaceX = 0, buttonsSpaceY = 40;

            // Inicijalizacija objekata kvadrata za prikaz brojeva i dugmeta za brisanje.

            graph = CreateGraphics();
            rectInput = new Rectangle(lblPoundsFeet.Location.X + 60, lblPoundsFeet.Location.Y - 5, 90, 25);
            rectOutput = new Rectangle(lblKgM.Location.X + 40, lblKgM.Location.Y - 5, 90, 25);
            cleanButton = new Rectangle(rectInput.X - 82, rectInput.Y + 5, 15, 15);

            // Iscrtavanje kvadrata za prikaz brojeva i dugmeta za brisanje

            graph.DrawRectangle(Pens.CadetBlue, rectInput);
            graph.DrawRectangle(Pens.CadetBlue, rectOutput);
            graph.DrawRectangle(Pens.CadetBlue, cleanButton);
            graph.DrawString("C", new Font(FontFamily.GenericSansSerif, 6, FontStyle.Bold), Brushes.Black, cleanButton.X + 4, cleanButton.Y + 4);

            // Iscrtavamo dugmiće, bojimo ih i upisujemo odgovarajući broj u njih, sa određenim razmakom između dugmića.

            for (int i = 1; i <= 9; i++)
            {
                arrayOfButtons[i - 1] = new RectangleF(lblPoundsFeet.Location.X + buttonsSpaceX, lblPoundsFeet.Location.Y + buttonsSpaceY, 30, 30);
                graph.DrawEllipse(Pens.CadetBlue, arrayOfButtons[i - 1]);
                graph.DrawString(i.ToString(), new Font(FontFamily.GenericSansSerif, 8, FontStyle.Bold), Brushes.Black, arrayOfButtons[i - 1].X + 10, arrayOfButtons[i - 1].Y + 10);
                buttonsSpaceX += 50;

                // Ako smo iscrtali 3 dugmeta prelazimo u novi red, s tim da posle prva tri iscrtavamo i dugme za konverziju.

                if (i == 3 || i == 6)
                {
                    buttonsSpaceX = 0;
                    buttonsSpaceY += 40;

                    if (i == 3)
                    {
                        rectConvertButton = new Rectangle(Convert.ToInt32(arrayOfButtons[2].X) + 50, Convert.ToInt32(arrayOfButtons[2].Y) + 15, 90, 30);
                        graph.DrawRectangle(Pens.CadetBlue, rectConvertButton);
                        graph.DrawString("Convert", new Font(FontFamily.GenericSansSerif, 8, FontStyle.Bold), Brushes.Black, rectConvertButton.X + rectConvertButton.Width / 2 - 20, rectConvertButton.Y + rectConvertButton.Height / 2 - 5);
                    }
                }

                // Iscrtavanje poslednja dva dugmeta( "0" i ",").

                if (i == 9)
                {
                    do
                    {
                        arrayOfButtons[i] = new RectangleF(lblPoundsFeet.Location.X + buttonsSpaceX, lblPoundsFeet.Location.Y + buttonsSpaceY, 30, 30);
                        graph.DrawEllipse(Pens.CadetBlue, arrayOfButtons[i]);
                        buttonsSpaceX += 50;

                    } while (++i < 11);

                    graph.DrawString("0".ToString(), new Font(FontFamily.GenericSansSerif, 8, FontStyle.Bold), Brushes.Black, arrayOfButtons[9].X + 10, arrayOfButtons[9].Y + 10);
                    graph.DrawString(",".ToString(), new Font(FontFamily.GenericSansSerif, 8, FontStyle.Bold), Brushes.Black, arrayOfButtons[10].X + 10, arrayOfButtons[10].Y + 10);
                }
            }
        }
    }
}