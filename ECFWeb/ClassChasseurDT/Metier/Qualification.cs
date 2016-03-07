using System;
using System.Collections.Generic;

namespace ClassChasseurDT.Metier
{
  public class Qualification
   {
      public int IdQualification {get; set;}
      public string LibelleQualification {get; set;}

      public List<PosteRecherche> Postes { get; set; }
   
   }
}