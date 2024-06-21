using PerondaApp.Data;
using PerondaApp.Entities;
using PerondaApp.Repositories;


var employeeRepository = new SqlRepository<Employee>(new PerondaAppDbContext());
AddEmployees(employeeRepository);
AddManagers(employeeRepository);
Console.WriteLine($"\n   View all managers and employee :\n");
WriteAllToConsole(employeeRepository);
GetEmployeeById(employeeRepository);

var businessPartnerRepository = new SqlRepository<BusinessPartner>(new PerondaAppDbContext());
AddBusinessPartners(businessPartnerRepository);
Console.WriteLine($"\n   View all Business Partners by ID :\n");
WriteAllBusinessPartners(businessPartnerRepository);

static void AddEmployees(IRepository<Employee> employeeRepository)
{
    employeeRepository.Add(new Employee { FirstName = "Adam" });
    employeeRepository.Add(new Employee { FirstName = "Piotr" });
    employeeRepository.Add(new Employee { FirstName = "Zuzia" });
    employeeRepository.Save();
}

Console.WriteLine($"\n   View managers \n");

static void AddManagers(IWriteRepository<Manager> managerRepository)
{
    managerRepository.Add(new Manager { FirstName = "Tomek" });
    managerRepository.Add(new Manager { FirstName = "Przemek" });
    managerRepository.Save();
}

static void GetEmployeeById(IRepository<Employee> employeeRepository)
{
    var employee = employeeRepository.GetById(2);
    Console.WriteLine($"\n   Find employee by ID :\n{employee.ToString()}");
}

static void WriteAllToConsole(IReadRepository<IEntity> repository)
{
    var items = repository.GetAll();
    foreach (var item in items)
    {
        Console.WriteLine(  item);
    }
}

static void AddBusinessPartners(IRepository<BusinessPartner> businessPartnerRepository)
{
    businessPartnerRepository.Add(new BusinessPartner { Name = "Carrea" });
    businessPartnerRepository.Add(new BusinessPartner { Name = "Opoczno" });
    businessPartnerRepository.Add(new BusinessPartner { Name = "Nexterio" });
    businessPartnerRepository.Add(new BusinessPartner { Name = "Leroy Marlin" });
    businessPartnerRepository.Save();
}

static void WriteAllBusinessPartners(IReadRepository<IEntity> businessPartnerRepository)
{
    var items = businessPartnerRepository.GetAll();
    foreach (var item in items)
    {
        Console.WriteLine(item);
    }
}
