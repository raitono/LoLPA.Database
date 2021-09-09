using LoLPA.Database.Models.MatchProcessor;
using Microsoft.EntityFrameworkCore;

namespace LoLPA.Database
{
    public class MatchProcessorContext : DbContext
    {
        public DbSet<ProcessorQueueItem> ProcessorQueue { get; set; }

        public MatchProcessorContext(DbContextOptions<MatchProcessorContext> options) : base(options)
        {
        }
    }
}