using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace SOA.WCFSvcHost
{
    [ServiceContract]
    public interface IFirmService
    {
        [OperationContract]
        [FaultContract(typeof(SqlException))]
        List<Employee> GetEmployeeList();

        [OperationContract]
        [FaultContract(typeof(Exception))]
        [FaultContract(typeof(SqlException))]
        Employee GetEmployee(int id);
    }
}
