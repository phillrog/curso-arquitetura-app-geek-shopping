using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GeekShopping.IdentityServer.Model.Context
{
    public class MsSqlIdentityContext : IdentityDbContext<ApplicationUser>
    {
        public MsSqlIdentityContext(DbContextOptions<MsSqlIdentityContext> options) : base(options) { }
    }
}
