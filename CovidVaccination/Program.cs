using System;
namespace CovidVaccination;
class Program{
    public static void Main(string[] args)
    {
        Operations.AddDefaultData();

        Operations.MainMenu();
    }
}