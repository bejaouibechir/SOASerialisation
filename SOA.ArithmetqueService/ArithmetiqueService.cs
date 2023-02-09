using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SOA.ArithmetqueService
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "Service1" à la fois dans le code et le fichier de configuration.
    public class ArithmetiqueService : IArithmetiqueService
    {
        public double Add(double a, double b)
        {
            return a + b;
        }

        public double Divide(double a, double b)
        {
            try
            {
                return a / b;
 
            }
            catch (FaultException<DivideByZeroException>)
            { 
                return -int.MaxValue;
            }
        }

        public double Multiply(double a, double b)
        {
             return a * b;
        }

        public double Substract(double a, double b)
        {
           return a- b;
        }
    }
}
