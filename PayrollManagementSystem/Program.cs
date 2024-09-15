using System;
using System.Collections.Generic;
namespace PayrollManagementSystem;
class PayrollManagementSystem
{
    public static List<AttendanceDetails> attendanceDetails = new List<AttendanceDetails>();
    public static List<EmployeeDetails> employeeDetails = new List<EmployeeDetails>();
    const string wrongInput = "!!!! ";
    public static void Main(string[] args)
    {
        DefaultValuesAssigning();
        int choice = 0;
        Console.WriteLine("------------------Payroll Management System------------------");
        do
        {
            Console.WriteLine("--------------------------MAIN MENU--------------------------");
            Console.WriteLine("1.Employee Registration\n2.Employee Login\n3.Exit");
            Console.Write("Enter any of the above mentioned choices : ");
            int.TryParse(Console.ReadLine(), out choice);
            switch (choice)
            {
                case 1:
                    {
                        EmployeeRegistration();
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
                        Console.WriteLine("Enter a valid choice " + wrongInput);
                        break;
                    }
            }
        } while (choice != 3);
        Console.WriteLine();
    }
    public static void DefaultValuesAssigning()
    {
        DateTime dob = new DateTime(1999, 11, 11);
        EmployeeDetails employee = new EmployeeDetails("Ravi", dob, "9958858888", Gender.Male, Branch.Eymard, Team.Developer);
        employeeDetails.Add(employee);
        DateTime checkIn1 = new DateTime(2022, 05, 15, 09, 00, 00);
        DateTime checkOut1 = new DateTime(2022, 05, 15, 06, 10, 00);
        AttendanceDetails attendanace1 = new AttendanceDetails("SF3001", checkIn1, checkIn1, checkOut1, 8);
        DateTime checkIn2 = new DateTime(2022, 05, 16, 09, 10, 00);
        DateTime checkOut2 = new DateTime(2022, 05, 16, 18, 50, 00);
        AttendanceDetails attendanace2 = new AttendanceDetails("SF3001", checkIn2, checkIn2, checkOut2, 8);
        attendanceDetails.Add(attendanace1);
        attendanceDetails.Add(attendanace2);
    }
    public static void EmployeeRegistration()
    {
        bool temp = false;
        string fullName, mobileNumber;
        Gender gender;
        Branch branch;
        Team team;
        DateTime dob;

        Console.Write("Enter Full Name : ");
        fullName = Console.ReadLine();
        if (string.IsNullOrEmpty(fullName))
        {
            Console.WriteLine("Name can't be empty " + wrongInput);
            return;
        }

        Console.Write("Enter Date of Birth in \"DD/MM/YYYY\" format : ");
        temp = DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dob);
        DateTime today = DateTime.Now;
        TimeSpan span = today - dob;
        if (!temp || (int)span.TotalDays / 365 < 17)
        {

            Console.WriteLine("Enter valid Date of Birth " + wrongInput);
            return;
        }

        //Mobile Number

        Console.Write("Enter Phone number : ");
        mobileNumber = Console.ReadLine();
        const string phonePattern = "[6-9]{1}[0-9]{9}";
        if (!string.IsNullOrEmpty(mobileNumber))
        {

            System.Text.RegularExpressions.Regex phoneCheck = new System.Text.RegularExpressions.Regex(phonePattern);
            if (!phoneCheck.IsMatch(mobileNumber))
            {
                Console.WriteLine("Enter valid mobile number " + wrongInput);

                return;
            }
        }
        else
        {
            Console.WriteLine("Mobile number can't be empty");
            return;

        }

        //Gender

        Console.Write("Enter your Gender : Male, Female, Other : ");
        temp = Enum.TryParse<Gender>(Console.ReadLine(), true, out gender);
        if (!temp)
        {
            Console.WriteLine("Enter valid gender " + wrongInput);
            return;
        }

        //Branch

        Console.Write("Enter your Branch : Eymard, Karuna, Madhura : ");
        temp = Enum.TryParse<Branch>(Console.ReadLine(), true, out branch);
        if (!temp)
        {
            Console.WriteLine("Enter valid Branch name " + wrongInput);
            return;
        }

        //Team

        Console.Write("Enter your Team : Network, Hardware, Developer, Facility : ");
        temp = Enum.TryParse<Team>(Console.ReadLine(), true, out team);
        if (!temp)
        {
            Console.WriteLine("Enter valid team name " + wrongInput);
            return;
        }

        //Payroll Management object creation
        EmployeeDetails employee = new EmployeeDetails(fullName, dob, mobileNumber, gender, branch, team);
        employeeDetails.Add(employee);
        Console.WriteLine($"Employee Registered Successfully and EmployeeID is {employee.EmployeeID}. Kindly note it and press enter.");
        Console.ReadKey();
    }
    public static void Login()
    {
        //Checking if employee id is present or not
        string employeeID;
        EmployeeDetails temp;

        Console.Write("Enter Employee Id for login: ");
        employeeID = Console.ReadLine().ToUpper();
        //lambda expression
        temp = employeeDetails.Find(e => e.EmployeeID == employeeID);
        if (temp == null)
        {
            Console.WriteLine("Invalid Employee ID " + wrongInput);
            return;
        }

        LoginOperation(temp);
    }
    public static void LoginOperation(EmployeeDetails employee)
    {
        Console.WriteLine($"Welcome {employee.FullName} ......");
        int choice = 0;
        do
        {
            Console.WriteLine("------------------------SUB MENU------------------------");
            Console.WriteLine("1.Add attendance\n2.Display details\n3.Calculate salary\n4.Exit");
            Console.Write("Enter any of the above mentioned choices : ");
            int.TryParse(Console.ReadLine(), out choice);
            switch (choice)
            {
                case 1:
                    {
                        AddAttendance(employee);
                        break;
                    }
                case 2:
                    {
                        EmployeeDetails.DisplayDetails(employee);
                        break;
                    }
                case 3:
                    {
                        CalculateSalary(employee);
                        break;
                    }
                case 4:
                    {
                        Console.WriteLine($"Logging out from {employee.EmployeeID}. Entering Main Menu ");
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Enter a valid choice" + wrongInput);
                        break;
                    }
            }
        } while (choice != 4);
    }
    public static void AddAttendance(EmployeeDetails employee)
    {
        string option;
        bool temp;
        DateTime checkIn, checkOut;
        TimeSpan span;
        int hours = 0;

        Console.Write("Do you want to Check-in yes / no : ");
        option = Console.ReadLine().ToLower();
        if (string.IsNullOrEmpty(option))
        {
            Console.WriteLine("Option can't be empty !!!!");
            return;
        }
        if (option == "yes")
        {

            Console.Write("Enter Check-In time in \"DD/MM/YYYY HH:mm\" format : ");
            temp = DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm", null, System.Globalization.DateTimeStyles.None, out checkIn);
            if (!temp)
            {
                temp = false;
                Console.WriteLine("Enter Valid Check-In time " + wrongInput);
                return;
            }
            Console.Write("Do you want to Check-Out yes / no : ");
            option = Console.ReadLine().ToLower();
            if (string.IsNullOrEmpty(option))
            {
                Console.WriteLine("Option can't be empty !!!!");
                return;
            }

            if (option == "yes")
            {

                Console.Write("Enter Check-Out time in \"DD/MM/YYYY HH:mm\" format : ");
                temp = DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm", null, System.Globalization.DateTimeStyles.None, out checkOut);
                if (!temp)
                {
                    temp = false;
                    Console.WriteLine("Enter Valid Check-Out time " + wrongInput);
                    return;
                }

                span = checkOut - checkIn;
                hours = (int)span.TotalHours;
                if (hours > 8)
                {
                    hours = 8;
                }
                if (hours < 0)
                {
                    Console.WriteLine($"Enter valid Check-In and Check-Out Time " + wrongInput);
                    return;
                }
                else
                {
                    AttendanceDetails attendance = new AttendanceDetails(employee.EmployeeID, checkIn, checkIn, checkOut, hours);
                    attendanceDetails.Add(attendance);
                    Console.WriteLine($"Check-in and Checkout Successful and today you have worked {hours} Hours.");
                    return;
                }
            }
            else
            {
                Console.WriteLine($"Add Check-Out time to add attendance");
                return;
            }
        }
        else
        {
            Console.WriteLine($"Add Check-In time to add attendance");
            return;
        }
    }

    public static void CalculateSalary(EmployeeDetails employee)
    {
        int totalHours = 0;
        double totalSalary = 0;
        DateTime today = DateTime.Now;
        bool flag = false;
        foreach (AttendanceDetails attendance in attendanceDetails)
        {
            if (attendance.CheckInTime.Month == today.Month)
            {
                flag = true;
                break;
            }
        }
        if (flag)
        {
            Console.WriteLine($"Attendance ID\t|   Employee Details\t|\tDate\t| CheckInTime\t| CheckOutTime\t| HoursWorked");
            foreach (AttendanceDetails attendance in attendanceDetails)
            {
                if (attendance.CheckInTime.Month == today.Month)
                {
                    Console.WriteLine($"  {attendance.AttendanceID}\t|\t{attendance.EmployeeID}\t\t|   {attendance.Date.ToString("dd/MM/yyyy")}\t|  {attendance.CheckInTime.ToString("hh:mm tt")}\t|   {attendance.CheckOutTime.ToString("hh:mm tt")}\t|\t{attendance.HoursWorked}");
                    totalHours += attendance.HoursWorked;
                }
            }
            totalSalary = Math.Round(((double)totalHours / 8) * 500, 2);
            Console.WriteLine($"Total salary for {employee.FullName} for this month is Rs.{totalSalary}");
        }
        else
        {
            Console.WriteLine($"There are no entries in this month");

        }
    }
}