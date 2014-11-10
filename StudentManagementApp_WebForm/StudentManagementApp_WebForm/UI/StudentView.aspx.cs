using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StudentManagementApp_WebForm.BLL;
using StudentManagementApp_WebForm.Models;

namespace StudentManagementApp_WebForm.UI
{
    public partial class StudentView : System.Web.UI.Page
    {
        StudentManager studentManager = new StudentManager();
        private DepartmentManager departmentManager = new DepartmentManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetAllDepartment();
            }
        }

        private void GetAllStudent()
        {
            int department = Convert.ToInt32(departmentDropDownList.SelectedValue);
            List<Student> students = studentManager.GetAllStudent(department);

            regNoDropDownList.DataSource = students;
            regNoDropDownList.DataTextField = "RegNo";
            regNoDropDownList.DataValueField = "ID";
            regNoDropDownList.DataBind();
        }

        private void GetAllDepartment()
        {

            List<Department> departments = departmentManager.GetAllDepartment();
            departmentDropDownList.DataSource = departments;
            departmentDropDownList.DataTextField = "Name";
            departmentDropDownList.DataValueField = "ID";
            departmentDropDownList.DataBind();
        }

        protected void showButton_OnClick(object sender, EventArgs e)
        {
            regNoDropDownList.Items.Clear();
            regNoDropDownList.SelectedValue = null;
            GetAllStudent();
            ShowStudent();

        }

        protected void regNoDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowStudent();
        }

        private void ShowStudent()
        {
            int studentId = Convert.ToInt32(regNoDropDownList.SelectedValue);
            List<Student> students = studentManager.ViewStudent(studentId);
            foreach (Student student1 in students)
            {
                string name = student1.Name;
                string email = student1.Email;
                nameLabel.Text = name;
                emailLabel.Text = email;
            }
        }
    }
}