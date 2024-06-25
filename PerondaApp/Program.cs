using Microsoft.Extensions.DependencyInjection;
using PerondaApp;
using PerondaApp.Components.DataProviders;
using PerondaApp.Data.Entities;
using PerondaApp.Data.Repositories;

var services = new ServiceCollection();
services.AddSingleton<IApp, App>();
services.AddSingleton<IRepository<Employee>, ListRepository<Employee>>();
services.AddSingleton<IRepository<Tile>, ListRepository<Tile>>();
services.AddSingleton<ITilesProvider, TilesProvider>();

//services.AddSingleton<IApp, App>();
//services.AddSingleton<IApp, App>();
//services.AddSingleton<IApp, App>();


var serviceProvider = services.BuildServiceProvider();
var app = serviceProvider.GetService<IApp>()!;
app.Run();















//using PerondaApp.Data;
//using PerondaApp.Entities;
//using PerondaApp.Repositories;
//using PerondaApp.Repositories.Extensions;

//var employeeRepository = new SqlRepository<Employee>(new PerondaAppDbContext(), EmployeeAdded);
//employeeRepository.ItemAdded += EmployeeRepositoryOnItemAdded;

//void EmployeeRepositoryOnItemAdded(object? sender, Employee e)
//{
//    Console.WriteLine($"Employee added =>{e.FirstName} from {sender?.GetType().Name}");
//}

//AddEmployees(employeeRepository);
////AddManagers(employeeRepository);
////Console.WriteLine($"\n   View all managers and employee :\n");
//WriteAllToConsole(employeeRepository);
//GetEmployeeById(employeeRepository);

//static void EmployeeAdded(Employee item)
//{
//    Console.WriteLine($"{item.FirstName} added");
//}

////var businessPartnerRepository = new SqlRepository<BusinessPartner>(new PerondaAppDbContext());
////AddBusinessPartners(businessPartnerRepository);
////Console.WriteLine($"\n   View all Business Partners by ID :\n");
////WriteAllBusinessPartners(businessPartnerRepository);

//static void AddEmployees(IRepository<Employee> repository)
//{
//    var employees = new[]
//    {
//        new Employee { FirstName = "Adam" },
//        new Employee { FirstName = "Piotr" },
//        new Employee { FirstName = "Zuzia" }
//    };

//    repository.AddBatch(employees);
//    "string".AddBatch(employees);
//}

////static void AddEmployees(IRepository<BusinessPartner> businessPartnerRepository)
////{
////    var businessPartners = new[]
////    {
////        new BusinessPartner { },
////        new BusinessPartner { },
////        new BusinessPartner { }
////    };

////    businessPartnerRepository.AddBatch(businessPartners);
////    //AddBatch(businessPartnerRepository, businessPartner);
////}

////static void AddEmployees(IRepository<Employee> employeeRepository)
////{
////    var employees = new[]
////    {
////        new Employee { FirstName = "Adam" },
////        new Employee { FirstName = "Piotr" },
////        new Employee { FirstName = "Zuzia" }
////    };

////    AddBatch(employeeRepository, employees);
////    //employeeRepository.Add(new Employee { FirstName = "Adam" });
////    //employeeRepository.Add(new Employee { FirstName = "Piotr" });
////    //employeeRepository.Add(new Employee { FirstName = "Zuzia" });
////    //employeeRepository.Save();
////}

////static void AddBatch<T>(IRepository<T> repository, T[] items)
////    where T : class, IEntity
////{
////    foreach (var item in items)
////    {
////        repository.Add(item);
////    }
////    repository.Save();
////}

////static void AddManagers(IWriteRepository<Manager> managerRepository)
////{
////    managerRepository.Add(new Manager { FirstName = "Tomek" });
////    managerRepository.Add(new Manager { FirstName = "Przemek" });
////    managerRepository.Save();
////}

//static void GetEmployeeById(IRepository<Employee> employeeRepository)
//{
//    var employee = employeeRepository.GetById(2);
//    Console.WriteLine($"\n   Find employee by ID :\n{employee.ToString()}");
//}

//static void WriteAllToConsole(IReadRepository<IEntity> repository)
//{
//    var items = repository.GetAll();
//    foreach (var item in items)
//    {
//        Console.WriteLine(  item);
//    }
//}

////static void AddBusinessPartners(IRepository<BusinessPartner> businessPartnerRepository)
////{
////    businessPartnerRepository.Add(new BusinessPartner { Name = "Carrea" });
////    businessPartnerRepository.Add(new BusinessPartner { Name = "Opoczno" });
////    businessPartnerRepository.Add(new BusinessPartner { Name = "Nexterio" });
////    businessPartnerRepository.Add(new BusinessPartner { Name = "Leroy Marlin" });
////    businessPartnerRepository.Save();
////}

////static void WriteAllBusinessPartners(IReadRepository<IEntity> businessPartnerRepository)
////{
////    var items = businessPartnerRepository.GetAll();
////    foreach (var item in items)
////    {
////        Console.WriteLine(item);
////    }
////}
