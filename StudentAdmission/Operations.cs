using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace StudentAdmission
{
    //Static class
    public static class Operations
    {
        //Local/Global Object Creation
        static StudentDetails currentLoggedInStudent;
        //Static list creation
        static List<StudentDetails> studentList = new List<StudentDetails>();
        static List<DepartmentDetails> departmentList = new List<DepartmentDetails>();
        static List<AdmissionDetails> admissionList = new List<AdmissionDetails>();

        //Main Menu
        public static void MainMenu()
        {
            int mainOption;
            Console.WriteLine($"************Welcome to Syncfusion College************");
            do
            {
                //Need to show the Main menu options
                Console.WriteLine($"MainMenu\n1.Registration\n2.Login\n3.Department wise seat availability\n4.Exit");
                //Need to get input from user and validate
                Console.Write($"Select an option : ");
                bool temp = int.TryParse(Console.ReadLine(), out mainOption);
                //Need to create Main Menu structure
                switch (mainOption)
                {
                    case 1:
                        {
                            Console.WriteLine($"************Student Registration************");
                            StudentRegistration();
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine($"************Student Login************");
                            StudentLogin();
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine($"************Department Wise Seat Availabilty************");
                            DepartmentWiseSeatAvailability();
                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine($"Application Exited successfully");
                            break;
                        }
                    default:
                        {
                            Console.WriteLine($"Enter valid option");
                            break;
                        }
                }
                //Need to iterate until option is exit
            } while (mainOption != 4);
        } //Main Menu ends
        //Student Registration
        public static void StudentRegistration()
        {
            // Need to get below Student Details
            Console.Write("Enter your Name : ");
            string studentName = Console.ReadLine();
            Console.Write("Enter your Father Name : ");
            string fatherName = Console.ReadLine();
            Console.Write($"Enter Your DOB in \"DD/MM/YYYY\" format : ");
            bool temp = DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime dob);
            Console.Write($"Enter your Gender (Male/Female/Transgender) : ");
            temp = Enum.TryParse<Gender>(Console.ReadLine(), true, out Gender gender);
            Console.Write("Enter your Physics mark : ");
            temp = int.TryParse(Console.ReadLine(), out int physicsMark);
            Console.Write("Enter your Chemistry mark : ");
            temp = int.TryParse(Console.ReadLine(), out int chemistryMark);
            Console.Write("Enter your Maths mark : ");
            temp = int.TryParse(Console.ReadLine(), out int mathsMark);
            // Need to create an object
            StudentDetails student = new StudentDetails(studentName, fatherName, dob, gender, physicsMark, chemistryMark, mathsMark);
            // Need to add in the list
            studentList.Add(student);
            // Need to display and confirmation message and ID.
            Console.WriteLine($"Student Registered successfully. Student ID is {student.StudentID}.");

        } //Student Registration Ends

        //Student Login
        public static void StudentLogin()
        {
            // Need to get ID input
            Console.Write($"Enter Student ID to Login : ");
            string loginID = Console.ReadLine().ToUpper();
            // Validate by its presnece and its list
            bool flag = true;
            foreach (StudentDetails student in studentList)
            {
                if (loginID.Equals(student.StudentID))
                {
                    flag = false;
                    //Assigning current user to gobal variable
                    currentLoggedInStudent = student;
                    Console.WriteLine($"Logged in Successfully");
                    //Need to call submenu
                    SubMenu();
                    break;
                }
            }
            if (flag)
            {
                Console.WriteLine($"Student ID is Invalid or not present");
            }
            // If not - Invalid valid.
        } //Student Login Ends
        //SubMenu Starts
        public static void SubMenu()
        {
            int subOption;
            do
            {
                Console.WriteLine($"****************SubMenu****************");
                //Need to show Sub Menu options
                Console.WriteLine("Select an option\n1.Check Eligibility\n2.Show Details\n3.Take Admission\n4.Cancel Admission\n5.Admission Details\n6.Exit");
                //Getting user option
                Console.Write("Enter your option : ");
                bool temp = int.TryParse(Console.ReadLine(), out subOption);
                //Need to create Sub Menu structure
                switch (subOption)
                {
                    case 1:
                        {
                            Console.WriteLine($"**********Check Eligibility**********");
                            CheckEligibility();
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine($"**********Show Details**********");
                            ShowDetails();
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine($"**********Take Admission**********");
                            TakeAdmission();
                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine($"**********Cancel Admission**********");
                            CancelAdmission();
                            break;
                        }
                    case 5:
                        {
                            Console.WriteLine($"**********Admission Details**********");
                            AdmissionDetails();
                            break;
                        }
                    case 6:
                        {
                            Console.WriteLine($"Taking back to Main Menu");
                            break;
                        }
                }
                //Itreate till sub option is exit
            } while (subOption != 6);
        }//SubMenu Ends
        //Check Eligibility
        public static void CheckEligibility()
        {
            //Get the cut off value as input
            Console.Write($"Enter the cutoff value : ");
            double cutOff;
            bool temp = double.TryParse(Console.ReadLine(), out cutOff);
            //Check Eligibility or not
            if (currentLoggedInStudent.CheckEligibilty(cutOff))
            {
                Console.WriteLine($"Student is eligible");
            }
            else
            {
                Console.WriteLine($"Student is not eligible");
            }


        }//Check Eligbility Ends
        //ShowDetails
        public static void ShowDetails()
        {
            //Need to show Current details' student
            Console.WriteLine($"|Student ID|Student Name|Father Name|DOB|Gender|Physics Mark|Chemistry Mark|Maths Mark|");
            Console.WriteLine($"|{currentLoggedInStudent.StudentID}|{currentLoggedInStudent.StudentName}|{currentLoggedInStudent.FatherName}|{currentLoggedInStudent.DOB}|{currentLoggedInStudent.Gender}|{currentLoggedInStudent.PhysicsMark}|{currentLoggedInStudent.ChemistryMark}|{currentLoggedInStudent.MathsMark}|");

        } // ShowDetails Ends
        //TakeAdmission
        public static void TakeAdmission()
        {
            //Need to show available department details
            DepartmentWiseSeatAvailability();
            //Ask department ID from user
            Console.Write($"Select a department ID : ");
            string departmentID = Console.ReadLine().ToUpper();
            //Check ID is present or not
            bool flag = true;
            foreach (DepartmentDetails department in departmentList)
            {
                if (department.DepartmentID.Equals(departmentID))
                {
                    flag = false;
                    //Check the student is eligible or not
                    if (currentLoggedInStudent.CheckEligibilty(75.0))
                    {
                        //Check the seat availability
                        if (department.NumberOfSeats > 0)
                        {
                            int count = 0;
                            //Check student already taken admission
                            foreach (AdmissionDetails admission in admissionList)
                            {
                                if (currentLoggedInStudent.StudentID.Equals(admission.StudentID) && admission.AdmissionStatus.Equals(AdmissionStatus.Booked))
                                {
                                    count++;
                                    break;
                                }
                            }
                            if (count == 0)
                            {
                                //create admission object
                                AdmissionDetails newAdmission = new AdmissionDetails(currentLoggedInStudent.StudentID, department.DepartmentID, DateTime.Now, AdmissionStatus.Booked);
                                //Reduce seat count
                                department.NumberOfSeats--;
                                //Add to the admission list
                                admissionList.Add(newAdmission);
                                //Display admission successfull message
                                Console.WriteLine($"Yoou have taken admission successfully. Admission id is {newAdmission.AdmissionID}");
                            }
                            else
                            {
                                Console.WriteLine($"You haev already taken admission");
                            }

                        }
                        else
                        {
                            Console.WriteLine($"Seat is not available.");

                        }

                    }
                    else
                    {
                        Console.WriteLine($"You are not eligible due to low cut off");

                    }

                }
            }
            if (flag)
            {
                Console.WriteLine($"Invalid ID or ID not present");
            }

        }//TakeAdmission Ends
        //CancelAdmission
        public static void CancelAdmission()
        {
            //Check the student is taken any admission nad display it
            bool flag = true;
            foreach (AdmissionDetails admission in admissionList)
            {
                if (admission.StudentID == currentLoggedInStudent.StudentID && admission.AdmissionStatus.Equals(AdmissionStatus.Booked)) 
                {
                    //Cancel the found admission
                    admission.AdmissionStatus = AdmissionStatus.Cancelled;
                    //return the seat of the department
                    foreach(DepartmentDetails department in departmentList){
                        if(admission.DepartmentID.Equals(department.DepartmentID)){
                            department.NumberOfSeats++;
                            Console.WriteLine($"Admission cancelled successfully");
                        }
                    }
                    flag = false;
                }
            }
            if(flag ){
                Console.WriteLine($"You have no admission to cancel.");
            }
            
        }//CancelAdmission Ends
        //AdmissionDetails
        public static void AdmissionDetails()
        {
            //Need to show Current logged in student Admission Detail
            bool flag = true;
            foreach (AdmissionDetails admission in admissionList)
            {
                if (currentLoggedInStudent.StudentID.Equals(admission.StudentID))
                {
                    flag = false;
                }
            }
            if (!flag)
            {
                Console.WriteLine($"|Admission ID|Student ID|Department ID|Admission Date|Admission Status|");
                foreach (AdmissionDetails admission in admissionList)
                {
                    if (currentLoggedInStudent.StudentID.Equals(admission.StudentID))
                    {
                        Console.WriteLine($"|{admission.AdmissionID}|{admission.StudentID}|{admission.DepartmentID}|{admission.AdmissionDate}|{admission.AdmissionStatus}|");
                    }
                }
            }
            else
            {
                Console.WriteLine($"There is no admission records");
            }
        }//AdmissionDetails Ends
        //Department Wise Seat Availabilty
        public static void DepartmentWiseSeatAvailability()
        {
            // Need to show all department details
            Console.WriteLine($"|DepartmentID|DepartmentName|NumberOfSeats|");
            foreach (DepartmentDetails department in departmentList)
            {
                if (department.NumberOfSeats > 0)
                {
                    Console.WriteLine($"| {department.DepartmentID,-10}|{department.DepartmentName,-10}|{department.NumberOfSeats,-10}|");
                }
            }
        } //Department Wise Seat Availability Ends
        //Adding default data
        public static void AddDefaultData()
        {
            StudentDetails student1 = new StudentDetails("Ravichandran E", "Ettaparajan", new DateTime(1999, 11, 11), Gender.Male, 95, 95, 95);
            StudentDetails student2 = new StudentDetails("Baskaran S", "Sethurajan", new DateTime(1999, 11, 11), Gender.Male, 95, 95, 95);
            studentList.AddRange(new List<StudentDetails> { student1, student2 });
            DepartmentDetails dept1 = new DepartmentDetails("EEE", 29);
            DepartmentDetails dept2 = new DepartmentDetails("CSE", 29);
            DepartmentDetails dept3 = new DepartmentDetails("MECH", 30);
            DepartmentDetails dept4 = new DepartmentDetails("ECE", 30);
            departmentList.AddRange(new List<DepartmentDetails> { dept1, dept2, dept3, dept4 });
            AdmissionDetails admissionDetail1 = new AdmissionDetails("SF3001", "DID101", new DateTime(2022, 05, 11), AdmissionStatus.Booked);
            AdmissionDetails admissionDetail2 = new AdmissionDetails("SF3002", "DID102", new DateTime(2022, 05, 12), AdmissionStatus.Booked);
            admissionList.AddRange(new List<AdmissionDetails> { admissionDetail1, admissionDetail2 });
        }//Default data ends


    }
}