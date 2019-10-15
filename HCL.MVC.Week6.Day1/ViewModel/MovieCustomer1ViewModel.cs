using HCL.MVC.Week6.Day1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HCL.MVC.Week6.Day1.ViewModel
{
    public class MovieCustomer1ViewModel
    {
        public CustomerC customer { get; set; }
        public List<MovieC> movies { get; set; }
    }
}