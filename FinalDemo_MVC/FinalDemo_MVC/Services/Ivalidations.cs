using FinalDemo_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalDemo_MVC.Services
{
    public interface Ivalidations
    {
        bool isuservalid(string _Emailid, string _password);

        void usersignup(string _firstName, string _lastName, string _emailId, string _password, string _contactno);

        void DeleteData(int id);

        List<userdocument> showdoc(int id);
    }
}
