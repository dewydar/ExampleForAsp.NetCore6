using NBU.DAL.Context;
using NBU.DAL.Entities;
using NBU.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBU.BLL._Gender
{
    public class GenderBLL : RepositoryBase<Gender>, IGenderBLL
    {
        private readonly IRepositoryBase<Gender> _repository;

        public GenderBLL(IRepositoryBase<Gender> repository)
        {
            _repository = repository;
        }
    }
}
