using System;
using System.Dynamic;
using System.Runtime.CompilerServices;
namespace EBBillCalculation;

class EBUser

{
    private static int s_billId  = 100; //field
    private static int s_userId = 1000;
    public string UserId { get; } //property
    public string UserName { get; set; }
    public string PhoneNumber { get; set; }
    public string MailId { get; set; }
    public int UnitsUsed { get; set; }
    
    public EBUser()
    {
        Console.WriteLine("Enter EB User Details : ");
        
    }
    public EBUser(string userName, string phoneNumber, string mailId)
    {
        UserId = "EB" + ++s_userId;
        UserName = userName;
        PhoneNumber = phoneNumber;
        MailId = mailId;
        UnitsUsed = 0;
    }
    public static void CalculateAmount(EBUser ebUser){
        //units used
        bool temp;
        int unitsUsed;
        do
        {
            Console.Write("Enter number of units used : ");
            temp = int.TryParse(Console.ReadLine(), out unitsUsed);
            if (!temp || unitsUsed < 0 )
            {
                Console.WriteLine("!!!!!!!!!!! Enter valid number of units");
            }
        } while (!temp || unitsUsed < 0 );
       
        ebUser.UnitsUsed = unitsUsed;
        Console.WriteLine("EB BILL Generated ...");
        Console.WriteLine($"Bill ID : B{++s_billId}");
        Console.WriteLine($"User ID : {ebUser.UserId}");
        Console.WriteLine($"UserName : {ebUser.UserName}");
        Console.WriteLine($"Units Used : {ebUser.UnitsUsed}");
        Console.WriteLine($"Amount need to pay : {ebUser.UnitsUsed*5}");
        Console.ReadKey();
    }
    public static void Display(EBUser ebUser){
        Console.WriteLine("EBUser detail is listed below");
        Console.WriteLine($"User ID : {ebUser.UserId}");
        Console.WriteLine($"UserName : {ebUser.UserName}");
        Console.WriteLine($"PhoneNumber : {ebUser.PhoneNumber}");
        Console.WriteLine($"Mail Id : {ebUser.MailId}");
        Console.WriteLine($"Units Used : {ebUser.UnitsUsed}");
        Console.ReadKey();
    }
    
}