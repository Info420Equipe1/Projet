using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace TexcelWeb.Classes
{
    public class CtrlController
    {
        protected static dbProjetE1Entities context = new dbProjetE1Entities();
        protected static Utilisateur CurrentUtilisateur;

        public static void openConnection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["context"].ConnectionString;
            var builder = new SqlConnectionStringBuilder(connectionString);
            builder.Password = "Jambon15";
            connectionString = builder.ConnectionString;
            //dbContext.Database.Connection.ConnectionString = connectionString;
            //dbContext.SaveChanges();
            //dbContext.Database.Connection.Close();
        }
    }
}