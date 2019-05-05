namespace CrudWithAngular6_Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using CrudWithAngular6_Models.Classes;
    using CrudWithAngular6_Models.Common;

    internal sealed class Configuration : DbMigrationsConfiguration<CrudWithAngular6_Data.CrudWithAngular6DbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CrudWithAngular6_Data.CrudWithAngular6DbContext context)
        {
            context.Employees.AddOrUpdate(
                e => e.Id,
                new Employee
                {
                    Name = "Rana Mateen",
                    IsPermanent = true,
                    Salary = 25000,
                    PicUrl = "/Images/1.jpg",
                    DateAdded = DateTime.UtcNow,
                    DateModified = DateTime.UtcNow,
                    AddedBy = "Seeded",
                    ModifiedBy = "Seeded"
                },
                new Employee
                {
                    Name = "Shahzad Akhter",
                    IsPermanent = true,
                    Salary = 35000,
                    PicUrl = "/Images/2.jpg",
                    DateAdded = DateTime.UtcNow,
                    DateModified = DateTime.UtcNow,
                    AddedBy = "Seeded",
                    ModifiedBy = "Seeded"
                }, new Employee
                {
                    Name = "Bilal Mehmood",
                    IsPermanent = true,
                    Salary = 45000,
                    PicUrl = "/Images/3.jpg",
                    DateAdded = DateTime.UtcNow,
                    DateModified = DateTime.UtcNow,
                    AddedBy = "Seeded",
                    ModifiedBy = "Seeded"
                }, new Employee
                {
                    Name = "Noman Butt",
                    IsPermanent = false,
                    Salary = 55000,
                    PicUrl = "/Images/4.jpg",
                    DateAdded = DateTime.UtcNow,
                    DateModified = DateTime.UtcNow,
                    AddedBy = "Seeded",
                    ModifiedBy = "Seeded"
                }, new Employee
                {
                    Name = "Sunny",
                    IsPermanent = true,
                    Salary = 65000,
                    PicUrl = "/Images/5.jpg",
                    DateAdded = DateTime.UtcNow,
                    DateModified = DateTime.UtcNow,
                    AddedBy = "Seeded",
                    ModifiedBy = "Seeded"
                });
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
