using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DemoApplication.Models
{
    public class ProjectDetail
    {
        [Key]
        [Column(Order =1)]
        public int EmpId { get; set; }
        [Key]
        [Column(Order = 2)]
        public int ProjectId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public virtual Employees Employeess { get; set; }
        public virtual Project Projects { get; set; }
    }
}