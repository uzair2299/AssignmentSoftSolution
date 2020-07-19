using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AssignmentSoftSolution.Models
{
    public class City
    {
        public int CityId { get; set; }

        [Required(ErrorMessage ="City  name is required")]
        [DisplayName("City Name *")]
        public string CityName { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }
    }
}