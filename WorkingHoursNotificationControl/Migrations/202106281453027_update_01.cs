namespace NotifyControl.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_01 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Records", "Date", c => c.DateTime(nullable: false, storeType: "date"));
            AlterColumn("dbo.Records", "CheckOut1", c => c.DateTime());
            AlterColumn("dbo.Records", "CheckIn2", c => c.DateTime());
            AlterColumn("dbo.Records", "CheckOut2", c => c.DateTime());
            AlterColumn("dbo.Records", "PredictionCheckOut2", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Records", "PredictionCheckOut2", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Records", "CheckOut2", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Records", "CheckIn2", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Records", "CheckOut1", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Records", "Date", c => c.DateTime(nullable: false));
        }
    }
}
