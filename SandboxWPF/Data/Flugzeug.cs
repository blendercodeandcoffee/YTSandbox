using System;
using System.Collections.Generic;
using System.Text;

namespace SandboxWPF.Data
{
    public class Flugzeug : BasisFahrzeug
    {
        public int Turbinen { get; set; }

        public override void Wartung()
        {
            Gewartet = 2;
        }
    }
}
