using ServiceEnchere_NB.Objects;
using ServiceEnchere_NB.Utils;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace ServiceEnchere_NB
{
    /// <summary>
    /// Description résumée de ServiceEnchere_NB
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Pour autoriser l'appel de ce service Web depuis un script à l'aide d'ASP.NET AJAX, supprimez les marques de commentaire de la ligne suivante. 
    // [System.Web.Script.Services.ScriptService]
    public class ServiceEnchere_NB : System.Web.Services.WebService
    {

        [WebMethod]
        public int? SauvegarderDemandeCreationEnchere(DemandeCreationEnchere pDemandeCreationEnchere)
        {
            int? idEnchere = null;
            try
            {
                using (SqlConnection sqlConn = DBUtil.GetGestionEnchereDBConnection())
                {
                    // insert a request
                    string aCommand = "INSERT INTO " +
                        "dbo.DemandeCreationEnchere(NomEnchere, PrixMinimum, OptionTransport, Duree, TypeEnchere, Categorie, MotsCles, AutresInformations)" +
                        "VALUES(@NomEnchere, @PrixMinimum, @OptionTransport, @Duree, @TypeEnchere, @Categorie, @MotsCles, @AutresInformations)" +
                        "SELECT SCOPE_IDENTITY();";
                    SqlCommand insertComm = new SqlCommand(aCommand);
                    insertComm.Connection = sqlConn;
                    SqlParameter[] sp = new SqlParameter[8];

                    sp[0] = new SqlParameter("@NomEnchere", SqlDbType.VarChar, 100);
                    sp[0].Value = pDemandeCreationEnchere.NomEnchere;

                    sp[1] = new SqlParameter("@PrixMinimum", SqlDbType.Decimal);
                    sp[1].Precision = 18; sp[2].Scale = 2;
                    sp[1].Value = pDemandeCreationEnchere.PrixMinimum;

                    sp[2] = new SqlParameter("@OptionTransport", SqlDbType.VarChar, 100);
                    sp[2].Value = pDemandeCreationEnchere.OptionTransport;

                    sp[3] = new SqlParameter("@Duree", SqlDbType.Int);
                    sp[3].Value = pDemandeCreationEnchere.Duree;

                    sp[4] = new SqlParameter("@TypeEnchere", SqlDbType.VarChar, 100);
                    sp[4].Value = pDemandeCreationEnchere.TypeEnchere;

                    sp[5] = new SqlParameter("@Categorie", SqlDbType.VarChar, 100);
                    sp[5].Value = pDemandeCreationEnchere.Categorie;

                    sp[6] = new SqlParameter("@MotsCles", SqlDbType.VarChar, 250);
                    sp[6].Value = pDemandeCreationEnchere.MotsCles;

                    sp[7] = new SqlParameter("@AutresInformations", SqlDbType.VarChar, 250);
                    sp[7].Value = pDemandeCreationEnchere.AutresInformations;

                    insertComm.Parameters.AddRange(sp);
                    if (sqlConn.State == ConnectionState.Closed)
                    {
                        sqlConn.Open();
                    }

                    idEnchere = (int)insertComm.ExecuteScalar();
                    idEnchere = (idEnchere <= 0) ? null : idEnchere;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return idEnchere;
        }

        [WebMethod]
        public bool SauvegarderEncherissement(Encherissement pEncherissement)
        {
            bool result = false;
            try
            {
                using (SqlConnection sqlConn = DBUtil.GetGestionEnchereDBConnection())
                {
                    // insert a request
                    string aCommand = "INSERT INTO " +
                        "dbo.Encherissement(IdUtilisateur, IdEnchere, OffreMaximale)" +
                        "VALUES(@IdUtilisateur, @IdEnchere, @OffreMaximale)" +
                        "SELECT SCOPE_IDENTITY();";
                    SqlCommand insertComm = new SqlCommand(aCommand);
                    insertComm.Connection = sqlConn;
                    SqlParameter[] sp = new SqlParameter[3];

                    sp[0] = new SqlParameter("@IdUtilisateur", SqlDbType.Int);
                    sp[0].Value = pEncherissement.IdUtilisateur;

                    sp[1] = new SqlParameter("@IdEnchere", SqlDbType.Int);
                    sp[1].Value = pEncherissement.IdUtilisateur;

                    sp[2] = new SqlParameter("@OffreMaximale", SqlDbType.Int);
                    sp[2].Value = pEncherissement.IdUtilisateur;

                    insertComm.Parameters.AddRange(sp);
                    if (sqlConn.State == ConnectionState.Closed)
                    {
                        sqlConn.Open();
                    }

                    result = (insertComm.ExecuteNonQuery() == 1);
                }
            }
            catch (Exception ex)
            {
                return false;
            }

            return result;
        }

        [WebMethod]
        public string BannirEncherisseurGagnant()
        {
            return "Hello World";
        }

        [WebMethod]
        public string SauvegarderInfosPaiement()
        {
            return "Hello World";
        }

        [WebMethod]
        public string InformerVendeurNouveauResultat()
        {
            return "Hello World";
        }

        [WebMethod]
        public string SauvegarderEvaluation()
        {
            return "Hello World";
        }

        [WebMethod]
        public string AffecterEvaluationAgent()
        {
            return "Hello World";
        }

        [WebMethod]
        public string BannirVendeur()
        {
            return "Hello World";
        }
    }
}
