using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBU.DAL.Entities
{
    public class Job:BaseEntity
    {
        [MaxLength(50)]
        public string NameEn { get; set; } = string.Empty;
        [MaxLength(50)]
        public string NameAr { get; set; } = string.Empty;
        
        public virtual int DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public virtual Department? Department { get; set; } = null;
        public ICollection<Employee> Employees { get; set; }

    }
}
