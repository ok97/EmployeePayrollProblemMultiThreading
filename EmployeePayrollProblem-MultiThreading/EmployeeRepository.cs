using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayrollProblem_MultiThreading

{
    public class EmployeeRepository
    {  /* UC0:- Ability to create a payroll service database and have C# program connect to database.
                - Use the payroll_service database created in MSSQL.
                - Install System.Data.SqlClient Package.
                - Check if the database connection to payroll_service mssql DB is established.
        */

          public static string connectionString = @"Data Source=DESKTOP-D8GLB66\SQLEXPRESS;Initial Catalog=Payroll_Service;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"; //Specifying the connection string from the sql server connection.


        SqlConnection connection = new SqlConnection(connectionString); // Establishing the connection using the Sqlconnection.  

        public bool DataBaseConnection()
        {
            try
            {
                DateTime now = DateTime.Now; //create object DateTime class //DateTime.Now class access system date and time 
                connection.Open(); // open connection
                using (connection)  //using SqlConnection
                {
                    Console.WriteLine($"Connection is created Successful {now}"); //print msg

                }
                connection.Close(); //close connection
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return true;
        }
        /* UC1:- Ability to add multiple employee to payroll DB.
         *       - Use the payroll_service database created in MS SQL
                 - Use addEmployeeToPayroll previously created along with ADO.NET Transaction.
                 - Record the start and stop time to essentially determine the time taken for the execution
                 - Use MSTest and TDD approach for all Use Cases.
                 - Ensure every Use Cases is a working code and is committed in GIT.
        */
        public bool AddEmployeeListToDataBase(List<EmployeeModel> employeeList)
        {
            foreach (var employee in employeeList)
            {
                Console.WriteLine("Employeee being added :", employee.EmployeeName);
                bool flag = AddEmployeeToDataBase(employee);
                Console.WriteLine("Employee Added :", employee.EmployeeName);
                if (flag == false)
                    return false;
            }
            return true;
        }
        public bool AddEmployeeToDataBase(EmployeeModel model)
        {           
            try
            {
                using (connection)
                {
                    SqlCommand command = new SqlCommand("dbo.SqlProcedureName", this.connection);   //Creating a stored Procedure for adding employees into database

                    command.CommandType = CommandType.StoredProcedure; //Command type is a class to set as stored procedure
                                                                       // Adding values from employeemodel to stored procedure 

                    command.Parameters.AddWithValue("@EmployeeName", model.EmployeeName);
                    command.Parameters.AddWithValue("@PhoneNumber", model.PhoneNumber);
                    command.Parameters.AddWithValue("@Address", model.Address);
                    command.Parameters.AddWithValue("@Department", model.Department);
                    command.Parameters.AddWithValue("@Gender", model.Gender);
                    command.Parameters.AddWithValue("@BasicPay", model.BasicPay);
                    command.Parameters.AddWithValue("@Deductions", model.Deductions);
                    command.Parameters.AddWithValue("@TaxablePay", model.TaxablePay);
                    command.Parameters.AddWithValue("@Tax", model.Tax);
                    command.Parameters.AddWithValue("@NetPay", model.NetPay);
                    command.Parameters.AddWithValue("@StartDate", model.StartDate);
                    command.Parameters.AddWithValue("@City", model.City);
                    command.Parameters.AddWithValue("@Country", model.Country);
                    connection.Open();
                    var result = command.ExecuteNonQuery();
                    connection.Close();

                    if (result != 0)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
            }

        }

    }
}