using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAdmission
{
    public enum AdmissionStatus { Select, Booked, Cancelled }
    public class AdmissionDetails
    {
        //Static private field
        private static int s_admissionID = 1000;
        //property
        public string AdmissionID { get; } //Read-Only property
        public string StudentID { get; set; }
        public string DepartmentID { get; set; }
        public DateTime AdmissionDate { get; set; }
        public AdmissionStatus AdmissionStatus { get; set; }
        //Constructor
        public AdmissionDetails(string studentID, string departmentID, DateTime admissionDate, AdmissionStatus admissionStatus)
        {
            AdmissionID = "AID" + ++s_admissionID; // Auto increment
            StudentID = studentID;
            DepartmentID = departmentID;
            AdmissionDate = admissionDate;
            AdmissionStatus = admissionStatus;
        }

    }
}