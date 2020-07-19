using AssignmentSoftSolution.Models;
using AssignmentSoftSolution.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AssignmentSoftSolution.Controllers
{
    public class CustomerController : Controller
    {
        private ApplicationContext _ApplicationContext;
        public CustomerController()
        {
            _ApplicationContext = new ApplicationContext();
        }
        // GET: Customer
        public ActionResult Save(int? Id)
        {
            CustomerViewModel customerViewModel = new CustomerViewModel();
           
            var cities = _ApplicationContext.Cities.ToList();
            foreach(var item in cities)
            {
                SelectListItem selectListItem = new SelectListItem()
                {
                    Text = item.CityName,
                    Value = item.CityId.ToString()
                };
                customerViewModel.CitiesList.Add(selectListItem);
            }

            Customer customer = _ApplicationContext.Customers.Where(x => x.CustomerId ==Id).FirstOrDefault();
            if (customer != null)
            {
                customerViewModel.CustomerId = customer.CustomerId;
                customerViewModel.CustomerName = customer.CustomerName;
                customerViewModel.Details = customer.Details;
                customerViewModel.Gender = customer.Gender;
                customerViewModel.selectedCityId = customer.CityId.ToString();
            }
            return View(customerViewModel);
        }


        [HttpPost]
        public ActionResult Save(CustomerViewModel customerViewModel)
        {
            if(customerViewModel.CustomerId==0)
            {
                if (ModelState.IsValid)
                {
                    Customer customer = new Customer()
                    {
                        CustomerName = customerViewModel.CustomerName,
                        Details = customerViewModel.Details,
                        CityId = Convert.ToInt32(customerViewModel.selectedCityId),
                        dateTime = DateTime.Now,

                    };
                    if (customerViewModel.Gender == false)
                    {
                        customer.Gender = false;
                    }
                    else
                    {
                        customer.Gender = true;
                    }
                    _ApplicationContext.Customers.Add(customer);
                    _ApplicationContext.SaveChanges();
                    return RedirectToAction("CustomerList");
                }
            }
            else
            {
                Customer customer = _ApplicationContext.Customers.Where(x => x.CustomerId == customerViewModel.CustomerId).FirstOrDefault();
                if (customer != null)
                {
                    customer.CustomerName = customerViewModel.CustomerName;
                    customer.Details = customerViewModel.Details;
                    customer.CityId =Convert.ToInt32(customerViewModel.selectedCityId);
                    if (customerViewModel.Gender == false)
                    {
                        customer.Gender = false;
                    }
                    else
                    {
                        customer.Gender = true;
                    }
                    _ApplicationContext.Entry(customer).State = EntityState.Modified;
                    _ApplicationContext.SaveChanges();
                }
                return RedirectToAction("CustomerList");
            }
            return View();
        }

        public ActionResult CustomerList()
        {
            var customers = _ApplicationContext.Customers.ToList();
            return View(customers);
        }

        public ActionResult Delete(int Id)
        {
            return View();
        }
    }
}