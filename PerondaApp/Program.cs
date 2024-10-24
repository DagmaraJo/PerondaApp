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
        "                                                         press X - to leave\n\n");

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
}