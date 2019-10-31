using System;
using System.Collections.Generic;
using System.Text;

namespace SandboxWPF.Data
{
    public abstract class BasisFahrzeug : IWartbaresGeraet
    {
        public int Gewartet { get; protected set; }

        public abstract void Wartung();
    }
}
