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
    public partial class DepartmentEntry : System.Web.UI.Page
    {
        private DepartmentManager aDepartmentManager = new DepartmentManager();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_OnClick(object sender, EventArgs e)
        {
            Department aDepartment=new Department(codeTextBox.Text,nameTextBox.Text);
            string msg = aDepartmentManager.Insert(aDepartment);
            msgLabel.Text = msg;


        }
    }
}