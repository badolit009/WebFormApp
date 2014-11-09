using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StudentManagementApp_WebForm.DAL;
using StudentManagementApp_WebForm.Models;

namespace StudentManagementApp_WebForm.BLL
{
    public class DepartmentManager
    {
        private DepartmentGateway departmentGateway;

        public DepartmentManager()
        {
            departmentGateway = new DepartmentGateway();
        }

        public string Insert(Department department)
        {
            if (!ThisCodeExits(department.Code))
            {
                return departmentGateway.Insert(department);
            }
            return "This Code Already Exits";
        }

        private bool ThisCodeExits(string code)
        {
            return departmentGateway.ThisCodeExits(code);
        }

        public List<Department> GetAllDepartment()
        {
            return departmentGateway.GetAllDepartment();
        }
    }
}