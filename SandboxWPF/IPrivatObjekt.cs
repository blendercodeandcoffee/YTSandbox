using SandboxWPF.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace SandboxWPF
{
    public interface IPrivatObjekt : IWartbaresGeraet
    {
        int Kaufpreis { get; }
    }
}
