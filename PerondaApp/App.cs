namespace PerondaApp;

using PerondaApp.Entities;
using PerondaApp.Repositories;

public class App : IApp
{
    private readonly IRepository<Employee> _employeesRepository;
    public App(IRepository<Employee> employeeRepository)  // wstrzyknięte repozytorim w konstruktorze
    {
        _employeesRepository = employeeRepository;
    }

    public void Run()
    {
        Console.WriteLine("I'm here in Run() method");

        // adding
        var employees = new[]
        {
           new Employee { FirstName = "Adam" },
           new Employee { FirstName = "Piotr" },
           new Employee { FirstName = "Zuzia" }
        };
        foreach( var employee in employees )
        {
            _employeesRepository.Add( employee );
        }
        _employeesRepository.Save();

        // reading
        var items = _employeesRepository.GetAll();

        foreach( var item in items )
        {
            Console.WriteLine( item );
        }
    }
}
