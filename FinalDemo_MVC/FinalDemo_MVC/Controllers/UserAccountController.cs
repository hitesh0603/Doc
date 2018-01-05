using FinalDemo_MVC.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;

namespace FinalDemo_MVC.Controllers
{
    public class UserAccountController : Controller
    {

        SqlConnection con = new SqlConnection();

        // GET: UserAccount
        public ActionResult Index()
        {
            return View();
        }


        /// <summary>
        /// Connecct to database
        /// </summary>
        private void connection()
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString;

        }

        /// <summary>
        /// Sign Up Page
        /// </summary>
        /// <returns></returns>
        public ActionResult UserRegistration()
        {
            return View();
        }


        /// <summary>
        /// Submit detail
        /// </summary>
        /// <param name="user">Model</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult UserRegistration(UserDetail user)
        {
            user.usersignup(user.FirstName, user.LastName, user.EmailId, user.Password, user.Contactno);
            return View();
        }

        /// <summary>
        /// Login Page
        /// </summary>
        /// <returns></returns>
        public ActionResult Userlogin(UserDetail user)
        {
            return View();
        }

        public ActionResult userlogout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Userlogin", "UserAccount");

        }


        /// <summary>
        /// Validating Detail
        /// </summary>
        /// <param name="user">Model</param>
        /// <returns></returns>
        [HttpPost]
        [ActionName("Userlogin")]
        public ActionResult loginValidation(UserDetail user)
        {
            if (ModelState.IsValid)
            {
                if (user.isuservalid(user.EmailId, user.Password))
                {
                    Session["userid"] = user.userid;
                    FormsAuthentication.SetAuthCookie(user.EmailId, false);
                    return RedirectToAction("UploadDocument");
                }
                else
                {
                    ViewBag.Message = "Fail";
                    ModelState.AddModelError("", "Login data is incorrect!");
                }
            }
            ViewBag.Message = "Fail";
            return View(user);
        }


        /// <summary>
        /// Show All Your Docments 
        /// </summary>
        /// <returns></returns>
        public ActionResult UploadDocument()
        {
            ViewBag.Message = "Success";
            userdocument user = new userdocument();
            List<userdocument> userlist = new List<userdocument>();

            userlist = user.showdoc(Convert.ToInt32(Session["userid"]));
            ViewData["userdata"] = userlist;
            return View();
        }




        /// <summary>
        /// Particular document page
        /// </summary>
        /// <returns></returns>
        public ActionResult PancardDoc()
        {
            ViewBag.Message = "Success";
            return View();
        }

        /// <summary>
        /// upload documnets
        /// </summary>
        /// <param name="user">model parameter</param>
        /// <returns></returns>
        [HttpPost]
        [ActionName("PancardDoc")]
        public ActionResult PancardDoc(userdocument user)
        {
            connection();
            SqlCommand cmd = new SqlCommand("sp_Uploaduserocument", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            //if (user.Cardno != null)
            //{
                cmd.Parameters.AddWithValue("@userid", Convert.ToString(Session["userid"]));
                cmd.Parameters.AddWithValue("@Documetname", user.Documetname);
                cmd.Parameters.AddWithValue("@Cardno", user.Cardno);
                cmd.Parameters.AddWithValue("@Createdate", user.Createdate);
                cmd.Parameters.AddWithValue("@Expirydate", user.expirydate);

                if (System.Web.HttpContext.Current.Request.Files.AllKeys.Any())
                {
                    var pic = System.Web.HttpContext.Current.Request.Files["HelpSectionImages"];
                    cmd.Parameters.AddWithValue("@ImgFileName", pic.FileName);
                    cmd.Parameters.AddWithValue("@imgType", pic.ContentType);
                    cmd.Parameters.AddWithValue("@imgContentLength", pic.ContentLength);
                    cmd.Parameters.AddWithValue("@imgInputStream", pic.InputStream);
                }

                cmd.ExecuteNonQuery();
                con.Close();
                return RedirectToAction("UploadDocument");
            //}
            //else
            //{
            //    return View(user);
            //}

        }


        public ActionResult ViewImage(userdocument user)
        {
            ViewBag.Message = "Success";
            
            connection();
            con.Open();

            SqlCommand cmd = new SqlCommand("select * from user_documetlist", con);
            SqlDataReader reader = cmd.ExecuteReader();

            //SqlCommand cmd = new SqlCommand("sp_ViewImage", con);
            //cmd.CommandType = CommandType.StoredProcedure;
            //SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                if (Convert.ToInt32(Session["userid"]) == Convert.ToInt32(reader["userid"]))
                {

                    byte[] binaryString = (byte[])reader["imgInputStream"];
                    MemoryStream ms = new MemoryStream();
                    ms.Write(binaryString,0, binaryString.Length);
                    
                    user = new userdocument();
                    //user.docimage = Encoding.UTF8.GetString(binaryString);
                    string base64 = Convert.ToBase64String(ms.ToArray());
                    var imgsrc = String.Format("data:image/png;base64, {0}", base64);
                    ViewData["imgpath"] = imgsrc;
                }
            }
            return View(user);
        }

        public ActionResult DeleteDocument(int id)
        {
            connection();
            con.Open();
            SqlCommand cmd = new SqlCommand("Delete from user_documetlist where Userdocno =" + id, con);
            cmd.ExecuteScalar();
            return RedirectToAction("UploadDocument");
        }


        public ActionResult UpdateDocument(userdocument user)
        {
            return View(user);
        }
    }
}
