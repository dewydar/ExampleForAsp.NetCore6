using NBU.DAL.Entities;
using NBU.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBU.BLL._Department
{
    public class DepartmentBLL : RepositoryBase<Department>,IDepartmentBLL
    {
        private readonly IRepositoryBase<Department> _repository;
        public DepartmentBLL(IRepositoryBase<Department> repository)
        {
            _repository = repository;
        }
    }
}
