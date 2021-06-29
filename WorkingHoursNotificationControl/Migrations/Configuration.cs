namespace NotifyControl.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<NotifyControl.Models.ContextApp>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(NotifyControl.Models.ContextApp context)
        {
   
        }
    }
}
