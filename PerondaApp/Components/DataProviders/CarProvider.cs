using PerondaApp.Data.Entities;
using PerondaApp.Data.Repositories;
using System.Linq;

namespace PerondaApp.Components.DataProviders;

public class CarProvider : ICarProvider
{
    private readonly IRepository<Car> _carRepository;

    public CarProvider(IRepository<Car> carRepository)
    {
        _carRepository = carRepository;
    }

    public List<Car> GetAll()
    {
        return _carRepository.GetAll().ToList();
    }

    public List<Car> GetAllWithUniqueNames()
    {
        return _carRepository.GetAll()
                .GroupBy(x => x.Name)
                .Where(x => x.Count() == 1)
                .Select(x => x.First())
                .ToList();
    }

    public List<string> GetUniqueNames()
    {
        var items = _carRepository.GetAll();
        var names = items.Select(x => x.Name).Distinct().ToList();
        return names!;
    }

    public List<Car> OrderByName() //FirstOrDefault(c => c.Name == name);
    {
        var items = _carRepository.GetAll();
        return items.OrderBy(x => x.Name).ToList();
    }

    public List<Car> OrderByProducerAndName()
    {
        var items = _carRepository.GetAll();
        return items.OrderBy(x => x.Name).ToList()
        .OrderBy(x => x.Manufacturer)
            .ThenBy(x => x.Name)
            .ToList();
    }

    public List<Car> OrderByNameDescending()
    {
        var items = _carRepository.GetAll();
        return items.OrderByDescending(x => x.Name).ToList();
    }

    public List<Car> WhereStartsWith(string prefix)
    {
        var cars = _carRepository.GetAll();
        return cars.Where(x => x.Name!.StartsWith(prefix)).ToList();
    }

    public List<Car> SkipItems(int howMany)
    {
        var cars = _carRepository.GetAll();
        return cars
           .OrderBy(x => x.Name)
           .Skip(howMany)
           .ToList();
    }

    public List<Car> SkipItemsWhileNameStartsWith(string prefix)
    {
        var cars = _carRepository.GetAll();
        return cars
           .OrderBy(x => x.Name)
           .SkipWhile(x => x.Name!.StartsWith(prefix))
           .ToList();
    }

    public List<string> DistinctAllNames()
    {
        var cars = _carRepository.GetAll();
        return cars
           .Select(x => x.Name!)
           .Distinct()
           .OrderBy(c => c)
           .ToList();
    }

    public List<Car> DistinctByNames()
    {
        var cars = _carRepository.GetAll();
        return cars
           .DistinctBy(x => x.Name)
           .OrderBy(x => x.Name)
           .ToList();
    }

    public List<Car> DistinctByProducerOrdrByCombined()
    {
        var cars = _carRepository.GetAll();
        return cars
            .DistinctBy(x => x.Manufacturer)
            .OrderBy(x => x.Combined)
            .ThenBy(x => x.Name)
            .ToList();
    }

    public List<Car[]> ChunkItems(int size)
    {
        var cars = _carRepository.GetAll();
        return cars.Chunk(size).ToList();
    }

    public  static void SearchCarsByCriteria()
    {

    }
}