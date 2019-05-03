﻿using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using CrudWithAngular6_Data.Repositories;
using CrudWithAngular6_Contracts.IRepositories;
using System.Web.Http.Cors;
using CrudWithAngular6_Models.Classes;
using System.Web;
using System;


namespace CrudWithAngular6_Api.Controllers
{
    [EnableCors("*", "*", "get,post", SupportsCredentials = true)]

    public class EmployeeController : ApiController
    {
        private readonly IEmployeeRepository _repository;

            public EmployeeController()
        {
            _repository = new EmployeeRepository();
        }


        public EmployeeController(EmployeeRepository repository)
        {
            _repository = repository;
        }

        [Route("api/Employee/GetAll")]
        public List<Employee> GetAll()
        {
            return _repository.GetAll().ToList();
        }
        [Route("api/Employee/GetOne")]
        public Employee GetOne (int id)
        {
            return _repository.GetAll().Where(e => e.Id == id).FirstOrDefault();
        }
        [Route("api/Employee/Save")]
        public  bool Save (Employee emp)
        {
            bool result = _repository.Save(emp);
            return result;
        }
        [Route("api/Employee/Delete")]
        public bool Delete (int id)
        {
            bool result = _repository.Delete(id);
            return result;
        }

        public bool SavePic (HttpPostedFileBase file)
        {
            bool result = true;
            string relativePath = "/Attachments/";
            try
            {
                relativePath = relativePath + file.FileName + file.FileName.Substring(file.FileName.LastIndexOf("."));
                string physicalPath = HttpContext.Current.Server.MapPath(relativePath);
                file.SaveAs(physicalPath);
            }
            catch (Exception ex)
            {
                result = false;
            }
            return result;
        }


    }
}