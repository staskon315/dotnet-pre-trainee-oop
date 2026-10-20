class Manager : Employee
{
    public int TeamSize{get; private set;}
    public Manager(string name, decimal salary, int teamSize) : base(name, salary)
    {
        if(teamSize<=0) throw new ArgumentOutOfRangeException("Team Size cannot be negative or 0");
        TeamSize=teamSize;
    }

    public override void Work()
    {
        Console.WriteLine($"Manager {Name} is managing a team of {TeamSize} people.");
    }
    public override void GenerateReport()
    {
        base.GenerateReport();
        Console.WriteLine($" I am a Manager,My team consists of {TeamSize} people");
    }
}