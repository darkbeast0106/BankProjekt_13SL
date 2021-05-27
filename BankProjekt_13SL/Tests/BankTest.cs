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
    }
}
