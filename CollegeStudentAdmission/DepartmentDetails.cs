using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CollegeStudentAdmission
{
    //class
    /// <summary>
    /// Class DepartmentDetails used to create instance for student <see cref="DepartmentDetails" />
    /// Refer documentation on <see href="www.syncfusion.com"/> 
    /// </summary>
    public class DepartmentDetails
    {
        /// <summary>
        /// Static field s_departmentID used to autoincrement DepartmentID of the instance of <see cref="DepartmentDetails" />
        /// </summary>
        private static int s_departmentID = 100; //Filed to auto increment  ID
        /// <summary>
        /// Department ID property used to hold a Department's ID of instance of <see cref="DepartmentDetails" />
        /// </summary>
        public string DepartmentID { get; } //Read-only property
        /// <summary>
        /// Department Name property used to hold the Department name of a instance of <see cref="DepartmentDetails" />
        /// </summary>
        public string DepartmentName { get; set; }
        /// <summary>
        /// Number of seats property used to hold the numebr of seats of a instance of <see cref="DepartmentDetails" />
        /// </summary>
        /// <value> Number of seat should be greater than 0.</value>
        public int NumberOfSeats { get; set; }
        //creating department details 
        /// <summary>
        /// This parameterized constructor is used to assign the values to respective properties of instance of <see cref="DepartmentDetails" />
        /// </summary>
        /// <param name="departmentName">departmentName parameter is used to assign value to its property </param>
        /// <param name="NumberOfSeats"> numberOfSeats parameter is used to assign value to its property</param>
        public DepartmentDetails(string departmentName, int numberOfSeats)
        {
            DepartmentID = "DID" + ++s_departmentID;
            DepartmentName = departmentName;
            NumberOfSeats = numberOfSeats;
        }
        /// <summary>
        /// Method DepartmentWiseSeatAvailability used to show the department instance of <see cref="DepartmentDetails" />
        /// </summary>
        /// <param name="departmentDetails">This department details list is used to show all the departments in the list.</param>
        public static void DepartmentWiseSeatAvailability(List<DepartmentDetails> departmentDetails)
        {
            int i;
            Console.WriteLine("Department ID\tDepartment Name\t  Number of Seats");
            for (i = 0; i < departmentDetails.Count; i++)
            {
                Console.WriteLine($"  {departmentDetails[i].DepartmentID}\t\t{departmentDetails[i].DepartmentName}\t\t{departmentDetails[i].NumberOfSeats}");
            }
        }
    }
}