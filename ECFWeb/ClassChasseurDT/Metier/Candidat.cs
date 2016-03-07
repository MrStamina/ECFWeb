using System;
using System.Collections.Generic;

namespace ClassChasseurDT.Metier
{
   public class Candidat
   {
      public int IdCandidat {get; set;}
      public string Nom {get; set;}
      public string Prenom {get; set;}
      public DateTime DateNaissance {get; set;}
      public string Telephone {get; set;}
      public string AdresseMail {get; set;}
      public bool SituationProfess {get; set;}
      public bool Mobilite {get; set;}
      public SituationFamiliale SituationF {get; set;}
      public PoleEmbauche PoleRattachement { get; set; }


      public List<DiplomeTitre> Diplomes {get; set;}
      public List<Experience> Experiences {get; set;}
      public List<PosteRecherche> Postes {get; set;}
   
   }
}