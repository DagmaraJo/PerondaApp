using PerondaApp.Entities;
using PerondaApp.Repositories;



Console.WriteLine("\n   Welcome to PerondaApp\n\n  Select Department\n  _ E\n" +
        "   The HR Employee Department :  -- access to the employee database");

var employeeRepository = new ListRepository<Employee>();

employeeRepository.ItemAdded += EmployeeRepositoryOnItemAdded;
employeeRepository.ItemRemoved += EmployeeRepositoryOnItemRemoved;

WriteAllToConsole(employeeRepository);

bool CloseApp = false;

while (!CloseApp)
{
    Console.WriteLine("\n Enter A_to Add new,  F_to Find by ID,  V_to View all  R_to Remove.");
    var userInput = Console.ReadLine()?.ToUpper();
    switch (userInput)
    {
        case "V":
            WriteAllToConsole(employeeRepository);
            break;
        case "F":
            GetItemById(employeeRepository);
            break;
        case "A":
            AddNewItem(employeeRepository);
            break;
        case "R":
            RemoveItemById(employeeRepository);
            break;
        case "X":
            CloseApp = true;
            break;
        default:
            Console.WriteLine("\n      Invalid operation.\n ");
            break;
    }
}
Console.WriteLine("  ~~ closing the program ~~ press any key to leave.");
Console.ReadKey();

static void GetItemById(IReadRepository<IEntity> repository)
{
    Console.Write("Enter ID : ");
    var input = Console.ReadLine();
    var id = int.Parse(input);
    repository.GetAll();
    var item = repository.GetById(id);
    if (item is not null)
    {
        Console.WriteLine(item);
    }
}

static void AddNewItem(IWriteRepository<Employee> repository)
{
    Console.Write(" Please insert personal details  :\n         name:  ");
    var firstName = Console.ReadLine(); Console.Write("      surname:  ");
    var surname = Console.ReadLine(); Console.Write("     position:  ");
    var position = Console.ReadLine();

    var item = new Employee { FirstName = firstName, Surname = surname, Position = position };
    repository.Add(item);
    repository.Save();
}

static void WriteAllToConsole(IReadRepository<IEntity> repository)
{
    Console.WriteLine($"     Viev all on the list \n");

    var items = repository.GetAll();
    foreach (var item in items)
    {
        Console.WriteLine(item);
    }
}

static void RemoveItemById(IRepository<Employee> repository)
{
    Console.Write("Insert personal ID to remove:\n Enter ID : ");
    var input = Console.ReadLine();
    var id = int.Parse(input);

    var item = repository.GetById(id);

    if (item is not null)
    {
        repository.Remove(item);
        repository.Save();
    }
}

void EmployeeRepositoryOnItemAdded(object? sender, Employee e)
{
    string text = $"  added  {e}";
    using (var writer = File.AppendText(IRepository<IEntity>.fileName))
    {
        writer.WriteLine($" | {DateTime.UtcNow} | + |" + text);
    }
    Console.WriteLine("\n process completed :\n New" + text);
}

void EmployeeRepositoryOnItemRemoved(object? sender, Employee e)
{
    string text = $" removed  {e}";
    using (var writer = File.AppendText(IRepository<IEntity>.fileName))
    {
        writer.WriteLine($" | { DateTime.UtcNow}   - " + text);
    }
    Console.WriteLine("\n process completed :\n " + text);
}