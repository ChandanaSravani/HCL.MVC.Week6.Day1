using HCL.MVC.Week6.Day1.Models;
using HCL.MVC.Week6.Day1.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace HCL.MVC.Week6.Day1.Controllers
{
    [Authorize]
    public class CustomerController : Controller
    {
        // GET: Customer
        private ApplicationDbContext DbContext=null;
        public CustomerController()
        {
            DbContext = new ApplicationDbContext();//the object is created only when the obj is created to the controller class
        }
        protected override void Dispose(bool disposing)
        {
            if(disposing)
            {
                DbContext.Dispose();
            }
        }

        [AllowAnonymous]
        public ActionResult Index()
        {
            //var c3 = GetCustomers();
            var c3 = DbContext.Customers.Include(a=>a.MembershipType).ToList();
            return View("IndexDiff",c3);
        }
        public ActionResult SpecificDetails(int Id)
        {
            //normal way
            //CustomerC c4 = new CustomerC();
            //var c5 = GetCustomers();
            //foreach (var ob in c5)
            //{
            //    if(ob.Id==Id)
            //    {
            //        c4 = ob;
            //    }
            //}
            //return View(c4);

            //using linq with lambda
            
            var c4 = DbContext.Customers.Include(a=>a.MembershipType).ToList().SingleOrDefault(a => a.Id == Id);
            return View(c4);

            //using linq
            //var customer = from res in GetCustomers()
            //         where res.Id == Id
            //         select res;
            //return View(customer);
        }
        //public List<CustomerC> GetCustomers()
        //{
        //    List<CustomerC> c2 = new List<CustomerC>
        //    {
        //        new CustomerC{Id=1,CustomerName="Jashiktha",DOB=Convert.ToDateTime("18-07-2019"),Gender="Female"},
        //        new CustomerC{Id=2,CustomerName="Lasya",DOB=Convert.ToDateTime("28-10-2015"),Gender="Female"},
        //        new CustomerC{Id=3,CustomerName="Chandana",DOB=Convert.ToDateTime("13-08-1998"),Gender="Female"},
        //        new CustomerC{Id=4,CustomerName="Mohan",DOB=Convert.ToDateTime("20-01-1995"),Gender="Male"},
        //        new CustomerC{Id=5,CustomerName="Madhuri",DOB=Convert.ToDateTime("02-04-1993"),Gender="Female"}
        //    };
        //    return c2;
        //}
        public ActionResult CustomerDisplay()
        {
            MovieCustomer1ViewModel VMC = new MovieCustomer1ViewModel();
            CustomerC c1 = new CustomerC { CustomerName = "Junnu" };
            List<MovieC> m1 = new List<MovieC>
            {
                new MovieC{Name="Maharshi"},
                new MovieC{Name="Bharat Ane Nenu"},
                new MovieC{Name="Busines Man"},
                new MovieC{Name="One"}
            };
            VMC.customer = c1;
            VMC.movies = m1;
            return View(VMC);
        }
        public ActionResult Test()
        {
            return View();
        }

        [HttpGet]
        
        public ActionResult Create()
        {
            var customer = new CustomerC();
            var gender = new List<SelectListItem>
            {
                new SelectListItem{Text="Select Gender",Value="0",Disabled=true,Selected=true },
                new SelectListItem{Text="Male",Value="Male"},
                new SelectListItem{Text="Female",Value="Female"},
                new SelectListItem{Text="Others",Value="Others"}
            };
            ViewBag.Gender = gender;
            ViewBag.MembershipTypeId = ListMembership();
            return View(customer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CustomerC customerFromView)
        {
            if(!ModelState.IsValid)
            {
                var gender = new List<SelectListItem>
            {
                new SelectListItem{Text="Select Gender",Value="0",Disabled=true,Selected=true },
                new SelectListItem{Text="Male",Value="1"},
                new SelectListItem{Text="Female",Value="2"},
                new SelectListItem{Text="Others",Value="3"}
            };
                ViewBag.Gender = gender;
                ViewBag.MembershipTypeId = ListMembership();
                return View(customerFromView);
            }

            DbContext.Customers.Add(customerFromView);//Insert statement
            DbContext.SaveChanges();//To Update Database
            return RedirectToAction("Index", "Customer");
        }

        [NonAction]
        public IEnumerable<SelectListItem> ListMembership ()
        {
            //by using LinQ
            //var membership = (from m in DbContext.MembershipTypes.AsEnumerable()
            //                  select new SelectListItem
            //                  {
            //                      Text = m.Type,
            //                      Value = m.Id.ToString()
            //                  }).ToList();
            //By using Lambda
            var membership = DbContext.MembershipTypes.AsEnumerable().
                Select(m => new SelectListItem() { Text = m.Type, Value = m.Id.ToString() }).ToList();
            membership.Insert(0, new SelectListItem { Text = "----select-----", Value = "0",Disabled=true,Selected=true });
            return membership;
        }
        [HttpGet]
        public ActionResult EditCustomer(int Id)
        {
            var customer = DbContext.Customers.SingleOrDefault(x => x.Id == Id);
            if (customer != null)
            {
                ViewBag.Gender = GenderList();
                ViewBag.MembershipTypeId = ListMembership();
                return View(customer);
            }
            else
            {
                return HttpNotFound("Customer Not Found");
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditCustomer(CustomerC CustomerFromView)
        {
            if(ModelState.IsValid)
            {
                var CustomerInDB = DbContext.Customers.FirstOrDefault(c => c.Id == CustomerFromView.Id);
                CustomerInDB.CustomerName = CustomerFromView.CustomerName;
                CustomerInDB.City = CustomerFromView.City;
                CustomerInDB.Gender = CustomerFromView.Gender;
                CustomerInDB.DOB = CustomerFromView.DOB;
                CustomerInDB.MembershipTypeId = CustomerFromView.MembershipTypeId;
                DbContext.SaveChanges();
                return RedirectToAction("Index", "Customer");
            }
            else
            {
                ViewBag.Gender = GenderList();
                ViewBag.MembershipTypeId = ListMembership();
                return View(CustomerFromView);
            }
            
        }

        [NonAction]
        public IEnumerable<SelectListItem> GenderList()
        {
            var gender = new List<SelectListItem>
            {
                new SelectListItem{Text="Select Gender",Value="0",Disabled=true,Selected=true },
                new SelectListItem{Text="Male",Value="1"},
                new SelectListItem{Text="Female",Value="2"},
                new SelectListItem{Text="Others",Value="3"}
            };
            return gender;
        }

        [HttpGet]
        public ActionResult Delete(int Id)
        {

            var customer = DbContext.Customers.SingleOrDefault(x => x.Id == Id);
            if (customer != null)
            {
                ViewBag.Gender = GenderList();
                ViewBag.MembershipTypeId = ListMembership();
                return View(customer);
            }
            else
            {
                return HttpNotFound("Customer Not Found");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(CustomerC CustomerFromView)
        {
            
                var CustomerInDB = DbContext.Customers.FirstOrDefault(c => c.Id == CustomerFromView.Id);
                DbContext.Customers.Remove(CustomerInDB);
                DbContext.SaveChanges();
                return RedirectToAction("Index", "Customer");
           
        }
    }
}