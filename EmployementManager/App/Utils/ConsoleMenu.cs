using System.Formats.Tar;

namespace EmployementManager.App.Utils;

using System.Diagnostics;
using EmployementManager;

public class ConsoleMenu
{
    static private List<Employee> employees = new List<Employee>();
    static private List<Manager> managers = new List<Manager>();
    static private bool exit = false;
    private static readonly string[] MENU_POINTS = new[]
    {
        "1.Manage Employees",
        "2.Manage Managers",
        "3.Exit",
    };

    public static void DisplayMainMenu()
    {
        do{
            Console.Clear();
            Console.WriteLine("Choose an option:");
            MENU_POINTS.ToList().ForEach(Console.WriteLine);
            MenuInput();
        }
        while(!exit);
        {
            Console.WriteLine("Exiting...");
        }

    }

    public static void MenuInput()
    {
        
        string input = "";

        input = Console.ReadLine();
        input.Replace(" ", "");
        switch (input)
        {
            case "1":
                employees.ForEach(employee =>Console.WriteLine(employee.Name));
                break;
            case "2":
                break;
            case "3":
                exit = true;
                break;
        }
    }

}