using Microsoft.Extensions.DependencyInjection;
using PerondaApp;
using PerondaApp.Components.DataProviders;
using PerondaApp.Data.Entities;
using PerondaApp.Data.Repositories;
using PerondaApp.Components.CsvReader;
using PerondaApp.Data;

//var services = new ServiceCollection();
//services.AddSingleton<IApp, App>();
//services.AddSingleton<IRepository<Employee>, ListRepository<Employee>>();
//services.AddSingleton<IRepository<Tile>, ListRepository<Tile>>();
//services.AddSingleton<ITilesProvider, TilesProvider>();
//services.AddSingleton<ICsvReader, CsvReader>();


//var serviceProvider = services.BuildServiceProvider();
//var app = serviceProvider.GetService<IApp>()!;
//app.Run();



static void WriteAllToConsole(IReadRepository<EntityBase> repository)
{
    var items = repository.GetAll();
    foreach (var item in items)
    {
        Console.WriteLine(item);
    }
}

var employeeRepository = new SqlRepository<Employee>(new PerondaAppDbContext());
var businessPartnersRepository = new SqlRepository<BusinessPartner>(new PerondaAppDbContext());

static void AddEmployees(IRepository<Employee> employeeRepository)
{
    employeeRepository.Add(new Employee { FirstName = "Dorota" });
    employeeRepository.Add(new Employee { FirstName = "Fabian" });
    employeeRepository.Add(new Employee { FirstName = "Sebastian" });
    employeeRepository.Add(new Employee { FirstName = "Katarzyna" });
    employeeRepository.Add(new Employee { FirstName = "łukasz" });
    employeeRepository.Add(new Manager { FirstName = "Magda" });
    employeeRepository.Add(new Employee { FirstName = "Adam" });
    employeeRepository.Add(new Employee { FirstName = "Piotr" });
    employeeRepository.Add(new Employee { FirstName = "Zuzia" });
    employeeRepository.Add(new Manager { FirstName = "Przemek" });
    employeeRepository.Add(new Manager { FirstName = "Tomek" });
    employeeRepository.Add(new Manager { FirstName = "Ricardo" });
    employeeRepository.Save();
}

static void AddBusinessPartners(IRepository<BusinessPartner> businessPartnerRepository)
{
    businessPartnerRepository.Add(new BusinessPartner { Name = "Carrea" });
    businessPartnerRepository.Add(new BusinessPartner { Name = "Opoczno" });
    businessPartnerRepository.Add(new BusinessPartner { Name = "Nexterio" });
    businessPartnerRepository.Add(new BusinessPartner { Name = "Leroy Marlin" });
    businessPartnerRepository.Save();
}

AddEmployees(employeeRepository);
AddBusinessPartners(businessPartnersRepository);

static void GetEmployeeById(IRepository<Employee> employeeRepository)
{
    var employee = employeeRepository.GetById(6);
    Console.WriteLine(employee.ToString());
}

bool Exit = false;
while (!Exit)
{
    Console.WriteLine("\n     MANAGMENT BRANCH - resource list   - press Esc - to leave" +
        "\n" +
        "   Choose option :\n" +
        "      press A   - to viev all employees teem\n" +
        "      press B   - to viev business partners list\n" +
        "      press C   - to viev last searched employee by ID\n");

    ConsoleKeyInfo key = Console.ReadKey();
    switch (key.Key)
    {
        case ConsoleKey.A:
            WriteAllToConsole(employeeRepository); break;
        case ConsoleKey.B:
            WriteAllToConsole(businessPartnersRepository); break;
        case ConsoleKey.C:
            GetEmployeeById(employeeRepository); break;
        case ConsoleKey.Escape:
            Exit = true;
            Environment.Exit(0); break;
        default:
            Console.Clear();
            Console.WriteLine("\n\n\n      Invalid operation.    ");
            break;
    }
}