class Program // change message in Console.Write may be Interface need to add methods
{
    static void Main()
    {
        var employees = new List<Employee>(){
        new Developer("Alisa", 1000,"js"),
        new Developer("Nikita", 2000.32M,"rust"),
        new Manager("Ivan", 700,5),
        new Designer("Ivan", 300,"figma")};
        int num = 0;
        decimal newSalary = 0;
        bool exit = false;

        foreach (Employee employee in employees) employee.SalaryChanged += (msg) => Console.WriteLine(msg);

        while (!exit)
        {
            Console.WriteLine("\nSelect an action");
            Console.WriteLine("1. show all employees");
            Console.WriteLine("2. make all employees work");
            Console.WriteLine("3. change an employee salary");
            Console.WriteLine("4. generate a report");
            Console.WriteLine("5. Add an employee");
            Console.WriteLine("6. Delete an employee");
            Console.WriteLine("7. Searching for an employee by number");
            Console.WriteLine("8. Calculate total salary");
            Console.WriteLine("0. exit");
            Console.Write("Input: ");

            switch (Console.ReadLine())
            {
                case "1":
                    foreach (Employee employee in employees) Console.WriteLine($"Id={employee.Id}, name: {employee.Name} - {employee.GetType().Name} ");
                    break;
                case "2":
                    foreach (Employee employee in employees) employee.Work();
                    break;
                case "3":
                    Console.WriteLine("Select the employee whose salary you want to change");
                    for (int i = 0; i < employees.Count; i++) Console.WriteLine(i + 1 + $". {employees[i].Name}");

                    Console.Write("Input: ");
                    while (!int.TryParse(Console.ReadLine(), out num) || num > employees.Count || num < 1) Console.WriteLine("there is no such option");

                    Console.WriteLine("enter the new salary");
                    while (!decimal.TryParse(Console.ReadLine(), out newSalary)) Console.WriteLine("invalid salary, please try again");

                    try { employees[num - 1].ChangeSalary(newSalary); }
                    catch (Exception e) { Console.WriteLine(e.Message); }
                    break;
                case "4":
                    Console.WriteLine("Select the employee to generate a report for");
                    for (int i = 0; i < employees.Count; i++) Console.WriteLine(i + 1 + $". {employees[i].Name}");

                    Console.Write("Input: ");
                    while (!int.TryParse(Console.ReadLine(), out num) || num > employees.Count || num < 1) Console.WriteLine("there is no such option");
                    employees[num - 1].GenerateReport();
                    break;
                case "5":
                    Console.WriteLine("Select the employee's profession:");
                    Console.WriteLine("1. Developer");
                    Console.WriteLine("2. Manager");
                    Console.WriteLine("3. Designer");

                    Console.Write("Input: ");
                    while (!int.TryParse(Console.ReadLine(), out num) || num > 3 || num < 1) Console.WriteLine("there is no such option");
                    CreateEmployee(num, employees);

                    break;
                case "6":
                    Console.WriteLine("Enter the ID of the employee you want to delete:");
                    for (int i = 0; i < employees.Count; i++) Console.WriteLine($"Id={employees[i].Id}: {employees[i].Name}");

                    Console.Write("Input: ");
                    while (!int.TryParse(Console.ReadLine(), out num)) Console.WriteLine("invalid input");

                    int removed = employees.RemoveAll(e => e.Id == num);
                    if (removed == 0) Console.WriteLine("This ID does not exist");
                    break;
                case "7":
                    Console.WriteLine("Enter the ID of the employee you want to find:");
                    Console.Write("Input: ");
                    while (!int.TryParse(Console.ReadLine(), out num)) Console.WriteLine("invalid input");
                    bool found = false;
                    foreach (var empl in employees)
                    {
                        if (empl.Id == num)
                        {
                            Console.WriteLine($"{empl.Name}-{empl.GetType().Name}");
                            found = true;
                            break;
                        }

                    }
                    if (!found) Console.WriteLine("An employee with this ID was not found");
                    break;
                case "8":
                    decimal totalSalary = 0;
                    foreach (var empl in employees) totalSalary += empl.Salary;
                    Console.WriteLine($"Total salary-{totalSalary}");
                    break;
                case "0":
                    exit = true;
                    break;

                default:
                    Console.WriteLine("there is no such option");
                    break;
            }
        }
    }

    static void CreateEmployee(int choise, List<Employee> employees)
    {
        string? name, input;
        decimal salary;
        int num;
        switch (choise)
        {
            case 1:
                CreateEmployeeBase(out name, out salary);

                Console.WriteLine("Enter the programming language");
                Console.Write("Input: ");
                input = Console.ReadLine();
                while (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("invalid programming language, please try again");
                    input = Console.ReadLine();
                }

                var dev = new Developer(name!, salary, input);
                employees.Add(dev);
                dev.SalaryChanged += (msg) => Console.WriteLine(msg);
                break;
            case 2:
                CreateEmployeeBase(out name, out salary);

                Console.WriteLine("Enter the team size");
                Console.Write("Input: ");
                while (!int.TryParse(Console.ReadLine(), out num) || num <= 0) Console.WriteLine("invalid team size, please try again");

                var men = new Manager(name!, salary, num);
                employees.Add(men);
                men.SalaryChanged += (msg) => Console.WriteLine(msg);
                break;
            case 3:
                CreateEmployeeBase(out name, out salary);

                Console.WriteLine("Enter the designer's tool");
                Console.Write("Input: ");
                input = Console.ReadLine();
                while (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("invalid tool, please try again");
                    input = Console.ReadLine();
                }
                var des = new Designer(name!, salary, input);
                employees.Add(des);
                des.SalaryChanged += (msg) => Console.WriteLine(msg);

                break;

            default:
                Console.WriteLine("there is no such option");
                break;

        }
    }

    static void CreateEmployeeBase(out string? name, out decimal salary)
    {
        Console.WriteLine("Enter the employee's name");
        Console.Write("Input: ");
        name = Console.ReadLine();
        while (string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("invalid name, please try again");
            name = Console.ReadLine();
        }

        Console.WriteLine("Enter salary");
        Console.Write("Input: ");
        while (!decimal.TryParse(Console.ReadLine(), out salary) || salary < 0) Console.WriteLine("invalid salary, please try again");
    }



}
