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
    public class DaoSecteurActivite
    {
        public static List<Activite> GetAllActivites()
        {
            List<Activite> Activites = new List<Activite>();
            // création connection
            using (SqlConnection sqlConnect = Connection.GetConnection())
            {
                using (SqlCommand sqlCde = new SqlCommand())
                {
                    //initialiser la connection de la commande
                    sqlCde.Connection = sqlConnect;
                    // chargement des collaborateurs + leur qualif
                    String strSql = "select idActivite, libelleActivite from dbo.Activite ";

                    sqlCde.CommandText = strSql;
                    // Exécution de la commande
                    try
                    {
                        SqlDataReader sqlRdr = sqlCde.ExecuteReader();
                        while (sqlRdr.Read())
                        {
                            Activite oActivite = new Activite()
                            {
                                IdActivite = Convert.ToSByte(sqlRdr[0]),
                                LibelleActivite = sqlRdr.GetString(1)
                            };
                            Activites.Add(oActivite);
                        }
                        sqlRdr.Close();
                        return Activites;
                    }
                    catch (SqlException se)
                    {
                        throw new DaoExceptionFinAppli("Lecture base impossible" + se.Message, se);
                    }
                }
            }
        }
    }
}
