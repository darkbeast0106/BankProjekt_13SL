using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace BankProjekt_13SL.Tests
{
    [TestFixture]
    class BankTest
    {
        Bank b;
        [SetUp]
        public void SetUp()
        {
            b = new Bank();
        }
        private void TesztElek1234()
        {
            b.UjSzamla("Teszt Elek", "1234");
        }

        private void NagyArpad5678()
        {
            b.UjSzamla("Nagy Árpád", "5678");
        }
        [TestCase]
        public void UjSzamlaSikeresenLetrejon()
        {
            Assert.DoesNotThrow(TesztElek1234);
            //Assert.DoesNotThrow(() => 
            //b.UjSzamla("Teszt Elek", "1234"));
        }
        [TestCase]
        public void UjSzamlaLetezoNevvelSikeres()
        {
            TesztElek1234();
            Assert.DoesNotThrow(() =>
            b.UjSzamla("Teszt Elek", "5678"));
        }
        [TestCase]
        public void UjSzamlaLetezoSzamlaszammalException()
        {
            TesztElek1234();
            Assert.Throws<ArgumentException>(() =>
                b.UjSzamla("Nagy Árpád", "1234"));
        }

        [TestCase]
        public void EgyenlegUjSzamlaEgyenlegNulla()
        {
            TesztElek1234();
            Assert.AreEqual(0, b.Egyenleg("1234"));
        }

        [TestCase]
        public void EgyenlegNemLetezoSzamlaszamEgyenlegeException()
        {
            TesztElek1234();
            Assert.Throws<HibasSzamlaszamException>(() =>
                b.Egyenleg("4321"));
        }

        [TestCase]
        public void EgyenlegFeltoltNemLetezoSzamlaraExceptiontDob()
        {
            TesztElek1234();
            Assert.Throws<HibasSzamlaszamException>(() =>
                b.EgyenlegFeltolt("4321", 10000));
        }
        [TestCase]
        public void EgyenlegFeltoltSikeresenMegvaltozikAzEgyenleg()
        {
            TesztElek1234();
            Assert.AreEqual(0, b.Egyenleg("1234"));
            b.EgyenlegFeltolt("1234", 10000);
            Assert.AreEqual(10000, b.Egyenleg("1234"));
        }
        [TestCase]
        public void EgyenlegFeltoltNullaOsszeg()
        {
            TesztElek1234();
            Assert.Throws<ArgumentException>(() =>
                b.EgyenlegFeltolt("1234", 0));
        }
        [TestCase]
        public void EgyenlegFeltoltAMegfeleloSzamlaraTolt()
        {
            TesztElek1234();
            NagyArpad5678();
            Assert.AreEqual(0, b.Egyenleg("1234"));
            Assert.AreEqual(0, b.Egyenleg("5678"));

            b.EgyenlegFeltolt("1234", 10000);

            Assert.AreEqual(10000, b.Egyenleg("1234"));
            Assert.AreEqual(0, b.Egyenleg("5678"));

        }
    }
}
