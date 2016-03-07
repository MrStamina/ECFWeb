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
    public class DaoCandidat
    {
        public static int AddCandidat(Candidat cd)
        {
            // création connection
            using (SqlConnection sqlConnect = Connection.GetConnection())
            {
                // projet forfait
                using (SqlCommand sqlCde = new SqlCommand())
                {
                    //initialiser la connection de la commande
                    sqlCde.Connection = sqlConnect;
                    string strSql = "AddCandidat";
                    sqlCde.CommandText = strSql;

                    // Affectation des parametres à la commande
                    AffectParamCde(cd, sqlCde);

                    // ajout du code Candidat en sortie 
                    SqlParameter pOut = new SqlParameter("@idCandidat", SqlDbType.Int);
                    pOut.Direction = ParameterDirection.Output;
                    sqlCde.Parameters.Add(pOut);
                    // exécution de la requete
                    //========================
                    try
                    {
                        int n = sqlCde.ExecuteNonQuery();
                        if (n != 1)
                            throw new DaoExceptionAfficheMessage("L'opération n'a pas été réalisée");
                        return (int)pOut.Value;
                    }
                    catch (SqlException se)
                    {
                        throw new DaoExceptionAfficheMessage("L'opération n'a pas été réalisée: \n" + se.Message, se);
                    }
                }
            }
        }

        private static void AffectParamCde(Candidat cd, SqlCommand sqlCde)
        {
            sqlCde.CommandType = CommandType.StoredProcedure;
            sqlCde.Parameters.Clear();
            // affectation des parametres communs 
            sqlCde.Parameters.Add(new SqlParameter("@idSituf", SqlDbType.TinyInt)).Value = cd.SituationF.IdSituF;
            if (cd.PoleRattachement != null)
            sqlCde.Parameters.Add(new SqlParameter("@idPole", SqlDbType.Int)).Value = cd.PoleRattachement.IdPole;
            sqlCde.Parameters.Add(new SqlParameter("@nom", SqlDbType.VarChar, 30)).Value = cd.Nom;
            sqlCde.Parameters.Add(new SqlParameter("@prenom", SqlDbType.VarChar, 30)).Value = cd.Prenom;
            sqlCde.Parameters.Add(new SqlParameter("@dnaiss", SqlDbType.Date)).Value = cd.DateNaissance;
            sqlCde.Parameters.Add(new SqlParameter("@tel", SqlDbType.VarChar, 20)).Value = cd.Telephone;
            sqlCde.Parameters.Add(new SqlParameter("@mail", SqlDbType.VarChar, 30)).Value = cd.AdresseMail;
            sqlCde.Parameters.Add(new SqlParameter("@situp", SqlDbType.Bit)).Value = cd.SituationProfess;
            sqlCde.Parameters.Add(new SqlParameter("@mobilite", SqlDbType.Bit)).Value = cd.Mobilite;


        }

        public static bool UpdCandidat(Candidat cd)
        {
            // création connection
            using (SqlConnection sqlConnect = Connection.GetConnection())
            {
                // projet forfait
                using (SqlCommand sqlCde = new SqlCommand())
                {
                    //initialiser la connection de la commande
                    sqlCde.Connection = sqlConnect;
                    string strSql = "UpdCandidat";
                    sqlCde.CommandText = strSql;

                    // Affectation des parametres à la commande
                    AffectParamCde(cd, sqlCde);

                    // ajout du code Candidat en entrée
                    sqlCde.Parameters.Add(new SqlParameter("@idCandidat", SqlDbType.Int)).Value = cd.IdCandidat;

                    // exécution de la requete
                    //========================
                    try
                    {
                        int n = sqlCde.ExecuteNonQuery();
                        if (n != 1)
                            throw new DaoExceptionAfficheMessage("L'opération n'a pas été réalisée");
                        return true;
                    }
                    catch (SqlException se)
                    {
                        throw new DaoExceptionAfficheMessage("La mise à jour n'a pas été réalisée: \n" + se.Message);
                    }
                }
            }
        }


        public static Candidat GetCandidatById(int idCd)
        {

            // création connection
            using (SqlConnection sqlConnect = Connection.GetConnection())
            {

                //
                using (SqlCommand sqlCde = new SqlCommand())
                {
                    //initialiser la connection de la commande
                    sqlCde.Connection = sqlConnect;
                    // chargement des qualifications
                    String strSql = "GetCandidatById";
                    sqlCde.CommandText = strSql;
                    sqlCde.CommandType = CommandType.StoredProcedure;
                    sqlCde.Parameters.Add(new SqlParameter("@idCandidat", SqlDbType.Int)).Value = idCd;

                    // Exécution de la commande
                    try
                    {
                        SqlDataReader sqlRdr = sqlCde.ExecuteReader();
                        Candidat cd = null;
                        if (sqlRdr.Read())
                        {
                            // Pole null ?
                            PoleEmbauche oPoleEmbauche = null;
                            if (!sqlRdr.IsDBNull(1)) oPoleEmbauche = new PoleEmbauche()
                            {
                                 IdPole=sqlRdr.GetInt32(1)
                            };
                            // Situation familiale
                            SituationFamiliale oSituFam = new SituationFamiliale()
                            {
                                  IdSituF= Convert.ToSByte(sqlRdr[0])
                            };

                            // Création objet
                            cd = new Candidat()
                            {
                                IdCandidat = idCd,
                                SituationF = oSituFam,
                                PoleRattachement = oPoleEmbauche,
                                Nom = sqlRdr[2].ToString(),
                                Prenom = sqlRdr[3].ToString(),
                                DateNaissance = sqlRdr.GetDateTime(4),
                                Telephone = sqlRdr[5].ToString(),
                                AdresseMail = sqlRdr[6].ToString(),
                                SituationProfess = sqlRdr.GetBoolean(7),
                                Mobilite = sqlRdr.GetBoolean(8),
                            };
                        }
                        sqlRdr.Close();

                        return cd;
                    }
                    catch (SqlException se)
                    {
                        throw new DaoExceptionFinAppli("Lecture Candidat impossible \n" + se.Message, se);
                    }
                }
            }
        }


        public static Candidat GetAllCandidats()
        {

            // création connection
            using (SqlConnection sqlConnect = Connection.GetConnection())
            {

                using (SqlCommand sqlCde = new SqlCommand())
                {
                    //initialiser la connection de la commande
                    sqlCde.Connection = sqlConnect;
                    // chargement des qualifications
                    String strSql = "GetAllCandidat";
                    sqlCde.CommandText = strSql;
                    sqlCde.CommandType = CommandType.StoredProcedure;

                    // Exécution de la commande
                    try
                    {
                        SqlDataReader sqlRdr = sqlCde.ExecuteReader();
                        Candidat cd = null;
                        if (sqlRdr.Read())
                        {
                            // Pole null ?
                            PoleEmbauche oPoleEmbauche = null;
                            if (!sqlRdr.IsDBNull(1)) oPoleEmbauche = new PoleEmbauche()
                            {
                                IdPole = sqlRdr.GetInt32(1)
                            };
                            // Situation familiale
                            SituationFamiliale oSituFam = new SituationFamiliale()
                            {
                                IdSituF = Convert.ToSByte(sqlRdr[0])
                            };

                            // Création objet
                            cd = new Candidat()
                            {
                                IdCandidat = sqlRdr.GetInt32(9),
                                SituationF = oSituFam,
                                PoleRattachement = oPoleEmbauche,
                                Nom = sqlRdr[2].ToString(),
                                Prenom = sqlRdr[3].ToString(),
                                DateNaissance = sqlRdr.GetDateTime(4),
                                Telephone = sqlRdr[5].ToString(),
                                AdresseMail = sqlRdr[6].ToString(),
                                SituationProfess = sqlRdr.GetBoolean(7),
                                Mobilite = sqlRdr.GetBoolean(8)
                            };
                        }
                        sqlRdr.Close();

                        return cd;
                    }
                    catch (SqlException se)
                    {
                        throw new DaoExceptionFinAppli("Lecture Candidat impossible \n" + se.Message, se);
                    }
                }
            }
        }

    }
}
