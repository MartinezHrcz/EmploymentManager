using EmployementManager.App.Utils;

namespace EmployementManager.App;

public class Manager : Person
{
    public string id { get; set; }
    private List<Employee> employees = new List<Employee>();
    public string department;

    public Manager(string name, decimal salary, DateOnly dateOfBirth, string department) : base(name, salary,
        dateOfBirth)
    {
        this.department = department;
        if (ManagerManager.GetManagers().Count != 0)
        {
            try
            {
                id = "MG" + (int.Parse(EmployeeManager.GetEmployees().Select(em => em.id).LastOrDefault().Replace("MG",""))+1);
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine("Error generating employee id!");
            }
            
        }
        else
        {
            id = "MG0";
        }
    }
    public List<Employee> Employees => employees;

    public void AddEmployee(Employee employee)
    {
        employees.Add(employee);
    }

    public string ToString()
    { 
        return $"ID: {this.id}, Name: {base.Name}, Salary: {base.Salary}, DateOfBirth: {base.DateOfBirth}, Employees: {employees.Count}";
    }
}