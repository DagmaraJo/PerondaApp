using DocumentFormat.OpenXml.Wordprocessing;
using PerondaApp.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType; // czemu ?

namespace PerondaApp.Repositories;

public interface IRepository<T> : IReadRepository<T>, IWriteRepository<T> where T : class, IEntity
{
    public const string fileName = "Resources\\Files\\audit.txt";

    public event EventHandler<T>? ItemAdded;
    public event EventHandler<T>? ItemRemoved;

    ////void Add(IEnumerable<IEntity> item);

    void SaveAudit(string action, object e)
    {
        string auditText = $" [ {DateTime.UtcNow} {action} {e} ]";
        using (var writer = File.AppendText(IRepository<IEntity>.fileName))
        {
            writer.WriteLine(auditText);
        }
    }

    void SaveAuditItems(string action, object items)
    {
        string auditText = $" [ {DateTime.UtcNow} {action} {items} ]";
        using (var writer = File.AppendText(IRepository<IEntity>.fileName))
        {
            writer.WriteLine(auditText);
        }
    }
}