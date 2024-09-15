using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;
namespace EmployeePayrollManagement;
class Program
{
    public static List<EmployeePayroll> employeePayrolls = new List<EmployeePayroll>();
    const string wrongInput = "!!!!!!!!!!!!!! ";
    public static void Main(string[] args)
    {
        int choice = 0;
        Console.WriteLine("----------------EMPLOYEE PAYROLL MANAGEMENT------------------");

        do
        {
            Console.WriteLine("-------------------------MAIN MENU--------------------------");
            Console.WriteLine("1.Registration\n2.Login\n3.Exit");
            Console.Write("Enter any of the above mentioned choices : ");
            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    {
                        Registration();
                        break;
                    }
                case 2:
                    {
                        Login();
                        break;
                    }
                case 3:
                    {
                        Console.WriteLine("Exiting Application .....");
                        break;
                    }
                default:
                    {
                        Console.WriteLine(wrongInput + " Enter a valid choice ");
                        break;
                    }
            }
        } while (choice != 3);
        Console.WriteLine();
    }
    public static void Registration()
    {
        //Declaring registration details variables
        string employeeName, role, teamName;
        int numberOfLeavesTaken, numberOfWorkingDaysInMonth;
        bool temp = true;
        WorkLocation workLocation;
        DateTime dateOfJoining;
        Gender gender;

        //Employee name
        do
        {
            Console.Write("Enter Employee Name : ");
            employeeName = Console.ReadLine();
            if (string.IsNullOrEmpty(employeeName))
            {
                Console.WriteLine(wrongInput + " Employee name can't be empty");
            }
        } while (string.IsNullOrEmpty(employeeName));
        //Role
        do
        {
            Console.Write("Enter Role : ");
            role = Console.ReadLine();
            if (string.IsNullOrEmpty(role))
            {
                Console.WriteLine(wrongInput + " Role name can't be empty");
            }
        } while (string.IsNullOrEmpty(role));
        //Work location
        do
        {
            Console.Write("Enter Worklocation : Chennai, Kenya : ");
            temp = Enum.TryParse<WorkLocation>(Console.ReadLine(), true, out workLocation);
            if (!temp)
            {
                Console.WriteLine($"{wrongInput} Enter valid Working location");
            }
        } while (!temp);
        //Team Name
        do
        {
            Console.Write("Enter Team Name : ");
            teamName = Console.ReadLine();
            if (String.IsNullOrEmpty(teamName))
            {
                Console.WriteLine(wrongInput + " Team name can't be empty");
            }
        } while (string.IsNullOrEmpty(teamName));
        //Date of joining
        do
        {
            Console.Write("Enter Date of joining in \"DD/MM/YYY\" format : ");
            temp = DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dateOfJoining);
            DateTime today = DateTime.Now;
            TimeSpan span = today - dateOfJoining;

            if (!temp || (int)span.TotalDays < 0)
            {
                Console.WriteLine(wrongInput + " Enter valid date of joining ");
            }
        } while (!temp);
        //Number of working days in a month
        do
        {
            Console.Write("Enter Number of working days in a month : ");
            temp = int.TryParse(Console.ReadLine(), out numberOfWorkingDaysInMonth);
            if (!temp || numberOfWorkingDaysInMonth < 0 || numberOfWorkingDaysInMonth > 31)
            {
                Console.WriteLine(wrongInput + " Enter valid number of working days");
            }
        } while (!temp || numberOfWorkingDaysInMonth < 0 || numberOfWorkingDaysInMonth > 31);
        //Number  of leaves taken
        do
        {
            Console.Write("Enter Number of leaves taken : ");
            temp = int.TryParse(Console.ReadLine(), out numberOfLeavesTaken);
            if (!temp || numberOfLeavesTaken < 0 || numberOfLeavesTaken > 31)
            {
                Console.WriteLine(wrongInput + " Enter valid number of leaves taken");
            }
        } while (!temp || numberOfLeavesTaken < 0 || numberOfLeavesTaken > numberOfWorkingDaysInMonth);
        //Gender
        do
        {
            Console.Write("Enter Gender : Male, Female, Other : ");
            temp = Enum.TryParse<Gender>(Console.ReadLine(), true, out gender);
            if (!temp)
            {
                Console.WriteLine($"{wrongInput} Enter valid gender");
            }
        } while (!temp);
        //object creation
        EmployeePayroll employee = new EmployeePayroll(employeeName, role, workLocation,
                    teamName, dateOfJoining, numberOfWorkingDaysInMonth, numberOfLeavesTaken, gender);
        employeePayrolls.Add(employee);
        Console.WriteLine($"Registration completed....");
        Console.WriteLine($"Hai {employee.EmployeeName}! Your Employee ID is {employee.EmployeeId}. Kindly note it and press enter.");
        Console.ReadKey();
    }
    public static void Login()
    {
        bool isPresent = false;
        //checking if customer id is already present
        string employeeId;
        EmployeePayroll temp;
        do
        {
            isPresent = true;
            Console.Write("Enter Employee Id for login: ");
            employeeId = Console.ReadLine().ToUpper();
            //lambda expression
            temp = employeePayrolls.Find(e => e.EmployeeId == employeeId);
            if (temp == null)
            {
                isPresent = false;
                Console.WriteLine(wrongInput + " Invalid user ID");
            }
        } while (!isPresent);
        LoginOperation(temp);
    }
    public static void LoginOperation(EmployeePayroll employee)
    {
        Console.WriteLine($"Welcome {employee.EmployeeName}.....");
        int choice = 0;

        do
        {
            Console.WriteLine("----------------------SUB MENU----------------------");
            Console.WriteLine("1.Calculate salary\n2.Display details\n3.Exit");
            Console.Write("Enter any of the above mentioned choices : ");
            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    {
                        CalculateSalary(employee);
                        break;
                    }
                case 2:
                    {
                        Display(employee);
                        break;
                    }
                case 3:
                    {
                        Console.WriteLine($"Logging out from {employee.EmployeeId}....");
                        break;
                    }
                default:
                    {
                        Console.WriteLine(wrongInput + " Enter a valid choice");
                        break;
                    }
            }
        } while (choice != 3);
    }
    public static void CalculateSalary(EmployeePayroll employee){
        int totalDays = employee.NumberOfWorkingDaysInMonth - employee.NumberOfLeavesTaken;
        Console.WriteLine($"Your salary is Rs.{totalDays*500}");
        Console.ReadKey();
    }
    public static void Display(EmployeePayroll employee){
        Console.WriteLine("Employee detail is listed below");
        Console.WriteLine($"Employee ID : {employee.EmployeeId}");
        Console.WriteLine($"Employee Name : {employee.EmployeeName}");
        Console.WriteLine($"Role : {employee.Role}");
        Console.WriteLine($"Work Location : {employee.WorkLocation}");
        Console.WriteLine($"Team Name : {employee.TeamName}");
        Console.WriteLine($"Date of joining : "+ employee.DateOfJoining.ToString("dd/MM/yyyy"));
        Console.WriteLine($"Number of working days in the month : {employee.NumberOfWorkingDaysInMonth}");
        Console.WriteLine($"Number of leave taken : {employee.NumberOfLeavesTaken}");
        Console.WriteLine($"Gender : {employee.Gender}");
        Console.ReadKey();
    }


}