using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panase.Infrastructure.Data
{
    public class ApiContextFactory: IDesignTimeDbContextFactory<ApiContext>
    {
        public ApiContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApiContext>();
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=PanaseDb;Username=postgres;Password=Eren9696;");

            return new ApiContext(optionsBuilder.Options);
        }
    }
}
