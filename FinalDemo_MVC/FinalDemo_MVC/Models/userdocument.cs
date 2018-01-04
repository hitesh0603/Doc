using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FinalDemo_MVC.Models
{
    public enum DocumentsName
    {
        PanCard,
        Passport,
        DrivingLicence,
        AadharCard,
        CollegeId,
        CompanyId
    }

    public class userdocument
    {

        public SqlConnection con = new SqlConnection();
        public List<userdocument> userdoc = new List<userdocument>();

        public int userid { get; set; }
        public string Documetname { get; set; }
        public string Cardno { get; set; }
        public string Createdate { get; set; }
        public string expirydate { get; set; }
        public int userdocno { get; set; }
        public byte[] docimage { get; set; }

        userdocument user = null;

        public void connection()
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString;
            con.Open();
        }

        public List<userdocument> showdoc(int id)
        {
            connection();
            SqlCommand cmd = new SqlCommand("select * from user_documetlist", con);
            SqlDataReader reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                if(id == Convert.ToInt32(reader[1]))
                {
                    user = new userdocument();
                    user.userdocno = Convert.ToInt32(reader[0]);
                    user.Documetname = Convert.ToString(reader.GetSqlValue(2)) ;
                    //DocumentsName Documetname = (DocumentsName)Enum.ToObject(typeof(DocumentsName), Convert.ToString(reader.GetSqlValue(2))) ;
                    user.Cardno = Convert.ToString(reader.GetSqlValue(3));
                    user.Createdate = Convert.ToString(reader.GetSqlValue(4));
                    user.expirydate = Convert.ToString(reader.GetSqlValue(5));
                    userdoc.Add(user);
                }
            }
            return userdoc;
        }

    }
}