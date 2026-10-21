var employees=new List<Employee>()
{
    new Developer("Alisa", 1000,"js"),
    new Developer("Nikita", 2000.32M,"rust"),
    new Manager("Ivan", 700,5),
    new Designer("Ivan", 300,"figma")
};


foreach(Employee employee in employees)
{ 
    employee.GenerateReport(); 
    employee.SalaryChanged+= (msg)=>Console.WriteLine(msg); 
}
foreach(Employee employee in employees) employee.Work();

employees[1].ChangeSalary(234);
