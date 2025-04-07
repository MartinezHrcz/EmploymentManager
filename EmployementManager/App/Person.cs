namespace EmployementManager.App;

public class Person
{
    public string Name { get; set; }
    public decimal Salary { get; set; }
    public DateOnly DateOfBirth { get; set; }

    public Person(string name, decimal salary, DateOnly dateOfBirth)
    {
        Name = name;
        Salary = salary;
        DateOfBirth = dateOfBirth;
    }
    
}