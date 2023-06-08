using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.DAL
{
    public class EmployeeDetail
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
    }
}
