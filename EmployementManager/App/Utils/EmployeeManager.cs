using System.Runtime.InteropServices.JavaScript;

namespace EmployementManager.App.Utils;

public class EmployeeManager
{
    public static Employee AddEmployee()
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
}