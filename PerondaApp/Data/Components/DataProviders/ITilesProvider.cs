namespace PerondaApp.Data.Components.DataProviders;

public interface ITilesProvider
{
    List<Tile> FilterTiles(decimal minPrice);

    // select

    List<string> GetUniqueTileColors();

    List<Tile> GetSpecificColumns();

    string AnonymusClassInString();

    decimal GetMinimumPriceOfAllTiles();

    // order by

    List<Tile> OrderByName();

    List<Tile> OrderByNameDescending();

    List<Tile> OrderByColorAndName();

    List<Tile> OrderByColorAndNameDesc();

    // where

    List<Tile> WhereStartsWith(string prefix);

    List<Tile> WhereStartsWithAndCostIsGreaterThan(string prefix, decimal cost);

    List<Tile> WhereColorIs(string color);

    // first, last, single

    Tile FirstByColor(string color);

    Tile? FirstOrDefaultByColor(string color);

    Tile FirstOrDefaultByColorWithDefault(string color);

    Tile LastByColor(string color);

    Tile SingleById(int id);

    Tile? SingleOrDefaultById(int id);

    // take

    List<Tile> TakeTiles(int howMany);

    List<Tile> TakeTilesRange(Range range);

    List<Tile> TakeTilesWhileNameStartsWith(string prefix);

    // skip

    List<Tile> SkipTiles(int howMany);

    List<Tile> SkipTilesWhileNameStartsWith(string prefix);

    // distinct

    List<string> DistinctAllColor();

    List<Tile> DistinctTilesByColor();

    // chunk

    List<Tile[]> ChunkTiles(int size);
}
