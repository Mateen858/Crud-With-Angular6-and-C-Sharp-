using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CrudWithAngular6_Contracts;
using CrudWithAngular6_Contracts.IRepositories;
using CrudWithAngular6_Data;
using CrudWithAngular6_Models.Common;
using CrudWithAngular6_Models.Classes;
using System.Data.Entity;

namespace CrudWithAngular6_Data.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ICrudWithAngular6DbContext _db;

        public EmployeeRepository()
        {
            _db = new CrudWithAngular6DbContext();
        }

        public EmployeeRepository(CrudWithAngular6DbContext db)
        {
            _db = db;
        }

        public bool Delete(int id)
        {
            bool result = true;
            try
            {
               var emp = _db.Employees.Find(id);
                _db.Entry(emp).State = EntityState.Deleted;
                _db.Employees.Remove(emp);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                result = false;
            }
            return result;
        }

        public IQueryable<Employee> GetAll()
        {
            return _db.Employees;
        }

        public bool Save(Employee employee)
        {
            bool result;
            if (employee.Id > 0)
            {
                result = UpdateRecord(employee);
            }
            else
            {
                result = AddRecord(employee);
            }
            return result;
        }
        public bool AddRecord (Employee employee)
        {
            bool result = true;
            try
            {
                employee.AddedBy = "Mateen";
                employee.DateAdded = DateTime.UtcNow;
                employee.DateModified = DateTime.UtcNow;
                _db.Entry(employee).State = EntityState.Added;
                _db.Employees.Add(employee);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                result = false; 
            }
            return result;
        }

        public bool UpdateRecord(Employee employee)
        {
            bool result = true;
            try
            {
                employee.DateModified = DateTime.UtcNow;
                employee.ModifiedBy = "Mateen";
                var dbitem = _db.Employees.Find(employee.Id);
                _db.Entry(dbitem).State = EntityState.Modified;
                dbitem = employee;
                _db.SaveChanges();

            }
            catch (Exception ex)
            {
                result = false;
            }
            return result;
        }

    }
}