using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBU.DAL.ViewModel
{
    public class BaseEntityVM
    {
        public int Id { get; set; }
        public DateTime CreateOn { get; set; } = DateTime.Now;
        public DateTime? UpdateOn { get; set; }
    }
}
