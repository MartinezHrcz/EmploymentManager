using System.Threading.Channels;

namespace EmployementManager.App.Utils;

public class ManagerManager
{
    static private List<Manager> managers { get; } = new List<Manager>();

    private static readonly string[] MANAGER_MENU = new[]
    {
        "1.Show Managers",
        "2.Add Manager",
        "3.Delete Manager",
        "4.Update Manager",
        "5.Back to Main Menu"
    };

    public static void Menu()
    {
        string input = "";
        do
        {
            Console.Clear();
            MenuWriter.Show(MANAGER_MENU);
            input = Console.ReadLine();
            Console.Clear();
            switch (input.Trim())
            {
                case "1":
                    
                    managers.ForEach(m => Console.WriteLine(m.ToString()));
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                    break;
                case "2":
                    managers.Add(AddManager());
                    break;
                case "3": 
                    Manager toBeDeleted = SelectManager();
                    if (toBeDeleted != null)
                    {
                        managers.Remove(toBeDeleted);
                    }
                    else
                    {
                        Console.WriteLine("\nManager not found");
                    }
                    break;
                case "4":
                        UpdateManager(SelectManager());
                    break;
                case "5":
                    Console.WriteLine("Going back to Main Menu...");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    break;
                default:
                    Console.WriteLine("Invalid input. Try again...");
                    break;
            }
        } while (input.Trim() != "5");
    }
    
    public static List<Manager> GetManagers() => managers;
    private static Manager AddManager()
    {
        Console.WriteLine("New manager data:");
        Console.Write("Manager name: ");
        string name = Console.ReadLine();
        
        Console.Write("Manager age: ");
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
        
        Manager tmp = new Manager(name, salary, birthdate,department);
        return tmp;
    }
    private static Manager SelectManager()
    {

        if (managers.Count == 0)
        {
            Console.WriteLine("No managers found.");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            return null;
        }

        Console.WriteLine("Employees: ");
        managers.ForEach(x => Console.WriteLine(x.ToString()));
        Console.Write("Manager ID: ");
        string id = Console.ReadLine();
        Manager tmp = managers.Find(x => x.id == id);
        
        return tmp;
    }

    private static Employee SelectEmployeeFromManager()
    {
        if (EmployeeManager.GetEmployees().Count == 0)
        {
            Console.WriteLine("No Employees found!");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            return null;
        }
        Console.WriteLine("Available employees:");
        EmployeeManager.GetEmployees().ForEach(x=>Console.WriteLine(x.toString()));
        Console.WriteLine("Employee ID: ");
        string id = " ";
        while (!EmployeeManager.GetEmployees().Select(x=>x.id).Contains(id))
        {
            id = Console.ReadLine().Trim().ToUpper();
        }
        Employee emp = EmployeeManager.GetEmployees().Find(x=>x.id == id);
        return emp;
    }

    private static void UpdateManager(Manager mg)
    {
        Console.Clear();
        Console.WriteLine($"Would you like to update on {mg.id}?");
        if (mg == null)
        {
            Console.WriteLine("Manager not found");
            return;
        }
        
        Console.WriteLine("What do you want to update?: ");
        
        char updateInput = ' ';
        do
        {
            Console.Clear();
            Console.WriteLine("Name = n \n Birthdate: b \n Salary: s \n Department: d \n Add Employee: e \n Delete Employee: f ");
            updateInput = Console.ReadKey().KeyChar;
            switch (updateInput.ToString().ToLower())
            {
                case "n":
                    Console.WriteLine("New manager name:");
                    string name = Console.ReadLine();
                    managers.Find(x => x.id == mg.id).Name = name;
                    break;
                
                case "b":
                    Console.WriteLine("New employee birthdate:");
                    string input = "";
                    DateOnly birthdate;
                    while (!DateOnly.TryParse(input, out birthdate))
                    {
                        input = Console.ReadLine();
                    }
                    managers.Find(x=>x.id == mg.id).DateOfBirth = birthdate;
                    break;
                
                case "s":
                    Console.WriteLine("New employee salary:");
                    decimal salary = Convert.ToDecimal(Console.ReadLine());
                    managers.Find(x=>x.id == mg.id).Salary = salary;
                    break;
                
                case "d":
                    Console.WriteLine("New employee department:");
                    string department = Console.ReadLine();
                    managers.Find(x=>x.id == mg.id).department = department;
                    break;
                
                case "e":
                  
                    Employee employeeToBeAdded = SelectEmployeeFromManager();
                    if (employeeToBeAdded == null)
                    { return; }
                    managers.Find(x=>x.id == mg.id).Employees.Add(employeeToBeAdded);
                    break;
                
                case "f":
                    Employee employeeToBeDeleted = SelectEmployeeFromManager();
                    if (employeeToBeDeleted == null)
                    { return; }
                    managers.Find(x=>x.id == mg.id).Employees.Remove(employeeToBeDeleted);
                    break;
                
                default:
                    Console.WriteLine("Invalid input. Try again...");
                    break;
            }
        } while (!"nbsd".Contains(updateInput));
        
    }
    
}