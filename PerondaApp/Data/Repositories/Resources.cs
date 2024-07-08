namespace PerondaApp.Data.Repositories;

using Entities;
using System.IO;
using System.Text.Json;

public class ResourcesRepository<T> : IRepository<T> where T : class, IEntity, new()
{
    private List<T> _items = new();

    private readonly string path = $"Resources\\Files\\{typeof(T).Name}_resourcesApdate.json";
    public event EventHandler<T>? ItemAdded;
    public event EventHandler<T>? ItemRemoved;
    //public event EventHandler<T>? ItemSaved;

    private int lastUsedId = 1;
    private string? s;

    public IEnumerable<T> GetAll()
    {
        //return _items.ToList();
        if (File.Exists(path))
        {
            var objectsSerialized = File.ReadAllText(path);
            var deserializedObjects = JsonSerializer.Deserialize<IEnumerable<T>>(objectsSerialized);
            if (deserializedObjects is not null)
            {
                _items = new List<T>();
                foreach (var items in deserializedObjects)
                {
                    _items.Add(items);
                }
            }
        }
        return _items;
    }

    public T? GetById(int id)
    {
        //return _items.Single(item => item.Id == id);
        var itemById = _items.SingleOrDefault(item => item.Id == id);
        if (itemById == null)
        {
            //Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($" {typeof(T).Name} with id {id} not found.");
            //Console.ResetColor();
        }
        return itemById;
    }

    public void Add(T item)
    {
        //if (_items.Count == 0)
        //{
        //    item.Id = lastUsedId;
        //    lastUsedId++;
        //}
        //else if (_items.Count > 0)
        //{
        //    lastUsedId = _items[_items.Count - 1].Id;
        //    item.Id = ++lastUsedId;
        //}

        ////item.Id = _items.Count + 1;
        ////_items.Add(item);

        int newId;
        if (_items.Count == 0)
        {
            newId = 1;
        }
        else
        {
            var currentId = _items
               .OrderBy(item => item.Id)
               .Select(item => item.Id)
               .Last();
            newId = currentId + 1;
        }
        item.Id = newId;
        _items.Add(item);
        ItemAdded?.Invoke(this, item);
    }

    public void Remove(T item)
    {
        _items.Remove(item);
        ItemRemoved?.Invoke(this, item);
    }

    public void Save()
    {
        foreach (var item in _items)
        {
            s = item.ToString();
            Console.WriteLine(s);
        }
        File.Delete(path);
        var objectsSerialized = JsonSerializer.Serialize<IEnumerable<T>>(_items);
        File.WriteAllText(path, objectsSerialized);
    }

    public IEnumerable<T> Read()
    {
        if (File.Exists(path))
        {
            var objectsSerialized = File.ReadAllText(path);
            var deserializedObjects = JsonSerializer.Deserialize<IEnumerable<T>>(objectsSerialized);
            if (deserializedObjects != null)
            {
                foreach (var item in deserializedObjects)
                {
                    _items.Add(item);
                }
            }
        }
        return _items;
    }

    public int GetListCount()
    {
        return _items.Count;
    }

    //public T CreateNewItem()
    //{
    //    return new T();
}    //}


/*
 * public string Date { get; set; }
public string Action { get; set; }
public string ItemData { get; set; }
private string? auditEntry = null;

public List<string> auditEntries = new();
private const string? auditFile = "AuditFile.json";
private static string currentDate => DateTime.Now.ToString();
public JsonAudit(string action, string itemData)
{
    Date = currentDate;
    Action = action;
    ItemData = itemData;

    if (File.Exists(auditFile))
    {
        string json = File.ReadAllText(auditFile);
        auditEntries = JsonSerializer.Deserialize<List<string>>(json)!;
    }
}
public List<string> ReadAuditFile()
{
    if (!File.Exists(auditFile))
    {
        TextPainting(ConsoleColor.DarkRed, "\tThis file does not exist!");
    }

    return auditEntries.ToList();
}
public void AddEntryToFile()
{
    auditEntry = $"| Date: {Date} | Action: {Action} | Item data: {ItemData} |";
    TextPainting(ConsoleColor.DarkCyan, $"\nEntry preview:\n{auditEntry}");
    auditEntries.Add(auditEntry);

    using (var writer = File.AppendText(auditFile))
    {
        writer.WriteLine(auditEntry);
    }
}
public void SaveAuditFile()
{
    string json = JsonSerializer.Serialize(auditEntries);
    File.WriteAllText(auditFile, json);
    TextPainting(ConsoleColor.DarkYellow, "AuditFile saved");
}
private static void TextPainting(ConsoleColor color, string text)
{
    Console.ForegroundColor = color;
    Console.WriteLine(text);
    Console.ResetColor();
    Console.ForegroundColor = ConsoleColor.DarkGray;
    Console.WriteLine("(Message from JsonAuditRepository)\n");
    Console.ResetColor();
}
}

*/