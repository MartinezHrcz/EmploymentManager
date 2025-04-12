using EmployementManager.App.Utils;

namespace EmployementManager.App;

public class Employee : Person
{
    public string id;
    public string department { get; set; }
    public Employee(string name, string department, decimal salary, DateOnly birthDate) : base(name,salary,birthDate)
    {
        this.department = department;
        if (EmployeeManager.GetEmployees().Count != 0)
        {
            try
            {
                id = "EM" + (int.Parse(EmployeeManager.GetEmployees().Select(em => em.id).LastOrDefault().Replace("EM",""))+1);
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine("Error generating employee id!");
            }
            
        }
        else
        {
            id = "EM0";
        }
    }

    public string toString()
    {
        return ($"ID: {this.id} Name: {this.Name}, Department: {this.department}, Salary: {this.Salary}, Birthdate: {this.DateOfBirth}");
    }
}