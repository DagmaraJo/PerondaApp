//namespace PerondaApp.DataProviders;

//using PerondaApp.Repositories;

//public class TilesProviderBasic : ITilesProvider
//{
//    private readonly IRepository<Tile> _tilesRepository;

//    public TilesProviderBasic(IRepository<Tile> tilesRepository)
//    {
//        _tilesRepository = tilesRepository;
//    }

//public List<Tile> FilterTiles(decimal minPrice)
//{
//    var tiles = _tilesRepository.GetAll();
//    var list = new List<Tile>();

//    foreach (var tile in tiles)
//    {
//        if (tile.ListPrice > minPrice)
//        {
//            list.Add(tile);
//        }
//    }
//    return list;
//}

//    public List<string> GetUniqueTileColors()
//    {
//        var tiles = _tilesRepository.GetAll();
//        List<string> list = new();

//        foreach (var tile in tiles)
//        {
//            if (!list.Contains(tile.Color))
//            {
//                list.Add(tile.Color);
//            }
//        }
//        return list;
//    }

//    public decimal GetMinimumPriceOfAllTiles()
//    {
//        var tiles = _tilesRepository.GetAll();
//        decimal ret = decimal.MaxValue;

//        foreach (var tile in tiles)
//        {
//            if (tile.ListPrice < ret)
//            {
//                ret = tile.ListPrice;
//            }
//        }
//        return ret;
//    }
//}
