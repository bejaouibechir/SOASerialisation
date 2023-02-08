using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace SOA.RHService
{
    //Cette classe représente le SOAP Request
    [MessageContract(IsWrapped = true,
        WrapperName ="EmployeeSOAP",
        WrapperNamespace = "http://www.doranco.com/2023/EmployeeRequest")]
    public class EmployeeSOAPRequest
    {
        public EmployeeSOAPRequest()
        {

        }

        public EmployeeSOAPRequest(Employee emp)
        {
            EmployeeRequest = emp;
        }

        #region Body
        [MessageBodyMember(Name = "Employee",
            Namespace = "http://www.doranco.com/2023/employee")]
        public Employee EmployeeRequest { get; set; }

        #endregion

        #region Header parameters
        [MessageHeader(Name ="login",
            Namespace ="http://www.doranco.com/2023/login")]
        public string Login { get; set; }
        [MessageHeader(Name = "password",
           Namespace = "http://www.doranco.com/2023/password")]
        public string Password { get; set; }
        #endregion
    }
}
