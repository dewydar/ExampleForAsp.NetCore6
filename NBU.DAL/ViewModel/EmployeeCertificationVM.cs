using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBU.DAL.ViewModel
{
    public class EmployeeCertificationVM:BaseEntityVM
    {
        public int EmployeeId { get; set; }
        [MaxLength(500)]
        public string CertificationName { get; set; } = string.Empty;
        public DateTime CertificationDate { get; set; }
        public string FormType { get; set; }
    }
}
