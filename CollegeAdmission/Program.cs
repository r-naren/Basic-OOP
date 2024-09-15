using System;
using System.Runtime.InteropServices;
namespace CollegeAdmission;
class Program{
    public static void Main(string[] args)
    {
        int choice = 0;
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
                        
                        break;
                    }
                case 2:
                    {
                        
                        break;
                    }
                case 3:
                    {
                        Console.WriteLine("Exiting Application .....");
                        break;
                    }
                default:
                    {
                        Console.WriteLine($"!!!!!!!!!!! Enter a valid choice !!!!!!!!!!");
                        break;
                    }
            }
        } while (choice!= 3);

    }
}