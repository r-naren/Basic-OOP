using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
namespace CollegeStudentAdmission;
class Program
{
    //object creation for classes
    public static List<StudentDetails> studentDetails = new List<StudentDetails>();
    public static List<DepartmentDetails> departmentDetails = new List<DepartmentDetails>();
    public static List<AdmissionDetails> admissionDetails = new List<AdmissionDetails>();
    const string wrongInput = "!!!! ";
    public static void Main(string[] args)
    {
        //Assigning default values to the lists
        DefaultValuesAssigning();

        int choice = 0;
        Console.WriteLine("-----------------Syncfusion College of Engineering and Technology-----------------");
        do
        {
            Console.WriteLine("------------------------------------MAIN MENU-------------------------------------");
            Console.WriteLine("1.Student Registration\n2.Student Login\n3.Department wise seat availability\n4.Exit");
            Console.Write("Enter any of the above mentioned choices : ");
            int.TryParse(Console.ReadLine(), out choice);
            switch (choice)
            {
                case 1:
                    {
                        StudentRegistration();
                        break;
                    }
                case 2:
                    {
                        StudentLogin();
                        break;
                    }
                case 3:
                    {
                        DepartmentDetails.DepartmentWiseSeatAvailability(departmentDetails);
                        break;
                    }
                case 4:
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
        } while (choice != 4);
        Console.WriteLine();
    }
    public static void DefaultValuesAssigning()
    {
        DateTime date1 = new DateTime(1999, 11, 11);
        StudentDetails student1 = new StudentDetails("Ravichandran E", "Ettaparajan", date1, Gender.Male, 95, 95, 95);
        StudentDetails student2 = new StudentDetails("Baskaran S", "Sethurajan", date1, Gender.Male, 95, 95, 95);
        studentDetails.Add(student1);
        studentDetails.Add(student2);
        DepartmentDetails dept1 = new DepartmentDetails("EEE", 29);
        DepartmentDetails dept2 = new DepartmentDetails("CSE", 29);
        DepartmentDetails dept3 = new DepartmentDetails("MECH", 30);
        DepartmentDetails dept4 = new DepartmentDetails("ECE", 30);
        departmentDetails.Add(dept1);
        departmentDetails.Add(dept2);
        departmentDetails.Add(dept3);
        departmentDetails.Add(dept4);
        DateTime date2 = new DateTime(2022, 05, 11);
        DateTime date3 = new DateTime(2022, 05, 12);
        AdmissionDetails admissionDetail1 = new AdmissionDetails("SF3001", "DID101", date2, AdmissionStatus.Booked);
        AdmissionDetails admissionDetail2 = new AdmissionDetails("SF3002", "DID102", date3, AdmissionStatus.Booked);
        admissionDetails.Add(admissionDetail1);
        admissionDetails.Add(admissionDetail2);
    }
    public static void StudentRegistration()
    {
        //Declaring registration details variables
        bool temp;
        string studentName, fatherName;
        double physics, chemistry, maths;
        DateTime dob;
        Gender gender;
        //Student name

        Console.Write("Enter Student's Name : ");
        studentName = Console.ReadLine();
        if (string.IsNullOrEmpty(studentName))
        {
            Console.WriteLine("Student's name can't be empty " + wrongInput);
            return;
        }

        //Father's name

        Console.Write("Enter Father's Name : ");
        fatherName = Console.ReadLine();
        if (string.IsNullOrEmpty(fatherName))
        {
            Console.WriteLine("Father's name can't be empty " + wrongInput);
            return;
        }
        //Date of Birth

        Console.Write("Enter Date of Birth in \"DD/MM/YYY\" format : ");
        temp = DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dob);
        DateTime today = DateTime.Now;
        TimeSpan span = today - dob;
        if (!temp || (int)span.TotalDays / 365 < 17)
        {

            Console.WriteLine("Enter valid Date of Birth " + wrongInput);
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

        //Physics mark

        Console.Write("Enter Physics mark (0-100) : ");
        temp = double.TryParse(Console.ReadLine(), out physics);
        if (!temp || physics < 0 || physics > 100)
        {

            Console.WriteLine("Enter valid Physics mark " + wrongInput);
            return;
        }

        //Chemistry mark

        Console.Write("Enter Chemistry mark (0-100) : ");
        temp = double.TryParse(Console.ReadLine(), out chemistry);
        if (!temp || chemistry < 0 || chemistry > 100)
        {

            Console.WriteLine("Enter valid Chemistry mark " + wrongInput);
            return;
        }

        //Maths mark

        Console.Write("Enter Maths mark (0-100) : ");
        temp = double.TryParse(Console.ReadLine(), out maths);
        if (!temp || maths < 0 || maths > 100)
        {
            Console.WriteLine("Enter valid Maths mark " + wrongInput);
            return;
        }
        //student object creation
        StudentDetails student = new StudentDetails(studentName, fatherName, dob,
                    gender, physics, chemistry, maths);
        studentDetails.Add(student);
        Console.WriteLine($"Student Registered Successfully and StudentID is  {student.StudentID}. Kindly note it and press enter.");
        Console.ReadKey();
    }
    //Student Login
    public static void StudentLogin()
    {
        //Checking if student id is present or not
        string studentID;
        StudentDetails temp;
        Console.Write("Enter Student Id for login: ");
        studentID = Console.ReadLine().ToUpper();
        //lambda expression
        temp = studentDetails.Find(s => s.StudentID == studentID);
        if (temp == null)
        {
            Console.WriteLine("Invalid user ID " + wrongInput);
            return;
        }
        LoginOperation(temp);
    }
    public static void LoginOperation(StudentDetails student)
    {
        Console.WriteLine($"Welcome {student.StudentName}.....");
        int choice = 0;
        do
        {
            Console.WriteLine("------------------------SUB MENU------------------------");
            Console.WriteLine("1.Check Eligibility\n2.Show Details\n3.Take Admission\n4.Cancel Admission\n5.Show Admission details\n6.Exit");
            Console.Write("Enter any of the above mentioned choices : ");
            int.TryParse(Console.ReadLine(), out choice);
            switch (choice)
            {
                case 1:
                    {
                        double total = student.Physics + student.Chemistry + student.Maths;
                        bool isEligible = StudentDetails.CheckEligibility(total);
                        if (isEligible)
                        {
                            Console.WriteLine("Student is eligible");
                        }
                        else
                        {
                            Console.WriteLine("Student is not eligible");
                        }
                        break;
                    }
                case 2:
                    {
                        StudentDetails.ShowDetails(student);
                        break;
                    }
                case 3:
                    {
                        TakeAdmission(student);
                        break;
                    }
                case 4:
                    {
                        CancelAdmission(student);
                        break;
                    }
                case 5:
                    {
                        ShowAdmissionDetails(student);
                        break;
                    }
                case 6:
                    {
                        Console.WriteLine($"Logging out from {student.StudentID}. Entering Main Menu ");
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Enter a valid choice" + wrongInput);
                        break;
                    }
            }
        } while (choice != 6);
    }
    public static void TakeAdmission(StudentDetails student)
    {
        bool temp = false, isCancelled;
        int lastIndex;
        string departmentID;
        int i, j;
        foreach (DepartmentDetails department in departmentDetails)
        {
            if (department.NumberOfSeats > 0)
            {
                temp = true;
            }
        }
        if (temp)
        {
            Console.WriteLine("Department ID\tDepartment Name\t  Number of Seats");
            for (i = 0; i < departmentDetails.Count; i++)
            {
                if (departmentDetails[i].NumberOfSeats > 0)
                {
                    Console.WriteLine($"  {departmentDetails[i].DepartmentID}\t\t{departmentDetails[i].DepartmentName}\t\t{departmentDetails[i].NumberOfSeats}");
                }
            }
        }
        else
        {
            Console.WriteLine($"There are no departments present");
        }
        //get department id for admission

        isCancelled = false;
        temp = false;
        Console.Write("Enter anyone of the department id from above : ");
        departmentID = Console.ReadLine().ToUpper();
        if (string.IsNullOrEmpty(departmentID))
        {
            temp = true;
            Console.WriteLine("Department ID can't be empty " + wrongInput);
        }
        else
        {
            temp = true;
            for (i = 0; i < departmentDetails.Count; i++)
            {
                if (departmentDetails[i].DepartmentID == departmentID)
                {
                    temp = false;
                    double total = student.Physics + student.Chemistry + student.Maths;
                    if (StudentDetails.CheckEligibility(total))
                    {
                        if (departmentDetails[i].NumberOfSeats > 0)
                        {
                            for (j = 0; j < admissionDetails.Count; j++)
                            {
                                if (admissionDetails[j].StudentID == student.StudentID)
                                {
                                    if (admissionDetails[j].AdmissionStatus == AdmissionStatus.Booked)
                                    {
                                        Console.WriteLine("You already took admission");
                                        break;
                                    }
                                    else
                                    {
                                        lastIndex = j;
                                        isCancelled = true;
                                    }
                                }
                            }
                            if (j == admissionDetails.Count || isCancelled)
                            {
                                DateTime today = DateTime.Now;
                                AdmissionDetails admission = new AdmissionDetails(student.StudentID, departmentID, today, AdmissionStatus.Booked);
                                admissionDetails.Add(admission);
                                departmentDetails[i].NumberOfSeats--;
                                Console.WriteLine($"Admission took successfully. Your admission ID --- {admission.AdmissionID}");
                            }
                        }
                        else
                        {
                            Console.WriteLine($"Department is full. Choose another department.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Student didn't have elligible cutoff");
                    }
                    break;
                }
            }
            if (i == departmentDetails.Count)
            {
                Console.WriteLine("Department Id is not present " + wrongInput);
            }
        }

    }
    public static void CancelAdmission(StudentDetails student)
    {
        int i, j;
        for (i = 0; i < admissionDetails.Count; i++)
        {
            if (admissionDetails[i].StudentID == student.StudentID && admissionDetails[i].AdmissionStatus == AdmissionStatus.Booked)
            {
                Console.WriteLine($"Admission ID : {admissionDetails[i].AdmissionID}");
                Console.WriteLine($"Department ID : {admissionDetails[i].DepartmentID}");
                Console.WriteLine($"Admission Date : " + admissionDetails[i].AdmissionDate.ToString("dd/MM/yyyy"));
                Console.WriteLine($"Admission Status : {admissionDetails[i].AdmissionStatus}");
                break;
            }
        }
        if (i == admissionDetails.Count)
        {
            Console.WriteLine($"There is no admission for this student");
        }
        else
        {
            if (admissionDetails[i].AdmissionStatus == AdmissionStatus.Booked)
            {
                admissionDetails[i].AdmissionStatus = AdmissionStatus.Cancelled;
                for (j = 0; j < departmentDetails.Count; j++)
                {
                    if (admissionDetails[i].DepartmentID == departmentDetails[j].DepartmentID)
                    {
                        departmentDetails[j].NumberOfSeats++;
                        Console.WriteLine($"Admission cancelled successfully");
                        break;
                    }
                }
            }
            else if (admissionDetails[i].AdmissionStatus == AdmissionStatus.Cancelled)
            {
                Console.WriteLine($"Admission is already cancelled");
            }
        }
    }
    public static void ShowAdmissionDetails(StudentDetails student)
    {
        int i, lastIndex = 0;
        for (i = 0; i < admissionDetails.Count; i++)
        {
            if (admissionDetails[i].StudentID == student.StudentID)
            {
                lastIndex = i;
            }
        }
        if (lastIndex >= 0)
        {
            Console.WriteLine($"Admission ID : {admissionDetails[lastIndex].AdmissionID}");
            Console.WriteLine($"Department ID : {admissionDetails[lastIndex].DepartmentID}");
            Console.WriteLine($"Admission Date : " + admissionDetails[lastIndex].AdmissionDate.ToString("dd/MM/yyyy"));
            Console.WriteLine($"Admission Status : {admissionDetails[lastIndex].AdmissionStatus}");
        }
        else if (i == admissionDetails.Count)
        {
            Console.WriteLine($"There is no admission available for this student. Kindly take admission.");
        }
    }
}