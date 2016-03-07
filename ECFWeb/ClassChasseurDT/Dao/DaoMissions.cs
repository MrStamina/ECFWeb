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
    public class DaoMissions
    {
        public static List<Mission> GetAllMissionsByEnt(int idEnt)
        {

            // création connection
            using (SqlConnection sqlConnect = Connection.GetConnection())
            {
                List<Mission> lstMissions = new List<Mission>();
                using (SqlCommand sqlCde = new SqlCommand())
                {
                    //initialiser la connection de la commande
                    sqlCde.Connection = sqlConnect;
                    // chargement des qualifications
                    String strSql = "GetAllMissionsByEnt";
                    sqlCde.CommandText = strSql;
                    sqlCde.CommandType = CommandType.StoredProcedure;
                    sqlCde.Parameters.Add(new SqlParameter("@idEntreprise", SqlDbType.Int)).Value = idEnt;

                    // Exécution de la commande
                    try
                    {
                        SqlDataReader sqlRdr = sqlCde.ExecuteReader();
                        Mission oMission = null;
                        while (sqlRdr.Read())
                        {
                            // Qualification
                            Qualification oQualif = new Qualification()
                            {
                                IdQualification= sqlRdr.GetInt32(2),
                                LibelleQualification=sqlRdr[10].ToString()
                            };
                            // Entreprise 
                            Entreprise oEntreprise = new Entreprise()
                            {
                                IdEntreprise = idEnt
                            };
                            // Niveau null ?
                            Niveau oNiveau = null;
                            if (!sqlRdr.IsDBNull(3))oNiveau= new Niveau()
                            {
                                IdNiveau = Convert.ToSByte(sqlRdr[3]),
                                Libelle=sqlRdr[11].ToString()
                            };
                            // consultant
                            Consultant oConsultant = new Consultant()
                            {
                                IdConsultant = Convert.ToSByte(sqlRdr[4])
                            };
                            // date fin null ?
                            DateTime? df;
                            if (!sqlRdr.IsDBNull(6)) df = sqlRdr.GetDateTime(6);
                            else df = null;
                            // Motif Null ?
                            MotifFin oMotif = null;
                            if (!sqlRdr.IsDBNull(1)) oMotif = new MotifFin()
                             {
                                 IdMotif = Convert.ToSByte(sqlRdr[1])
                             };
                            // Remuneration proposée Null?
                            Decimal? remu;
                            if (!sqlRdr.IsDBNull(7)) remu = sqlRdr.GetDecimal(7);
                            else remu = null;
                            // Duree
                            sbyte? d;
                            if (!sqlRdr.IsDBNull(9)) d = Convert.ToSByte(sqlRdr[9]);
                            else d = null;
                            // Création objet
                            oMission = new Mission()
                            {
                                IdMission = sqlRdr.GetInt32(0),
                                DateOuverture=sqlRdr.GetDateTime(5),
                                Precisions=sqlRdr[8].ToString(),
                                RemunerationProposee=remu,
                                Duree=d,
                                QualificationDemandee=oQualif,
                                EntrepriseOffre=oEntreprise,
                                NiveauDemande=oNiveau,
                                Consult=oConsultant,
                                DateFin=df,
                                Motif=oMotif
                            };
                            lstMissions.Add(oMission);
                        }
                        sqlRdr.Close();

                        return lstMissions;
                    }
                    catch (SqlException se)
                    {
                        throw new DaoExceptionFinAppli("Lecture Mission impossible \n" + se.Message, se);
                    }
                }
            }
        }
    }
}
