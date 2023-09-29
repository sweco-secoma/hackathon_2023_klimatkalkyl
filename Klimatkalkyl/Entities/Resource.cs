using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klimatkalkyl.Entities
{
    internal class Resource
    {
        public string Namn { get; set; }

        public double Klimat { get; set; }

        public Enhet Enhet { get; set;}

        public double Energi { get; set; }

        public Enhet EnergiEnhet { get; set; }

        public string Datakalla { get; set; }

        public string TekniskBeskrivning { get; set; }
    }

    internal class Enhet
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Beskrivning { get; set; }
    }
}
