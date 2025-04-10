namespace EmployementManager.App;

public class Manager : Person
{
    private List<Employee> employees = new List<Employee>();
    private string department;

    public Manager(string name, decimal salary, DateOnly dateOfBirth, string department) : base(name, salary,
        dateOfBirth)
    {
        this.department = department;
    }
    public List<Employee> Employees => employees;

    public void AddEmployee(Employee employee)
    {
        employees.Add(employee);
    }

    public void ToString()
    {
        Console.WriteLine($"Name: {base.Name}, Salary: {base.Salary}, DateOfBirth: {base.DateOfBirth}, Employees: {employees.Count}");
    }
}