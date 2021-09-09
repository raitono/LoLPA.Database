using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;

namespace LoLPA.Database
{
    public class MatchProcessorContextFactory : IDesignTimeDbContextFactory<MatchProcessorContext>
    {
        public MatchProcessorContext CreateDbContext(string[] args)
        {
            var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            var config = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{env}.json", optional: true, reloadOnChange: true)
                .Build();
            var optionsBuilder = new DbContextOptionsBuilder<MatchProcessorContext>();
            optionsBuilder.UseSqlServer(config.GetConnectionString("MatchProcessor"));

            return new MatchProcessorContext(optionsBuilder.Options);
        }
    }
}