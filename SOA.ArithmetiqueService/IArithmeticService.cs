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
        [OperationContract]
        double Addition(double a,double b);
        [OperationContract]
        double Soustraction(double a, double b);
        [OperationContract]
        double Multiplicaton(double a, double b);
        [OperationContract]
        [FaultContract(typeof(DivideByZeroException))]
        double Division(double a, double b);

    } 
}
