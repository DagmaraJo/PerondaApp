namespace PerondaApp.Data.Components.DataProviders;

public interface ITilesProvider
{
    List<Tile> FilterTilesMoreExpensive(decimal minPrice);

    List<Tile> FilterTilesCheaper(decimal maxPrice);

    // select

    List<string> GetUniqueTileColors();

    //List<Tile> GetSpecificColumns1();

    string AnonymusClassInStringFormat();

    string AnonymusClassInStringMy();

    string AnonymusClassInStringType();

    decimal GetMinimumPriceOfAllTiles();

    decimal GetMaximumPriceOfAllTiles();

    // order by

    List<Tile> OrderByName();

    List<Tile> OrderByCollection();

    List<Tile> OrderByNameDescending();

    List<Tile> OrderByColorAndName();

    List<Tile> OrderByColorAndNameDesc();

    List<Tile> OrderWhereIsMinimumPrice(decimal minPrice);

    List<Tile> OrderByProducentAndCollection();

    // where

    List<Tile> WhereStartsWith(string prefix);

    List<Tile> WhereStartsWithAndCostIsGreaterThan(string prefix, decimal cost);

    List<Tile> WhereColorIs(string color);

    List<Tile> WhereMaterialIs(string material);
    
    List<Tile> WhereShapeIs(string shape);

    List<Tile> WhereAppearanceIs(string appearance);

    // first, last, single

    Tile FirstByColor(string color);

    Tile FirstByMaterial(string material);

    Tile? FirstOrDefaultByColor(string color);

    Tile? FirstOrDefaultByMaterial(string material);

    Tile FirstOrDefaultByColorWithDefault(string color);

    Tile LastByColor(string color);

    Tile SingleById(int id);

    Tile? SingleOrDefaultById(int id);

    // take

    List<Tile> TakeTiles(int howMany);

    List<Tile> TakeTilesRange(Range range);

    List<Tile> TakeTilesWhileNameStartsWith(string prefix);

    List<Tile> TakeTilesWhileToUseStartsWith(string prefix);

    // skip

    List<Tile> SkipTiles(int howMany);

    List<Tile> SkipTilesWhileNameStartsWith(string prefix);

    // distinct

    List<string> DistinctAllColor();

    List<string> DistinctAllName();

    List<string> DistinctAllNameOrdeByMaterial();
    List<string> DistinctAllToUse();
    List<string> DistinctAllToUseInstal();

    List<Tile> DistinctTilesByColor();

    List<Tile> DistinctTilesByToUse();

    List<Tile> DistinctTilesByInstal();

    List<Tile> DistinctTilesByMaterial();

    List<string> DistinctAllProducer();

    List<Tile> DistinctTilesByProducer();

    List<Tile> DistinctByCollectionAndMaterial();

    List<Tile> DistinctByNameThanByProducerAndCollection();

    // chunk

    List<Tile[]> ChunkTiles(int size);
}