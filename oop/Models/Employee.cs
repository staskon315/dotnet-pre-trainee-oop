abstract class Employee : IReportable
{
    public event Action<string>? SalaryChanged;
    private static int count = 1;
    public int Id { get; private set; }
    public string Name { get; }
    public decimal Salary { get; private set; }
    public abstract void Work();
    protected Employee(string name, decimal salary)
    {
        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Name cannot be empty");
        if (salary < 0) throw new ArgumentOutOfRangeException("Salary cannot be negative");
        Salary = salary;
        Name = name;
        Id = count++;
    }
    public void ChangeSalary(decimal salary)
    {
        if (salary < 0) throw new ArgumentOutOfRangeException("Salary cannot be negative");
        SalaryChanged?.Invoke($"Salary for {Name} has been changed from {Salary} to {salary}");
        Salary = salary;

    }
    public virtual void GenerateReport()
    {
        Console.WriteLine($"| ID:      {Id} ");
        Console.WriteLine($"| Name:    {Name} ");
        Console.WriteLine($"| Salary:  {Salary}$");
    }

}