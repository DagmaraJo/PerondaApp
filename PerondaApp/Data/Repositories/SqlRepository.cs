namespace PerondaApp.Data.Repositories;

using Microsoft.EntityFrameworkCore;
using PerondaApp.Data.Entities;

public class SqlRepository<T> : IRepository<T> where T : class, IEntity, new()
{
    //private readonly PerondaAppDbContext _perondaAppDbContext;
    private readonly DbContext _dbContext;
    private readonly DbSet<T> _dbSet;
    //private List<T> _items = new();

    //public PerondaAppDbContext PerondaAppDbContext { get; }
    //public Action<Employee> EmployeeAdded { get; }
    //public Action<Employee> EmployeeRemoved { get; }
    //public Action<BusinessPartner> BusinessPartnerAdded { get; }
    //public Action<BusinessPartner> BusinessPartnerRemoved { get; }

    public SqlRepository(DbContext dbContext, 
        Action<Employee> employeeAdded, Action<Employee> employeeRemoved) 
    //    Action<BusinessPartner> bsinessPartnerAdded, Action<BusinessPartner> bsinessPartnerRemoved)
    {
        _dbContext = dbContext;
        _dbSet = dbContext.Set<T>();
        //    _perondaAppDbContext = perondaAppDbContext;
        //    _dbSet = _perondaAppDbContext.Set<T>();
        //    _perondaAppDbContext.Database.EnsureCreated();

    }

    //public SqlRepository(PerondaAppDbContext perondaAppDbContext, Action<Employee> employeeAdded, Action<Employee> employeeRemoved)
    //{
    //    PerondaAppDbContext = perondaAppDbContext;
    //    EmployeeAdded = employeeAdded;
    //    EmployeeRemoved = employeeRemoved;
    //}

    //public SqlRepository(PerondaAppDbContext perondaAppDbContext, Action<BusinessPartner> businessPartnerAdded, Action<BusinessPartner> businessPartnerRemoved)
    //{
    //    PerondaAppDbContext = perondaAppDbContext;
    //    BusinessPartnerAdded = businessPartnerAdded;
    //    BusinessPartnerRemoved = businessPartnerRemoved;
    //}

    public event EventHandler<T>? ItemAdded;
    public event EventHandler<T>? ItemRemoved;

    public IEnumerable<T> GetAll()
    {
        return _dbSet.OrderBy(item => item.Id).ToList();
    }

    public T? GetById(int id)
    {
        return _dbSet.Find(id);
    }

    public void Add(T item)
    {
        _dbSet.Add(item);
        ItemAdded?.Invoke(this, item);
    }

    public void Remove(T item)
    {
        _dbSet.Remove(item);
        ItemRemoved?.Invoke(this, item);
    }

    public void Save()
    {
        _dbContext.SaveChanges();
    }

    public IEnumerable<T> Read()
    {
        return _dbSet.ToList();
    }

    //public int GetListCount()
    //{
    //    return Read().ToList().Count;
    //}
}