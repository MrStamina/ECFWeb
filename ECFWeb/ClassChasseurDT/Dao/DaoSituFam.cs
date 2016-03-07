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
    public class DaoSituFam
    {
        public static List<SituationFamiliale> GetAllSituationFamiliales()
        {
            List<SituationFamiliale> SituationFamiliales = new List<SituationFamiliale>();
            // création connection
            using (SqlConnection sqlConnect = Connection.GetConnection())
            {
                using (SqlCommand sqlCde = new SqlCommand())
                {
                    //initialiser la connection de la commande
                    sqlCde.Connection = sqlConnect;
                    // chargement des collaborateurs + leur qualif
                    String strSql = "select idSituF, libelleSituF from dbo.SituationFamiliale ";

                    sqlCde.CommandText = strSql;
                    // Exécution de la commande
                    try
                    {
                        SqlDataReader sqlRdr = sqlCde.ExecuteReader();
                        while (sqlRdr.Read())
                        {
                            SituationFamiliale oSituationFamiliale = new SituationFamiliale()
                            {
                                 IdSituF= Convert.ToSByte(sqlRdr[0]),
                                LibelleSituF= sqlRdr.GetString(1)
                            };
                            SituationFamiliales.Add(oSituationFamiliale);
                        }
                        sqlRdr.Close();
                        return SituationFamiliales;
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
