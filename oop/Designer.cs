class Designer : Employee
{
    public string DesignTool{get;private set;}
    public Designer(string name, decimal salary, string designTool) : base(name, salary)
    {
        if(string.IsNullOrWhiteSpace(designTool)) throw new ArgumentException("Design tool cannot be empty");
        DesignTool=designTool;
    }

    public override void Work()=>Console.WriteLine($"Designer {Name} is working in {DesignTool}.");
    
    public override void GenerateReport()
    {
        base.GenerateReport();
        Console.WriteLine($" I am a Designer,I draw using a {DesignTool}");
    }
}
