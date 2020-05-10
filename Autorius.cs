using System;
using System.Collections.Generic;
using System.Text;

namespace KD2
{
    public class Autorius
    {
        public string pavVard { get; set; }
        public string knyga { get; set; }
        public string leidykla { get; set; }
        public double kaina { get; set; }

        public Autorius (string pavVard = "", string knyga = "",
            string leidykla = "", double kaina = 0)
        {
            this.pavVard = pavVard;
            this.knyga = knyga;
            this.leidykla = leidykla;
            this.kaina = kaina;
        }
        void Deti(string a, string b, string c, double d)
        {
            pavVard = a;
            knyga = b;
            leidykla = c;
            kaina = d;
        }
        public override string ToString()
        {
            string eilute;
            eilute = string.Format("|{0, -30}| {1,-20} | {2, -20} |   {3, 8:f}   |",
                pavVard, knyga, leidykla, kaina);
            return eilute;
        }
        public override bool Equals(object objektas)
        {
            Autorius elem = objektas as Autorius;
            return elem.pavVard == pavVard && elem.knyga == knyga &&
                elem.leidykla == leidykla && elem.kaina == kaina;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public static bool operator >= (Autorius pirmas, Autorius antras)
        {
            int poz = String.Compare(pirmas.pavVard, antras.pavVard,
                StringComparison.CurrentCulture);
            return pirmas.kaina > antras.kaina || pirmas.kaina == antras.kaina
                && poz > 0;
        }
        public static bool operator <=(Autorius pirmas, Autorius antras)
        {
            int poz = String.Compare(pirmas.pavVard, antras.pavVard,
                StringComparison.CurrentCulture);
            return pirmas.kaina < antras.kaina || pirmas.kaina == antras.kaina
                && poz < 0;
        }
    }
}
