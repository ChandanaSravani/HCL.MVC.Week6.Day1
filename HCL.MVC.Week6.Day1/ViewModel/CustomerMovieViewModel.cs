using HCL.MVC.Week6.Day1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HCL.MVC.Week6.Day1.ViewModel
{
    public class CustomerMovieViewModel
    {
        public MovieC Movie { get; set; }
        public List<CustomerC> Customers { get; set; }
    }
}