using EMS.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Model
{
    public class EmployeeModel
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public int Salary { get; set; }
        public string EmailAddress { get; set; }
        public string ContactNo { get; set; }
        public string ProfileImage { get; set; }

        public int DepartmentId { get; set; }

        public static List<EmployeeModel> Convert(List<Employee> Employees)
        {
            List<EmployeeModel> Elist = new List<EmployeeModel>();
            foreach (Employee emp in Employees)
            {
                Elist.Add(new EmployeeModel()
                {
                  EmployeeId = emp.EmployeeId,
                  Name = emp.Name,
                  Age = emp.Age,
                  ContactNo = emp.ContactNo,
                  EmailAddress = emp.EmailAddress,
                  Gender = emp.Gender,
                  ProfileImage = emp.ProfileImage,
                  Salary = emp.Salary
                });
            }
            return Elist;
        }

        public static EmployeeModel Convert(Employee employee)
        {

            return new EmployeeModel()
            {
                EmployeeId = employee.EmployeeId,
                Name = employee.Name,
                Age = employee.Age,
                ContactNo = employee.ContactNo,
                EmailAddress = employee.EmailAddress,
                Gender = employee.Gender,
                ProfileImage = employee.ProfileImage,
                Salary = employee.Salary,
                DepartmentId =employee.DepartmentId
            };
        }

        public static Employee Convert(EmployeeModel employee)
        {

            return new Employee()
            {
                EmployeeId = employee.EmployeeId,
                Name = employee.Name,
                Age = employee.Age,
                ContactNo = employee.ContactNo,
                EmailAddress = employee.EmailAddress,
                Gender = employee.Gender,
                ProfileImage = employee.ProfileImage,
                Salary = employee.Salary,
                DepartmentId = employee.DepartmentId
            };
        }
    }
}
