using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AssignmentSoftSolution.ViewModel
{
    public class CustomerViewModel
    {
        public CustomerViewModel()
        {
            CitiesList = new List<SelectListItem>();
            Gender = null;
        }
        public int CustomerId { get; set; }
        [Required(ErrorMessage = "*Customer  name is required")]
        [DisplayName("Customer Name *")]
        public string CustomerName { get; set; }

        [Required(ErrorMessage = "*Gender is required")]
        [DisplayName("Gender *")]
        public bool? Gender { get; set; }

        [Required(ErrorMessage ="*City Is Required")]
        [DisplayName("Select City *")]
        public string selectedCityId { get; set; }
        public string Details { get; set; }

       public List<SelectListItem> CitiesList { get; set; } 
    }
}