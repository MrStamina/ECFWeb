using System;

namespace ClassChasseurDT.Metier
{
 public class Contact
   {
      public int IdContact { get; set; }
      public DateTime DateRendezVous {get; set;}
      public Candidat LeCandidat {get; set;}
      public Mission LaMission {get; set;}
      public string CommentaireSuivi {get;set;}
      public SituationContact Situation { get; set; }
   
   }
}