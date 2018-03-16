namespace OisisCarRental.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StatusFieldIdChange : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Payments", "PayStatusId", "dbo.PayStatus");
            DropIndex("dbo.Payments", new[] { "PayStatusId" });
            RenameColumn(table: "dbo.Payments", name: "PayStatusId", newName: "PayStatus_Id");
            AddColumn("dbo.Payments", "PayStaId", c => c.Int(nullable: false));
            AlterColumn("dbo.Payments", "PayStatus_Id", c => c.Int());
            CreateIndex("dbo.Payments", "PayStatus_Id");
            AddForeignKey("dbo.Payments", "PayStatus_Id", "dbo.PayStatus", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Payments", "PayStatus_Id", "dbo.PayStatus");
            DropIndex("dbo.Payments", new[] { "PayStatus_Id" });
            AlterColumn("dbo.Payments", "PayStatus_Id", c => c.Int(nullable: false));
            DropColumn("dbo.Payments", "PayStaId");
            RenameColumn(table: "dbo.Payments", name: "PayStatus_Id", newName: "PayStatusId");
            CreateIndex("dbo.Payments", "PayStatusId");
            AddForeignKey("dbo.Payments", "PayStatusId", "dbo.PayStatus", "Id", cascadeDelete: true);
        }
    }
}
