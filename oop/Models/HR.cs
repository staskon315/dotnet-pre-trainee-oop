
class HR : Employee
{
    public List<Employee> EnrolledEmployees {get; private set;}
    public HR(string name, decimal salary, List<Employee> enrolledEmployees) : base(name, salary)
    {
        EnrolledEmployees = enrolledEmployees ?? new List<Employee>();
    }

    public override void Work() {
        Console.WriteLine($"HR {Name} is checking the following employees : ");
        Check(EnrolledEmployees);
    }
    public override void GenerateReport()
    {
        base.GenerateReport();
        Console.WriteLine($"| Role:    {"HR"}");
        Console.WriteLine($"| Enrolled Employees: {EnrolledEmployees.Count}");
    }
    private void Check(List<Employee> employees)
    {
        if (employees.Count == 0)
        {
            Console.WriteLine("  (No employees assigned)");
            return;
        }

        foreach(var employee in employees) Console.WriteLine($"  Id={employee.Id}, name: {employee.Name} - {employee.GetType().Name} ");
    }
}