using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentManagementApp_WebForm.Models
{
    public class StudentView
    {
        public int StudentId { get; set; }
        public string StuName { get; set; }
        public string Email { get; set; }
        public string RegNo { get; set; }
        public int DepartmentId { get; set; }

    }
}