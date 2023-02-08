using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SOA.ArithmetiqueService
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "ArithmeticService" à la fois dans le code et le fichier de configuration.
    public class ArithmeticService : IArithmeticService
    {
        public double Addition(double a, double b)
        {
             return a + b;
        }
  
        public double Division(double a, double b)
        {
            DivideByZeroException ex  //Objet CLR =>Objet .net
                = new DivideByZeroException("Division par zéro n'est pas permise");
            try
            {
                if (b == 0) throw ex ;
                return a / b;
            }
            catch (FaultException<DivideByZeroException> caught)
            {
                Debug.WriteLine(caught.Message);
                throw new FaultException<DivideByZeroException>(ex,ex.Message);
            }
        }

        public double Multiplicaton(double a, double b)
        {
            return a * b;
        }

        public double Soustraction(double a, double b)
        {
            return a - b;
        }
    }
}
