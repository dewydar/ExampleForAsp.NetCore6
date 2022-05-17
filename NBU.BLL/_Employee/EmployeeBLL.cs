using NBU.DAL.Entities;
using NBU.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBU.BLL._Employee
{
    public class EmployeeBLL : RepositoryBase<Employee>, IEmployeeBLL
    {
        private readonly IRepositoryBase<Employee> _repository;

        public EmployeeBLL(IRepositoryBase<Employee> repository)
        {
            _repository = repository;
        }
    }
}
