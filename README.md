# dotnet-pre-trainee-oop

A console application demonstrating core **Object-Oriented Programming (OOP)** concepts in C#: abstraction, inheritance, polymorphism, encapsulation, interfaces, events, and lambda expressions.

The app manages a collection of employees of different types (Developer, Manager, Designer, HR) and provides an interactive console menu for working with them.

---

## Project Description

The application allows you to:

- view all employees;
- make all employees "work" (polymorphic behavior);
- change an employee's salary with validation;
- generate a detailed report for a selected employee;
- add new employees (Developer / Manager / Designer / HR);
- remove employees by ID;
- find an employee by ID;
- calculate the total salary of all employees;
- filter employees by type;
- exit the application.

Invalid input is handled gracefully — the app does not crash on wrong menu options, empty names, negative salaries, or non-existent IDs.

---

## Implemented Employee Types

| Type | Extra property | Description |
|---|---|---|
| `Developer` | `ProgrammingLanguage` | Writes code in a given language |
| `Manager` | `TeamSize` | Manages a team of N people |
| `Designer` | `DesignTool` | Works in a given design tool |
| `HR` | `EnrolledEmployees` | Supervises a list of other employees |

All types inherit from the abstract `Employee` class and implement the `IReportable` interface.

---

## OOP Concepts Used

### Encapsulation
- `Salary` has a `private set` — external code cannot modify it directly.
- Changes go through `ChangeSalary(decimal newSalary)`, which rejects negative values.
- `Id`, `Name`, `ProgrammingLanguage`, `TeamSize`, `DesignTool` are read-only from outside.

### Inheritance
- `Developer`, `Manager`, `Designer`, `HR` inherit from the abstract `Employee`.
- Shared fields (`Id`, `Name`, `Salary`) and behavior (`ChangeSalary`, `GenerateReport`) live in the base class.

### Polymorphism
- Employees are stored in a single `List<Employee>`.
- Calling `Work()` on each element automatically invokes the correct override for its actual type — no `switch` on type required.

### Abstraction
- `Employee` is `abstract` — you cannot instantiate it directly.
- `Work()` is declared as `abstract` — every derived class must provide its own implementation.

### Interfaces
- `IReportable` declares `GenerateReport()`.
- Every employee type implements it, and each generates a different report.

### Events
- `Employee` declares `public event Action<string>? SalaryChanged`.
- The event is raised **after** a successful salary change.
- Subscribers are notified with a message like:  
  `Salary for Anna has been changed from 1000 to 1200.`

### Lambda Expressions
- The event is subscribed to using a lambda:
  ```csharp
  employee.SalaryChanged += msg => Console.WriteLine(msg);
  ```
- Lambdas are also used in `RemoveAll(e => e.Id == num)` for deletion by ID.

---

## Project Structure

The project follows a clean separation of concerns. The entry point is in the root directory, while all domain models and interfaces are placed in the `Models` folder.

```text
dotnet-pre-trainee-oop/
│
├── Models/                 # Domain models and interfaces
│   ├── Employee.cs         # Abstract base class + SalaryChanged event
│   ├── Developer.cs        # Inherits from Employee
│   ├── Manager.cs          # Inherits from Employee
│   ├── Designer.cs         # Inherits from Employee
│   ├── HR.cs               # Inherits from Employee
│   └── IReportable.cs      # Interface with GenerateReport()
│
├── Program.cs              # Entry point (Main method) & Console Menu
├── oop.csproj              # Project file
├── .gitignore              # Git ignore rules
└── README.md               # Project documentation
```


---

## How to Copy and Run



### 1. Clone the repository

```bash
https://github.com/staskon315/dotnet-pre-trainee-oop.git

```



### 2. Navigate to the project folder

```bash
cd dotnet-pre-trainee-oop
```


### 3. Run the application

```bash
dotnet run
```

The console menu will appear:

```
Select an action
1. show all employees
2. make all employees work
3. change an employee salary
4. generate a report
5. Add an employee
6. Delete an employee
7. Searching for an employee by number
8. Calculate total salary
9. Display employees by type
0. exit
Input:
```

Type the number 