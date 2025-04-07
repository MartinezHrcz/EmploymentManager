namespace EmployementManager.App;

public class Manager : Person
{
    private List<Employee> employees = new List<Employee>();
    public Manager(string name, decimal salary, DateOnly dateOfBirth) : base(name, salary, dateOfBirth)
    { }
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