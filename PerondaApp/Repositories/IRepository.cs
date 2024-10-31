using PerondaApp.Entities;

namespace PerondaApp.Repositories;

public interface IRepository<T> : IReadRepository<T>, IWriteRepository<T> where T : class, IEntity
{
    public const string fileName = "Resources\\Files\\audit.txt";

    public event EventHandler<T>? ItemAdded;
    public event EventHandler<T>? ItemRemoved;

    //void SaveAuditItems(string action, object items)
    //{
    //    string auditText = $" [ {DateTime.UtcNow} {action} {items} ]";
    //    using (var writer = File.AppendText(IRepository<IEntity>.fileName))
    //    {
    //        writer.WriteLine(auditText);
    //    }
    //}

    //void SaveAudit(string action, object e)
    //{
    //    string auditText = $" [ {DateTime.UtcNow} {action} {e} ]";
    //    using (var writer = File.AppendText(IRepository<IEntity>.fileName))
    //    {
    //        writer.WriteLine(auditText);
    //    }
    //}

    //void ItemsToList();
}