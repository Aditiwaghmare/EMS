using EMS.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Model
{
    public class DepartmentModel
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }

        public static List<DepartmentModel> Convert(List<Department> departments)
        {
            List<DepartmentModel> dlist = new List<DepartmentModel>();
            foreach (Department dep in departments)
            {
                dlist.Add(new DepartmentModel()
                {
                    DepartmentId = dep.DepartmentId,
                    DepartmentName = dep.DepartmentName
                });
            }
            return dlist;
        }

        public static DepartmentModel Convert(Department department)
        {

            return new DepartmentModel()
            {
                DepartmentId = department.DepartmentId,
                DepartmentName = department.DepartmentName
            };
        }

        public static Department Convert(DepartmentModel department)
        {

            return new Department()
            {
                DepartmentId = department.DepartmentId,
                DepartmentName = department.DepartmentName
            };
        }
    }
}
