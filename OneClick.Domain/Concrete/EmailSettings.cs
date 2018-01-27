using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneClick.Domain.Concrete
{
    public class EmailSettings
    {
        public string MailToAddress = "www.emonykim@gmail.com";
        public string MailFromAddress = "www.emonykim@gmail.com";
        public bool UseSsl = true;
        public string Username = "www.emonykim@gmail.com";
        public string Password = "xsjlddrksboltuho"; // Need to create a google app password with username emonykim
        public string ServerName = "smtp.gmail.com";
        public int ServerPort = 587;
    }
}
