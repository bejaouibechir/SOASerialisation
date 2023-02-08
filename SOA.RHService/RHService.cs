//Changer PC2023\PC2023 par le nom de votre serveur sql server
//Data Source=PC2023\PC2023;Initial Catalog=FirmDB;Integrated Security=True
using System;
using System.Configuration;
using System.Data.SqlClient; /* Bibliothèque ADO.NET qui permet de manipuler 
                              * les données en SQL Server
                              */

/*Utiliser le password  pass =>  1984728699 pour des raisons de démo*/

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


        private bool IsAuthenticated(string username, string password)
        {
            bool result = false;
            int index = 0;

            try
            {
                _query = "SELECT [Login],PasswordHash FROM Credentials " +
                        $"WHERE [Login]='{username}' AND PasswordHash ={password.GetHashCode()}";

                SqlCommand cmd = new SqlCommand(_query, _connection);
                
                _connection.Open();
                SqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    index++;
                }

                if (index == 0)
                    result = false;
                else result = true;
            }
            catch (SqlException)
            {
                result = false;
            }
            finally
            {
                _connection.Close();
            }
            return result;
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

        public EmployeeSOAPResponse  GetEmployee(EmployeeSOAPRequest request)
        {
            

            Credentials credentials = new Credentials
            {
                Login = request.Login,
                Password = request.Password
            };


            EmployeeSOAPResponse response = new EmployeeSOAPResponse();
            if(IsAuthenticated(credentials.Login,credentials.Password)==false)
            {
                throw new Exception("Vous n'êtes pas authentifiée");
            }
            else
            {
                response.EmployeeResponse = GetEmployeeFromDatabase(request.EmployeeRequest.Id);
                return response;
            }

        }

        private  Employee GetEmployeeFromDatabase(int id)
        {
            Employee employee = new Employee();
            try
            {
                _query = $"SELECT Id,Name,HireDate,Salary FROM [dbo].[Employees] WHERE Id ={id}";
                SqlCommand cmd = new SqlCommand(_query, _connection);
                _connection.Open();
                
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                employee.Id = int.Parse(reader[0].ToString());
                employee.Nom = reader[1].ToString();
                employee.DateRecrutement = DateTime.Parse(reader[2].ToString());
                employee.Salaire = decimal.Parse(reader[3].ToString());

                Debug.WriteLine($"Recuperé(e) la base en {DateTime.Now.Hour}:{DateTime.Now.Minute}");
            }
            catch (SqlException ex)
            {
                Debug.WriteLine(ex.Message);
            }
            finally
            {
                _connection.Close();
            }

            return employee;
        }

    }
}
