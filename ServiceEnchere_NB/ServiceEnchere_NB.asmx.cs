using GestionEnchereClassLibrary.Model;
using ServiceEnchere_NB.Utils;
using System;
using System.Data;
using System.Data.SqlClient;
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
        #region Sauvegarder

        [WebMethod]
        public BO_Enchere SauvegarderDemandeCreationEnchere(BO_DemandeCreationEnchere pDemandeCreationEnchere)
        {
            BO_Enchere enchere = new BO_Enchere();
            try
            {
                using (SqlConnection sqlConn = DBUtil.GetGestionEnchereDBConnection())
                {
                    // insert a request
                    string aCommand = "INSERT INTO " +
                        "dbo.DemandeCreationEnchere(IdUtilisateur_Vendeur, NomEnchere, PrixMinimum, OptionTransport, Duree, TypeEnchere, Categorie, MotsCles, AutresInformations) " +
                        "VALUES(@IdUtilisateur_Vendeur, @NomEnchere, @PrixMinimum, @OptionTransport, @Duree, @TypeEnchere, @Categorie, @MotsCles, @AutresInformations) " +
                        "SELECT SCOPE_IDENTITY();";
                    SqlCommand insertComm = new SqlCommand(aCommand);
                    insertComm.Connection = sqlConn;
                    SqlParameter[] sp = new SqlParameter[9];

                    sp[0] = new SqlParameter("@IdUtilisateur_Vendeur", SqlDbType.Int);
                    sp[0].Value = pDemandeCreationEnchere.IdUtilisateur_Vendeur;

                    sp[1] = new SqlParameter("@NomEnchere", SqlDbType.VarChar, 100);
                    sp[1].Value = pDemandeCreationEnchere.NomEnchere;

                    sp[2] = new SqlParameter("@PrixMinimum", SqlDbType.Decimal);
                    sp[2].Precision = 18; sp[2].Scale = 2;
                    sp[2].Value = pDemandeCreationEnchere.PrixMinimum;

                    sp[3] = new SqlParameter("@OptionTransport", SqlDbType.VarChar, 100);
                    sp[3].Value = pDemandeCreationEnchere.OptionTransport;

                    sp[4] = new SqlParameter("@Duree", SqlDbType.Int);
                    sp[4].Value = pDemandeCreationEnchere.Duree;

                    sp[5] = new SqlParameter("@TypeEnchere", SqlDbType.VarChar, 100);
                    sp[5].Value = pDemandeCreationEnchere.TypeEnchere;

                    sp[6] = new SqlParameter("@Categorie", SqlDbType.VarChar, 100);
                    sp[6].Value = pDemandeCreationEnchere.Categorie;

                    sp[7] = new SqlParameter("@MotsCles", SqlDbType.VarChar, 250);
                    sp[7].Value = pDemandeCreationEnchere.MotsCles;

                    sp[8] = new SqlParameter("@AutresInformations", SqlDbType.VarChar, 250);
                    sp[8].Value = pDemandeCreationEnchere.AutresInformations;

                    insertComm.Parameters.AddRange(sp);
                    if (sqlConn.State == ConnectionState.Closed)
                    {
                        sqlConn.Open();
                    }

                    enchere.IdEnchere = Convert.ToInt32(insertComm.ExecuteScalar());
                    enchere.IdEnchere = (enchere.IdEnchere <= 0) ? 0 : enchere.IdEnchere;
                    enchere.DemandeCreationEnchere = pDemandeCreationEnchere;
                }
            }
            catch (Exception ex)
            {
                return enchere;
            }
            return enchere;
        }

        [WebMethod]
        public bool SauvegarderEncherissement(BO_Encherissement pEncherissement)
        {
            bool result = false;
            try
            {
                using (SqlConnection sqlConn = DBUtil.GetGestionEnchereDBConnection())
                {
                    // insert a request
                    string aCommand = "INSERT INTO " +
                        "dbo.Encherissement(IdUtilisateur_Encherisseur, IdEnchere, OffreMaximale) " +
                        "VALUES(@IdUtilisateur_Encherisseur, @IdEnchere, @OffreMaximale) " +
                        "SELECT SCOPE_IDENTITY();";
                    SqlCommand insertComm = new SqlCommand(aCommand);
                    insertComm.Connection = sqlConn;
                    SqlParameter[] sp = new SqlParameter[3];

                    sp[0] = new SqlParameter("@IdUtilisateur_Encherisseur", SqlDbType.Int);
                    sp[0].Value = pEncherissement.IdUtilisateur_Encherisseur;

                    sp[1] = new SqlParameter("@IdEnchere", SqlDbType.Int);
                    sp[1].Value = pEncherissement.IdEnchere;

                    sp[2] = new SqlParameter("@OffreMaximale", SqlDbType.Int);
                    sp[2].Value = pEncherissement.OffreMaximale;

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
        public bool BannirEncherisseurGagnant(int pIdUtilisateur_EncherisseurGagnant)
        {
            bool result = false;
            try
            {
                using (SqlConnection sqlConn = DBUtil.GetGestionEnchereDBConnection())
                {
                    // insert a request
                    string aCommand = "UPDATE dbo.Utilisateur " +
                        "SET Banni = @Banni " +
                        "WHERE ID = @IdUtilisateur ";
                    SqlCommand insertComm = new SqlCommand(aCommand);
                    insertComm.Connection = sqlConn;
                    SqlParameter[] sp = new SqlParameter[2];

                    sp[0] = new SqlParameter("@Banni", SqlDbType.Bit);
                    sp[0].Value = true;

                    sp[1] = new SqlParameter("@IdUtilisateur", SqlDbType.Int);
                    sp[1].Value = pIdUtilisateur_EncherisseurGagnant;

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
        public bool SauvegarderInfosPaiement(BO_Paiement pPaiement)
        {
            bool result = false;
            try
            {
                using (SqlConnection sqlConn = DBUtil.GetGestionEnchereDBConnection())
                {
                    // insert a request
                    string aCommand = "INSERT INTO " +
                        "dbo.InfosPaiement(IdEnchere, InfosPaiement)" +
                        "VALUES(@IdEnchere, @InfosPaiement)";
                    SqlCommand insertComm = new SqlCommand(aCommand);
                    insertComm.Connection = sqlConn;
                    SqlParameter[] sp = new SqlParameter[2];

                    sp[0] = new SqlParameter("@IdEnchere", SqlDbType.Int);
                    sp[0].Value = pPaiement.IdEnchere;

                    sp[1] = new SqlParameter("@InfosPaiement", SqlDbType.VarChar);
                    sp[1].Value = pPaiement.InfosPaiement;

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
        public bool SauvegarderEvaluation(BO_Evaluation pEvaluation)
        {
            bool result = false;
            try
            {
                using (SqlConnection sqlConn = DBUtil.GetGestionEnchereDBConnection())
                {
                    // insert a request
                    string aCommand = "INSERT INTO " +
                        "dbo.EvaluationTransaction(IdEnchere, IdUtilisateur, EvaluationGlobale, Message, FonctionnementProduit) " +
                        "VALUES(@IdEnchere, @IdUtilisateur, @EvaluationGlobale, @Message, @FonctionnementProduit)";
                    SqlCommand insertComm = new SqlCommand(aCommand);
                    insertComm.Connection = sqlConn;
                    SqlParameter[] sp = new SqlParameter[5];

                    sp[0] = new SqlParameter("@IdEnchere", SqlDbType.Int);
                    sp[0].Value = pEvaluation.IdEnchere;

                    sp[1] = new SqlParameter("@IdUtilisateur", SqlDbType.Int);
                    sp[1].Value = pEvaluation.IdUtilisateur;

                    sp[2] = new SqlParameter("@EvaluationGlobale", SqlDbType.Bit);
                    sp[2].Value = pEvaluation.EvaluationGlobale;

                    sp[3] = new SqlParameter("@Message", SqlDbType.VarChar, 250);
                    sp[3].Value = pEvaluation.Message;

                    sp[4] = new SqlParameter("@FonctionnementProduit", SqlDbType.VarChar, 250);
                    sp[4].Value = pEvaluation.FonctionnementProduit;


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
        public bool BannirVendeur(int pIdUtilisateur_Vendeur)
        {
            bool result = false;
            try
            {
                using (SqlConnection sqlConn = DBUtil.GetGestionEnchereDBConnection())
                {
                    // insert a request
                    string aCommand = "UPDATE dbo.Utilisateur " +
                        "SET Banni = @Banni " +
                        "WHERE ID = @IdUtilisateur ";
                    SqlCommand insertComm = new SqlCommand(aCommand);
                    insertComm.Connection = sqlConn;
                    SqlParameter[] sp = new SqlParameter[2];

                    sp[0] = new SqlParameter("@Banni", SqlDbType.Bit);
                    sp[0].Value = true;

                    sp[1] = new SqlParameter("@IdUtilisateur", SqlDbType.Int);
                    sp[1].Value = pIdUtilisateur_Vendeur;

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

        #endregion

        #region Recuperer
        [WebMethod]
        public BO_EncherissementGagnant RecupererEncherissementGagnant(int idEnchere)
        {
            BO_EncherissementGagnant encherissementGagnant = new BO_EncherissementGagnant();
            try
            {
                using (SqlConnection sqlConn = DBUtil.GetGestionEnchereDBConnection())
                {
                    // insert a request
                    string aCommand = "SELECT TOP 1 dce.ID, ue.ID, e.OffreMaximale, uv.ID, uv.NomUtilisateur, uv.Courriel, ue.ID, ue.NomUtilisateur, ue.Courriel " +
                        "FROM dbo.Encherissement as e " +
                        "JOIN dbo.DemandeCreationEnchere as dce on dce.ID = e.IdEnchere " +
                        "JOIN dbo.Utilisateur as ue on e.IdUtilisateur_Encherisseur = ue.IdUtilisateur " +
                        "JOIN dbo.Utilisateur as uv on dce.IdUtilisateur_Vendeur = uv.IdUtilisateur " +
                        "WHERE e.IdEnchere = @IdEnchere " +
                        "AND ue.banni = @Banni " +
                        "ORDER BY e.OffreMaximale desc";
                    SqlCommand insertComm = new SqlCommand(aCommand);
                    insertComm.Connection = sqlConn;
                    SqlParameter[] sp = new SqlParameter[2];

                    sp[0] = new SqlParameter("@IdEnchere", SqlDbType.Int);
                    sp[0].Value = idEnchere;

                    sp[1] = new SqlParameter("@Banni", SqlDbType.Bit);
                    sp[1].Value = false;

                    insertComm.Parameters.AddRange(sp);
                    if (sqlConn.State == ConnectionState.Closed)
                    {
                        sqlConn.Open();
                    }

                    SqlDataReader reader =  insertComm.ExecuteReader();
                    if (reader.Read())
                    {
                        encherissementGagnant.Encherissement = new BO_Encherissement()
                        {
                            IdEnchere = reader.GetInt32(0),
                            IdUtilisateur_Encherisseur = reader.GetInt32(1),
                            OffreMaximale = reader.GetDecimal(2)
                        };
                        encherissementGagnant.Utilisateur_Vendeur = new BO_Utilisateur()
                        {
                            IdUtilisateur = reader.GetInt32(3),
                            NomUtilisateur = reader.GetString(4),
                            Courriel = reader.GetString(5)
                        };
                        encherissementGagnant.Utilisateur_EncherisseurGagnant = new BO_Utilisateur()
                        {
                            IdUtilisateur = reader.GetInt32(6),
                            NomUtilisateur = reader.GetString(7),
                            Courriel = reader.GetString(8)
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                return encherissementGagnant;
            }
            return encherissementGagnant;
        }
        #endregion
    }
}
