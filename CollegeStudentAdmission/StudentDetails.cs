using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeStudentAdmission
{
    /// <summary>
    /// DataType Gender used to select a instance of <see cref="StudentDetails" /> Gender Information 
    /// </summary>
    public enum Gender { Select, Male, Female, Other }
    //class
    /// <summary>
    /// Class StudentDetails used to create instance for student <see cref="StudentDetails" />
    /// Refer documentation on <see href="www.syncfusion.com"/> 
    /// </summary>
    class StudentDetails
    {
        /// <summary>
        /// Static field s_studentID used to autoincrement StudentID of the instance of <see cref="StudentDetails" />
        /// </summary>
        private static int s_studentID = 3000; //Field to Auto increment the ID
        /// <summary>
        /// Student ID property used to hold a Student's ID of instance of <see cref="StudentDetails" />
        /// </summary>
        public string StudentID { get; } //Read-only property
        /// <summary>
        /// Stduent Name property used to hold the full name of a instance of <see cref="StudentDetails" />
        /// </summary
        public string StudentName { get; set; }
        /// <summary>
        /// Father name property used to hold the Father's name of a instance of <see cref="StudentDetails" />
        /// </summary>
        public string FatherName { get; set; }
        /// <summary>
        /// DOB property us used to hold the DAte Of Birth of the student of a instance of <see cref="StudentDetails" />
        /// </summary>
        /// <value>This property gets DOB in dd/MM/yyyy format. Example: 31/12/2022</value>
        public DateTime DOB { get; set; }
        /// <summary>
        /// This property holds Gender enumeration type of a instance of <see cref="StudentDetails" />
        /// </summary>
        /// <value>Only accepts  Male, Female, Other values.</value>
        public Gender Gender { get; set; }
        /// <summary>
        /// This property holds decimal value of Physics marks of a instance of <see cref="StudentDetails" />
        /// </summary>
        /// <value>Value Between 0 to 100.</value>
        public double Physics { get; set; }
        /// <summary>
        /// This property holds decimal value of Chemistry marks of a instance of <see cref="StudentDetails" />
        /// </summary>
        /// <value>Value Between 0 to 100.</value>
        public double Chemistry { get; set; }
        /// <summary>
        /// This property holds decimal value of Maths marks of a instance of <see cref="StudentDetails" />
        /// </summary>
        /// <value>Value Between 0 to 100.</value>
        public double Maths { get; set; }
        //Default constructor
        /// <summary>
        /// Default constructor used to initialize default value to its properties.
        /// </summary>
        public StudentDetails(){
            Console.WriteLine($"Initializing values");
        }
        //creating student details with user input values
        //Paramterized constructor
        /// <summary>
        /// Constructor StudentDetails used to initialize paramter values to its properties.
        /// </summary>
        /// <param name="studentName">studentName parameter used to assign its value to associated property</param>
        /// <param name="fatherName">fatherName parameter used to assign its value to associated property</param>
        /// <param name="dob">dob parameter used to assign its value to associated property</param>
        /// <param name="gender">gender parameter used to assign its value to associated property</param>
        /// <param name="physics">physics parameter used to assign its value to associated property</param>
        /// <param name="chemistry">chemistry parameter used to assign its value to associated property</param>
        /// <param name="maths">maths parameter used to assign its value to associated property</param> 
        public StudentDetails(string studentName, string fatherName, DateTime dob, Gender gender,
                double physics, double chemistry, double maths)
        {
            StudentID = "SF" + ++s_studentID;
            StudentName = studentName;
            FatherName = fatherName;
            DOB = dob;
            Gender = gender;
            Physics = physics;
            Chemistry = chemistry;
            Maths = maths;
        }
        //Methods
        /// <summary>
        /// Method CheckEligibility used to calculate average mark score of instance of <see cref="StudentDetails" />
        /// </summary>
        /// <param name="total">total marks of Physics, Chemistry and Maths to calculate cutOff</param>
        /// <returns>Return true if eligible, else false.</returns>
        public static bool CheckEligibility(double total)
        {
            return total / 3 >= 75;
        }
        /// <summary>
        /// Method ShowDetails used to show the student instance of <see cref="StudentDetails" />
        /// </summary>
        /// <param name="student">This student object is used to show the student details.</param>
        public static void ShowDetails(StudentDetails student)
        {
            Console.WriteLine("Student detail is listed below");
            Console.WriteLine($"Student ID : {student.StudentID}");
            Console.WriteLine($"Student Name : {student.StudentName}");
            Console.WriteLine($"Father Name : {student.FatherName}");
            Console.WriteLine($"Date Of Birth : " + student.DOB.ToString("dd/MM/yyyy"));
            Console.WriteLine($"Gender : {student.Gender}");
            Console.WriteLine($"Physics Mark : {student.Physics}");
            Console.WriteLine($"Chemistry Mark : {student.Chemistry}");
            Console.WriteLine($"Maths Mark: {student.Maths}");
            Console.ReadKey();
        }
    }


}