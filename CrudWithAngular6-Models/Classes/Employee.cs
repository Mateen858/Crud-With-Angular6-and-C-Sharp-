using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CrudWithAngular6_Models.Common;

namespace CrudWithAngular6_Models.Classes
{
    public class Employee : BaseModel
    {
        public string Name { get; set; }
        public bool IsPermanent { get; set; }
        public float Salary { get; set; }
        public string PicUrl { get; set; }
    }
}