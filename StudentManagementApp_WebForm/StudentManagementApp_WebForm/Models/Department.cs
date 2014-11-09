using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentManagementApp_WebForm.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }

        public Department(string code, string name):this()
        {
            Code = code;
            Name = name;
        }

        public Department()
        {
        }
    }
}