using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace DemoApplication.Models
{
    public class Role
    {
        [Key]
        public string RoleId { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        public DateTime Create { get; set; }
        public string CreatedBy { get; set; }
        [StringLength(1000)]
        public string Description { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}