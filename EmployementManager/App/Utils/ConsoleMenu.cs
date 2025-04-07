using System.Formats.Tar;

namespace EmployementManager.App.Utils;
using EmployementManager;

public class ConsoleMenu
{
    static List<Employee> employees = new List<Employee>();
    private static readonly string[] MENU_POINTS = new[]
    {
        "1.Manage Employees",
        "2.Manage Managers",
        "3.Exit",
    };

    public static void DisplayMainMenu()
    {
        
        Console.Clear();
        Console.WriteLine("Choose an option:");
        MENU_POINTS.ToList().ForEach(Console.WriteLine);
        MenuInput();
    }

    public static void MenuInput()
    {
        string input = "";
        do
        {
            input = Console.ReadLine();
            input.Replace(" ", "");
            switch (input)
            {
                case "1":
                    employees.Add(EmployeeManager.AddEmployee());
                    employees.ForEach(employee =>Console.WriteLine(employee.Name));
                    break;
                case "2":
                    break;
                case "3":
                    Console.WriteLine("Exiting...");
                    break;
            }
        } while (input != "3");
    }

}