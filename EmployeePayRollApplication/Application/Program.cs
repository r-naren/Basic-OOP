using System;
using System.Collections.Generic;
namespace Application;
using EmployeeLibrary;
class Program
{
    public static void Main(string[] args)
    {
        bool temp = true;
        
        Gender gender = Gender.Male;
        List<EmployeePayroll> employeePayrolls = new List<EmployeePayroll>();
        DateTime date = new DateTime(2024, 03, 20);
        string wrongInput = "!!!!!!!!!!!!!! ";
        do
        {
            if(!temp){
                Console.WriteLine($"{wrongInput} Enter valid gender");
            }
            Console.Write("Enter Gender : Male, Female, Other : ");
            temp = Enum.TryParse<Gender>(Console.ReadLine(), true, out gender);
        } while (!temp);

        EmployeePayroll employee = new EmployeePayroll("Ram", "Developer", WorkLocation.Chennai, "TrainingTeam", date, gender, 28, 1);
        Console.WriteLine(employee.Gender);

        Console.WriteLine();
    }

    
}