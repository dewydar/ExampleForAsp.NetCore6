using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBU.DAL.Entities
{
    public class DocumentInfo:BaseEntity
    {
        [MaxLength(500)]
        public string FileName { get; set; }
        [MaxLength(500)]
        public string FilePath { get; set; }
        [MaxLength(10)]
        public string FileType { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}
