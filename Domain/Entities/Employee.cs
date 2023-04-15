using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public DateTime EmploymentDate { get; set; }
        public bool IsManager { get; set; }
        public bool IsDeliveryProvider{ get; set; }
        public string ApplicationUserID { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        public int RestaurantID { get; set; }
        public virtual Restaurant Restaurant { get; set; }
       
    }
}
