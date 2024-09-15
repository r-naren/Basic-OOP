using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeStudentAdmission
{
    /// <summary>
    /// DataType Admission Status used to select a instance of <see cref="AdmissionDetails" /> Admission Status Information 
    /// </summary>
    public enum AdmissionStatus { Select, Booked, Cancelled }
    //class
    /// <summary>
    /// Class AdmissionDetails used to create instance for Admission <see cref="AdmissionDetails" />
    /// Refer documentation on <see href="www.syncfusion.com"/> 
    /// </summary>
    public class AdmissionDetails
    {
        /// <summary>
        /// Static field s_admissionID used to autoincrement AdmissionID of the instance of <see cref="AdmissionDetails" />
        /// </summary>
        private static int s_admissionID = 3000;
        /// <summary>
        /// Admission ID property used to hold a Admission's ID of instance of <see cref="AdmissionDetails" />
        /// </summary>
        public string AdmissionID { get; } //Read-only property
        /// <summary>
        /// Student ID property used to hold the student ID of a instance of <see cref="AdmissionDetails" />
        /// </summary>
        public string StudentID { get; set; }
        /// <summary>
        /// Department ID property used to hold the department ID of a instance of <see cref="AdmissionDetails" />
        /// </summary>
        public string DepartmentID { get; set; }
        /// <summary>
        /// AdmissionDate property used to hold the Admission ID of a instance of <see cref="AdmissionDetails" />
        /// </summary>
        public DateTime AdmissionDate { get; set; }
        /// <summary>
        /// Admission Status property used to hold the Admission Status of a instance of <see cref="AdmissionDetails" />
        /// </summary>
        public AdmissionStatus AdmissionStatus { get; set; }
        //creating Admission details 
        /// <summary>
        /// This parameterized constructor is used to assign the values to respective properties of instance of <see cref="AdmissionDetails" />
        /// </summary>
        /// <param name="studentID">studentId parameter is used to assign value to its property </param>
        /// <param name="departmentID"> departmentID parameter is used to assign value to its property</param>
        /// <param name="admissionDate">admissionDate parameter is used to assign value to its property</param>
        /// <param name="admissionStatus">admissionStatus parameter is used to assign value to its property</param>
        public AdmissionDetails(string studentID, string departmentID, DateTime admissionDate, AdmissionStatus admissionStatus)
        {
            AdmissionID = "AID" + ++s_admissionID;
            StudentID = studentID;
            DepartmentID = departmentID;
            AdmissionDate = admissionDate;
            AdmissionStatus = admissionStatus;
        }

    }
}