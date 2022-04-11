using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace Vineforce.TusharBhagat.EntityFrameworkCore
{
    public static class TusharBhagatDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<TusharBhagatDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<TusharBhagatDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
