using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ServiceEnchere_NB.Utils
{
    public static class DBUtil
    {
        public static SqlConnection GetGestionEnchereDBConnection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;

            return new SqlConnection(connectionString);
        }

    }
}