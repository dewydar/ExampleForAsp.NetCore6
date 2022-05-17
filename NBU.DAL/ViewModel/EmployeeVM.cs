using Microsoft.AspNetCore.Http;
using NBU.DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO.Abstractions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBU.DAL.ViewModel
{
    public class EmployeeVM :BaseEntityVM
    {
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; } = string.Empty;
        [StringLength(50)]
        public string? LastName { get; set; } = String.Empty;
        public DateTime? DateOfBirth { get; set; }
        public decimal Salary { get; set; } = 0;
        public IFormFile? DocumentAttached { get; set; }
        public int? DocumentInfoId { get; set; }
        public DocumentInfo? DocumentInfo { get; set; }
        public ICollection<EmployeeCertification>? EmployeeCertifications { get; set; }
        public int? GenderId { get; set; }
        public ICollection<ListOptions>? Genders { get; set; }
        public int? JobId { get; set; }
        public ICollection<ListOptions>? Jobs { get; set; }
        public int? DepartmentId { get; set; }
        public ICollection<ListOptions>? Departments { get; set; }
        public string? FormName { get; set; }
        public string? JobName { get; set; }
        public string? GenderType { get; set; }
        public string? FilePath { get; set; }
    }
}
