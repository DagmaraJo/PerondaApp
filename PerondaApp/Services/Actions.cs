using PerondaApp.Entities;
using PerondaApp.Repositories;

namespace PerondaApp.Services;

public class Actions : IActions
{
    private readonly IRepository<Employee> _employeeRepository;
    private readonly IRepository<BusinessPartner> _businessPartnerRepository;
    private readonly IRepository<Tile> _tileRepository;
    //public const string fileName = "Resources\\Files\\audit.txt";
    public string s;
    private readonly IRepository<IEntity> _repository;

    public readonly List<Action> actions = new();

    public Actions(
        IRepository<Employee> employeeRepository,
        IRepository<BusinessPartner> businessPartnerRepository,
        IRepository<Tile> tileRepository)
    {
        _employeeRepository = employeeRepository;
        _businessPartnerRepository = businessPartnerRepository;
        _tileRepository = tileRepository;
    }

    //public void SubscribeToEvents()
    //{
    //    _employeeRepository.ItemAdded += EmployeeRepositoryOnItemAdded;
    //    _employeeRepository.ItemRemoved += EmployeeRepositoryOnItemRemoved;
    //    _businessPartnerRepository.ItemAdded += BusinessPartnerOnItemAdded;
    //    _businessPartnerRepository.ItemRemoved += BusinessPartnerOnItemRemoved;
    //    _tileRepository.ItemAdded += TileRepositoryOnItemAdded;
    //    _tileRepository.ItemRemoved += TileRepositoryOnItemRemoved;
    //}
    public void SubscribeToActions()
    {
        _repository.ItemAdded += (sender, e) => SaveActionInAudit(e,s);
        _repository.ItemRemoved += (sender, e) => SaveActionInAudit(e,s);

        //_businessPartnerRepository.ItemAdded += (sender, e) => SaveItemAddedInAudit(e);

        //_tileRepository.ItemAdded += (sender, e) => SaveItemAddedInAudit(e);

        //_employeeRepository.ItemRemoved += (sender, e) => SaveItemAddedInAudit(e);

        //_businessPartnerRepository.ItemRemoved += (sender, e) => SaveItemAddedInAudit(e);

        //_tileRepository.ItemRemoved += (sender, e) => SaveItemAddedInAudit(e);
    }

    //void EmployeeRepositoryOnItemAdded(object? sender, Employee e)
    //{
    //    string text = $" [ {DateTime.UtcNow} | + | {e} added ]";
    //    using (var writer = File.AppendText(IRepository<IEntity>.fileName))
    //    {
    //        writer.WriteLine(text);
    //    }
    //    Console.WriteLine(text);
    //}

    //private void EmployeeRepositoryOnItemAdded2(object? sender, Employee e) // void _2
    //{
    //    SaveActionInAuditFile(s);
    //}

    //void EmployeeRepositoryOnItemRemoved(object? sender, Employee e)
    //{
    //    string text = $" [ {DateTime.UtcNow} | - | {e} removed ]";
    //    using (var writer = File.AppendText(IRepository<IEntity>.fileName))
    //    {
    //        writer.WriteLine(text);
    //    }
    //    Console.WriteLine(text);
    //}

    //private void EmployeeRepositoryOnItemAdded(object? sender, Employee e)
    //{
    //    AddAuditInfo(e, "ADDED");
    //    Console.ForegroundColor = ConsoleColor.Green;
    //    Console.WriteLine($" {e.GetType} successfully.\n");
    //    Console.ResetColor();
    //}

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

    private void TileRepositoryOnItemAdded(object? sender, Tile e)
    {
        AddAuditInfo(e, "ADDED");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($" {e.GetType} successfully.\n");
        Console.ResetColor();
    }

    private void TileRepositoryOnItemRemoved(object? sender, Tile e)
    {
        AddAuditInfo(e, "REMOVED");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($" {e.GetType} successfully.\n");
        Console.ResetColor();
    }


    static void SaveActionInAuditFile(string s)
    {
        using (var writer = File.AppendText(IRepository<IEntity>.fileName))
        {
            writer.WriteLine($"  [ {DateTime.UtcNow}  {s} ]");
        }
    }

    static void SaveActionInAudit<T>(T e, string s) where T : class, IEntity
    {
        using (var writer = File.AppendText(IRepository<IEntity>.fileName))
        {
            writer.WriteLine($"  [ {DateTime.UtcNow} {s} {e} ]");


            //string text = $" [ {DateTime.UtcNow} | + | {e} added ]";
            //    using (var writer = File.AppendText(IRepository<IEntity>.fileName))
            //    {
            //        writer.WriteLine(text);
            //    }
            //    Console.WriteLine(text);
        }
        //WriteItemAdded(e);
    }

    private void AddAuditInfo<T>(T e, string info) where T : class, IEntity
    {
        using (var writer = File.AppendText(IRepository<IEntity>.fileName))
        //using (StreamWriter writer = new StreamWriter(IRepository<IEntity>.fileName, true))
        {
            writer.WriteLine($"  [ {DateTime.UtcNow} ] {info} ]");


            string text = $" [ {DateTime.UtcNow} | + | {e} added ]";
            //    using (var writer = File.AppendText(IRepository<IEntity>.fileName))
            //    {
            //        writer.WriteLine(text);
            //    }
            //    Console.WriteLine(text);
        }
    }

    static void WriteInfoBack(object? sender, string i)
    {
        
    }

    static void WriteItemAdded(object e)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"  new  {e}  successfully added  ");
        Console.ResetColor();
    }

    static void WriteItemRemoved(object e)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($" {e} just REMOVED");
        Console.ResetColor();
    }
}