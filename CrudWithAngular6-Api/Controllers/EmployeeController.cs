using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using CrudWithAngular6_Data.Repositories;
using CrudWithAngular6_Contracts.IRepositories;
using System.Web.Http.Cors;
using CrudWithAngular6_Models.Classes;
using System.Web;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net;
using System.Diagnostics;

namespace CrudWithAngular6_Api.Controllers
{

    [EnableCors(origins: "*", headers: "*", methods: "*")]
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
        [Route("api/Employee/GetOne/{id:int}")]
        public Employee GetOne (int id)
        {
            return _repository.GetAll().Where(e => e.Id == id).FirstOrDefault();
        }
        [HttpPut]
       
        //[Route("api/Employee/Save/{emp}")]
        public  bool Save (Employee emp)
        {
            bool result = _repository.Save(emp);
            return result;
        }
        [HttpPost]
        public bool SaveNew(Employee emp)
        {
            bool result = _repository.Save(emp);
            return result;
        }
        [HttpDelete]
        [Route("api/Employee/Delete/{id:int}")]
        public bool Delete (int id)
        {
            bool result = _repository.Delete(id);
            return result;
        }
        [HttpPost]
        public HttpResponseMessage UploadJsonFile()
        {
            HttpResponseMessage response = new HttpResponseMessage();
            var httpRequest = HttpContext.Current.Request;
            if (httpRequest.Files.Count > 0)
            {
                foreach (string file in httpRequest.Files)
                {
                    var postedFile = httpRequest.Files[file];
                    var filePath = HttpContext.Current.Server.MapPath("~/Attachments/" + postedFile.FileName);
                    postedFile.SaveAs(filePath);
                }
            }
            return response;
        }

        [HttpPost]
        public bool SavePic (HttpPostedFileBase file)
        {
            if (!Request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }

            string root = HttpContext.Current.Server.MapPath("~/App_Data");
            var provider = new MultipartFormDataStreamProvider(root);

            return false;
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

        [HttpPost]
        public async Task<HttpResponseMessage> PostFormData()
        {
            // Check if the request contains multipart/form-data.
            if (!Request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }

            string root = HttpContext.Current.Server.MapPath("~/App_Data");
            var provider = new MultipartFormDataStreamProvider(root);

            try
            {
                // Read the form data.
                await Request.Content.ReadAsMultipartAsync(provider);

                // This illustrates how to get the file names.
                foreach (MultipartFileData file in provider.FileData)
                {
                    Trace.WriteLine(file.Headers.ContentDisposition.FileName);
                    Trace.WriteLine("Server file path: " + file.LocalFileName);
                }
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (System.Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }
        //public bool SavePicFormCollection()
        //{
        //    var provider = Request.Content.ReadAsMultipartAsync();
        //    access form data
        //    NameValueCollection formData = provider.FormData;
        //    return false;
        //    bool result = true;
        //    string relativePath = "/Attachments/";
        //    try
        //    {
        //        relativePath = relativePath + file.FileName + file.FileName.Substring(file.FileName.LastIndexOf("."));
        //        string physicalPath = HttpContext.Current.Server.MapPath(relativePath);
        //        file.SaveAs(physicalPath);
        //    }
        //    catch (Exception ex)
        //    {
        //        result = false;
        //    }
        //    return result;
        //}

    }
}
