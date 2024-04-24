using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidVaccination
{
    public enum Gender { Select, Male, Female, Transgender}
    public class Beneficiary
    {
        private static int s_registrationNumber = 1000;
        //property
        public string RegistrationNumber{get;} //Read-only property
        public string Name{get;set;}
        public int Age{get;set;}
        public Gender Gender{get;set;}
        public string MobileNumber{get;set;}
        public string City {get;set;}
        //Constructor
        public Beneficiary(string name, int age, Gender gender, string mobileNumber, string city){
            RegistrationNumber = "BID"+ ++s_registrationNumber;
            Name = name;
            Age = age;
            Gender = gender;
            MobileNumber = mobileNumber;
            City = city;
        }

    }
}