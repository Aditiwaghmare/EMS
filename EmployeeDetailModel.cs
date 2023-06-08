using EMS.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Model
{
    public class EmployeeDetailModel
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public int Salary { get; set; }
        public string EmailAddress { get; set; }
        public string ContactNo { get; set; }
        public string ProfileImage { get; set; }
        public string Department { get; set; }

        public static EmployeeDetailModel Convert(EmployeeDetail employee)
        {

            return new EmployeeDetailModel()
            {
                EmployeeId = employee.EmployeeId,
                Name = employee.Name,
                Age = employee.Age,
                ContactNo = employee.ContactNo,
                EmailAddress = employee.EmailAddress,
                Gender = employee.Gender,
                ProfileImage = employee.ProfileImage,
                Salary = employee.Salary,
                Department = employee.Department
            };
        }
    }
}
