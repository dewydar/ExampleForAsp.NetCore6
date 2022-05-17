using NBU.DAL.Entities;
using NBU.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;


namespace NBU.BLL._Job
{
    public class JobBLL : RepositoryBase<Job>, IJobBLL
    {
        private readonly IRepositoryBase<Job> _repo;
        public JobBLL(IRepositoryBase<Job> repo)
        {
            _repo=repo;
        }
        public async Task<List<Job>> JobsByDepartment(int DeptId)
        {
            List<Job> jobs =await _repo.GetList();
            return jobs.Where(x => x.DepartmentId == DeptId).ToList();
        }
    }
}
