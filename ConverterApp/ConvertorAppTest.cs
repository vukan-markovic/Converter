using NUnit.Framework;
using NUnit.Framework.Interfaces;
using System;

namespace ConverterApp
{
    [TestFixture]
    public class ConvertorAppTest
    {
        // ukoliko neki test nije prošao, ispisujemo naziv testa koji je neuspešan i poruku da nije prošao

        [TearDown]
        public void TearDownFailed()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                Console.WriteLine(TestContext.CurrentContext.Test.FullName);
                Console.WriteLine(TestContext.CurrentContext.Result.Outcome + " test nije prošao");
            }
        }

        // ukoliko je neki test prošao, ispisujemo naziv testa koji je uspešan i poruku da je prošao

        [TearDown]
        public void TearDownPassed()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Passed)
            {
                Console.WriteLine(TestContext.CurrentContext.Test.FullName);
                Console.WriteLine(TestContext.CurrentContext.Result.Outcome + " test je prošao");
            }
        }

        // metoda za testiranje metode Convert() klase MassConverter, tj. konverzije iz funti u kilograme

        [Test]
        public void ConvertMassTest()
        {
            /*
               u metodi dajemo primer unosa, očekivani izlaz na osnovu tog unosa i stvarni rezultat konverzije
               koji smo dobili pozivom metode Convert() klase MassConverter za prosleđeni unos. Ukoliko su
               data i dobijena vrednost rezultata jednake test će biti uspešan, u suprotnom test će biti neuspešan
               i ispisujemo poruku greške
            */

            double input = 48;
            double expectedOutput = 21.772;
            MassConverter mass = new MassConverter();
            double actualOutput = mass.Convert(input);
            Assert.AreEqual(expectedOutput, actualOutput, "Postoji greška, konverzija nije tačno izvršena.");
        }

        // metoda za testiranje metode Convert() klase LengthConverter, tj. konverzije iz stope u metre

        [Test]
        public void ConvertLengthTest()
        {
            /*
               u metodi dajemo primer unosa, očekivani izlaz na osnovu tog unosa i stvarni rezultat konverzije
               koji smo dobili pozivom metode Convert() klase LengthConverter za prosleđeni unos. Ukoliko su
               data i dobijena vrednost rezultata jednake test će biti uspešan, u suprotnom test će biti neuspešan
               i ispisujemo poruku greške
            */

            double input = 123.12;
            double expectedOutput = 37.527;
            LengthConverter length = new LengthConverter();
            double actualOutput = length.Convert(input);
            Assert.AreEqual(expectedOutput, length.Convert(input), "Postoji greška, konverzija nije tačno izvršena.");
        }
        
        // generička metoda za testiranje metode za konverziju funti u kilograme

        [TestCase(32.71, 14.837)]
        [TestCase(48, 21.772)]
        [TestCase(17, 7.711)]
        public void ConvertMassParameterTest(double input, double expectedOutput)
        {
            Assert.AreEqual(expectedOutput, new MassConverter().Convert(input), "Postoji greška, konverzija nije tačno izvršena.");
        }

        // generička metoda za testiranje metode za konverziju feet u metre

        [TestCase(59, ExpectedResult = 17.983)]
        [TestCase(123.21, ExpectedResult = 37.554)]
        [TestCase(23, ExpectedResult = 7.010)]
        public double ConvertLengthParameterTest(double input)
        {
            LengthConverter lC = new LengthConverter();
            return lC.Convert(input);
        }
    }
}