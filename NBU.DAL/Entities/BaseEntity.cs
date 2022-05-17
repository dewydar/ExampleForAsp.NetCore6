using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBU.DAL.Entities
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreateOn { get; set; } = DateTime.Now;
        public bool IsDelete { get; set; } = false;
        public DateTime? UpdateOn { get; set; }
    }
}
