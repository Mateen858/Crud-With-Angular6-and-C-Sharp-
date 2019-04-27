using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using CrudWithAngular6_Contracts;
using CrudWithAngular6_Models.Classes;


namespace CrudWithAngular6_Data
{
    public class CrudWithAngular6DbContext : DbContext, ICrudWithAngular6DbContext
    {
      

        public CrudWithAngular6DbContext ()
        {
            //"Data Source=DESKTOP-SHB3L6S\SQLEXPRESS;Initial Catalog=DocumentWizard;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"
            Database.Connection.ConnectionString = @"Data Source=DESKTOP-SHB3L6S\SQLEXPRESS; Initial Catalog=CrudWithAngularDb; Integrated Security=True";
        }
        public DbSet<Employee> Employees { get; set; }
        
    }
}