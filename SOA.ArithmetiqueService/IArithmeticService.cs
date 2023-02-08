using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SOA.ArithmetiqueService
{
   
    [ServiceContract]
    public interface IArithmeticService
    {
       
        double Addition(double a,double b);
        
        double Soustraction(double a, double b);
        
        double Multiplicaton(double a, double b);
       
        //[FaultContract(typeof(DivideByZeroException))]
        double Division(double a, double b);

    } 
}
