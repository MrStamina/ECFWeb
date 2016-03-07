using System;
using System.Collections.Generic;

namespace ClassChasseurDT.Metier
{
   public class PosteRecherche
   {
      public int IdPoste { get; set; }
      public decimal RemuPlancher {get; set;}
      public decimal RemuPlafond {get; set;}
      
      public Qualification LaQualif {get; set;}
      public Candidat LeCandidat { get; set; }

   }
}