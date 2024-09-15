using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidVaccination
{
    public static class Operations
    {
        static Beneficiary currentLoggedInBeneficiary;
        // static lists
        static List<Beneficiary> beneficiaryList = new List<Beneficiary>();
        static List<Vaccination> vaccinationList = new List<Vaccination>();
        static List<Vaccine> vaccineList = new List<Vaccine>();
        public static void MainMenu()
        {
            int mainOption;
            Console.WriteLine($"************Vaccination Drive************");
            do
            {
                Console.WriteLine($"MainMenu\n1.Beneficiary Registration\n2.Login\n3.Get vaccine info\n4.Exit");
                Console.Write($"Select an option : ");
                bool temp = int.TryParse(Console.ReadLine(), out mainOption);
                switch (mainOption)
                {
                    case 1:
                        {
                            Console.WriteLine($"************Beneficiary Registration************");
                            BeneficiaryRegistration();
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine($"************Login************");
                            Login();
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine($"************Get Vaccine Info************");
                            GetVaccineInfo();
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
            } while (mainOption != 4);
        }
        public static void BeneficiaryRegistration()
        {
            Console.Write($"Enter Full Name : ");
            string name = Console.ReadLine();
            int age = 0;
            bool temp;
            Gender gender;
            string mobileNumber, city;
            if (string.IsNullOrEmpty(name))
            {
                Console.WriteLine($"Name can't be empty");
            }
            else
            {
                Console.Write($"Enter your age :");
                temp = int.TryParse(Console.ReadLine(), out age);
                if (!temp || age < 1)
                {
                    Console.WriteLine($"Enter valid age");
                }
                else
                {
                    Console.Write($"Enter your Gender (Male/Female/Transgender) : ");
                    temp = Enum.TryParse<Gender>(Console.ReadLine(), true, out gender);
                    if (!temp)
                    {
                        Console.WriteLine($"Enter Valid gender");
                    }
                    else
                    {
                        Console.Write("Enter Mobile number : ");
                        mobileNumber = Console.ReadLine();
                        const string phonePattern = "[6-9]{1}[0-9]{9}";
                        System.Text.RegularExpressions.Regex phoneCheck = new System.Text.RegularExpressions.Regex(phonePattern);
                        if (!phoneCheck.IsMatch(mobileNumber))
                        {
                            Console.WriteLine("Enter valid mobile number ");
                            temp = true;
                        }
                        else
                        {
                            Console.Write($"Enter city :");
                            city = Console.ReadLine();
                            if (string.IsNullOrEmpty(city))
                            {
                                Console.WriteLine($"Enter valid city name");
                            }
                            else
                            {
                                Beneficiary beneficiary1 = new Beneficiary(name, age, gender, mobileNumber, city);
                                beneficiaryList.Add(beneficiary1);
                                Console.WriteLine($"Beneficiary Registered successfully. Beneficiary ID is {beneficiary1.RegistrationNumber}.");
                            }
                        }
                    }
                }
            }
        }
        public static void Login()
        {
            Console.Write($"Enter Beneficiary ID to Login : ");
            string loginID = Console.ReadLine().ToUpper();

            bool flag = true;
            foreach (Beneficiary beneficiary in beneficiaryList)
            {
                if (loginID.Equals(beneficiary.RegistrationNumber))
                {
                    flag = false;

                    currentLoggedInBeneficiary = beneficiary;
                    Console.WriteLine($"Logged in Successfully");
                    SubMenu();
                    break;
                }
            }
            if (flag)
            {
                Console.WriteLine($"Beneficiary ID is Invalid or not present");
            }
        }
        public static void SubMenu()
        {
            int subOption;
            do
            {
                Console.WriteLine($"****************SubMenu****************");
                Console.WriteLine("Select an option\n1.Show My Details\n2.Take Vaccination\n3.My Vaccination History\n4.Next Due date\n5.Exit");
                Console.Write("Enter your option : ");
                bool temp = int.TryParse(Console.ReadLine(), out subOption);
                switch (subOption)
                {
                    case 1:
                        {
                            Console.WriteLine($"**********Show My Details**********");
                            ShowMyDetails();
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine($"**********Take Vaccination**********");
                            TakeVaccination();
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine($"**********My Vaccination History**********");
                            MyVaccinationHistory();
                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine($"**********Next Due date**********");
                            NextDueDate();
                            break;
                        }
                    case 5:
                        {
                            Console.WriteLine($"Taking back to Main Menu");
                            break;
                        }
                }
            } while (subOption != 5);
        }
        public static void ShowMyDetails()
        {
            Console.WriteLine($"Your Name : {currentLoggedInBeneficiary.Name}");
            Console.WriteLine($"Age : {currentLoggedInBeneficiary.Age}");
            Console.WriteLine($"Gender : {currentLoggedInBeneficiary.Gender}");
            Console.WriteLine($"Mobile Number : {currentLoggedInBeneficiary.MobileNumber}");
            Console.WriteLine($"City : {currentLoggedInBeneficiary.City}");
        }
        public static void TakeVaccination()
        {
            GetVaccineInfo();
            Console.Write($"Enter Vaccine ID : ");
            string vaccineID = Console.ReadLine().ToUpper();
            bool temp = true;
            foreach (Vaccine vaccine in vaccineList)
            {
                if (vaccine.VaccineID.Equals(vaccineID))
                {
                    temp = false;
                    int dose = 0;
                    foreach (Vaccination vaccination in vaccinationList)
                    {
                        if (vaccination.RegistrationNumber.Equals(currentLoggedInBeneficiary.RegistrationNumber))
                        {
                            dose++;
                        }
                    }
                    if (dose == 0)
                    {
                        if (currentLoggedInBeneficiary.Age > 14)
                        {
                            Vaccination newVaccination = new Vaccination(currentLoggedInBeneficiary.RegistrationNumber, vaccine.VaccineID, DoseNumber.I, DateTime.Now);
                            vaccinationList.Add(newVaccination);
                            vaccine.NoOfDoseAvailable--;
                            Console.WriteLine($"Vaccinated {vaccine.VaccineName} of dose {newVaccination.DoseNumber} successfully.");
                            break;
                        }
                        else
                        {
                            Console.WriteLine($"Beneficiary is not eligible because of age restriction Greater than 14.");
                            break;
                        }
                    }
                    else if (dose == 3)
                    {
                        Console.WriteLine($"All the three Vaccination are completed, you cannot be vaccinated now");
                        break;
                    }
                    else
                    {
                        foreach (Vaccination vaccination in vaccinationList)
                        {
                            if (vaccination.RegistrationNumber.Equals(currentLoggedInBeneficiary.RegistrationNumber))
                            {
                                if (vaccination.DoseNumber.Equals(DoseNumber.I) && dose == 1)
                                {
                                    if (vaccination.VaccineID.Equals(vaccineID))
                                    {
                                        TimeSpan span = DateTime.Now - vaccination.VaccinatedDate;
                                        if ((int)span.TotalDays > 30)
                                        {
                                            Vaccination newVaccination = new Vaccination(currentLoggedInBeneficiary.RegistrationNumber, vaccine.VaccineID, DoseNumber.II, DateTime.Now);
                                            vaccinationList.Add(newVaccination);
                                            vaccine.NoOfDoseAvailable--;
                                            Console.WriteLine($"Vaccinated {vaccine.VaccineName} of dose {newVaccination.DoseNumber} successfully.");
                                            break;
                                        }
                                        else
                                        {
                                            Console.WriteLine($"30 days not completed from previous vaccination.");
                                            break;
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine($"You have selected different vaccine from previous vaccine. You can't vaccine With {vaccine.VaccineName}");
                                        break;
                                    }
                                }
                                else if (vaccination.DoseNumber.Equals(DoseNumber.II) && dose == 2)
                                {
                                    if (vaccination.VaccineID.Equals(vaccineID))
                                    {
                                        TimeSpan span = DateTime.Now - vaccination.VaccinatedDate;
                                        if ((int)span.TotalDays > 30)
                                        {
                                            Vaccination newVaccination = new Vaccination(currentLoggedInBeneficiary.RegistrationNumber, vaccine.VaccineID, DoseNumber.III, DateTime.Now);
                                            vaccinationList.Add(newVaccination);
                                            vaccine.NoOfDoseAvailable--;
                                            Console.WriteLine($"Vaccinated {vaccine.VaccineName} of dose {newVaccination.DoseNumber} successfully.");
                                            break;
                                        }
                                        else
                                        {
                                            Console.WriteLine($"30 days not completed from previous vaccination.");
                                            break;
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine($"You have selected different vaccine from previous vaccine. You can't vaccine With {vaccine.VaccineName}2");
                                        break;
                                    }
                                }
                            }
                        }
                    }

                }
            }
            if (temp)
            {
                Console.WriteLine($"Enter valid Vaccine ID");
            }
        }
        public static void MyVaccinationHistory()
        {
            bool temp = false;
            foreach (Vaccination vaccination in vaccinationList)
            {
                if (vaccination.RegistrationNumber.Equals(currentLoggedInBeneficiary.RegistrationNumber))
                {
                    temp = true;
                    break;
                }
            }
            if (temp)
            {
                string line = "------------------------------------------------------------";
                Console.WriteLine(line);
                Console.WriteLine($"|{"Vaccination ID",-15}|{"Vaccine ID",-13}|{"Dose Number",-12}|{"Vaccinated Date",-15}|");
                Console.WriteLine(line);
                foreach (Vaccination vaccination in vaccinationList)
                {
                    if (vaccination.RegistrationNumber.Equals(currentLoggedInBeneficiary.RegistrationNumber))
                    {
                        Console.WriteLine($"|{vaccination.VaccinationID,-15}|{vaccination.VaccineID,-13}|      {vaccination.DoseNumber,-6}|{vaccination.VaccinatedDate.ToString("dd/MM/yyyy"),-15}|");
                        Console.WriteLine(line);
                    }
                }
            }
            else
            {
                Console.WriteLine($"Beneficiary hasn't taken any vacccinations.");
            }
        }
        public static void NextDueDate()
        {
            int dose = 0;

            foreach (Vaccination vaccination in vaccinationList)
            {
                if (vaccination.RegistrationNumber.Equals(currentLoggedInBeneficiary.RegistrationNumber))
                {
                    dose++;
                }
            }

            if (dose == 0)
            {
                Console.WriteLine("you can take vaccine now");
            }
            else if (dose == 3)
            {
                Console.WriteLine($"You have completed all vaccination. Thanks for your participation in the vaccination drive.");
            }
            foreach (Vaccination vaccination in vaccinationList)
            {
                if (vaccination.RegistrationNumber.Equals(currentLoggedInBeneficiary.RegistrationNumber))
                {
                    if ((vaccination.DoseNumber.Equals(DoseNumber.I) && dose == 1) || (vaccination.DoseNumber.Equals(DoseNumber.II) && dose == 2))
                    {
                        Console.WriteLine($"Next due date for vaccination will be after {vaccination.VaccinatedDate.AddDays(30).ToString("dd/MM/yyyy")}.");
                        break;
                    }
                }
            }
        }
        public static void GetVaccineInfo()
        {
            bool temp = false;
            foreach (Vaccine vaccine in vaccineList)
            {
                if (vaccine.NoOfDoseAvailable > 0)
                {
                    temp = true;
                    break;
                }
            }
            if (temp)
            {
                string line = "--------------------------------------------------";
                Console.WriteLine(line);
                Console.WriteLine($"|{"Vaccine ID",-13}|{"Vaccine Name",-13}|{"No Of Dose Available",-20}|");
                Console.WriteLine(line);
                foreach (Vaccine vaccine in vaccineList)
                {
                    if (vaccine.NoOfDoseAvailable > 0)
                    {
                        Console.WriteLine($"|{vaccine.VaccineID,-13}|{vaccine.VaccineName,-13}|{vaccine.NoOfDoseAvailable,-20}|");
                        Console.WriteLine(line);
                    }
                }
            }
            else
            {
                Console.WriteLine($"There are no vaccines available.");
            }
        }
        public static void AddDefaultData()
        {
            Beneficiary beneficiary1 = new Beneficiary("Ravichandran", 21, Gender.Male, "8484484", "Chennai");
            Beneficiary beneficiary2 = new Beneficiary("Baskaran", 22, Gender.Male, "8484747", "Chennai");
            beneficiaryList.Add(beneficiary1);
            beneficiaryList.Add(beneficiary2);
            Vaccine vaccine1 = new Vaccine(VaccineName.Covishield, 50);
            Vaccine vaccine2 = new Vaccine(VaccineName.Covaccine, 50);
            vaccineList.Add(vaccine1);
            vaccineList.Add(vaccine2);
            Vaccination vaccination1 = new Vaccination("BID1001", "CID2001", DoseNumber.I, new DateTime(2021, 11, 11));
            Vaccination vaccination2 = new Vaccination("BID1001", "CID2001", DoseNumber.II, new DateTime(2022, 03, 11));
            Vaccination vaccination3 = new Vaccination("BID1002", "CID2002", DoseNumber.I, new DateTime(2022, 04, 04));
            vaccinationList.Add(vaccination1);
            vaccinationList.Add(vaccination2);
            vaccinationList.Add(vaccination3);
        }
    }
}