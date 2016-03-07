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
    public class DaoPoleEmbauche
    {
        public static List<PoleEmbauche> GetAllPoleEmbauches()
        {
            List<PoleEmbauche> PoleEmbauches = new List<PoleEmbauche>();
            // création connection
            using (SqlConnection sqlConnect = Connection.GetConnection())
            {
                using (SqlCommand sqlCde = new SqlCommand())
                {
                    //initialiser la connection de la commande
                    sqlCde.Connection = sqlConnect;
                    // chargement des collaborateurs + leur qualif
                    String strSql = "select idPole, libellePole from dbo.PoleEmbauche ";

                    sqlCde.CommandText = strSql;
                    // Exécution de la commande
                    try
                    {
                        SqlDataReader sqlRdr = sqlCde.ExecuteReader();
                        while (sqlRdr.Read())
                        {
                            PoleEmbauche oPoleEmbauche = new PoleEmbauche()
                            {
                                 IdPole = Convert.ToInt32(sqlRdr[0]),
                                LibellePole= sqlRdr.GetString(1)
                            };
                            PoleEmbauches.Add(oPoleEmbauche);
                        }
                        sqlRdr.Close();
                        return PoleEmbauches;
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
