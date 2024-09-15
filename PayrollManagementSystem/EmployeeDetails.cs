using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace PayrollManagementSystem
{
    public enum Gender { Select, Male, Female,Other }
    public enum Branch { Eymard, Karuna, Madhura }
    public enum Team { Network, Hardware, Developer, Facility }
    /// <summary>
    /// This class is used for creating Employee details
    /// </summary>
    public class EmployeeDetails
    {
        private static int s_employeeID = 3000;
        public string EmployeeID { get; set; }
        public string FullName { get; set; }
        public DateTime DOB { get; set; }
        public string MobileNumber { get; set; }
        public Gender Gender { get; set; }
        public Branch Branch { get; set; }
        public Team Team { get; set; }
        public EmployeeDetails(string fullName, DateTime dob, string mobileNumber, Gender gender, Branch branch, Team team)
        {
            EmployeeID = "SF" + ++s_employeeID;
            FullName = fullName;
            DOB = dob;
            MobileNumber = mobileNumber;
            Gender = gender;
            Branch = branch;
            Team = team;
        }
        public static void DisplayDetails(EmployeeDetails employee)
        {
            Console.WriteLine($"Employee ID : {employee.EmployeeID}");
            Console.WriteLine($"Full Name : {employee.FullName}");
            Console.WriteLine($"DOB : {employee.DOB.ToString("dd/MM/yyyy")}");
            Console.WriteLine($"Mobile Number : {employee.MobileNumber}");
            Console.WriteLine($"Gender : {employee.Gender}");
            Console.WriteLine($"Branch Name : {employee.Branch}");
            Console.WriteLine($"Team Name : {employee.Team}");
            Console.ReadKey();
        }
    }
}