abstract class Employee : IReportable
{
    public event Action<string>? SalaryChanged;
    private static int count=0;
    public int Id{ get ; private set;}
    public string Name{ get;}
    public decimal Salary{ get ; private set;}
    public abstract void Work();
    protected Employee(string name,decimal salary)
    {
        if(string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Name cannot be empty"); 
        if(salary<0) throw new ArgumentOutOfRangeException("Salary cannot be negative");
        Salary=salary;
        Name=name;
        Id=count++;
    }
    public void ChangeSalary(decimal salary)
    {
        if(salary<0) throw new ArgumentOutOfRangeException("Salary cannot be negative");
        SalaryChanged?.Invoke($"Salary for {Name} has been changed from {Salary} to {salary}");
        Salary=salary;
        
    }
     public virtual void GenerateReport()=>Console.Write($"My name is {Name},I have a number {Id} and I earn a salary = {Salary}");
    
}