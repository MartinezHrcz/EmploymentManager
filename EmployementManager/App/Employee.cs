namespace EmployementManager.App;

public class Employee : Person
{
    private string department { get; set; }
    private bool manager{get;set;}
    public Employee(string name, string department, decimal salary, DateOnly birthDate) : base(name,salary,birthDate)
    {
        this.manager = manager;
        this.department = department;
    }

    public string toString()
    {
        return ($"Name: {base.Name}, Department: {this.department}, Salary: {base.Salary}, Birthdate: {base.DateOfBirth}");
    }
}