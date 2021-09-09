using LoLPA.Database.Models.Riot;
using Microsoft.EntityFrameworkCore;

namespace LoLPA.Database
{
    public class RiotContext : DbContext
    {
        public DbSet<Summoner> Summoners { get; set; }

        public RiotContext(DbContextOptions<RiotContext> options) : base(options)
        {
        }
    }
}