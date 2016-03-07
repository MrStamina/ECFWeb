using System;
using System.Collections.Generic;
using System.Linq;

namespace ClassChasseurDT.Metier
{
    public class Consultant
    {
        public sbyte IdConsultant{ get; set; }
        public string NomConsultant { get; set; }
        public string PrenomConsultant { get; set; }

        public List<Mission> Missions { get; set; }
    }
}
