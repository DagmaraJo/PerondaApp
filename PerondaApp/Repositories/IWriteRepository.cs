using PerondaApp.Entities;

namespace PerondaApp.Repositories;

public interface IWriteRepository<in T> where T : class, IEntity
{
    void Add(T item);
    
    void Remove(T item);

    void Save();

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

    //void SaveAudit(string action, object e);

    //void ItemsToList();
}
