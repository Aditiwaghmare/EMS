
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.DAL
{
    public class EmployeeRepository
    {
        public List<Employee> GetEmployees
        {
            get
            {
                List<Employee> Elist = new List<Employee>();
                using (SqlConnection con = DBContext.GetConnection)
                {
                    SqlCommand cmd = new SqlCommand("select * from TEmployee", con);
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Elist.Add(new Employee()
                            {
                                EmployeeId = Convert.ToInt32(reader["EmployeeId"]),
                                Name = reader["Name"].ToString(),
                                EmailAddress = reader["EmailAddress"].ToString(),
                                ContactNo = reader["ContactNo"].ToString(),
                                Gender = reader["Gender"].ToString(),
                                ProfileImage = (reader["ProfileImage"] != DBNull.Value ? "../Images/" + reader["ProfileImage"].ToString() : null),
                                Age = Convert.ToInt32(reader["Age"]),
                                Salary = Convert.ToInt32(reader["Salary"]),
                            });
                        }
                    }
                    con.Close();
                }
                return Elist;
            }

        }

        public EmployeeDetail GetEmployee(int EmployeeId)
        {
            EmployeeDetail employee = null;
            using (SqlConnection con = DBContext.GetConnection)
            {
                SqlCommand cmd = new SqlCommand("SpGetEmployeeById", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmployeeId", EmployeeId);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    employee = new EmployeeDetail();
                    while (reader.Read())
                    {

                            employee.EmployeeId = Convert.ToInt32(reader["EmployeeId"]);
                            employee.Name = reader["Name"].ToString();
                            employee.EmailAddress = reader["EmailAddress"].ToString();
                            employee.ContactNo = reader["ContactNo"].ToString();
                            employee.Gender = reader["Gender"].ToString();
                            employee.ProfileImage = (reader["ProfileImage"] != DBNull.Value ? "../Images/" + reader["ProfileImage"].ToString() : null);
                            employee.Age = Convert.ToInt32(reader["Age"]);
                            employee.Salary = Convert.ToInt32(reader["Salary"]);
                             employee.Department = reader["DepartmentName"].ToString();
                            
                        
                    }
                }
                con.Close();
            }

            if (employee != null)
            {
                return employee;
            }
            else
            {
                return null;
            }
        }

        public UserDetails GetUser(string UserId,string Password)
        {
            UserDetails user = null;
            using (SqlConnection con = DBContext.GetConnection)
            {
                SqlCommand cmd = new SqlCommand("SpGetUser", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserId", UserId);
                cmd.Parameters.AddWithValue("@Password", Password);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    user = new UserDetails();
                    while (reader.Read())
                    {
                        user.Name = reader["Name"].ToString();
                        user.ProfileImage = (reader["ProfileImage"] != DBNull.Value ? "../Images/" + reader["ProfileImage"].ToString() : null);
                     }
                }
                con.Close();
            }

            if (user != null)
            {
                return user;
            }
            else
            {
                return null;
            }
        }
        public void Save(Employee model)
        {
            using (SqlConnection con = DBContext.GetConnection)
            {
                SqlCommand cmd = new SqlCommand("SpInsertEmployee", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", model.Name);
                cmd.Parameters.AddWithValue("@Gender", model.Gender);
                cmd.Parameters.AddWithValue("@Age", model.Age);
                cmd.Parameters.AddWithValue("@Salary", model.Salary);
                cmd.Parameters.AddWithValue("@EmailAddress", model.EmailAddress);
                cmd.Parameters.AddWithValue("@ContactNo", model.ContactNo);
                cmd.Parameters.AddWithValue("@DepartmentId", model.DepartmentId);
                cmd.Parameters.AddWithValue("@ProfileImage", model.ProfileImage);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void Update(Employee model)
        {
            using (SqlConnection con = DBContext.GetConnection)
            {
                SqlCommand cmd = new SqlCommand("SpUpdateEmployee", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmployeeId", model.EmployeeId);
                cmd.Parameters.AddWithValue("@Name", model.Name);
                cmd.Parameters.AddWithValue("@Gender", model.Gender);
                cmd.Parameters.AddWithValue("@Age", model.Age);
                cmd.Parameters.AddWithValue("@Salary", model.Salary);
                cmd.Parameters.AddWithValue("@EmailAddress", model.EmailAddress);
                cmd.Parameters.AddWithValue("@ContactNo", model.ContactNo);
                cmd.Parameters.AddWithValue("@DepartmentId", model.DepartmentId);
                cmd.Parameters.AddWithValue("@ProfileImage", model.ProfileImage);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void Remove(int EmployeeId)
        {
            using (SqlConnection con = DBContext.GetConnection)
            {
                SqlCommand cmd = new SqlCommand("SpDeleteEmployee", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmployeeId", EmployeeId);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
