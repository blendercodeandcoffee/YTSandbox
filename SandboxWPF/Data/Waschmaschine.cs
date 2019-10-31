using System;
using System.Collections.Generic;
using System.Text;

namespace SandboxWPF.Data
{
    public class Waschmaschine : Elektrogeraet, IPrivatObjekt
    {
        public int Fuellmenge { get; set; }
        public int Gewartet { get; private set; }

        public int Kaufpreis => 600;

        public void Wartung()
        {
            Gewartet = 12;
        }
    }
}
