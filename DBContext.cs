using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace EMS.DAL
{
    public static class DBContext
    {
        public static SqlConnection GetConnection
        {
            get
            {
                return new SqlConnection("data source=.;database=EMS;Trusted_Connection=true;");
            }
        }
    }
}
