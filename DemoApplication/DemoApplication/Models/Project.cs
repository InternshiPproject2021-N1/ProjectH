using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DemoApplication.Models
{
    public class Project
    {
        [Key]
        public int ProjectId { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        public int TeamSize { get; set; }
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
        [StringLength(10)]
        public string Status { get; set; }
        public Boolean IsActive { get; set; }
        [DataType(DataType.Date)]
        public DateTime Create { get; set; }
        public string CreatedBy { get; set; }
        [StringLength(1000)]
        public string Description { get; set; }

        public virtual ICollection<ProjectDetail> ProjectDetails { get; set; }
    }
}