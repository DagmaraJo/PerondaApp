namespace PerondaApp;

using PerondaApp.Components.CsvReader;
using PerondaApp.Components.DataProviders;
using PerondaApp.Data.Entities;
using PerondaApp.Data.Repositories;

public class App : IApp
{
    private readonly IRepository<Employee> _employeesRepository;
    private readonly IRepository<Tile> _tilesRepository;
    private readonly ITilesProvider _tilesProvider;
    private readonly ICsvReader _csvReader;

    public App(
        IRepository<Employee> employeeRepository, 
        IRepository<Tile> tilesRepository,
        ITilesProvider tilesProvider,
        ICsvReader csvReader)  // wstrzyknięte repozytoria w konstruktorze
    {
        _employeesRepository = employeeRepository;
        _tilesRepository = tilesRepository;
        _tilesProvider = tilesProvider;
        _csvReader = csvReader;
    }

    public void Run()
    {
        var tiles = _csvReader.ProcessTiles("Resources\\Files\\fuel.csv");
        var manufactures = _csvReader.ProcessManufacturers("Resources\\Files\\manufactures.csv");



        //Console.WriteLine("I'm here in Run() method");

        //// adding
        //var employees = new[]
        //{
        //   new Employee { FirstName = "Adam" },
        //   new Employee { FirstName = "Piotr" },
        //   new Employee { FirstName = "Zuzia" }
        //};
        //foreach (var employee in employees)
        //{
        //    _employeesRepository.Add(employee);
        //}
        //_employeesRepository.Save();

        //// reading
        //var items = _employeesRepository.GetAll();

        //foreach (var item in items)
        //{
        //    Console.WriteLine(item);
        //}

        //// tiles
        //var tiles = GenerateSampleTiles();
        //foreach (var item in tiles)
        //{
        //    _tilesRepository.Add(item);
        //}

        //Console.WriteLine();
        //Console.WriteLine("GetUniqueTileColors()");
        //foreach (var item in _tilesProvider.GetUniqueTileColors())  // Run()
        //{
        //    Console.WriteLine(item);
        //}

        //Console.WriteLine();
        //Console.WriteLine("GetMinimumPriceOfAllTiles()");
        //Console.WriteLine(_tilesProvider.GetMinimumPriceOfAllTiles());

        //Console.WriteLine();
        //Console.WriteLine("GetSpecificColumns()");
        //foreach (var item in _tilesProvider.GetSpecificColumns())
        //{
        //    Console.WriteLine(item);
        //}

        //Console.WriteLine();
        //Console.WriteLine("AnonymusClassInString()");
        //Console.WriteLine(_tilesProvider.AnonymusClassInString());

        //Console.WriteLine();
        //Console.WriteLine("OrderByName()");
        //foreach (var item in _tilesProvider.OrderByName())
        //{
        //    Console.WriteLine(item);
        //}

        //Console.WriteLine();
        //Console.WriteLine("OrderByNameDescending()");
        //foreach (var item in _tilesProvider.OrderByNameDescending())
        //{
        //    Console.WriteLine(item);
        //}

        //Console.WriteLine();
        //Console.WriteLine("WhereStartsWith : C");
        //foreach (var item in _tilesProvider.WhereStartsWith("C"))
        //{
        //    Console.WriteLine(item);
        //}

        //Console.WriteLine();
        //Console.WriteLine("WhereStartsWithAndCostIsGreaterThan : C , cost > 140");
        //foreach (var item in _tilesProvider.WhereStartsWithAndCostIsGreaterThan("C", 140))
        //{
        //    Console.WriteLine(item);
        //}

        //Console.WriteLine();
        //Console.WriteLine("WhereColorIs : gray");
        //foreach (var item in _tilesProvider.WhereColorIs("Gray"))
        //{
        //    Console.WriteLine(item);
        //}

        //Console.WriteLine();
        //Console.WriteLine("TakeTiles : 4");
        //foreach (var tile in _tilesProvider.TakeTiles(4))
        //{
        //    Console.WriteLine(tile);
        //}

        //Console.WriteLine();
        //Console.WriteLine("TakeTilesRange");
        //foreach (var tile in _tilesProvider.TakeTilesRange(3..7))
        //{
        //    Console.WriteLine(tile);
        //}

        //Console.WriteLine();
        //Console.WriteLine("TakeTilesWhileNameStartsWith : A");
        //foreach (var tile in _tilesProvider.TakeTilesWhileNameStartsWith("A"))
        //{
        //    Console.WriteLine(tile);
        //}

        //Console.WriteLine();
        //Console.WriteLine("SkipTiles : 6");
        //foreach (var item in _tilesProvider.SkipTiles(6))
        //{
        //    Console.WriteLine(item);
        //}

        //Console.WriteLine();
        //Console.WriteLine("SkipTilesWhileNameStartsWith : A");
        //foreach (var item in _tilesProvider.SkipTilesWhileNameStartsWith("A"))
        //{
        //    Console.WriteLine(item);
        //}

        //Console.WriteLine();
        //Console.WriteLine("DistinctAllColor()");
        //foreach (var item in _tilesProvider.DistinctAllColor())
        //{
        //    Console.WriteLine(item);
        //}

        //Console.WriteLine();
        //Console.WriteLine("DistinctTilesByColor()");
        //foreach (var item in _tilesProvider.DistinctTilesByColor())
        //{
        //    Console.WriteLine(item);
        //}

        //Console.WriteLine();
        //Console.WriteLine("ChunkTiles()");
        //foreach (var item in _tilesProvider.ChunkTiles(3))
        //{
        //    Console.WriteLine($" Chunk : ");
        //    foreach(var i in item) 
        //    { 
        //        Console.WriteLine(i);
        //    }
        //    Console.WriteLine("######");
        //}
    }

    public static List<Tile> GenerateSampleTiles()
    {
        return new List<Tile>
        {
            new Tile{
                Id = 321,
                Name = "ALCHEMY PEARL",
                Color = "White",
                StandardCost = 97,
                ListPrice = 100,
                Type = "q.60",
            },
            new Tile{
                Id = 322,
                Name = "ALCHEMY PEARL",
                Color = "White",
                StandardCost = 120,
                ListPrice = 120,
                Type = "q.90",
            },
            new Tile{
                Id = 323,
                Name = "ALCHEMY PEARL",
                Color = "White",
                StandardCost = 140,
                ListPrice = 149,
                Type = "60x120",
            },
            new Tile{
                Id = 324,
                Name = "ALCHEMY IRON",
                Color = "Gray",
                StandardCost = 90,
                ListPrice = 90,
                Type = "q.60",
            },
            new Tile{
                Id = 325,
                Name = "ALCHEMY IRON",
                Color = "Gray",
                StandardCost = 120,
                ListPrice = 120,
                Type = "q.90",
            },
            new Tile{
                Id = 326,
                Name = "ALCHEMY IRON",
                Color = "Gray",
                StandardCost = 160,
                ListPrice = 160,
                Type = "q.120",
            },
            new Tile{
                Id = 327,
                Name = "ALCHEMY IRON",
                Color = "Gray",
                StandardCost = 149,
                ListPrice = 140,
                Type = "60x120",
            },
            new Tile{
                Id = 328,
                Name = "ALCHEMY EARTH",
                Color = "Beige",
                StandardCost = 97,
                ListPrice = 90,
                Type = "q.60",
            },
            new Tile{
                Id = 329,
                Name = "ALCHEMY EARTH",
                Color = "Beige",
                StandardCost = 97,
                ListPrice = 120,
                Type = "q.90",
            },
            new Tile{
                Id = 330,
                Name = "CLUNY Beige",
                Color = "Beige",
                StandardCost = 97,
                ListPrice = 130,
                Type = "q.100",
            },
            new Tile{
                Id = 330,
                Name = "CLUNY SAND",
                Color = "Beige",
                StandardCost = 150,
                ListPrice = 270,
                Type = "100x275",
            },
        };
    }
}
