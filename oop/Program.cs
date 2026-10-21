var employees=new List<Employee>()
{
    new Developer("Alisa", 1000,"js"),
    new Developer("Nikita", 2000.32M,"rust"),
    new Manager("Ivan", 700,5),
    new Designer("Ivan", 300,"figma")
};
int num=0;
decimal newSalary=0;
bool exit=false;

foreach(Employee employee in employees)  employee.SalaryChanged+= (msg)=>Console.WriteLine(msg); 

while (!exit)
{
    Console.WriteLine("Select an action");
    Console.WriteLine("1. show all employees");
    Console.WriteLine("2. make all employees work");
    Console.WriteLine("3. change an employee salary");
    Console.WriteLine("4. generate a report");
    Console.WriteLine("0. exit");
    Console.Write("Input: ");
    string? input =Console.ReadLine();

    switch (input)
    {
        case "1":
            foreach(Employee employee in employees) Console.WriteLine(employee.Name);
            break;
        case "2":
            foreach(Employee employee in employees) employee.Work();
            break;
        case "3":
            Console.WriteLine("Select the employee whose salary you want to change");
            for( int i = 0; i < employees.Count; i++) Console.WriteLine(i+1 + $". {employees[i].Name}");

            Console.Write("Input: ");
            while(!int.TryParse(Console.ReadLine(),out num) || num>employees.Count || num<1) Console.WriteLine("there is no such option");
            
            Console.WriteLine("enter the new salary");
            while(!decimal.TryParse(Console.ReadLine(),out newSalary)) Console.WriteLine("invalid salary, please try again");

            try{employees[num-1].ChangeSalary(newSalary);}
            catch(Exception e){Console.WriteLine(e.Message);}
            break;
        case "4":
            Console.WriteLine("Select the employee to generate a report for");
            for( int i = 0; i < employees.Count; i++) Console.WriteLine(i+1 + $". {employees[i].Name}");

            Console.Write("Input: ");
            while(!int.TryParse(Console.ReadLine(),out num )|| num>employees.Count || num<1) Console.WriteLine("there is no such option"); 
            employees[num-1].GenerateReport();
            break;
        case "0":
            exit=true;
            break;
        default:
            Console.WriteLine("there is no such option");
            break;
    }
}


