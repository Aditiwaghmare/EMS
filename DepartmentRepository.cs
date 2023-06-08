using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.DAL
{
    public class DepartmentRepository
    {
        public List<Department> GetDepartments
        {
            get
            {
                List<Department> dlist = new List<Department>();
                dlist.Add(new Department()
                {
                    DepartmentId = -1,
                    DepartmentName = "Select Department"
                });
                using (SqlConnection con = DBContext.GetConnection)
                {
                    SqlCommand cmd = new SqlCommand("select * from TDepartment", con);
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            dlist.Add(new Department()
                            {
                                DepartmentId = Convert.ToInt32(reader["DepartmentId"]),
                                DepartmentName = reader["DepartmentName"].ToString()
                            });
                        }
                    }
                    con.Close();
                }
                return dlist;
            }

        }
        public void Save(Department model)
        {
            using (SqlConnection con = DBContext.GetConnection)
            {
                SqlCommand cmd = new SqlCommand("SpInsertDepartment", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@DepartmentName", model.DepartmentName);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void Update(Department model)
        {
            using (SqlConnection con = DBContext.GetConnection)
            {
                SqlCommand cmd = new SqlCommand("SpUpdateDepartment", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@DepartmentName", model.DepartmentName);
                cmd.Parameters.AddWithValue("@DepartmentId", model.DepartmentId);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void Remove(int DepartmentId)
        {
            using (SqlConnection con = DBContext.GetConnection)
            {
                SqlCommand cmd = new SqlCommand("SpDeleteDepartment", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@DepartmentId", DepartmentId);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
