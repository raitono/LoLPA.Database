using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;

namespace LoLPA.Database
{
    public class RiotContextFactory : IDesignTimeDbContextFactory<RiotContext>
    {
        public RiotContext CreateDbContext(string[] args)
        {
            var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            var config = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{env}.json", optional: true, reloadOnChange: true)
                .Build();
            var optionsBuilder = new DbContextOptionsBuilder<RiotContext>();
            optionsBuilder.UseSqlServer(config.GetConnectionString("Riot"));

            return new RiotContext(optionsBuilder.Options);
        }
    }
}