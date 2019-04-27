using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrudWithAngular6_Models.Classes;
using System.Data.Entity.Infrastructure;


namespace CrudWithAngular6_Contracts
{
    public interface ICrudWithAngular6DbContext
    {
        DbEntityEntry Entry(object o);
        int SaveChanges();

        DbSet<Employee> Employees { get; set; }
    }
}
