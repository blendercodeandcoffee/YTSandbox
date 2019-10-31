using System;
using System.Collections.Generic;
using System.Text;

namespace SandboxWPF.Data
{
    public class Mixer : Elektrogeraet, IPrivatObjekt
    {
        public int Ruehrstaebe { get; set; }

        public int Kaufpreis => 30;

        public int Gewartet => throw new NotImplementedException();

        public void Wartung()
        {
            throw new NotImplementedException();
        }
    }
}
