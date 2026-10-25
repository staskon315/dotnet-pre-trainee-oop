class Developer : Employee
{
    public string ProgrammingLanguage { get; private set; }
    public Developer(string name, decimal salary, string programmingLanguage) : base(name, salary)
    {
        if (string.IsNullOrWhiteSpace(programmingLanguage)) throw new ArgumentException("Programming language cannot be empty");
        ProgrammingLanguage = programmingLanguage;
    }

    public override void Work() => Console.WriteLine($"Developer {Name} is writing {ProgrammingLanguage} code.");

    public override void GenerateReport()
    {
        base.GenerateReport();
        Console.WriteLine($"| Role:    {"Developer"}");
        Console.WriteLine($"| Language: {ProgrammingLanguage}");
    }

}