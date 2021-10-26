using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;

namespace DemoApplication.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(100)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public DateTime Create { get; set; }
        public string CreatedBy { get; set; }
        [StringLength(1000)]
        public string Description { get; set; }
        public virtual ICollection<Role> Roles { get; set; }
    }

}