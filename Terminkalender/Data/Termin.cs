using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terminkalender.Data
{
    [Serializable]
    public class Termin
    {
        public DateTime Faelligkeit { get; set; }

        public string Kurztext { get; set; }

        public string Langtext { get; set; }

        public string Ort { get; set; }
    }
}
