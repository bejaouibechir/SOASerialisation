using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SOA.RHService
{
    [ServiceContract]
    public interface IRHService
    {
        [OperationContract]
        void AddEmployee(Employee employee);
    }

   
}
