using System.Web;
using System.Web.Mvc;

namespace Lab_4_Dot_Net
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
