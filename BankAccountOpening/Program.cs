using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Formats.Tar;
using System.Globalization;
using System.Runtime.CompilerServices;
namespace BankAccountOpening;


public class BankAccount
{
    
    public string CustomerId { get; set; }
    public string CustomerName { get; set; }
    public double Balance { get; set; }
    public Sex Gender { get; set; }
    public string PhoneNo { get; set; }
    public string MailId { get; set; }
    public DateTime DateOfBirth { get; set; }

}
public enum Sex
{
    male = 1,
    female,
    other
}
class Program
{

    public static List<BankAccount> bankAccounts = new List<BankAccount>();
    public static void Main(string[] args)
    {

        int choice = 0;
        bool exit = false;
        do
        {
            Console.WriteLine("----------------------MAIN MENU----------------------");
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
                        choice = -1;
                        exit = true;
                        break;
                    }
                default:
                    {
                        Console.WriteLine($"!!!!!!!!!!! Enter a valid choice !!!!!!!!!!");
                        break;
                    }
            }
        } while (!exit || choice >= 0);

    }

    //user registration
    public static void Registration()
    {
        bool isPresent = false;
        bool isInvalid = false;
        //declaration
        string customerId;
        string customerName;
        double balance;
        string gender;
        string phoneNo;
        string mailId;
        DateTime dateOfBirth;
        do
        {
            isPresent = false;
            Console.Write("Enter Customer Id : ");
            customerId = Console.ReadLine().ToUpper();
            //input cannot be empty
            if (!string.IsNullOrEmpty(customerId))
            {
                isInvalid = false;
                //checking if customer id is already present
                foreach (BankAccount account in bankAccounts)
                {
                    if (account.CustomerId == customerId)
                    {
                        Console.WriteLine("!!!!!!!!!!! Customer Id is already present !!!!!!!!!!!");
                        isPresent = true;
                        break;
                    }
                }
            }
            else
            {
                Console.WriteLine($"!!!!!!!!Customer Id can't be empty");
                isInvalid = true;
            }
        } while (isPresent || isInvalid);

        do
        {
            Console.Write("Enter Customer Name : ");
            customerName = Console.ReadLine();
            if (!string.IsNullOrEmpty(customerName))
            {
                isInvalid = false;
            }
            else
            {
                Console.WriteLine($"!!!!!!Customer name can't be empty");
                isInvalid = true;
            }
        } while (isInvalid);

        do
        {
            Console.Write("Enter balance : ");
            isPresent = double.TryParse(Console.ReadLine(), out balance);
            if(!isPresent){
                Console.WriteLine($"!!!!!!!! Enter valid balance amount");
            }
            if (balance < 0)
            {
                Console.WriteLine($"!!!!!!!! Balance should not be negative !!!!!!!");
            }
            
        } while (balance < 0 || !isPresent);

        do
        {
            isInvalid = false;
            Console.Write("Enter gender (male, female, other) : ");
            gender = Console.ReadLine();
            if (!string.IsNullOrEmpty(gender))
            {
                isInvalid = false;
                if (gender != "male" && gender != "female" && gender != "other")
                {
                    Console.WriteLine("!!!!!!!!!!! Enter valid gender !!!!!!!!!!!");
                    isInvalid = true;
                }
            }
            else
            {
                Console.WriteLine($"!!!!!!Customer Gender can't be empty");
                isInvalid = true;
            }
        } while (isInvalid);

        do
        {
            Console.Write("Enter Phone number : ");
            phoneNo = Console.ReadLine();
            const string phonePattern = "[6-9]{1}[0-9]{9}";
            if (!string.IsNullOrEmpty(phoneNo))
            {
                isInvalid = false;
                System.Text.RegularExpressions.Regex phoneCheck = new System.Text.RegularExpressions.Regex(phonePattern);
                if (!phoneCheck.IsMatch(phoneNo))
                {
                    Console.WriteLine($"!!!!!!!! Enter valid mobile number");
                    isInvalid = true;
                }
            }
            else
            {
                isInvalid = true;
            }
        } while (isInvalid);

        do
        {
            Console.Write("Enter Mail Id : ");
            mailId = Console.ReadLine();
            const string mailPattern = @"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.]+\.[A-Za-z]{2,5}$";
            if (!string.IsNullOrEmpty(mailId))
            {
                isInvalid = false;
                System.Text.RegularExpressions.Regex mailCheck = new System.Text.RegularExpressions.Regex(mailPattern);
                if (!mailCheck.IsMatch(mailId))
                {
                    Console.WriteLine($"!!!!!!!!!!! Enter valid mail Id");
                    isInvalid = true;
                }
            }
            else
            {
                isInvalid = true;
            }
        } while (isInvalid);


        isPresent = false;

        do
        {
            Console.Write("Enter Date of Birth in \"DD/MM/YYY\" format : ");
            isPresent = DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dateOfBirth);
            DateTime today = DateTime.Now;
            TimeSpan span = today - dateOfBirth;
            if (!isPresent || (int)span.TotalDays/365 < 18)
            {
                Console.WriteLine($"!!!!!!! Enter valid date of birth !!!!!!!!");
            }
        } while (!isPresent);
        //creating account
        bankAccounts.Add(new BankAccount() { CustomerId = customerId, CustomerName = customerName, Balance = balance, Gender = (Sex)Enum.Parse(typeof(Sex), gender), PhoneNo = phoneNo, MailId = mailId, DateOfBirth = dateOfBirth });
        Console.WriteLine("Registration completed........");
        Console.WriteLine($"Customer Id: {bankAccounts[bankAccounts.Count - 1].CustomerId} ");
        Console.WriteLine($"Customer Name: {bankAccounts[bankAccounts.Count - 1].CustomerName} ");
        Console.WriteLine($"Balance: {bankAccounts[bankAccounts.Count - 1].Balance} ");
        Console.WriteLine($"Gender: {(Sex)bankAccounts[bankAccounts.Count - 1].Gender} ");
        Console.WriteLine($"Phone Number: {bankAccounts[bankAccounts.Count - 1].PhoneNo} ");
        Console.WriteLine($"Mail Id: {bankAccounts[bankAccounts.Count - 1].MailId} ");
        Console.WriteLine($"Date Of Birth: {bankAccounts[^1].DateOfBirth.ToString("dd/MM/yyyy")} ");

    }

    public static void Login()
    {
        bool isPresent = false;
        //checking if customer id is already present
        string customerId = "";
        BankAccount temp;
        do
        {
            isPresent = true;
            Console.Write("Enter Customer Id for login: ");
            customerId = Console.ReadLine().ToUpper();
            temp = bankAccounts.Find(accounts => accounts.CustomerId == customerId);
            if (temp == null)
            {
                isPresent = false;
                Console.WriteLine($"!!!!!!!! Invalid user ID !!!!!!!!!");
            }
        } while (!isPresent);
        LoginOperation(temp);
        Console.WriteLine(temp.CustomerName + temp.CustomerId + temp.DateOfBirth);
    }
    public static void LoginOperation(BankAccount temp)
    {
        Console.WriteLine($"Welcome {temp.CustomerName} ....");
        int choice = 0;
        bool exit = false;
        do
        {
            Console.WriteLine("----------------------SUB MENU----------------------");
            Console.WriteLine("1.Deposit\n2.Withdraw\n3.Balance check\n4.Exit");
            Console.Write("Enter any of the above mentioned choices : ");
            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    {
                        Deposit(temp);
                        break;
                    }
                case 2:
                    {
                        Withdraw(temp);
                        break;
                    }
                case 3:
                    {
                        BalanceCheck(temp);
                        break;
                    }
                case 4:
                    {
                        choice = -1;
                        exit = true;
                        break;
                    }
                default:
                    {
                        Console.WriteLine($"!!!!!!!!!!! Enter a valid choice !!!!!!!!!!");
                        break;
                    }
            }
        } while (!exit || choice >= 0);
    }
    public static void Deposit(BankAccount user)
    {

        double deposit;
        do
        {
            Console.Write("Enter deposit amount : ");
            deposit = double.Parse(Console.ReadLine());
            if (deposit < 0)
            {
                Console.WriteLine($"!!!!!!!! Deposit amount should not be negative !!!!!!!");
            }
        } while (deposit < 0);
        user.Balance += deposit;
    }
    public static void Withdraw(BankAccount user)
    {
        double withdraw;
        do
        {
            Console.Write("Enter withdraw amount : ");
            withdraw = double.Parse(Console.ReadLine());
            if (withdraw < 0)
            {
                Console.WriteLine($"!!!!!!!! Withdraw amount should not be negative !!!!!!!");
            }
            if (user.Balance - withdraw < 0)
            {
                Console.WriteLine($"!!!!!!! You have only {user.Balance}. So enter within that range");
            }
        } while (withdraw < 0 || user.Balance - withdraw < 0);
        user.Balance -= withdraw;
    }
    public static void BalanceCheck(BankAccount user)
    {
        Console.WriteLine($"Current Balance for {user.CustomerName}: {user.Balance}");
    }

}