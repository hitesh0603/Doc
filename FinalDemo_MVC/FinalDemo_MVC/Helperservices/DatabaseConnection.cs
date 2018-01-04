using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FinalDemo_MVC.Helperservices
{
    public class DatabaseConnection
    {
        public SqlConnection con = new SqlConnection();

        public void Connection()
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString;
            con.Open();
        }
    }
}