namespace EmployementManager.App.Utils;

public class ManagerManager
{

    public static void Menu()
    {
        
    }

    static private List<Manager> managers { get; } = new List<Manager>();


    public static Manager AddManager()
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
}