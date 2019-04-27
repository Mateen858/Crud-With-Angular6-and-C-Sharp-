namespace CrudWithAngular6_Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CrudWithAngular6 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IsPermanent = c.Boolean(nullable: false),
                        Salary = c.Single(nullable: false),
                        PicUrl = c.String(),
                        DateAdded = c.DateTime(nullable: false),
                        DateModified = c.DateTime(nullable: false),
                        AddedBy = c.String(),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Employees");
        }
    }
}
