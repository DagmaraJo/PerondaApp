namespace PerondaApp.Data.Components.DataProviders;

using PerondaApp.Data.Components.DataProviders.Extensions;
using PerondaApp.Repositories;
using System.Text;

public class TilesProvider : ITilesProvider
{
    private readonly IRepository<Tile> _tilesRepository;

    public TilesProvider(IRepository<Tile> tilesRepository)
    {
        _tilesRepository = tilesRepository;
    }

    public List<string> GetUniqueTileColors()
    {
        var tiles = _tilesRepository.GetAll();
        var color = tiles.Select(x => x.Color).Distinct().ToList();
        return color;
    }

    public decimal GetMinimumPriceOfAllTiles()
    {
        var tiles = _tilesRepository.GetAll();
        return tiles.Select(x => x.ListPrice).Min();
    }

    public List<Tile> GetSpecificColumns()
    {
        var tiles = _tilesRepository.GetAll();
        var list = tiles.Select(tile => new Tile
        {
            Id = tile.Id,
            Name = tile.Name,
            Type = tile.Type
        }).ToList();

        return list;
    }

    public string AnonymusClassInString()
    {
        var tiles = _tilesRepository.GetAll();
        var list = tiles.Select(tile => new
        {
            Identifier = tile.Id,
            ProductName = tile.Name,
            ProductSize = tile.Type,
        });

        StringBuilder sb = new(2048);
        foreach (var tile in list)
        {
            sb.AppendLine($"Proguct ID : {tile.Identifier}");
            sb.AppendLine($"  Product Name : {tile.ProductName}");
            sb.AppendLine($"  Product Size : {tile.ProductSize}");
        }
        return sb.ToString();
    }

    public List<Tile> FilterTiles(decimal minPrice)
    {
        var tiles = _tilesRepository.GetAll();
        var list = new List<Tile>();

        foreach (var tile in tiles)
        {
            if (tile.ListPrice > minPrice)
            {
                list.Add(tile);
            }
        }
        return list;
    }

    public List<Tile> OrderByName()
    {
        var tiles = _tilesRepository.GetAll();
        return tiles.OrderBy(x => x.Name).ToList();
    }

    public List<Tile> OrderByNameDescending()
    {
        var tiles = _tilesRepository.GetAll();
        return tiles.OrderByDescending(x => x.Name).ToList();
    }

    public List<Tile> OrderByColorAndName()
    {
        var tiles = _tilesRepository.GetAll();
        return tiles
            .OrderBy(x => x.Color)
            .ThenBy(x => x.Name)
            .ToList();
    }

    public List<Tile> OrderByColorAndNameDesc()
    {
        var tiles = _tilesRepository.GetAll();
        return tiles
            .OrderByDescending(x => x.Color)
            .ThenByDescending(x => x.Name)
            .ToList();

    }

    public List<Tile> WhereStartsWith(string prefix)
    {
        var tiles = _tilesRepository.GetAll();
        return tiles.Where(x => x.Name.StartsWith(prefix)).ToList();
    }

    public List<Tile> WhereStartsWithAndCostIsGreaterThan(string prefix, decimal cost)
    {
        var tiles = _tilesRepository.GetAll();
        return tiles.Where(x => x.Name.StartsWith(prefix) && x.StandardCost > cost).ToList();
    }

    public List<Tile> WhereColorIs(string color)
    {
        var tiles = _tilesRepository.GetAll();
        return tiles.ByColor(color).ToList();  //return tiles.ByColor("Gray").ToList();
    }

    //teraz dopisane
    public Tile FirstByColor(string color)
    {
        var tiles = _tilesRepository.GetAll();
        return tiles.First(x => x.Color == color);
    }

    public Tile? FirstOrDefaultByColor(string color) //fajniejsza wersja z opcją zwracania null
    {
        var tiles = _tilesRepository.GetAll();
        return tiles.FirstOrDefault(x => x.Color == color);
    }

    public Tile FirstOrDefaultByColorWithDefault(string color) // kiedy defaultem ma być obiekt określony przez nas, a nie "zwykły null"
    {
        var tiles = _tilesRepository.GetAll();
        return tiles
            .FirstOrDefault(
            x => x.Color == color,  //x => x.Color == "Gray",
            new Tile { Id = -1, Name = "NOT FOUND" });
    }

    public Tile LastByColor(string color)
    {
        var tiles = _tilesRepository.GetAll();
        return tiles.Last(x => x.Color == color);
    }

    public Tile SingleById(int id)
    {
        var tiles = _tilesRepository.GetAll();
        return tiles.Single(x => x.Id == id);
    }

    public Tile? SingleOrDefaultById(int id) // żeby nie leciał exception to jest lepsza wersja-gdy spytamy o id które nie istnieje - defaultem będzie null
    {
        var tiles = _tilesRepository.GetAll();
        return tiles.SingleOrDefault(x => x.Id == id);
    }





    public List<Tile> TakeTiles(int howMany)
    {
        var tiles = _tilesRepository.GetAll();
        return tiles
            .OrderBy(x => x.Color)
            .Take(howMany)
            .ToList();
    }

    public List<Tile> TakeTilesRange(Range range)
    {
        var tiles = _tilesRepository.GetAll();
        return tiles
            .OrderBy(x => x.Color)
            .Take(range)  //.Take(2..7) określamy zakres
            .ToList();
    }

    public List<Tile> TakeTilesWhileNameStartsWith(string prefix) // weź tak dużo jak startują z danym prefiksem
    {
        var tiles = _tilesRepository.GetAll();
        return tiles
            .OrderBy(x => x.Name)
            .TakeWhile(x => x.Name.StartsWith(prefix))
            .ToList();
    }

    public List<Tile> SkipTiles(int howMany)
    {
        var tiles = _tilesRepository.GetAll();
        return tiles
            .OrderBy(x => x.Name)
            .Skip(howMany)  // pomiń tyle elementów(np stron itp.) i weź całą resztę
            .ToList();
    }

    public List<Tile> SkipTilesWhileNameStartsWith(string prefix)
    {
        var tiles = _tilesRepository.GetAll();
        return tiles
            .OrderBy(x => x.Name)
            .SkipWhile(x => x.Name.StartsWith(prefix))
            .ToList();
    }

    public List<string> DistinctAllColor()
    {
        var tiles = _tilesRepository.GetAll();
        return tiles
            .Select(x => x.Color)
            .Distinct()
            .OrderBy(c => c)
            .ToList();
    }

    public List<Tile> DistinctTilesByColor()
    {
        var tiles = _tilesRepository.GetAll();
        return tiles
            .DistinctBy(x => x.Color)
            .OrderBy(x => x.Color)
            .ToList();
    }

    public List<Tile[]> ChunkTiles(int size)
    {
        var tiles = _tilesRepository.GetAll();
        return tiles.Chunk(size).ToList();
    }
}
