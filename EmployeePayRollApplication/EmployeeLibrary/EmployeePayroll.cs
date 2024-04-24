using System;
using System.Dynamic;
using System.Runtime.CompilerServices;
namespace EmployeeLibrary;
public enum Gender
{
    Select,
    Male ,
    Female,
    Other
}
public enum WorkLocation
{
    Select,
    Chennai,
    Kenya
}
class EmployeePayroll
{
    private static int s_employeeId = 1000;
    public string EmployeeId { get; }
    public string EmployeeName { get; set; }
    public string Role { get; set; }
    public WorkLocation WorkLocation { get; set; }
    public string TeamName { get; set; }
    public DateTime DateOfJoining { get; set; }
    public Gender Gender { get; set; }
    public int NumberOfWorkingDaysInMonth { get; set; }
    public int NumberOfLeavesTaken { get; set; }

    public EmployeePayroll()
    {
        Console.WriteLine("Enter Employee Details : ");
        WorkLocation = WorkLocation.Select;
        Gender = Gender.Select;
    }
    public EmployeePayroll(string employeeName, string role, WorkLocation workLocation, string teamName, DateTime dateOfJoining,
                Gender gender, int numberOfWorkingDaysInMonth, int numberOfLeavesTaken)
    {
        EmployeeId = "SF" + ++s_employeeId;
        EmployeeName = employeeName;
        Role = role;
        WorkLocation = workLocation;
        TeamName = teamName;
        DateOfJoining = dateOfJoining;
        Gender = gender;
        NumberOfWorkingDaysInMonth = numberOfWorkingDaysInMonth;
        NumberOfLeavesTaken = numberOfLeavesTaken;
    }
}