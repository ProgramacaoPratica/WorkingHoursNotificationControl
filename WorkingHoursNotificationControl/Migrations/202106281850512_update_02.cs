namespace NotifyControl.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class update_02 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Records", "NotifiedCheckIn1", c => c.Boolean(nullable: false));
            AddColumn("dbo.Records", "NotifiedCheckOut1", c => c.Boolean(nullable: false));
            AddColumn("dbo.Records", "NotifiedCheckIn2", c => c.Boolean(nullable: false));
            AddColumn("dbo.Records", "NotifiedCheckOut2", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Records", "NotifiedCheckOut2");
            DropColumn("dbo.Records", "NotifiedCheckIn2");
            DropColumn("dbo.Records", "NotifiedCheckOut1");
            DropColumn("dbo.Records", "NotifiedCheckIn1");
        }
    }
}
