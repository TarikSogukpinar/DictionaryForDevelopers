using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DataAccess.Concrete.EntityFramework.Contexts
{
    public class MsDbContext : ProjectDbContext
    {
        public MsDbContext(DbContextOptions<ProjectDbContext> options, IConfiguration configuration) : base(options,
            configuration)
        {
        }
    }
}