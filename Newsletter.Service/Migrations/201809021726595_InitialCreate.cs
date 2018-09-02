namespace Newsletter.Service.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Subscriptions",
                c => new
                    {
                        EmailAddress = c.String(nullable: false, maxLength: 128),
                        SubscriptionDate = c.DateTime(nullable: false),
                        MarketingSource = c.Int(nullable: false),
                        Other = c.String(),
                        Reason = c.String(),
                    })
                .PrimaryKey(t => t.EmailAddress);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Subscriptions");
        }
    }
}
