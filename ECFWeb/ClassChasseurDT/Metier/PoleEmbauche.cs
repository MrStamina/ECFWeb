using System;

namespace ClassChasseurDT.Metier
{
   public class PoleEmbauche
   {
      public int? IdPole {get; set;}
      public string LibellePole {get; set;}
       
        public PoleEmbauche()
        {

        }

        public override string ToString()
        {
            return base.ToString();
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public override bool Equals(Object obj)
        {
            return obj is PoleEmbauche && ((PoleEmbauche)obj).IdPole.Equals(this.IdPole);
        }

    }
}