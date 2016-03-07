using System;
using System.Collections.Generic;

namespace ClassChasseurDT.Metier
{
   public class Entreprise
   {
      public int IdEntreprise {get; set;}
      public string RaisonSociale {get; set;}
      public string Adresse1Ent {get; set;}
      public string Adresse2Ent {get; set;}
      public string CpEnt {get; set;}
      public string VilleEnt {get; set;}
      public bool Cliente {get; set;}
      public string Contact { get; set; }
      public string TelContact { get; set; }
      public string MailContact { get; set; }
      public DateTime DateCreation { get; set; }
      public Activite SecteurActivite {get; set;}
      public PoleEmbauche PoleRattachement {get; set;}

      public List<Mission> Missions { get; set; }

        public Entreprise()
        {

        }

        public override bool Equals(Object obj)
        {
            return obj is Entreprise && ((Entreprise)obj).IdEntreprise.Equals(this.IdEntreprise);
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}