using NBU.DAL.Entities;
using NBU.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBU.BLL._EmployeeCertification
{
    public class EmployeeCertificationBLL : RepositoryBase<EmployeeCertification>, IEmployeeCertificationBLL
    {
        private readonly IRepositoryBase<EmployeeCertification> _repository;

        public EmployeeCertificationBLL(IRepositoryBase<EmployeeCertification> repository)
        {
            _repository = repository;
        }
    }
}
