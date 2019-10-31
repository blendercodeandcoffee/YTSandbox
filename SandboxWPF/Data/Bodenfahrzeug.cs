using System;
using System.Collections.Generic;
using System.Text;

namespace SandboxWPF.Data
{
    public class Bodenfahrzeug : BasisFahrzeug, IPrivatObjekt
    {
        public int Reifen { get; set; }

        public int Kaufpreis => 14000;

        public override void Wartung()
        {
            Gewartet = 1;
        }
    }
}
