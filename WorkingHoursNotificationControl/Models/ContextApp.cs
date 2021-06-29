using System.Data.Entity;

namespace NotifyControl.Models
{
    public class ContextApp : DbContext
    {
        public ContextApp()
            : base("name=ContextApp")
        {
        }

        public DbSet<Record> Records { get; set; }
    }
}