using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;
namespace EBBillCalculation;
class Program
{
    public static List<EBUser> ebUsers = new List<EBUser>();
    const string wrongInput = "!!!!!!!!!!!!!! ";
    public static void Main(string[] args)
    {
        int choice = 0;
        Console.WriteLine("---------------------EB BILL CALCULATION--------------------");

        do
        {
            Console.WriteLine("-------------------------MAIN MENU--------------------------");
            Console.WriteLine("1.Registration\n2.Login\n3.Exit");
            Console.Write("Enter any of the above mentioned choices : ");
            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    {
                        Registration();
                        break;
                    }
                case 2:
                    {
                        Login();
                        break;
                    }
                case 3:
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
        } while (choice != 3);
        Console.WriteLine();
    }
    public static void Registration()
    {
        //Declaring registration details variables
        string userName, phoneNumber, mailId;
        bool temp = true;

        //User name
        do
        {
            Console.Write("Enter EB userName : ");
            userName = Console.ReadLine();
            if (string.IsNullOrEmpty(userName))
            {
                Console.WriteLine(wrongInput + " Employee name can't be empty");
            }
        } while (string.IsNullOrEmpty(userName));
        //Phone number
        do
        {
            Console.Write("Enter Phone number : ");
            phoneNumber = Console.ReadLine();
            const string phonePattern = "[6-9]{1}[0-9]{9}";
            if (!string.IsNullOrEmpty(phoneNumber))
            {
                temp = false;
                System.Text.RegularExpressions.Regex phoneCheck = new System.Text.RegularExpressions.Regex(phonePattern);
                if (!phoneCheck.IsMatch(phoneNumber))
                {
                    Console.WriteLine($"!!!!!!!! Enter valid mobile number");
                    temp = true;
                }
            }
            else
            {
                temp = true;
            }
        } while (temp);
        //Mail Id
        do
        {
            Console.Write("Enter Mail Id : ");
            mailId = Console.ReadLine();
            const string mailPattern = @"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.]+\.[A-Za-z]{2,5}$";
            if (!string.IsNullOrEmpty(mailId))
            {
                temp = false;
                System.Text.RegularExpressions.Regex mailCheck = new System.Text.RegularExpressions.Regex(mailPattern);
                if (!mailCheck.IsMatch(mailId))
                {
                    Console.WriteLine($"!!!!!!!!!!! Enter valid mail Id");
                    temp = true;
                }
            }
            else
            {
                temp = true;
            }
        } while (temp);
        
        
        
        //object creation
        EBUser ebUser = new EBUser(userName, phoneNumber, mailId);
        ebUsers.Add(ebUser);
        Console.WriteLine($"Registration completed....");
        Console.WriteLine($"Hai {ebUser.UserName}! Your EB user ID is \x1b[1m{ebUser.UserId}\x1b[0m. Kindly note it and press enter.");
        Console.ReadKey();
    }
    public static void Login()
    {
        bool isPresent = false;
        //checking if user id is already present
        string userId;
        EBUser temp;
        do
        {
            isPresent = true;
            Console.Write("Enter User Id for login: ");
            userId = Console.ReadLine().ToUpper();
            //lambda expression
            temp = ebUsers.Find(e => e.UserId == userId);
            if (temp == null)
            {
                isPresent = false;
                Console.WriteLine(wrongInput + " Invalid user ID");
            }
        } while (!isPresent);
        LoginOperation(temp);
    }
    public static void LoginOperation(EBUser ebUser)
    {
        Console.WriteLine($"Welcome {ebUser.UserName}.....");
        int choice = 0;

        do
        {
            Console.WriteLine("----------------------SUB MENU----------------------");
            Console.WriteLine("1.Calculate Amount\n2.Display user details\n3.Exit");
            Console.Write("Enter any of the above mentioned choices : ");
            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    {
                        EBUser.CalculateAmount(ebUser);
                        break;
                    }
                case 2:
                    {
                        EBUser.Display(ebUser);
                        break;
                    }
                case 3:
                    {
                        Console.WriteLine($"Logging out from {ebUser.UserId}....");
                        break;
                    }
                default:
                    {
                        Console.WriteLine(wrongInput + " Enter a valid choice");
                        break;
                    }
            }
        } while (choice != 3);
    }
    
}
