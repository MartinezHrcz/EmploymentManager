using System.Runtime.InteropServices.JavaScript;
using System.Threading.Channels;

namespace EmployementManager.App.Utils;

public class EmployeeManager
{
    static private List<Employee> employees { get; } = new List<Employee>();
    
    private static readonly string[] EMPLOYEE_MENU = new[]
    {
        "1.Show Employees",
        "2.Add Employee",
        "3.Delete Employee",
        "4.Update Employee",
        "5.Back to Main Menu"
    };

    public static void Menu()
    {
        string input = "";
        do
        { 
            Console.Clear();
            MenuWriter.Show(EMPLOYEE_MENU); 
            input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    employees.ForEach(x=> Console.WriteLine(x.toString()));
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    break;
                case "2":
                    employees.Add(AddEmployee());
                    break;
                case "3":
                    employees.Remove(SelectEmployee());
                    break;
                case "4":
                    
                    break;
                case "5":
                    break;
            }
        } while (input.Trim() != "5");
        
        
    }

    private static Employee AddEmployee()
    {
        Console.WriteLine("New employee data:");
        Console.Write("Employee name: ");
        string name = Console.ReadLine();
        
        Console.Write("Employee age: ");
        string birthinput = Console.ReadLine();
        DateOnly birthdate;
        bool isValidAge = false;
        do
        { 
            isValidAge = DateOnly.TryParse(birthinput, out birthdate);
        } while (isValidAge == false);

        Console.WriteLine("Salary: ");
        decimal salary = Convert.ToDecimal(Console.ReadLine());
        
        Console.Write("Department: ");
        string department = Console.ReadLine();
        
        Employee tmp = new Employee(name, department, salary, birthdate);
        return tmp;
    }

    private static Employee SelectEmployee()
    {
        Console.WriteLine("Employees: ");
        employees.ForEach(x => Console.WriteLine(x.toString()));
        Console.Write("Employee name: ");
        string name = Console.ReadLine();
        return employees.Where(x=>x.Name.ToUpper() == name.Trim().ToUpper()).First();
    }
}