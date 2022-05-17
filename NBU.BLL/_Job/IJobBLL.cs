using NBU.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBU.BLL._Job
{
    public interface IJobBLL
    {
       public Task<List<Job>> JobsByDepartment(int DeptId);
    }
}
