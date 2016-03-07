using System;

namespace ClassChasseurDT.Metier
{
    public class Experience
   {
      public int IdExperience { get; set; }

      public int IdCandidat { get; set; }

      public DateTime DateDebut {get; set;}
      public DateTime? DateFin {get; set;}
      public string Commentaire {get; set;}
      
      public Qualification LaQualif {get; set;}
      public Entreprise Lentreprise {get; set;}

     
   
   }
}