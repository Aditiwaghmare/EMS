using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMS.DAL;

namespace EMS.Model
{
    public class DepartmentDataProcessor
    {
        private readonly DepartmentRepository repository;
        public DepartmentDataProcessor()
        {
            repository = new DepartmentRepository();
        }
        public List<DepartmentModel> GetDepartments
        {
            get
            {
                return DepartmentModel.Convert(repository.GetDepartments);
            }

        }
        public void Save(DepartmentModel model)
        {
            repository.Save(DepartmentModel.Convert(model));
        }

        public void Update(DepartmentModel model)
        {
            repository.Update(DepartmentModel.Convert(model));
        }

        public void Remove(int DepartmentId)
        {
            repository.Remove(DepartmentId);
        }
    }
}
