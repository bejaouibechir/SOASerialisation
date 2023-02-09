using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SOA.ArithmetqueService
{
  
    [ServiceContract]
    public interface IArithmetiqueService
    {
        [OperationContract]
        double Add(double a,double b);

        [OperationContract]
        double Substract(double a, double b);

        [OperationContract]
        [FaultContract(typeof(DivideByZeroException))]
        double Divide(double a, double b);

        [OperationContract]
        double Multiply(double a, double b);

    }
}
