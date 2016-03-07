using System;

namespace ClassChasseurDT.Metier
{
   public class Activite
   {
       public sbyte? IdActivite {get; set;}
       public string LibelleActivite {get; set;}

       public Activite()
        {

        }

        public override string ToString()
        {
            return base.ToString();
        }

        public override bool Equals(Object obj)
        {
            return obj is Activite && ((Activite)obj).IdActivite.Equals(this.IdActivite);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}