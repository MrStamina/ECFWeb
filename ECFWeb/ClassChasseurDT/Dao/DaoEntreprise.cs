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
    public class DaoEntreprise
    {
        public static int AddEntreprise(Entreprise ent)
        {
            // création connection
            using (SqlConnection sqlConnect = Connection.GetConnection())
            {
                // projet forfait
                using (SqlCommand sqlCde = new SqlCommand())
                {
                    //initialiser la connection de la commande
                    sqlCde.Connection = sqlConnect;
                    string strSql = "AddEntreprise";
                    sqlCde.CommandText = strSql;

                    // Affectation des parametres à la commande
                    AffectParamCde(ent, sqlCde);

                    // ajout du code Entreprise en sortie 
                    SqlParameter pOut = new SqlParameter("@idEntreprise", SqlDbType.Int);
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

        private static void AffectParamCde(Entreprise ent, SqlCommand sqlCde)
        {
            sqlCde.CommandType = CommandType.StoredProcedure;
            sqlCde.Parameters.Clear();
            // affectation des parametres communs 
            sqlCde.Parameters.Add(new SqlParameter("@idActivite", SqlDbType.TinyInt)).Value = ent.SecteurActivite.IdActivite;
            if (ent.PoleRattachement != null)
                sqlCde.Parameters.Add(new SqlParameter("@idPole", SqlDbType.Int)).Value = ent.PoleRattachement.IdPole;
            sqlCde.Parameters.Add(new SqlParameter("@raisonsociale", SqlDbType.VarChar, 50)).Value = ent.RaisonSociale;
            sqlCde.Parameters.Add(new SqlParameter("@adr1", SqlDbType.VarChar, 30)).Value = ent.Adresse1Ent;
            sqlCde.Parameters.Add(new SqlParameter("@adr2", SqlDbType.VarChar, 30)).Value = ent.Adresse2Ent;
            sqlCde.Parameters.Add(new SqlParameter("@cpent", SqlDbType.VarChar, 5)).Value = ent.CpEnt;
            sqlCde.Parameters.Add(new SqlParameter("@villeEnt", SqlDbType.VarChar, 30)).Value = ent.VilleEnt;
            sqlCde.Parameters.Add(new SqlParameter("@cliente", SqlDbType.Bit)).Value = ent.Cliente;
            if (ent.Contact != null)
                sqlCde.Parameters.Add(new SqlParameter("@nomCorresp", SqlDbType.VarChar, 50)).Value = ent.Contact;
            if (ent.TelContact != null)
                sqlCde.Parameters.Add(new SqlParameter("@tel", SqlDbType.VarChar, 20)).Value = ent.TelContact;
            if (ent.MailContact != null)
                sqlCde.Parameters.Add(new SqlParameter("@mail", SqlDbType.VarChar, 30)).Value = ent.MailContact;
            sqlCde.Parameters.Add(new SqlParameter("@datecreation", SqlDbType.Date)).Value = ent.DateCreation;
        }

        public static bool UpdEntreprise(Entreprise ent)
        {
            // création connection
            using (SqlConnection sqlConnect = Connection.GetConnection())
            {
                // projet forfait
                using (SqlCommand sqlCde = new SqlCommand())
                {
                    //initialiser la connection de la commande
                    sqlCde.Connection = sqlConnect;
                    string strSql = "UpdEntreprise";
                    sqlCde.CommandText = strSql;

                    // Affectation des parametres à la commande
                    AffectParamCde(ent, sqlCde);

                    // ajout du code Entreprise en entrée
                    sqlCde.Parameters.Add(new SqlParameter("@idEntreprise", SqlDbType.Int)).Value = ent.IdEntreprise;

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


        public static Entreprise GetEntrepriseById(int idEnt)
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
                    String strSql = "GetEntrepriseById";
                    sqlCde.CommandText = strSql;
                    sqlCde.CommandType = CommandType.StoredProcedure;
                    sqlCde.Parameters.Add(new SqlParameter("@idEntreprise", SqlDbType.Int)).Value = idEnt;

                    // Exécution de la commande
                    try
                    {
                        SqlDataReader sqlRdr = sqlCde.ExecuteReader();
                        Entreprise cd = null;
                        if (sqlRdr.Read())
                        {
                            // Pole null ?
                            PoleEmbauche oPoleEmbauche = null;
                            if (!sqlRdr.IsDBNull(1)) oPoleEmbauche = new PoleEmbauche()
                            {
                                IdPole = sqlRdr.GetInt32(1)
                            };
                            // Secteur d'activite
                            Activite oActivite = new Activite()
                            {
                                 IdActivite= Convert.ToSByte(sqlRdr[0])
                            };

                            // Création objet
                            cd = new Entreprise()
                            {
                                IdEntreprise = idEnt,
                                RaisonSociale= sqlRdr[2].ToString(),
                                Adresse1Ent = sqlRdr[3].ToString(),
                                Adresse2Ent = sqlRdr[4].ToString(),
                                CpEnt = sqlRdr[5].ToString(),
                                VilleEnt =sqlRdr[6].ToString(),
                                Cliente = sqlRdr.GetBoolean(7),
                                Contact = sqlRdr[8].ToString(),
                                TelContact = sqlRdr[9].ToString(),
                                MailContact = sqlRdr[10].ToString(),
                                DateCreation=sqlRdr.GetDateTime(11),
                                SecteurActivite=oActivite,
                                PoleRattachement = oPoleEmbauche
                            };
                        }
                        sqlRdr.Close();

                        return cd;
                    }
                    catch (SqlException se)
                    {
                        throw new DaoExceptionFinAppli("Lecture Entreprise impossible \n" + se.Message, se);
                    }
                }
            }
        }


       

    }
}
