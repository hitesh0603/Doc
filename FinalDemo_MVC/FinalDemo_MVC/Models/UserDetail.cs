using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using FinalDemo_MVC.Helperservices;
using System.ComponentModel.DataAnnotations;

namespace FinalDemo_MVC.Models
{
    public class UserDetail
    {
        public SqlConnection con = new SqlConnection();

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailId { get; set; }
        public string Password { get; set; }
        public string Contactno { get; set; }
        public bool RememberMe { get; set; }
        public int userid { get; set; }

        public void Connection()
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString;
            con.Open();
        }


        public bool isuservalid(string _Emailid, string _password)
        {
            bool isValid = false;
            Connection();
            SqlCommand cmd = new SqlCommand("select * from signup_document", con);
            //cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@EmailId", _Emailid);
            //cmd.Parameters.AddWithValue("@Loginpassword", detailEncode.Encodedata(_password));
            var reader = cmd.ExecuteReader();


            while (reader.Read())
            {
                if (_Emailid == Convert.ToString(reader["EmailId"]) && detailEncode.Encodedata(_password) ==  Convert.ToString(reader["Loginpassword"]))
                {
                    userid = Convert.ToInt32(reader[0]);
                    isValid = true;
                }

            }
            //reader.Dispose();
            //cmd.Dispose();

            return isValid;
        }

        public void usersignup(string _firstName, string _lastName, string _emailId, string _password, string _contactno)
        {
            Connection();
            SqlCommand cmd = new SqlCommand("sp_userRegistration", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Firstname", _firstName);
            cmd.Parameters.AddWithValue("@Lastname", _lastName);
            cmd.Parameters.AddWithValue("@EmailId", _emailId);
            cmd.Parameters.AddWithValue("@Loginpassword", detailEncode.Encodedata(_password));
            cmd.Parameters.AddWithValue("@Contactno", _contactno);
            cmd.ExecuteNonQuery();
            con.Close();
        }

    }
}
