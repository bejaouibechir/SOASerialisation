using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

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
