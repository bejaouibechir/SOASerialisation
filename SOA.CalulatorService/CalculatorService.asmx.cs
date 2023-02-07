using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;

namespace SOA.CalulatorService
{
    /// <summary>
    /// Description résumée de CalculatorService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    //[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    //[System.ComponentModel.ToolboxItem(false)]
    // Pour autoriser l'appel de ce service Web depuis un script à l'aide d'ASP.NET AJAX, supprimez les marques de commentaire de la ligne suivante. 
    // [System.Web.Script.Services.ScriptService]
    public class CalculatorService //: System.Web.Services.WebService
    {

        public AuthenticationHeader header;
        
        [WebMethod]
        public double Add(int a, int b)
        {
            return a + b;
        }
        [WebMethod]
        public double Substract(int a, int b)
        {
            return a - b;
        }
        [WebMethod]
        [SoapHeader("header",Direction = SoapHeaderDirection.In)]
        public double SubstractVIP(int a, int b)
        {
            try
            {
                if (header.Valid == true)
                {
                    header.DidUnderstand = true;
                }
                else
                {
                    header.DidUnderstand = false;
                    throw new Exception("Utilisateur n'est pas authentifié");
                }

                return a - b;
            }
            catch (Exception caught)
            {
                DateTime time = DateTime.Now;
                string message = $"Error time: {time.Hour}:{time.Minute}:{time.Second} error message: {caught.Message}"; 
                EventLog.WriteEntry("Application", message,
                    EventLogEntryType.Error);
                return int.MaxValue;
            }
        }
        [WebMethod]
        public double Mulbtiply(int a, int b)
        {
            return a * b;
        }
        [WebMethod]
        public double Divide(int a, int b)
        {
            if (b != 0)
            {
                return a / b;
            }
            else
            {
                return -9999;
            }

        }
    }
}
