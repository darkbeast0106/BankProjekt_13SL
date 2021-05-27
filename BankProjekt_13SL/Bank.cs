using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankProjekt_13SL
{
    public class Bank
    {
        // Egy létező számlára pénzt helyez
        public void EgyenlegFeltolt(string szamlaszam, ulong osszeg)
        {
            throw new NotImplementedException();
        }

        // Új számlát nyit a megadott névvel, számlaszámmal
        public void UjSzamla(string nev, string szamlaszam)
        {
            throw new NotImplementedException();
        }

        // Két számla között utal.
        // Ha nincs elég pénz a forrás számlán, akkor
        public bool Utal(string honnan, string hova, ulong osszeg)
        {
            throw new NotImplementedException();
        }

        // Lekérdezi az adott számlán lévő pénzösszeget
        public ulong Egyenleg(string szamlaszam)
        {
            throw new NotImplementedException();
        }
    }

    // Nem létező számla esetén dobhatjuk bármely függvényből
    class HibasSzamlaszamException : Exception
    {
        public HibasSzamlaszamException(string szamlaszam)
            : base("Hibas szamlaszam: " + szamlaszam)
        {
        }
    }
}
