using EMS.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Model
{
   public class EmployeeDataProcessor
    {
        private readonly EmployeeRepository repository;
        public EmployeeDataProcessor()
        {
            repository = new EmployeeRepository();
        }
        public List<EmployeeModel> GetDepartments
        {
            get
            {
                return EmployeeModel.Convert(repository.GetEmployees);
            }

        }

        public EmployeeDetailModel GetEmployee(int EmployeeId)
        {
            EmployeeDetail model = repository.GetEmployee(EmployeeId);

            if(model != null)
            {
                return EmployeeDetailModel.Convert(model);
            }
            return null;
        }

        public UserModel GetUser(string UserId, string Password)
        {
           UserDetails details = repository.GetUser(UserId, Password);

            if(details != null)
            {
                return new UserModel()
                {
                    Name = details.Name,
                    ProfileImage = details.ProfileImage
                };
            }
            return null;
        }
        public void Save(EmployeeModel model)
        {
            
                repository.Save(EmployeeModel.Convert(model));
            
        }

        public void Update(EmployeeModel model)
        {
            repository.Update(EmployeeModel.Convert(model));
        }

        public void Remove(int EmployeeId)
        {
            repository.Remove(EmployeeId);
        }
    }
}
