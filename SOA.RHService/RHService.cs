
//Data Source=PC2023\PC2023;Initial Catalog=FirmDB;Integrated Security=True
using System;
using System.Configuration;
using System.Data.SqlClient; /* Bibliothèque ADO.NET qui permet de manipuler 
                              * les données en SQL Server
                              */
using System.Diagnostics;

namespace SOA.RHService
{
    public class RHService : IRHService
    {
        SqlConnection _connection;
        string _connectionString;
        private string _query;

        public RHService()
        {
            _connectionString = ConfigurationManager
                .ConnectionStrings["firmdbconnection"].ConnectionString; 
            _connection= new SqlConnection(_connectionString);
        }

        public void AddEmployee(Employee employee)
        {
            try
            {
                _query = $"INSERT INTO Employees(Id,Name,HireDate,Salary) VALUES({employee.Id}," +
                       $"'{employee.Nom}','{employee.DateRecrutement}',{employee.Salaire})";

                SqlCommand cmd = new SqlCommand(_query, _connection);
                _connection.Open();
                cmd.ExecuteNonQuery();
                Debug.WriteLine($"Employee ajouté(e) à la base en {DateTime.Now.Hour}:{DateTime.Now.Minute}");
            }
            catch (SqlException ex)
            {
                Debug.WriteLine(ex.Message);
            }
            finally
            {
                _connection.Close();
            }

        }
    }
}
