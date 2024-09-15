using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidVaccination
{
    public enum VaccineName { Covishield, Covaccine }
    public class Vaccine
    {
        private static int s_vaccineID = 2000;
        //property
        public string VaccineID { get; } //Read-only property
        public VaccineName VaccineName { get; set; }
        public int NoOfDoseAvailable { get; set; }
        //Constructor
        public Vaccine(VaccineName vaccineName, int noOfDoseAvailable)
        {
            VaccineID = "CID" + ++s_vaccineID;
            VaccineName = vaccineName;
            NoOfDoseAvailable = noOfDoseAvailable;
        }

    }
}