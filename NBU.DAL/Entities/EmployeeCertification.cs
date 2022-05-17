using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBU.DAL.Entities
{
    public class EmployeeCertification :BaseEntity
    {
        [Required]
        public int EmployeeId { get; set; }
        [ForeignKey("EmployeeId")]
        public virtual Employee? Employee { get; set; } = null;
        [MaxLength(500)]
        public string CertificationName { get; set; } = string.Empty;
        public DateTime CertificationDate { get; set; }
    }
}
