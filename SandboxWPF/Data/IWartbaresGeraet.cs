using System;
using System.Collections.Generic;
using System.Text;

namespace SandboxWPF.Data
{
    public interface IWartbaresGeraet
    {
        int Gewartet { get; }

        void Wartung();







        public void WartungTest()
        {
            Wartung();
            int gewartet = Gewartet;
        }
    }
}
