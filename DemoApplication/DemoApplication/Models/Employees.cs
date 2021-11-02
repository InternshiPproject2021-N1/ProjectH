using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DemoApplication.Models
{
    public class Employees
    {
        [Key]
        public int EmpId { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(150)]
        public string Address { get; set; }
        [StringLength(50)]
        public string Email { get; set; }
        public int Age { get; set; }
        [StringLength(10)]
        public string Status { get; set; }
        public Boolean IsActive { get; set; }
        public int Rank { get; set; }
        [StringLength(1000)]
        public string Description { get; set; }
        [DataType(DataType.Date)]
        public DateTime Create { get; set; }
        public string CreatedBy { get; set; }

        public virtual ICollection<ProjectDetail> ProjectDetails { get; set; }
        public virtual ICollection<Contract> Contracts { get; set; }
    }
}