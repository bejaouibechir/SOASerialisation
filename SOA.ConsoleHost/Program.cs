//Data Source = PC2023\PC2023; Initial Catalog = FirmDB; Integrated Security = True
using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Data.SqlClient; // La bibliothèque ADO.NET
using System.Configuration;
using System.Reflection;
using System.Diagnostics;

namespace SOA.ConsoleHost
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
    public class FirmService : IFirmService
    {

        SqlConnection _connection;
        string _connectiontring;
        string _query;
        public FirmService()
        {
            _connectiontring = ConfigurationManager
                .ConnectionStrings["firmdbconnection"]
                .ConnectionString;
            _connection = new SqlConnection(_connectiontring);
        }
        public Employee GetEmployee(int id)
        {
            Employee employee = new Employee();
            try
            {
                _query = "SELECT Id,[Name],HireDate,Salary FROM [dbo].[Employees] " +
                          $"WHERE Id={id}";

                SqlCommand cmd = new SqlCommand(_query, _connection);
                _connection.Open();
                SqlDataReader dataReader = cmd.ExecuteReader();
               if(dataReader.Read())
                {
                    employee.Id = int.Parse(dataReader[0].ToString());
                    employee.Nom = dataReader[1].ToString();
                    employee.DateRecrutement = DateTime.Parse(dataReader[2].ToString());
                    employee.Salaire = decimal.Parse(dataReader[3].ToString());
                }
                else
                {
                    throw new Exception("La table est vide");
                }
            }
            catch (FaultException<SqlException> ex1)
            {
                Debug.WriteLine(ex1.Message);
            }
            catch (FaultException<Exception> ex2)
            {
                Debug.WriteLine(ex2.Message);
            }
            finally
            {
                _connection.Close();
                
            }
                return employee;
        }
        public List<Employee> GetEmployeeList()
        {
            List<Employee> list = new List<Employee>();
            Employee employee; 
            try
            {
                _query = "SELECT Id,[Name],HireDate,Salary FROM [dbo].[Employees]";

                SqlCommand cmd = new SqlCommand(_query, _connection);
                _connection.Open();
                SqlDataReader dataReader = cmd.ExecuteReader();
                while(dataReader.Read())
                {
                    employee = new Employee();
                    employee.Id = int.Parse(dataReader[0].ToString());
                    employee.Nom = dataReader[1].ToString();
                    employee.DateRecrutement = DateTime.Parse(dataReader[2].ToString());
                    employee.Salaire = decimal.Parse(dataReader[3].ToString());
                    list.Add(employee);
                }
                
            }
            catch (FaultException<SqlException> ex1)
            {
                Debug.WriteLine(ex1.Message);
            }
            finally
            {
                _connection.Close();
            }
            return list;
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            ServiceHost host;
            using (host = new ServiceHost(typeof(FirmService)))
            {
                foreach (var address in host.BaseAddresses)
                {
                    Console.WriteLine(address);
                }   
                host.Open();
                Console.WriteLine("Le service WCF est prêt ...");
                Console.WriteLine("Presser une touche pour arrêter le service ");
                Console.ReadKey();
            }
            Console.Read();
        }
    }
}
