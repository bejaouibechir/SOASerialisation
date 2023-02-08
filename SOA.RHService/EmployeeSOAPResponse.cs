using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace SOA.RHService
{

    //Represente la reponse SOAP 
    [MessageContract(IsWrapped = true, WrapperName = "EmployeeSOAP"
        , WrapperNamespace = "WrapperNamespace = \"http://www.doranco.com/2023/EmployeeResponse\"")]
    public class EmployeeSOAPResponse
    {
        [MessageBodyMember(Name ="Employee", 
            Namespace = "http://www.doranco.com/2023/employee")]
        public Employee EmployeeResponse { get; set; }
    }
}
