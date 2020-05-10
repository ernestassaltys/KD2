using System;
using System.Collections.Generic;
using System.Text;

namespace KD2
{
    public sealed class Autoriai
    {
        public string pv { get; set; }
        private Mazgas pr;
        private Mazgas pb;
        private Mazgas d;

        public Autoriai()
        {
            this.pr = null;
            this.d = null;
        }
        public void Pradzia()
        {
            d = pr;
        }
        public void Kitas()
        {
            d = d.kitas;
        }
        public bool Yra()
        {
            return d != null;
        }
        public void Pabaiga()
        {
            d = pb;
        }
        public Autorius ImtiDuomenis()
        {
            return d.duomenys;
        }
        public void DetiDuomenisT(Autorius obj)
        {
            var d = new Mazgas(obj, null);
            if (pr != null)
            {
                pb.kitas = d;
                pb = d;
            }
            else
            {
                pr = d;
                pb = d;
            }
        }
        public void RikiuotiBurbuliukas()
        {
            bool keista = true;
            Mazgas d1, d2;
            while (keista)
            {
                keista = false;
                d1 = d2 = pr;
                while(d2 != null)
                {
                    if (d2.duomenys <= d1.duomenys)
                    {
                        Autorius k = d1.duomenys;
                        d1.duomenys = d2.duomenys;
                        d2.duomenys = k;
                        keista = true;
                    }
                    d1 = d2;
                    d2 = d2.kitas;
                }
            }
        }
        public void Naikinti()
        {
            while (pr != null)
            {
                d = pr;
                pr = pr.kitas;
                d.kitas = null;
            }
            pb = d = pr;
        }
    }
}
