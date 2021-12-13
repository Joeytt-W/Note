using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols;

namespace Core.Service.Data
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<CoreDbContext>
    {
        public CoreDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<CoreDbContext>();
            optionsBuilder.UseSqlServer("Data Source = 127.0.0.1;Initial Catalog = CoreDB; User ID = sa;Password = wang0705");

            return new CoreDbContext(optionsBuilder.Options);
        }
    }
}
