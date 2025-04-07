namespace EmployementManager.App;

public class Employee
{
    private string name { get; set; }
    private string department { get; set; }
    private decimal salary { get; set; }
    private DateTime birthDate { get; set; }

    public Employee(string name, string department, decimal salary, DateTime birthDate)
    {
        this.name = name;
        this.department = department;
        this.salary = salary;
        this.birthDate = birthDate;
    }
    public void showData()
    {
        Console.WriteLine($"Name: {this.name} ");
        Console.WriteLine($"Department: {this.department} ");
        Console.WriteLine($"Salary: {this.salary} ");
        Console.WriteLine($"Birth Date: {this.birthDate} ");
    }
}