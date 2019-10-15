using System.Web;
using System.Web.Mvc;

namespace HCL.MVC.Week6.Day1
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
