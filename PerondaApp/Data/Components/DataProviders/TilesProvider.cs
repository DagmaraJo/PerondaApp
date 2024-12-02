using PerondaApp.Data.Components.DataProviders.Extensions;
using PerondaApp.Repositories;
using System.Text;

namespace PerondaApp.Data.Components.DataProviders;

public class TilesProvider : ITilesProvider
{
    private readonly IRepository<Tile> _tilesRepository;

    public TilesProvider(IRepository<Tile> tilesRepository)
    {
        _tilesRepository = tilesRepository;
    }

    public List<Tile> OrderByCollection() 
    {
        var tiles = _tilesRepository.GetAll();
        return tiles.OrderBy(x => x.Collection).ToList();
    }

    public List<string> GetUniqueTileColors()
    {
        var tiles = _tilesRepository.GetAll();
        var color = tiles.Select(x => x.Color).Distinct().ToList();
        return color!;
    }

    public decimal GetMinimumPriceOfAllTiles()
    {
        var tiles = _tilesRepository.GetAll();
        return tiles.Select(tile => tile.ListPrice).Min();
    }

    public decimal GetMaximumPriceOfAllTiles()
    {
        var tiles = _tilesRepository.GetAll();
        return tiles.Select(x => x.ListPrice).Max();
    }

    public List<Tile> GetSpecificColumns()
    {
        var tiles = _tilesRepository.GetAll();
        var list = tiles.Select(tile => new Tile
        {
            Id = tile.Id,
            Name = tile.Name,
            Location = tile.Location,
            Instalator = tile.Instalator
        }).ToList();

        return list;
    }

    public List<Tile> GetSpecificColumns1()
    {
        var tiles = _tilesRepository.GetAll();
        var list = tiles.Select(tile => new Tile
        {
            Id = tile.Id,
            Name = tile.Name,
            Location = tile.ToUse,
            Instalator = tile.ToUse
        }).Skip(5).ToList();

        return list;
    }

    public string AnonymusClassInStringMy()
    {
        var tiles = _tilesRepository.GetAll();
        var list = tiles.Select(tile => new
        {
            tile.Id,
            tile.Name,
            tile.Collection,
            tile.ManuFacturer,
            tile.Instalator,
        });

        StringBuilder sb = new(2048);
        foreach (var tile in list)
        {
            sb.AppendLine($"   _________________________________________________{tile.ManuFacturer}");
            sb.AppendLine($"   Product ID: {tile.Id}            ♦  {tile.Name}");
            sb.AppendLine($"           Collection  {tile.Collection}\n");
        }
        return sb.ToString();
    }

    public string AnonymusClassInStringType()
    {
        var tiles = _tilesRepository.GetAll();
        var list = tiles.Select(tile => new
        {
            tile.Type,
            tile.Name,
            tile.Collection,
            tile.Id,
        });

        StringBuilder sb = new(2048);
        foreach (var tile in list)
        {
            sb.AppendLine($"  Techn.Type:______{tile.Type}");
            sb.AppendLine($"          ID:  {tile.Id}      Collection {tile.Collection}  ♦  {tile.Name}\n");
        }
        return sb.ToString();
    }

    public string AnonymusClassInStringFormat()
    {
        var tiles = _tilesRepository.GetAll();
        var list = tiles.Select(tile => new
        {
            ProductSize = tile.Size,
            ProductName = tile.Name,
            Identifier = tile.Id,
        });

        StringBuilder sb = new(2048);
        foreach (var tile in list)
        {
            sb.AppendLine($"  Product Size : {tile.ProductSize: cm}");
            sb.AppendLine($"    Proguct ID : {tile.Identifier}");
            sb.AppendLine($"  Product Name : {tile.ProductName}\n");
        }
        return sb.ToString();
    }

    public List<Tile> FilterTilesMoreExpensive(decimal minPrice)
    {
        var tiles = _tilesRepository.GetAll();
        var list = new List<Tile>();

        foreach (var tile in tiles)
        {
            if (tile.ListPrice >= minPrice)
            {
                list.Add(tile);
            }
        }
        return list;
    }

    public List<Tile> FilterTilesCheaper(decimal maxCost)
    {
        var tiles = _tilesRepository.GetAll();
        var list = new List<Tile>();

        foreach (var tile in tiles)
        {
            if (tile.StandardCost <= maxCost)
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

    public List<Tile> OrderByProducentAndCollection() 
    {
        var tiles = _tilesRepository.GetAll();
        return tiles
            .OrderBy(x => x.ManuFacturer)
            .ThenBy(x => x.Collection)
            .ToList();
    }

    public List<Tile> WhereStartsWith(string prefix)
    {
        var tiles = _tilesRepository.GetAll();
        return tiles.Where(x => x.Location!.StartsWith(prefix)).ToList();
    }

    public List<Tile> DistinctTilesByInstal()
    {
        var tiles = _tilesRepository.GetAll();
        return tiles
            .DistinctBy(x => x.Instalator)
            .OrderBy(x => x.Instalator)
            .ThenBy(x => x.Location)
            .ThenBy(x => x.Name)
            .ThenBy(x => x.Collection)
            .ToList();
    }

    public List<Tile> DistinctTilesByToUse1() // 1
    {
        var tiles = _tilesRepository.GetAll();
        return tiles
            .DistinctBy(x => x.ToUse)
            .OrderBy(x => x.Name)
            .ThenBy(x => x.Instalator)
            //.ThenBy(x => x.Collection)
            .ToList();
    }

    public List<Tile> DistinctTilesByToUse() // podmianka
    {
        var tiles = _tilesRepository.GetAll();
        return tiles
            .DistinctBy(x => x.ToUse)
            .OrderBy(x => x.Instalator)
            .ThenBy(x => x.Name)
            //.ThenBy(x => x.Collection)
            //.ThenBy(x => x.Name)
            .ToList();
    }

    public List<Tile> WhereStartsWithAndCostIsGreaterThan(string prefix, decimal cost)
    {
        var tiles = _tilesRepository.GetAll();
        return tiles.Where(x => x.Name!.StartsWith(prefix) && x.StandardCost > cost).ToList();
    }

    public List<Tile> TilesMinPrice(decimal minPrice) ////////
    {
        var tiles = _tilesRepository.GetAll();
        return tiles.OrderBy(x => x.ListPrice)
            .Where(x => x.ListPrice >= minPrice).ToList();
    }

    public List<Tile> OrderWhereIsMinimumPrice(decimal minPrice)
    {
        //GetMinimumPriceOfAllTiles();
        var tiles = _tilesRepository.GetAll();
        return tiles
            //.Select(tile => tile.ListPrice).Min()
            .OrderBy(x => x.FullName)
            .Where(tile => tile.ListPrice == minPrice).ToList();
    }

    public List<Tile> WhereColorIs(string color)
    {
        var tiles = _tilesRepository.GetAll();
        return tiles.FilterByColor(color).ToList();  //return tiles.ByColor("Gray").ToList();
    }

    public List<Tile> WhereMaterialIs(string material)
    {
        var tiles = _tilesRepository.GetAll();
        return tiles
            .FilterByMaterial(material).ToList();
    }

    public List<Tile> WhereShapeIs(string shape)
    {
        var tiles = _tilesRepository.GetAll();
        return tiles.FilterByShape(shape).ToList();
    }

    public List<Tile> WhereAppearanceIs(string appearance)
    {
        var tiles = _tilesRepository.GetAll();
        return tiles.FilterByAppearance(appearance).ToList();
    }

    public Tile FirstByMaterial(string material)
    {
        var tiles = _tilesRepository.GetAll();
        return tiles.First(x => x.Material == material); //System.InvalidOperationException: „Sequence contains no matching pasującego element nie zawiera
    }

    public Tile? FirstOrDefaultByMaterial(string material)
    {
        var tiles = _tilesRepository.GetAll();
        return tiles.FirstOrDefault(x => x.Material == material);
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

    public List<Tile> TakeTilesWhileNameStartsWith(string prefix)
    {
        var tiles = _tilesRepository.GetAll();
        return tiles
            .OrderBy(x => x.Collection)
            .TakeWhile(x => x.Collection!.StartsWith(prefix))
            .ToList();
    }

    public List<Tile> TakeTilesWhileToUseStartsWith(string prefix) // weź tak dużo jak startują z danym prefiksem
    {
        var tiles = _tilesRepository.GetAll();
        return tiles
            .OrderBy(x => x.ToUse)  // będzie ok??
            .TakeWhile(tile => tile.Instalator!.StartsWith(prefix))
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
            .SkipWhile(x => x.Name!.StartsWith(prefix))
            .ToList();
    }

    public List<string> DistinctAllColor()
    {
        var tiles = _tilesRepository.GetAll();
        return tiles
            .Select(x => x.Color!)
            .Distinct()
            .OrderBy(c => c)
            .ToList();
    }

    public List<string> DistinctAllToUseInstal()
    {
        var tiles = _tilesRepository.GetAll();
        return tiles
            .Select(x => x.Instalator!)
            .Distinct()
            .OrderBy(c => c)
            .ToList();
    }
    public List<string> DistinctAllToUse()
    {
        var tiles = _tilesRepository.GetAll();
        return tiles
            .Select(x => x.Location!)
            .Distinct()
            .OrderBy(c => c)
            .ToList();
    }

    public List<string> DistinctAllName()// super
    {
        var tiles = _tilesRepository.GetAll();
        return tiles
            .Select(x => x.Name!)
            .Distinct()
            .OrderBy(c => c)
            .ToList();
    }

    public List<string> DistinctAllProducer()
    {
        var tiles = _tilesRepository.GetAll();
        return tiles
            .Select(x => x.Collection!)
            .Distinct()
            .OrderBy(c => c)
            .ToList();
    }

    public List<Tile> DistinctByCollectionOrderByMaterialThanByCollection()
    {
        var tiles = _tilesRepository.GetAll();
        return tiles
            .DistinctBy(x => x.Collection)
            .OrderBy(c => c.Material)
            .ThenBy(x => x.Collection)
            .ToList();

            //.DistinctBy(x => x.Name)
            //.OrderBy(c => c.Material)
            //.ThenBy(x => x.Collection)
            //.ToList();
    }

    public List<Tile> DistinctTilesByProducer()//
    {
        var tiles = _tilesRepository.GetAll();
        return tiles
            //.Select(x => x.Collection!)
            //.Distinct()
            .DistinctBy(x => x.Collection)
            .OrderBy(c => c.ManuFacturer)
            .ThenBy(x => x.Collection) // 2 wersja z tą dopisaną linijką - czy teraz będą kolekcje alfabet?
            .ToList();
    }
    public List<Tile> DistinctByNameThanByProducerAndCollection()
    {
        var tiles = _tilesRepository.GetAll();
        return tiles
            //.Select(x => x.Collection!)  2
            .DistinctBy(x => x.Name)
            .OrderBy(x => x.ManuFacturer)
            .ThenBy(x => x.Collection)
            .OrderBy(c => c.Name)
            .ToList();

        ////.Select(x => x.Collection!)   1
        //    .DistinctBy(x => x.Name)
        //    .DistinctBy(x => x.Collection)
        //    .OrderBy(c => c.ManuFacturer)
        //    .ToList();
    }

    public List<Tile> DistinctTilesByNameOrdrByColor() // CUCOWNIE
    {
        var tiles = _tilesRepository.GetAll();
        return tiles
            //.DistinctBy(x => x.Color)
            //.DistinctBy(x => x.Name)  // dopisane, czy doda resztę nazw ? nie
            //.OrderBy(x => x.Color)
            //.ToList();

            //.DistinctBy(x => x.Name)
            //.DistinctBy(x => x.Color)  // dopisane, czy doda resztę nazw ? nie
            //.OrderBy(x => x.Color)
            //.ToList();
            .DistinctBy(x => x.Name)
            .OrderBy(x => x.Color)  // dopisane, czy doda resztę nazw ? TAA
            .ThenBy(x => x.Name)
            .ToList();

    }

    public List<Tile> DistinctTilesByMaterial()
    {
        var tiles = _tilesRepository.GetAll();
        return tiles
            //.DistinctBy(x => x.Material)  1 ok
            //.OrderBy(x => x.Material)
            //.ToList();

            .DistinctBy(x => x.Name)
            .OrderBy(x => x.Material)
            .ThenBy(x => x.Collection)
            .ThenBy(x => x.Name)
            .ToList();
    }

    public List<Tile[]> ChunkTiles(int size)
    {
        var tiles = _tilesRepository.GetAll();
        return tiles.Chunk(size).ToList();
    }
}