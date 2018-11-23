using System.Web;
using System.Web.Mvc;

namespace _21_WCF_Assignment_1_Task2
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
