using Microsoft.Extensions.DependencyInjection;
using PerondaApp;
using PerondaApp.Components.DataProviders;
using PerondaApp.Data.Entities;
using PerondaApp.Data.Repositories;
using PerondaApp.Data;
using PerondaApp.Data.Repositories.Extensions;
using System.Text;
using Newtonsoft.Json;
using System.Resources;

//var services = new ServiceCollection();
//services.AddSingleton<IApp, App>();
//services.AddSingleton<IRepository<Employee>, ListRepository<Employee>>();
//services.AddSingleton<IRepository<Tile>, ListRepository<Tile>>();
//services.AddSingleton<ITilesProvider, TilesProvider>();
//services.AddSingleton<ICsvReader, CsvReader>();


//var serviceProvider = services.BuildServiceProvider();
//var app = serviceProvider.GetService<IApp>()!;
//app.Run();




//var employeeRepository = new SqlRepository<Employee>(new PerondaAppDbContext(), EmployeeAdded, EmployeeRemoved);
var employeeRepository = new ListRepository<Employee>();

employeeRepository.ItemAdded += EmployeeRepositoryOnItemAdded;
employeeRepository.ItemRemoved += EmployeeRepositoryOnItemRemoved;

void EmployeeRepositoryOnItemAdded(object? sender, Employee e)
{
    string text = $" [ {DateTime.UtcNow} | + | {e} added ]";
    using (var writer = File.AppendText(IRepository<IEntity>.fileName))
    {
        writer.WriteLine(text);
    }
    Console.WriteLine(text);
}

void EmployeeRepositoryOnItemRemoved(object? sender, Employee e)
{
    string text = $" [ {DateTime.UtcNow} | - | {e} removed ]";
    using (var writer = File.AppendText(IRepository<IEntity>.fileName))
    {
        writer.WriteLine(text);
    }
    Console.WriteLine(text);
}

static void AddEmployee(IRepository<Employee> employeeRepository)
{
    Console.WriteLine("Insert employee first name:");
    var name = Console.ReadLine();

    Console.WriteLine("Insert employee surname:");
    var surname = Console.ReadLine();

    Console.WriteLine("Insert employee position");
    var position = Console.ReadLine();

    var employee = new Employee { FirstName = name, Surname = surname, Position = position };

    employeeRepository.Add(employee);
    employeeRepository.Save();
}

static void RemoveEmployee(IRepository<Employee> employeeRepository)
{
    Console.WriteLine("Insert employee ID to remove:");
    var input = Console.ReadLine();
    var id = int.Parse(input);

    var employeeToRemove = employeeRepository.GetById(id);

    if (employeeToRemove is not null)
    {
        employeeRepository.Remove(employeeToRemove);
        employeeRepository.Save();
    }
}

//static void InsertPersonalDetails (out string firstName, out string surname, out string position)
//{
//    Console.Clear();
//    Console.Write("\n\n   Please insert personal details  :   ");
//    Console.Write("\n  first name:  ");
//    firstName = Console.ReadLine();
//    Console.Write("\n  surname:  ");
//    surname = Console.ReadLine();
//    Console.Write("\n  position:  ");
//    position = Console.ReadLine();
//}

var businessPartnerRepository = new ListRepository<BusinessPartner>();
businessPartnerRepository.ItemAdded += BusinessPartnerRepositoryOnItemAdded;
businessPartnerRepository.ItemRemoved += BusinessPartnerRepositoryOnItemRemoved;

void BusinessPartnerRepositoryOnItemAdded(object? sender, BusinessPartner e)
{
    string text = $" [ {DateTime.UtcNow} | + | {e} added ]";
    using (var writer = File.AppendText(IRepository<IEntity>.fileName))
    {
        writer.WriteLine(text);
    }
    Console.WriteLine(text);
}

void BusinessPartnerRepositoryOnItemRemoved(object? sender, BusinessPartner e)
{
    string text = $" [ {DateTime.UtcNow} | - | {e} removed ]";
    using (var writer = File.AppendText(IRepository<IEntity>.fileName))
    {
        writer.WriteLine(text);
    }
    Console.WriteLine(text);
}

static void AddBusinessPartner(IRepository<BusinessPartner> businessPartnerRepository)
{
    Console.WriteLine("Insert Business Partner first name:");
    var name = Console.ReadLine();

    Console.WriteLine("Insert Business Partner surname:");
    var surname = Console.ReadLine();

    Console.WriteLine("Insert Business Partner position");
    var position = Console.ReadLine();

    Console.Write("\n  Insert Business Partner company name:  ");
    var companyName = Console.ReadLine();

    var businessPartner = new BusinessPartner { FirstName = name, Surname = surname, Position = position, CompanyName = companyName };

    businessPartnerRepository.Add(businessPartner);
    businessPartnerRepository.Save();
}

static void RemoveBusinessPartner(IRepository<BusinessPartner> businessPartnerRepository)
{
    Console.WriteLine("Insert Business Partner ID to remove:");
    var input = Console.ReadLine();
    var id = int.Parse(input);

    var businessPartnerToRemove = businessPartnerRepository.GetById(id);

    if (businessPartnerToRemove is not null)
    {
        businessPartnerRepository.Remove(businessPartnerToRemove);
        businessPartnerRepository.Save();
    }
}

bool Exit = false;
while (!Exit)
{
    Console.WriteLine("\n     MANAGMENT BRANCH - resource list" +
        "\n" +
        "   Choose option :\n" +
        "      press A   - to viev all employees\n" +
        "      press B   - to viev all business partners\n" +
        "      press C   - to add new employees\n" +
        "      press D   - to add new business partners\n" +
        "      press E   - to remove employees\n" +
        "      press F   - to remove business partners\n" +
        "      press G   - to find employee by ID\n" +
        "      press H   - to find business partner by ID\n\n" +
        "                                                         press X - to leave\n\n"); //press Esc - to leave\n\n");

    var userInput = Console.ReadLine()?.ToUpper();
    switch (userInput)
    {
        case "A":
            WriteAllToConsole(employeeRepository); break;
        case "B":
           WriteAllToConsole(businessPartnerRepository); break;
        case "C":
            AddEmployee(employeeRepository); break;
        case "D":
            AddBusinessPartner(businessPartnerRepository); break;
        case "E":
            RemoveEmployee(employeeRepository); break;
        case "F":
            RemoveBusinessPartner(businessPartnerRepository); break;
        case "G":
            GetEmployeeById(employeeRepository); break;
        case "H":
            GetBusinessPartnerById(businessPartnerRepository); break;
        case "X":
            Exit = true;
            Environment.Exit(0); break;
        default:
            Console.Clear();
            Console.WriteLine("\n\n\n      Invalid operation.    ");
            break;
    }

    static void WriteAllToConsole(IReadRepository<IEntity> repository)
    {
        var items = repository.GetAll();
        foreach (var item in items)
        {
            Console.WriteLine(item);
        }
    }

    static void GetEmployeeById(IRepository<Employee> employeeRepository)
    {
        Console.Write("Insert employee ID : ");
        var input = Console.ReadLine();
        var id = int.Parse(input);

        employeeRepository.Read();
        var employee = employeeRepository.GetById(id);

        if (employee is not null)
        {
            employeeRepository.GetById(id);
            Console.WriteLine(employee);
        }
    }

    static void GetBusinessPartnerById(IRepository<BusinessPartner> businessPartnerRepository)
    {
        Console.Write("Insert Business Partner ID : ");
        var input = Console.ReadLine();
        var id = int.Parse(input);

        businessPartnerRepository.Read();
        var businessPartner = businessPartnerRepository.GetById(id);

        if (businessPartner is not null)
        {
            businessPartnerRepository.GetById(id);
            Console.WriteLine(businessPartner);
        }
    }


    //ConsoleKeyInfo key = Console.ReadKey();
    //switch (key.Key)
    //{
    //    case ConsoleKey.A:
    //        WriteAllToConsole(employeeRepository); break;
    //    //case ConsoleKey.B:
    //    //    WriteAllToConsole(businessPartnerRepository); break;
    //    case ConsoleKey.C:
    //        AddEmployee(employeeRepository); break;
    //    //case ConsoleKey.D:
    //    //    AddBusinessPartner(out string fullName, out name, out string position, businessPartnerRepository);
    //    //    break;
    //    case ConsoleKey.E:
    //        RemoveEmployee(employeeRepository); break;
    //    //case ConsoleKey.F://ConsoleKey.NumPad2:
    //    //    RemoveBusinessPartner(businessPartnerRepository); break;
    //    case ConsoleKey.G:
    //        GetEmployeeById(employeeRepository); break;
    //    //case ConsoleKey.H:
    //    //    GetBusinessPartnerById(businessPartnerRepository); break;
    //    case ConsoleKey.Escape:
    //        Exit = true;
    //        Environment.Exit(0); break;
    //    default:
    //        Console.Clear();
    //        Console.WriteLine("\n\n\n      Invalid operation.    ");
    //        break;
    //}
}

//static void AddEmployee(IRepository<Employee> employeeRepository)
//{
//    var employee = new[]
//    {
//        new Employee { FirstName = "Konrad" },
//        new Employee { FirstName = "Ewa" },
//        new Employee { FirstName = "Marek" }
//    };

//    string employeeSerialized = JsonConvert.SerializeObject(employee);
//    File.WriteAllText("Resources\\Files\\save.json", employeeSerialized);

//    employeeRepository.AddBatch(employee);
//    //public const string fileJsonName = "Resources\\Files\\save.json";
//}

//static void AddTiles(IRepository<Tile> tilesRepository)
//{
//    Console.Write("Enter Car Model: ");
//    string name = Console.ReadLine();
//    Console.Write("Enter Car Country: ");
//    string color = Console.ReadLine();
//    string type = Console.ReadLine();
//    Console.Write("Enter Car Year: ");
//    if (!int.TryParse(Console.ReadLine(), out int year) || year < 0)
//    {
//        Console.WriteLine("Invalid Year, Please enter a valid year");
//        return;
//    }

//    var newTile = new Tile
//    {
//        Name = name,
//        Color = color,
//        Type = type
//    };
//    tilesRepository.Add(newTile);
//    tilesRepository.Save();
//    Console.WriteLine("Tiles Added");
//}

//static void GetEmployeeById(IRepository<Employee> employeeRepository)
//{
//    var employee = employeeRepository.GetById(6);
//    Console.WriteLine(employee);
//}

//static void AddBusinessPartners(IRepository<BusinessPartner> businessPartnerRepository) //AddBusinessPartners *s !
//{
//    businessPartnerRepository.Add(new BusinessPartner { Name = "Carrea" });
//    businessPartnerRepository.Add(new BusinessPartner { Name = "Opoczno" });
//    businessPartnerRepository.Add(new BusinessPartner { Name = "Nexterio" });
//    businessPartnerRepository.Add(new BusinessPartner { Name = "Leroy Marlin" });
//    businessPartnerRepository.Save();
//}

//AddEmployee(employeeRepository);
//AddBusinessPartner(businessPartnersRepository);

//static void RemoveEmployee(IRepository<Employee> employeeRepository)
//{
//    employeeRepository.Remove(new Employee { FirstName = "Magda" });
//    employeeRepository.Remove(new Employee { FirstName = "Sebastian" });
//    employeeRepository.Save();
//}