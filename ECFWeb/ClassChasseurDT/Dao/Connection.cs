using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using System.Data;
using System.Configuration;

using ClassChasseurDT.Metier;
using ClassChasseurDT.Exceptions;

namespace ClassChasseurDT.Dao
{
    public class Connection
    {
        public static SqlConnection GetConnection()
        {
            // creation de la connection
            SqlConnection sqlConnect = new SqlConnection();
            ConnectionStringSettings oConfig = ConfigurationManager.ConnectionStrings["ConChasseur"];
            // ConnectionStringSettings oConfig = ConfigurationManager.ConnectionStrings["ConGest"];

            // affectation de la chaine de connection extraite
            if (oConfig == null) // chaine de connexion non trouvée
                throw new DaoExceptionFinAppli("La base est inaccessible, l'appplication va se fermer, recommencez ultérieurement: \n" + "La chaine de connexion est introuvable");
            else
            {
                sqlConnect.ConnectionString = oConfig.ConnectionString;
                try
                {
                    // Ouvre la connection.
                    sqlConnect.Open();
                    return sqlConnect;
                }
                catch (SqlException se)
                {
                    throw new DaoExceptionFinAppli("La base est inaccessible, l'appplication va se fermer, recommencez ultérieurement : \n" + se.Message, se);
                }
            }

        }
    }
}
