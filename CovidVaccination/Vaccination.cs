using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidVaccination
{
    public enum DoseNumber { I, II, III}
    public class Vaccination
    {
        private static int s_vaccinationID = 3000;
        //property
        public string VaccinationID { get; } //Read-only property
        public string RegistrationNumber { get; set; }
        public string VaccineID { get; set; }
        public DoseNumber DoseNumber { get; set; }
        public DateTime VaccinatedDate {get;set;}
        //Constructor
        public Vaccination(string registrationNumber, string vaccineID, DoseNumber doseNumber, DateTime vaccinatedDate)
        {
            VaccinationID = "VID" + ++s_vaccinationID;
            RegistrationNumber = registrationNumber;
            VaccineID = vaccineID;
            DoseNumber = doseNumber;
            VaccinatedDate = vaccinatedDate;
        }
    }
}