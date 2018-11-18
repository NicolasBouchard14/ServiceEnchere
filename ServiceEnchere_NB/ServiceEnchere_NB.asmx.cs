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
        public bool SauvegarderDemandeCreationEnchere(DemandeCreationEnchere demandeCreationEnchere)
        {
            try
            {
                using (SqlConnection sqlConn = DBUtil.GetGestionEnchereDBConnection())
                {
                    // insert a request
                    string aCommand = "INSERT INTO " + 
                        "dbo.DemandeCreationEnchere(IdEnchere, NomEnchere, PrixMinimum, OptionTransport, Duree, TypeEnchere, Categorie, MotsCles, AutresInformations)" +
                        "VALUES(@IdEnchere, @NomEnchere, @PrixMinimum, @OptionTransport, @Duree, @TypeEnchere, @Categorie, @MotsCles, @AutresInformations)";
                    SqlCommand insertComm = new SqlCommand(aCommand);
                    insertComm.Connection = sqlConn;
                    SqlParameter[] sp = new SqlParameter[9];

                    sp[0] = new SqlParameter("@IdEnchere", SqlDbType.UniqueIdentifier);
                    sp[0].Value = new Guid();

                    sp[1] = new SqlParameter("@NomEnchere", SqlDbType.VarChar, 100);
                    sp[1].Value = demandeCreationEnchere.NomEnchere;

                    sp[2] = new SqlParameter("@PrixMinimum", SqlDbType.Decimal);
                    sp[2].Precision = 18; sp[2].Scale = 2;
                    sp[2].Value = demandeCreationEnchere.PrixMinimum;

                    sp[3] = new SqlParameter("@OptionTransport", SqlDbType.VarChar, 100);
                    sp[3].Value = demandeCreationEnchere.OptionTransport;

                    sp[4] = new SqlParameter("@Duree", SqlDbType.Int);
                    sp[4].Value = demandeCreationEnchere.Duree;

                    sp[5] = new SqlParameter("@TypeEnchere", SqlDbType.VarChar, 100);
                    sp[5].Value = demandeCreationEnchere.TypeEnchere;

                    sp[6] = new SqlParameter("@Categorie", SqlDbType.VarChar, 100);
                    sp[6].Value = demandeCreationEnchere.Categorie;

                    sp[7] = new SqlParameter("@MotsCles", SqlDbType.VarChar, 250);
                    sp[7].Value = demandeCreationEnchere.MotsCles;

                    sp[8] = new SqlParameter("@AutresInformations", SqlDbType.VarChar, 250);
                    sp[8].Value = demandeCreationEnchere.AutresInformations;

                    insertComm.Parameters.AddRange(sp);
                    if (sqlConn.State == ConnectionState.Closed)
                    {
                        sqlConn.Open();
                    }
                    insertComm.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        [WebMethod]
        public string SauvegarderEncherissement()
        {
            return "Hello World";
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
