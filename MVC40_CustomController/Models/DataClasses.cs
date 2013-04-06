using System.Collections.Generic;

namespace MVC40_CustomController.Models
{
    public class EmployeeInfo
    {
        public int EmpNo { get; set; }
        public string EmpName { get; set; } 
        public string DeptName { get; set; }
        public string Designation { get; set; }
        public int  Salary { get; set; }
    }

    public class DataAccess
    {
        List<EmployeeInfo> lstEmps = new List<EmployeeInfo>();

        public DataAccess()
        {
            lstEmps.Add(new EmployeeInfo() {EmpNo=1,EmpName="A",DeptName="D1",Designation="TL",Salary=45000 });
            lstEmps.Add(new EmployeeInfo() { EmpNo = 2, EmpName = "B", DeptName = "D1", Designation = "TL", Salary = 45000 });
            lstEmps.Add(new EmployeeInfo() { EmpNo = 3, EmpName = "C", DeptName = "D2", Designation = "PM", Salary = 55000 });
            lstEmps.Add(new EmployeeInfo() { EmpNo = 4, EmpName = "D", DeptName = "D2", Designation = "PM", Salary = 55000 });
            lstEmps.Add(new EmployeeInfo() { EmpNo = 5, EmpName = "E", DeptName = "D3", Designation = "PH", Salary = 65000 });
            lstEmps.Add(new EmployeeInfo() { EmpNo = 6, EmpName = "F", DeptName = "D3", Designation = "PH", Salary = 65000 });
        }

        public List<EmployeeInfo> GetEmps()
        {
            return lstEmps;
        }
    }
}