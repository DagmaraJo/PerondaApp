using PerondaApp.Data.Entities;
using PerondaApp.Data.Repositories;

namespace PerondaApp.Services;

public class Actions
{
    private readonly IRepository<Employee> _employeeRepository;
    private readonly IRepository<BusinessPartner> _businessPartnerRepository;
    private readonly IRepository<Tile> _tileRepository;
    private readonly IRepository<Person> _personRepository;
    private readonly IRepository<IEntity> _itemRepository;

    public Actions(IRepository<Employee> employeeRepository,
        IRepository<BusinessPartner> businessPartnerRepository,
        IRepository<Tile> tileRepository,
        IRepository<IEntity> _itemRepository)
    {
        _employeeRepository = employeeRepository;
        _businessPartnerRepository = businessPartnerRepository;
        _tileRepository = tileRepository;
        //_personRepository = personRepository;
        //_itemRepository = itemRepository;

    }

    //public void SubscribeToEvents()
    //{
    //    _employeeRepository.ItemAdded += EmployeeRepositoryOnItemAdded;
    //    _employeeRepository.ItemRemoved += EmployeeRepositoryOnItemRemoved;
    //    _businessPartnerRepository.ItemAdded += BusinessPartnerOnItemAdded;
    //    _businessPartnerRepository.ItemRemoved += BusinessPartnerOnItemRemoved;
    //}

    private void EmployeeRepositoryOnItemAdded(object? sender, Employee e)
    {
        AddAuditInfo(e, "ADDED");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($" {e.GetType} successfully.\n");
        Console.ResetColor();
    }

    private void EmployeeRepositoryOnItemRemoved(object? sender, Employee e)
    {
        AddAuditInfo(e, "REMOVED");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($" {e.GetType} successfully.\n");
        Console.ResetColor();
    }

    private void BusinessPartnerOnItemAdded(object? sender, BusinessPartner e)
    {
        AddAuditInfo(e, "ADDED");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($" {e.GetType} successfully.\n");
        Console.ResetColor();
    }

    private void BusinessPartnerOnItemRemoved(object? sender, BusinessPartner e)
    {
        AddAuditInfo(e, "REMOVED");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($" {e.GetType} successfully.\n");
        Console.ResetColor();
    }

    private void AddAuditInfo<T>(T e, string info) where T : class, IEntity
    {
        //using (var writer = File.AppendText(IRepository<IEntity>.fileName))
        using (StreamWriter writer = new StreamWriter(IRepository<IEntity>.fileName, true))
        {
            writer.WriteLine($"  [ {DateTime.UtcNow} ] {info} ]");
        }
    }

    public void SaveAction<T>(T e, string info) where T : class, IEntity
    {
        using (var writer = File.AppendText("newAudit.txt"))
        {
            //foreach(object sender in args)
        }
    }

    //public delegate void ItemAddedCalback(object item);

    static void ItemAddedCalback(object item)
    {
        string s = $" {item} added";

        Console.WriteLine(s);
    }

    static void LoadAudit()
    {

    }

    //private void AddAuditInfo<T>(T e, string info) where T : class, IEntity
    //{
    //    using (var writer = File.AppendText(IRepository<IEntity>.fileName))
    //    {
    //        writer.WriteLine($"[{DateTime.UtcNow}]\t{info} :\n    [{e}]");
    //    }

    //    using (StreamWriter writer = new StreamWriter(IRepository<IEntity>.fileName, true))
    //    {
    //        // zapisujemy nowe linie na początku pliku
    //        writer.WriteLine($" [ {DateTime.UtcNow} | + | {info} {e} ]");
    //    }
    //}
}
