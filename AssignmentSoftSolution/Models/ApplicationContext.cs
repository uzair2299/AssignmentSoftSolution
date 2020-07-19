using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AssignmentSoftSolution.Models
{
    public class ApplicationContext :DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<City> Cities { get; set; }
    }
}