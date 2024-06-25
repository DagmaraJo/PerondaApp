namespace PerondaApp.Components.DataProviders;

using PerondaApp.Components.DataProviders.Extensions;
using PerondaApp.Data.Repositories;
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
        var colors = tiles.Select(x => x.Color).Distinct().ToList();
        return colors;
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
            .Take(range)  //.Take(2..7)
            .ToList();
    }

    public List<Tile> TakeTilesWhileNameStartsWith(string prefix)
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
            .Skip(howMany)
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
