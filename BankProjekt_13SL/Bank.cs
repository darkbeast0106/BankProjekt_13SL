using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankProjekt_13SL
{
    public class Bank
    {
        private class Szamla
        {
            string nev;
            string szamlaszam;
            ulong egyenleg;

            public Szamla(string nev, string szamlaszam)
            {
                this.nev = nev;
                this.szamlaszam = szamlaszam;
                this.egyenleg = 0;
            }

            public string Szamlaszam { get => szamlaszam; }
            public ulong Egyenleg { get => egyenleg; set => egyenleg = value; }
        }
        private List<Szamla> szamlak = new List<Szamla>();
        // Egy létező számlára pénzt helyez
        public void EgyenlegFeltolt(string szamlaszam, ulong osszeg)
        {
            if (osszeg == 0)
            {
                throw new ArgumentException(
                    "0 Forintot nem lehet feltölteni", "osszeg");
            }
            Szamla szamla = SzamlaKeres(szamlaszam);
            szamla.Egyenleg += osszeg;
        }

        // Új számlát nyit a megadott névvel, számlaszámmal
        public void UjSzamla(string nev, string szamlaszam)
        {
            foreach (Szamla szamla1 in szamlak)
            {
                if (szamla1.Szamlaszam.Equals(szamlaszam))
                {
                    throw new ArgumentException(
                        "Az adott számlaszámmal már létezik számla",
                        "szamlaszam");
                }
            }
            Szamla szamla = new Szamla(nev, szamlaszam);
            szamlak.Add(szamla);
        }

        // Két számla között utal.
        // Ha nincs elég pénz a forrás számlán,
        // akkor 'false' értékkel tére vissza
        public bool Utal(string honnan, string hova, ulong osszeg)
        {
            if (osszeg == 0)
            {
                throw new ArgumentException(
                    "0 Forintot nem lehet utalni", "osszeg");
            }
            Szamla honnanSzamla = SzamlaKeres(honnan);
            Szamla hovaSzamla = SzamlaKeres(hova);
            if (osszeg > honnanSzamla.Egyenleg)
            {
                return false;
            }
            honnanSzamla.Egyenleg -= osszeg;
            hovaSzamla.Egyenleg += osszeg;
            return true;
        }

        // Lekérdezi az adott számlán lévő pénzösszeget
        public ulong Egyenleg(string szamlaszam)
        {
            Szamla szamla = SzamlaKeres(szamlaszam);
            return szamla.Egyenleg;
        }

        private Szamla SzamlaKeres(string szamlaszam)
        {
            foreach (Szamla szamla in szamlak)
            {
                if (szamla.Szamlaszam.Equals(szamlaszam))
                {
                    return szamla;
                }
            }
            throw new HibasSzamlaszamException(szamlaszam);
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
