﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBU.DAL.Entities
{
    public class Department:BaseEntity
    {
        [MaxLength(50)]

        public string NameEn { get; set; } = String.Empty;
        [MaxLength(50)]

        public string NameAr { get; set; } = String.Empty;
        public ICollection<Job> Jobs { get; set; }
        //public ICollection<Employee> Employees { get; set; }

    }
}
