using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using StudentManagementApp_WebForm.Models;

namespace StudentManagementApp_WebForm.DAL
{
    public class DepartmentGateway : Gateway
    {
        public DepartmentGateway()
            : base("StudentConnectionString")
        {
        }
        public string Insert(Department department)
        {
            string query = string.Format("INSERT INTO t_Department VALUES('{0}','{1}')", department.Code, department.Name);
            Command.CommandText = query;
            Connection.Open();
            int affactedRow = Command.ExecuteNonQuery();
            Connection.Close();

            if (affactedRow > 0)
            {
                return "Insetrt Success";
            }
            return "Somethig Wrong";
        }

        public bool ThisCodeExits(string code)
        {
            string query = string.Format("SELECT * FROM t_Department WHERE Code='{0}'", code);
            Command.CommandText = query;

            Connection.Open();
            SqlDataReader aReader = Command.ExecuteReader();
            bool HasRows = aReader.HasRows;
            Connection.Close();
            return HasRows;
        }

        public List<Department> GetAllDepartment()
        {
            string query = string.Format("SELECT * FROM t_Department");
            Command.CommandText = query;
            List<Department> aDepartments = new List<Department>();
            Connection.Open();
            SqlDataReader aReader = Command.ExecuteReader();
            while (aReader.Read())
            {
                Department aDepartment = new Department();
                aDepartment.Id = (int)aReader[0];
                aDepartment.Code = aReader[1].ToString();
                aDepartment.Name = aReader[2].ToString();
                aDepartments.Add(aDepartment);
            }
            Connection.Close();
            return aDepartments;
        }
    }
}