using System;
using System.Collections.Generic;
using System.Text;

namespace KD2
{
    public sealed class Mazgas
    {
        public Autorius duomenys { get; set; }
        public Mazgas kitas { get; set; }
        public Mazgas()
        {

        }
        public Mazgas(Autorius duomenys, Mazgas kitas)
        {
            this.duomenys = duomenys;
            this.kitas = kitas;
        }
    }
}
