using System.Web;
using System.Web.Mvc;

namespace Appli
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());

            // Make all functionalities require authentication (login first)
            filters.Add(new AuthorizeAttribute());

            // Disable accessing application through HTTP (not secure connection)
            // Following allows only HTTPS (secure connection)
            filters.Add(new RequireHttpsAttribute());
        }
    }
}
