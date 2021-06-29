namespace NotifyControl.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Records",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        CheckIn1 = c.DateTime(nullable: false),
                        CheckOut1 = c.DateTime(nullable: true),
                        CheckIn2 = c.DateTime(nullable: true),
                        CheckOut2 = c.DateTime(nullable: true),
                        PredictionCheckOut2 = c.DateTime(nullable: true),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Records");
        }
    }
}
