using PerondaApp.Data.Entities;

namespace PerondaApp.Components.DataProviders;

public interface ICarProvider
{
    List<Car> GetAll();
    public List<Car> GetAllWithUniqueNames();
    public List<string> GetUniqueNames();
    public List<Car> OrderByName();
    public List<Car> OrderByNameDescending();
    public List<Car> OrderByProducerAndName();
    public List<Car> WhereStartsWith(string prefix);
    public List<Car> SkipItems(int howMany);
    public List<Car> SkipItemsWhileNameStartsWith(string prefix);
    public List<string> DistinctAllNames();
    public List<Car> DistinctByNames();
    public List<Car> DistinctByProducerOrdrByCombined();
    public List<Car[]> ChunkItems(int size);
}