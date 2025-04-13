using System.Runtime.InteropServices.JavaScript;
using System.Threading.Channels;

namespace EmployementManager.App.Utils;

public class EmployeeManager
{
    static private List<Employee> employees = new List<Employee>();
    
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
            Console.Clear();
            switch (input)
            {
                case "1":
                    employees.ForEach(x=> Console.WriteLine(x.toString()));
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                    break;
                case "2":
                    employees.Add(AddEmployee());
                    break;
                case "3":
                    Employee toBeDeleted = SelectEmployee();
                    if (toBeDeleted != null)
                    {
                        employees.Remove(toBeDeleted);
                    }
                    else
                    {
                        Console.WriteLine("\nEmployee not found");
                    }
                    break;
                case "4":
                    updateEmployee(SelectEmployee());
                    break;
                case "5":
                    Console.WriteLine("Back to Main Menu...");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    break;
                default:
                    Console.WriteLine("Invalid input. Try again...");
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
        string id = "EM" + employees.Count().ToString();
        Employee tmp = new Employee(name, department, salary, birthdate);
        return tmp;
    }

    private static Employee SelectEmployee()
    {
        
        if (employees.Count == 0) { return null; }

        Console.WriteLine("Employees: ");
        employees.ForEach(x => Console.WriteLine(x.toString()));
        Console.Write("Employee ID: ");
        string id = Console.ReadLine();
        Employee tmp = employees.Find(x => x.id == id);
        
        return tmp;
    }

    private static void updateEmployee(Employee emp)
    {
        if (emp == null)
        {
            Console.WriteLine("Employee not found");
            return;
        }

        Console.WriteLine("What do you want to update?");
        Console.WriteLine("Name = n \n Birthdate: b \n Salary: s \n Department: d ");
        char updateInput = ' ';
        do
        {
            updateInput = Console.ReadKey().KeyChar;
            switch (updateInput.ToString().ToLower())
            {
                case "n":
                    Console.WriteLine("New employee name:");
                    string name = Console.ReadLine();
                    employees.Find(x => x.id == emp.id).Name = name;
                    break;
                case "b":
                    Console.WriteLine("New employee birthdate:");
                    string input = "";
                    DateOnly birthdate;
                    while (!DateOnly.TryParse(input, out birthdate))
                    {
                        input = Console.ReadLine();
                    }
                    employees.Find(x=>x.id == emp.id).DateOfBirth = birthdate;
                    break;
                case "s":
                    Console.WriteLine("New employee salary:");
                    decimal salary = Convert.ToDecimal(Console.ReadLine());
                    employees.Find(x=>x.id == emp.id).Salary = salary;
                    break;
                case "d":
                    Console.WriteLine("New employee department:");
                    string department = Console.ReadLine();
                    employees.Find(x=>x.id == emp.id).department = department;
                    break;
                default:
                    Console.WriteLine("Invalid input. Try again...");
                    break;
            }
        } while (!"nbsd".Contains(updateInput));
        
    }

    public static List<Employee> GetEmployees() => employees;
}