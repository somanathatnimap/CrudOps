using System.Web;
using System.Web.Mvc;

namespace Crud_using_Api_and_stored_procedure
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
