using PerondaApp.Entities;
using PerondaApp.Repositories;
using System.Text.Json;

namespace PerondaApp.Services;

public class Actions : IActions
{
    private readonly IRepository<Employee> _employeeRepository;
    private readonly IRepository<BusinessPartner> _businessPartnerRepository;
    private readonly IRepository<Tile> _tileRepository;
    //public const string fileName = "Resources\\Files\\audit.txt";
    public string s;

    public Actions(
        IRepository<Employee> employeeRepository,
        IRepository<BusinessPartner> businessPartnerRepository,
        IRepository<Tile> tileRepository)
    {
        _employeeRepository = employeeRepository;
        _businessPartnerRepository = businessPartnerRepository;
        _tileRepository = tileRepository;
    }

    public void SubscribeToEvents()
    {
        _employeeRepository.ItemAdded += EmployeeRepositoryOnItemAdded;
        _employeeRepository.ItemRemoved += EmployeeRepositoryOnItemRemoved;
        _businessPartnerRepository.ItemAdded += BusinessPartnerOnItemAdded;
        _businessPartnerRepository.ItemRemoved += BusinessPartnerOnItemRemoved;
        _tileRepository.ItemAdded += TileRepositoryOnItemAdded;
        _tileRepository.ItemRemoved += TileRepositoryOnItemRemoved;
    }

    private void WriteItemAdded(object e)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        string s = $" | + | {e.GetType} ADDED";
        Console.WriteLine(s);
        //AddAuditInfo(e, "ADDED");

        string text = $" [ {DateTime.UtcNow} | + | {e} added ]";

        //Console.WriteLine($" {e.GetType} successfully.\n");
        Console.ResetColor();
    }

    private void WriteItemRemoved(object e)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        string s = $" | - | {e.GetType} REMOVED";
        Console.WriteLine($" {s} successfully");
        Console.ResetColor();
    }

    void EmployeeRepositoryOnItemAdded(object? sender, Employee e)
    {
        string text = $" [ {DateTime.UtcNow} | + | {e} added ]";
        using (var writer = File.AppendText(IRepository<IEntity>.fileName))
        {
            writer.WriteLine(text);
        }
        Console.WriteLine(text);
    }

    private void EmployeeRepositoryOnItemAdded2(object? sender, Employee e) // void _2
    {
        SaveActionInAuditFile(s);
        WriteItemAdded(e);
        //AddAuditInfo(e, "ADDED");
        //Console.ForegroundColor = ConsoleColor.Green;
        //Console.WriteLine($" {e.GetType} successfully.\n");
        //Console.ResetColor();
    }

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
            writer.WriteLine($"  [ {DateTime.UtcNow}  {s} ]");


            //string text = $" [ {DateTime.UtcNow} | + | {e} added ]";
            //    using (var writer = File.AppendText(IRepository<IEntity>.fileName))
            //    {
            //        writer.WriteLine(text);
            //    }
            //    Console.WriteLine(text);
        }
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

    static void ItemAddedCalback(object item)
    {
        string s = $" {item} added";

        Console.WriteLine(s);
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