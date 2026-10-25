class Program 
{
    static void Main()
    {
        var employees = new List<Employee>(){
        new Developer("Alisa", 1000,"js"),
        new Developer("Nikita", 2000.32M,"rust"),
        new Manager("Ivan", 700,5),
        new Designer("Ivan", 300,"figma")};
        var typeOfEmployees = new List<string>()
        {
            "Developer","Manager","Designer", "HR"
        };
        int num = 0;
        decimal newSalary = 0;
        bool exit = false;

        foreach (Employee employee in employees) employee.SalaryChanged += (msg) => Console.WriteLine(msg);

        while (!exit)
        {
            Console.WriteLine("\nSelect an action");
            Console.WriteLine("1. Show all employees");
            Console.WriteLine("2. Make all employees work");
            Console.WriteLine("3. Change an employee salary");
            Console.WriteLine("4. Generate a report");
            Console.WriteLine("5. Add an employee");
            Console.WriteLine("6. Delete an employee");
            Console.WriteLine("7. Searching for an employee by number");
            Console.WriteLine("8. Calculate total salary");
            Console.WriteLine("9. Display employees by type");
            Console.WriteLine("0. Exit");
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
                    while (!int.TryParse(Console.ReadLine(), out num) || num > employees.Count || num < 1) Console.Write("there is no such option\nInput: ");

                    Console.WriteLine("enter the new salary");
                    while (!decimal.TryParse(Console.ReadLine(), out newSalary)) Console.Write("invalid salary, please try again\nInput: ");

                    try { employees[num - 1].ChangeSalary(newSalary); }
                    catch (Exception e) { Console.WriteLine(e.Message); }
                    break;
                case "4":
                    Console.WriteLine("Select the employee to generate a report for");
                    for (int i = 0; i < employees.Count; i++) Console.WriteLine(i + 1 + $". {employees[i].Name}");

                    Console.Write("Input: ");
                    while (!int.TryParse(Console.ReadLine(), out num) || num > employees.Count || num < 1) Console.Write("there is no such option\nInput: ");
                    employees[num - 1].GenerateReport();
                    break;
                case "5":
                    Console.WriteLine("Select the employee's profession:");
                    for (int i = 0; i < typeOfEmployees.Count; i++) Console.WriteLine($"{i + 1}. {typeOfEmployees[i]}");

                    Console.Write("Input: ");
                    while (!int.TryParse(Console.ReadLine(), out num) || num > typeOfEmployees.Count || num < 1) Console.Write("there is no such option\nInput: ");
                    CreateEmployee(num, employees);

                    break;
                case "6":
                    Console.WriteLine("Enter the ID of the employee you want to delete:");
                    for (int i = 0; i < employees.Count; i++) Console.WriteLine($"Id={employees[i].Id}: {employees[i].Name}");

                    Console.Write("Input: ");
                    while (!int.TryParse(Console.ReadLine(), out num)) Console.Write("invalid input\nInput: ");

                    int removed = employees.RemoveAll(e => e.Id == num);
                    if (removed == 0) Console.WriteLine("This ID does not exist");
                    break;
                case "7":
                    Console.WriteLine("Enter the ID of the employee you want to find:");
                    Console.Write("Input: ");
                    while (!int.TryParse(Console.ReadLine(), out num)) Console.Write("invalid input\nInput: ");
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
                case "9":
                    Console.WriteLine($"Select employee type:(1-{typeOfEmployees.Count})");
                    for (int i = 0; i < typeOfEmployees.Count; i++) Console.WriteLine($"{i + 1}. {typeOfEmployees[i]}");
                    Console.Write("Input: ");
                    while (!int.TryParse(Console.ReadLine(), out num) || num > typeOfEmployees.Count || num < 1) Console.Write("invalid input\nInput: ");
                    foreach (var employee in employees)
                    {
                        if (typeOfEmployees[num - 1] == employee.GetType().Name) Console.WriteLine($"Id={employee.Id}, name: {employee.Name} - {employee.GetType().Name} ");
                    }
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
            case 4:
                CreateEmployeeBase(out name, out salary);

                Console.WriteLine("Enter the IDs of the employees trained by HR separated by commas (enter 0 if none):");
                Console.Write("Input: ");
                input = Console.ReadLine() ?? "";

                var empl = new List<Employee>();

                if (input.Trim() == "0" || string.IsNullOrWhiteSpace(input))
                {
                    var hrEmpty = new HR(name!, salary, empl);
                    employees.Add(hrEmpty);
                    hrEmpty.SalaryChanged += (msg) => Console.WriteLine(msg);
                    Console.WriteLine($"HR {hrEmpty.Name} created with 0 employees");
                    break;
                }

                string[] ids = input.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                bool found = false; 
                foreach (var id in ids)
                {
                    string trim = id.Trim();
                    if (int.TryParse(trim, out int idf))
                    {
                        Employee? foundEmp = null;
                        foreach (var e in employees) if (e.Id == idf) { foundEmp = e; break; }
            
                        if (foundEmp != null)
                        {
                            if (!empl.Contains(foundEmp))
                            {
                                empl.Add(foundEmp);
                                found = true;
                            }
                        }
                        else Console.WriteLine($"Id={idf} not found.");
                    }
                    else Console.WriteLine($"{trim} — invalid input.");
                }

                if (!found)
                {
                    Console.WriteLine("HR was not created: no valid employees were selected.");
                    break; 
                }

                var hr = new HR(name!, salary, empl);
                employees.Add(hr);
                hr.SalaryChanged += (msg) => Console.WriteLine(msg);
                Console.WriteLine($"HR {hr.Name} created with {empl.Count} employees.");
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
