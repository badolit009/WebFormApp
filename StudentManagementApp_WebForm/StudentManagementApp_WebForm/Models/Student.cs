namespace StudentManagementApp_WebForm.Models
{
    public class Student
    {
        public Student(string name, string email, string regNo,int departmentId):this()
        {
            Name = name;
            Email = email;
            RegNo = regNo;
            DepartmentId = departmentId;

        }

        public Student()
        {
            
        }

        public int ID { get; set; }
        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string RegNo { get; set; }
    }
}