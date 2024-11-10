using Nest;
using PerondaApp.Entities;
using PerondaApp.Repositories;

namespace PerondaApp.Services;

public class App : IApp
{
    //private readonly IRepository<Employee> _employeeRepository;
    //private readonly IRepository<BusinessPartner> _businessPartnersRepository;

    private readonly IUserCommunication _userCommunication;
    //rivate readonly IActions _actions;

    public App(
        IUserCommunication userCommunication,
        IActions actions)
    {
        _userCommunication = userCommunication;
        //_actions = actions;
    }

    public void Run()
    {
        
    }

    //public App(IRepository<Employee> employeeRepository)
    //{
    //    _employeeRepository = employeeRepository;
    //}

    //public void Run()
    //{
    //    Console.WriteLine("\n   Welcome to PerondaApp\n\n  Select Department\n  _ E\n" +
    //            "   The HR Employee Department :  -- access to the employee database");

    //    //var employeeRepository = new ListRepository<Employee>();
    //    /// ? var employeeRepository = new SqlRepository<Employee>(new PerondaAppDbContext(), EmployeeRepositoryOnItemAdded())

    //    //employeeRepository.ItemAdded += EmployeeRepositoryOnItemAdded;
    //    //employeeRepository.ItemRemoved += EmployeeRepositoryOnItemRemoved;

    //    //WriteAllToConsole(employeeRepository);
    //}
}