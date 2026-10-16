abstract class Employee
{
    private static int count=0;
    public int Id{ get ; private set;}
    public string Name{ get ; private set;}
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

}