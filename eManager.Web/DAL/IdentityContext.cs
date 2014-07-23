using eManager.Web.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace eManager.Web.DAL
{
    public class IdentityContext : IdentityDbContext<ApplicationUser>
    {
        public IdentityContext()
            : base("DefaultConnection")
        {
        }
    }
}