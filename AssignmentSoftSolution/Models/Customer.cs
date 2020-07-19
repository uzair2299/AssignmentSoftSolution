using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AssignmentSoftSolution.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        [Required]
        public string CustomerName { get; set; }
        public bool Gender { get; set; }
        public DateTime dateTime { get; set; }
        public string Details { get; set; }

        public int CityId { get; set; }
        public City City { get; set; }
    }
}