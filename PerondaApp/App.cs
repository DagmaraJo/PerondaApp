namespace PerondaApp;

using PerondaApp.Components.CsvReader;
using PerondaApp.Components.DataProviders;
using PerondaApp.Data.Entities;
using PerondaApp.Data.Repositories;
using System.Reflection.Metadata;
using System.Xml.Linq;

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

    public void CreateXml()
    {
        var records = _csvReader.ProcessTiles("Resources\\Files\\fuel.csv");

        var document = new XDocument();

        var tiles = new XElement("Tiles", records
            .Select(x =>
            new XElement("Tile",
            new XAttribute ("Name", x.Name),
                   new XAttribute("Combined", x.Combined),
                   new XAttribute("Manufacturer", x.ManuFacturer))));

        document.Add(tiles);
        document.Save("Fuel.xml");
    }

    private static void QueryXml()
    {
        var document = XDocument.Load("Fuel.xml");
        var names = document.Element("Tiles")?
            .Elements("Tile")
            .Where(x => x.Attribute("Manufacturer")?.Value=="BMW")
            .Select(x=> x.Attribute("Name")?.Value);

        foreach (var name in names)
        {
            Console.WriteLine(name);
        }
    }

    public void Run()
    {
        CreateXml();
        QueryXml();




        //var tiles = _csvReader.ProcessTiles("Resources\\Files\\fuel.csv");
        //var manufacturers = _csvReader.ProcessManufacturers("Resources\\Files\\manufacturers.csv");

        //var groups = tiles.GroupBy(x => x.ManuFacturer).Select(g => new
        //{
        //    Name = g.Key,
        //    Max = g.Max(t => t.Combined),
        //    Average = g.Average(t => t.Combined)
        //})
        //    .OrderBy(x => x.Average);

        //foreach (var group in groups)
        //{
        //    Console.WriteLine($"{group.Name}");
        //    Console.WriteLine($"\t{group.Max}");
        //    Console.WriteLine($"{group.Average}");
        //}



        //var tilesInCountry = tiles.Join(  //nowa kolekcja za pomocą Join'a, łączy nasze 2 kolekcje z 2 plików
        //    manufacturers,
        //    x => x.ManuFacturer,  // wg klucza z Tile
        //    x => x.Name,           // wg klucza z Manufa
        //    (tile, manufacturer) =>  // z tych połączonych obiektów
        //    new
        //    {               // tworzymy nowy obiekt wg kluczy(w nowej anonimowej klasie)
        //        manufacturer.Country,
        //        tile.Name,
        //        tile.Combined  //ile zostało skonstruowanych
        //    })
        //    .OrderByDescending(x => x.Combined)
        //    .ThenBy(x => x.Name);

        //foreach (var tile in tilesInCountry)
        //{
        //    Console.WriteLine($"Country: {tile.Country}");
        //    Console.WriteLine($"\t Name : {tile.Name}");
        //    Console.WriteLine($"\t Combined : {tile.Combined}");
        //}



        //var tilesInCountry = tiles.Join(  //nowa kolekcja za pomocą Join'a, łączy nasze 2 kolekcje z 2 plików
        //    manufacturers,
        //    t => new { t.ManuFacturer, t.Year },           // wg złożonego klucza z Tile
        //    m => new { ManuFacturer = m.Name, m.Year },    // wg złożonego klucza z Manufa
        //    (tile, manufacturer) =>
        //    new
        //    { 
        //        manufacturer.Country,
        //        tile.Name,
        //        tile.Combined  //ile zostało skonstruowanych
        //    })
        //    .OrderByDescending(x => x.Combined)
        //    .ThenBy(x => x.Name);

        //foreach (var tile in tilesInCountry)
        //{
        //    Console.WriteLine($"Country: {tile.Country}");
        //    Console.WriteLine($"\t Name : {tile.Name}");
        //    Console.WriteLine($"\t Combined : {tile.Combined}");
        //}

        //var groups = manufacturers.GroupJoin(
        //    tiles,
        //    manufacturers => manufacturers.Name,
        //    tile => tile.ManuFacturer,
        //    (m, g) =>
        //    new
        //    { 
        //        Manufacturer = m,
        //        Tiles = g
        //    })
        //    .OrderBy(x => x.Manufacturer.Name);

        //foreach (var tile in groups)
        //{
        //    Console.WriteLine($"Manufacturer: {tile.Manufacturer.Name}");
        //    Console.WriteLine($"\t Tiles : {tile.Tiles.Count()}");
        //    Console.WriteLine($"\t Max : {tile.Tiles.Max(x => x.Combined)}");
        //    Console.WriteLine($"\t Min : {tile.Tiles.Min(x => x.Combined)}");
        //    Console.WriteLine($"\t Avg : {tile.Tiles.Average(x => x.Combined)}");
        //    Console.WriteLine();
        //}



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

    //public static List<Tile> GenerateSampleTiles()
    //{
    //    return new List<Tile>
    //    {
    //        new Tile{
    //            Id = 321,
    //            Name = "ALCHEMY PEARL",
    //            Color = "White",
    //            StandardCost = 97,
    //            ListPrice = 100,
    //            Type = "q.60",
    //        },
    //        new Tile{
    //            Id = 322,
    //            Name = "ALCHEMY PEARL",
    //            Color = "White",
    //            StandardCost = 120,
    //            ListPrice = 120,
    //            Type = "q.90",
    //        },
    //        new Tile{
    //            Id = 323,
    //            Name = "ALCHEMY PEARL",
    //            Color = "White",
    //            StandardCost = 140,
    //            ListPrice = 149,
    //            Type = "60x120",
    //        },
    //        new Tile{
    //            Id = 324,
    //            Name = "ALCHEMY IRON",
    //            Color = "Gray",
    //            StandardCost = 90,
    //            ListPrice = 90,
    //            Type = "q.60",
    //        },
    //        new Tile{
    //            Id = 325,
    //            Name = "ALCHEMY IRON",
    //            Color = "Gray",
    //            StandardCost = 120,
    //            ListPrice = 120,
    //            Type = "q.90",
    //        },
    //        new Tile{
    //            Id = 326,
    //            Name = "ALCHEMY IRON",
    //            Color = "Gray",
    //            StandardCost = 160,
    //            ListPrice = 160,
    //            Type = "q.120",
    //        },
    //        new Tile{
    //            Id = 327,
    //            Name = "ALCHEMY IRON",
    //            Color = "Gray",
    //            StandardCost = 149,
    //            ListPrice = 140,
    //            Type = "60x120",
    //        },
    //        new Tile{
    //            Id = 328,
    //            Name = "ALCHEMY EARTH",
    //            Color = "Beige",
    //            StandardCost = 97,
    //            ListPrice = 90,
    //            Type = "q.60",
    //        },
    //        new Tile{
    //            Id = 329,
    //            Name = "ALCHEMY EARTH",
    //            Color = "Beige",
    //            StandardCost = 97,
    //            ListPrice = 120,
    //            Type = "q.90",
    //        },
    //        new Tile{
    //            Id = 330,
    //            Name = "CLUNY Beige",
    //            Color = "Beige",
    //            StandardCost = 97,
    //            ListPrice = 130,
    //            Type = "q.100",
    //        },
    //        new Tile{
    //            Id = 330,
    //            Name = "CLUNY SAND",
    //            Color = "Beige",
    //            StandardCost = 150,
    //            ListPrice = 270,
    //            Type = "100x275",
    //        },
    //    };
    //}
}
