using FinalDemo_MVC.Helperservices;
using FinalDemo_MVC.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FinalDemo_MVC.Services
{
    public class validations : Ivalidations
    {
        UserDetail user = new UserDetail();
        DatabaseConnection dbcon = new DatabaseConnection();
        public List<userdocument> userdoc = new List<userdocument>();
        public bool isuservalid(string _Emailid, string _password)
        {
            bool isValid = false;
            dbcon.Connection();
            SqlCommand cmd = new SqlCommand("select * from signup_document", dbcon.con);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                if (_Emailid == Convert.ToString(reader["EmailId"]) && detailEncode.Encodedata(_password) == Convert.ToString(reader["Loginpassword"]))
                {
                    user.userid = Convert.ToInt32(reader["userid"]);
                    isValid = true;
                }
            }
            return isValid;
        }


        public void usersignup(string _firstName, string _lastName, string _emailId, string _password, string _contactno)
        {
            dbcon.Connection();
            SqlCommand cmd = new SqlCommand("sp_userRegistration", dbcon.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Firstname", _firstName);
            cmd.Parameters.AddWithValue("@Lastname", _lastName);
            cmd.Parameters.AddWithValue("@EmailId", _emailId);
            cmd.Parameters.AddWithValue("@Loginpassword", detailEncode.Encodedata(_password));
            cmd.Parameters.AddWithValue("@Contactno", _contactno);
            cmd.ExecuteNonQuery();
            dbcon.con.Close();
        }


        public void DeleteData(int id)
        {
            dbcon.Connection();
            dbcon.con.Open();
            SqlCommand cmd = new SqlCommand("Delete from user_documetlist where Userdocno =" + id, dbcon.con);
            cmd.ExecuteScalar();
        }

        public List<userdocument> showdoc(int id)
        {
            dbcon.Connection();
            SqlCommand cmd = new SqlCommand("select * from user_documetlist", dbcon.con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                if (id == Convert.ToInt32(reader["userid"]))
                {
                    userdocument user = new userdocument();
                    user.userdocno = Convert.ToInt32(reader["Userdocno"]);
                    user.Documetname = Convert.ToString(reader["Documetname"]);
                    //DocumentsName Documetname = (DocumentsName)Enum.ToObject(typeof(DocumentsName), Convert.ToString(reader.GetSqlValue(2))) ;
                    user.Cardno = Convert.ToString(reader["Cardno"]);
                    user.Createdate = Convert.ToString(reader["Createdate"]);
                    user.expirydate = Convert.ToString(reader["Expirydate"]);
                    userdoc.Add(user);
                }
            }
            return userdoc;
        }
    }
}
