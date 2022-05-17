using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO.Abstractions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBU.DAL.Entities
{
    public class Employee : BaseEntity
    {
        [MaxLength(50)]
        public string FirstName { get; set; } = string.Empty;
        [MaxLength(50)]
        public string? LastName { get; set; } = String.Empty;
        public DateTime? DateOfBirth { get; set; }
        public decimal Salary { get; set; } = 0;
        
        public int? DocumentInfoId { get; set; }
        [ForeignKey("DocumentInfoId")]
        public DocumentInfo? DocumentInfo { get; set; }

        
        public int? GenderId { get; set; }
        [ForeignKey("GenderId")]
        public Gender? Gender { get; set; }
        public int? JobId { get; set; }
        [ForeignKey("JobId")]
        public Job? Job { get; set; }
        public ICollection<EmployeeCertification> EmployeeCertifications { get; set; }
    }
}
