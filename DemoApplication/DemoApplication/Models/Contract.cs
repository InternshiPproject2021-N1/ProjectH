using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace DemoApplication.Models
{
    public class Contract
    { 
        [Key]
        public int ContractId { get; set; }
        [StringLength(1000)]
        public string Contents { get; set; }
        [StringLength(100)]
        public string ConstractType { get; set; }
        public DateTime SignDate { get; set; }
        public int EmpId { get; set; }
        public DateTime Create { get; set; }
        public string CreateBy { get; set; }
        [StringLength(1000)]
        public string Description { get; set; }

        public virtual Employees Employees { get; set; }
    }
}