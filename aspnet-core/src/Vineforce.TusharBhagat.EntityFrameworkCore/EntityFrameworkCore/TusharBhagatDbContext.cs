using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using Vineforce.TusharBhagat.Authorization.Roles;
using Vineforce.TusharBhagat.Authorization.Users;
using Vineforce.TusharBhagat.MultiTenancy;
using Vineforce.TusharBhagat.Countries;
using Vineforce.TusharBhagat.States;

namespace Vineforce.TusharBhagat.EntityFrameworkCore
{
    public class TusharBhagatDbContext : AbpZeroDbContext<Tenant, Role, User, TusharBhagatDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public virtual DbSet<Country> Contries { get; set; }

        public virtual DbSet<State> States { get; set; }
        public TusharBhagatDbContext(DbContextOptions<TusharBhagatDbContext> options)
            : base(options)
        {
        }
    }
}
