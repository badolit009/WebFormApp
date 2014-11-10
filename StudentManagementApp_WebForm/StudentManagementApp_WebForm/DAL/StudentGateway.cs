using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using StudentManagementApp_WebForm.Models;

namespace StudentManagementApp_WebForm.DAL
{
    public class StudentGateway : Gateway
    {

        public StudentGateway()
            : base("StudentConnectionString")
        {

        }
        public Student GetStudentByRegNo(string regNo)
        {
            Student student = null;
            var query = "SELECT * FROM t_student WHERE RegNo = '" + regNo + "'";
            Command.CommandText = query;
            Connection.Open();
            SqlDataReader rdr = Command.ExecuteReader();
            while (rdr.Read())
            {
                student = new Student();
                student.RegNo = rdr["RegNo"].ToString();
                student.Name = rdr["Name"].ToString();
                student.Email = rdr["Email"].ToString();
                student.ID = Convert.ToInt32(rdr["ID"]);
            }

            rdr.Close();
            Connection.Close();
            return student;
        }

        public int Insert(Student student)
        {
            var query = @"INSERT INTO t_student VALUES('" + student.DepartmentId + "','" + student.RegNo + "','" + student.Name + "','" + student.Email +
                        "')";

            Command.CommandText = query;
            Connection.Open();
            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;
        }

        public List<Student> GetAllStudent(int department)
        {
            List<Student> students = new List<Student>();

            var query = "SELECT * FROM t_student WHERE DepartmentId='" + department + "'";

            Command.CommandText = query;

            Connection.Open();
            SqlDataReader aReader = Command.ExecuteReader();

            while (aReader.Read())
            {
                Student student = new Student();
                student.DepartmentId = (int)aReader[0];
                student.RegNo = aReader[1].ToString();
                student.Name = aReader[2].ToString();
                student.Email = aReader[3].ToString();
                student.ID = (int)aReader[4];
                students.Add(student);
            }

            Connection.Close();
            return students;
        }

        public List<Student> ViewStudent(int studentId)
        {
            List<Student> students = new List<Student>();

            var query = "SELECT * FROM t_student WHERE ID='" + studentId + "'";

            Command.CommandText = query;

            Connection.Open();
            SqlDataReader aReader = Command.ExecuteReader();

            while (aReader.Read())
            {
                Student student = new Student();
                student.DepartmentId = (int)aReader[0];
                student.RegNo = aReader[1].ToString();
                student.Name = aReader[2].ToString();
                student.Email = aReader[3].ToString();
                student.ID = (int)aReader[4];
                students.Add(student);
            }

            Connection.Close();
            return students;
        }
    }
}