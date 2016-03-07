using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ClassChasseurDT.Metier;
using ClassChasseurDT.Exceptions;
using System.Data.SqlClient;


using System.Data;
using System.Configuration;




namespace ClassChasseurDT.Dao
{
    public class DaoExperience
    {
        public static List<Experience> GetAllExperiencesByCand(int idCand)
        {

            // création connection
            using (SqlConnection sqlConnect = Connection.GetConnection())
            {
                List<Experience> lstExperiences = new List<Experience>();
                using (SqlCommand sqlCde = new SqlCommand())
                {
                    //initialiser la connection de la commande
                    sqlCde.Connection = sqlConnect;
                    // chargement des qualifications
                    String strSql = "GetAllExperiencesByCand";
                    sqlCde.CommandText = strSql;
                    sqlCde.CommandType = CommandType.StoredProcedure;
                    sqlCde.Parameters.Add(new SqlParameter("@idCandidat", SqlDbType.Int)).Value = idCand;

                    // Exécution de la commande
                    try
                    {
                        SqlDataReader sqlRdr = sqlCde.ExecuteReader();
                        Experience oExperience = null;
                        while (sqlRdr.Read())
                        {
                            // Qualification
                            Qualification oQualif = new Qualification()
                            {
                                IdQualification = sqlRdr.GetInt32(2),
                                LibelleQualification =sqlRdr[8].ToString()
                            };
                            // Entreprise 
                            Entreprise oEntreprise = new Entreprise()
                            {
                                IdEntreprise = idCand,
                                RaisonSociale = sqlRdr[7].ToString()
                            };
                            // date fin null ?
                            DateTime? df;
                            if (!sqlRdr.IsDBNull(5)) df = sqlRdr.GetDateTime(5);
                            else df = null;
                           
                            
                            // Création objet
                            oExperience = new Experience()
                            {
                                IdExperience = sqlRdr.GetInt32(0),
                                IdCandidat=idCand,
                                DateDebut = sqlRdr.GetDateTime(4),
                                DateFin = df,
                                Commentaire=sqlRdr[6].ToString(),
                                LaQualif= oQualif,
                                Lentreprise = oEntreprise
                            };
                            lstExperiences.Add(oExperience);
                        }
                        sqlRdr.Close();

                        return lstExperiences;
                    }
                    catch (SqlException se)
                    {
                        throw new DaoExceptionFinAppli("Lecture Experience impossible \n" + se.Message, se);
                    }
                }
            }
        }
    }
}
