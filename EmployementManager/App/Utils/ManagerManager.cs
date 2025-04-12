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
            switch (input.Trim())
            {
                case "1":
                    managers.ForEach(m => MenuWriter.Show(MANAGER_MENU));
                    Console.WriteLine("\nPress any key to continue...");
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
        
        if (managers.Count == 0) { return null; }

        Console.WriteLine("Employees: ");
        managers.ForEach(x => Console.WriteLine(x.toString()));
        Console.Write("Manager ID: ");
        string id = Console.ReadLine();
        Manager tmp = managers.Find(x => x.id == id);
        
        return tmp;
    }
}