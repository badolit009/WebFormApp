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
    public partial class StudentEntry : System.Web.UI.Page
    {
        StudentManager studentManager = new StudentManager();
        DepartmentManager departmentManager=new DepartmentManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                msgLabel.Text = "";
                GetAllDepartment();
            }
            
        }

        private void GetAllDepartment()
        {
            List<Department> departments = departmentManager.GetAllDepartment();
            DepartmentDownList.DataSource = departments;
            DepartmentDownList.DataTextField = "Name";
            DepartmentDownList.DataValueField = "ID";
            DepartmentDownList.DataBind();
        }

        protected void btnSave_OnClick(object sender, EventArgs e)
        {
            try
            {

                var name = txtName.Text;
                var email = txtEmail.Text;
                var regNo = txtRegNo.Text;
                int departmentId =Convert.ToInt16( DepartmentDownList.SelectedValue);
                Student student = new Student(name, email, regNo,departmentId);

                bool isSaved = studentManager.Insert(student);

                if (isSaved)
                {
                    msgLabel.Text = "Saved Successfully!";
                }
                else
                {
                    msgLabel.Text = "Insertion Failed!";
                }

            }
            catch (Exception exception)
            {
                msgLabel.Text = exception.Message;
            }
            
        }
    }
}