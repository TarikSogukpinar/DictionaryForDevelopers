using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DataAccess.Concrete.EntityFramework.Contexts
{
    public class PostgreDbContext : ProjectDbContext
    {
        public PostgreDbContext(DbContextOptions options, IConfiguration configuration) : base(options, configuration)
        {
        }
    }
}