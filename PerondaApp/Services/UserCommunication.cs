using PerondaApp.Data.Components.DataProviders;
using PerondaApp.Entities;
using PerondaApp.Repositories;
using PerondaApp.Repositories.Extensions;

namespace PerondaApp.Services;

public class UserCommunication : UserCommunicationBase, IUserCommunication
{
    private readonly IRepository<Employee> _employeeRepository;
    private readonly IRepository<BusinessPartner> _businessPartnerRepository;
    private readonly IRepository<Tile> _tileRepository;
    private readonly ITilesProvider? _tilesProvider;

    public UserCommunication(IRepository<Employee> employeeRepository,
        IRepository<BusinessPartner> businessPartnerRepository,
        IRepository<Tile> tileRepository,
        ITilesProvider tilesProvider)
    {
        _employeeRepository = employeeRepository;
        _businessPartnerRepository = businessPartnerRepository;
        _tileRepository = tileRepository;
        _tilesProvider = tilesProvider;
    }


    //Console.WriteLine("\n   Welcome to PerondaApp\n\n  Select Department\n  _ E\n" +
    //        "   The HR Employee Department :  -- access to the employee database");

    //var employeeRepository = new ListRepository<Employee>();
    /// later ?  var employeeRepository = new SqlRepository<Employee>(new PerondaAppDbContext(), EmployeeRepositoryOnItemAdded())

    //employeeRepository.ItemAdded += EmployeeRepositoryOnItemAdded;
    //employeeRepository.ItemRemoved += EmployeeRepositoryOnItemRemoved;

    //WriteAllToConsole(employeeRepository);

    public void SelectSection()
    {
        bool CloseApp = false;

        while (!CloseApp)
        {
            var userChoice = GetInputFromUser("  What You want To do ?   Enter  A, B, E or F").ToUpper();
            if (userChoice == "A")
            {
                var employeeRepository = new ListRepository<Employee>(ChoiceOption); //WriteAllToConsole(_tileRepository);
                break;
            }
            if (userChoice == "B")
            {
                var businessPartnerRepository = new ListRepository<BusinessPartner>(ChoiceOption); //WriteAllToConsole(_businessPartnerRepository);
                break;
            }
            if (userChoice == "E")
            {
                var employeeRepository = new ListRepository<Employee>(ChoiceOption); //WriteAllToConsole(_employeeRepository);
                break;
            }
            if (userChoice == "X")
            {
                CloseApp = true;
                break;
            }
        }
    }

    public void ChoiceOption(IRepository<IEntity> repository)
    {
        Console.WriteLine("\n   Welcome to PerondaApp\n\n  Select Department\n  _ E\n" +
        "   The HR Employee Department :  -- access to the employee database");

        //var employeeRepository = new ListRepository<Employee>();
        SelectSection();
        bool CloseApp = false;

        while (!CloseApp)
        {
            Console.WriteLine("\n Enter A_to Add new,  F_to Find by ID,  V_to View all  R_to Remove.");
            var userInput = Console.ReadLine()?.ToUpper();
            switch (userInput)
            {
                case "V":
                    WriteAllToConsole(repository);
                    break;
                case "F":
                    GetItemById(repository);
                    break;
                case "A":
                    AddNewItem(repository);
                    break;
                case "R":
                    RemoveItemById(repository);
                    break;
                case "S":
                    SelectSection();
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
    }

    static void AddNewItem(IWriteRepository<Tile> tileRepository)
    {
        WritelineColor($"  Add new Tiles to the list", ConsoleColor.DarkCyan);
        Console.WriteLine(" Please insert details  :   ");
        Console.Write("         name:  ");
        var name = Console.ReadLine();
        Console.Write("        color:  ");
        var color = Console.ReadLine();
        Console.Write("         type:  ");
        var type = Console.ReadLine();
        Console.Write("         cost:  ");
        var cost = Console.ReadLine();   //System.FormatException: „The input string 'g' was not in a correct format.”
        Console.Write("        price:  ");
        var price = Console.ReadLine();

        var newItem = new Tile { Name = name, Color = color, Type = type, StandardCost = decimal.Parse(cost), ListPrice = decimal.Parse(price) };

        tileRepository.Add(newItem);
        tileRepository.Save();
        string action = " | + |  added  ] ";
        object e = newItem;
        tileRepository.SaveAudit(action, e); // ciekawe czy sie zdubluje
        WriteItemAdded(e);
    }

    static void RemoveItemById<T>(IRepository<T> repository) where T : class, IEntity
    {
        Console.Write($" Insert {typeof(T).Name} ID to remove :  ");
        var input = Console.ReadLine();
        var id = int.Parse(input);

        var item = repository.GetById(id);

        if (item is not null)
        {
            repository.Remove(item);
            repository.Save();
            string action = " | - | removed ] ";
            object e = item;
            repository.SaveAudit(action, e);
            WriteItemRemoved(e);
        }
    }

    static void WriteAllToConsole<T>(IReadRepository<T> repository) where T : class, IEntity
    {
        WritelineColor($"  Viev all:    _The {typeof(T).Name}s list_ ", ConsoleColor.Blue);
        var items = repository.GetAll();
        if (items != null)
        {
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
        }
        else
        {
            WritelineColor("\n      This list is empty.",ConsoleColor.Red);
        }
    }

    static void GetItemById(IReadRepository<IEntity> repository)
    {
        //WritelineColor($"  Viev all:    _The {typeof(T).Name}s list_ ", ConsoleColor.Blue);
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
}
