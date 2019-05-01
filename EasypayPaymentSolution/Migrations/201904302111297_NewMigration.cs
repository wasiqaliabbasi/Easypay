namespace EasypayPaymentSolution.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewMigration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.BankDetails", "AccNo", c => c.String(nullable: false));
            AlterColumn("dbo.BankDetails", "RoutingNo", c => c.String(nullable: false));
            AlterColumn("dbo.BankDetails", "Email", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.BankDetails", "Email", c => c.String());
            AlterColumn("dbo.BankDetails", "RoutingNo", c => c.String());
            AlterColumn("dbo.BankDetails", "AccNo", c => c.String());
        }
    }
}
