
using System;
using System.Web.Services.Protocols;

namespace SOA.CalulatorService
{
    public class AuthenticationHeader :SoapHeader
    {
        public string Login { get; set; }
        public string Pasword { get; set; }

        public bool Valid
        {
            get
            {
                return GetUserInfo(Login,Pasword);
            }
        }

        private bool GetUserInfo(string login,string pass)
        {
            if (login.Equals("bechir".ToLower()) &&
                  pass.Equals("pass".ToLower()))
               return true;
            else return false;
        }
    }
}