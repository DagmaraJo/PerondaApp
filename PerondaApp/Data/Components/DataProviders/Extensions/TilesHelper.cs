namespace PerondaApp.Data.Components.DataProviders.Extensions;

public static class TilesHelper
{
    public static IEnumerable<Tile> FilterByColor(this IEnumerable<Tile> query, string color)
    {
        return query.Where(x => x.Color == color);
    }

    public static IEnumerable<Tile> FilterByMaterial(this IEnumerable<Tile> query, string material)
    {
        return query.Where(x => x.Material == material);
    }

    public static IEnumerable<Tile> FilterByShape(this IEnumerable<Tile> query, string shape)
    {
        return query.Where(x => x.Shape == shape);
    }

    public static IEnumerable<Tile> FilterByAppearance(this IEnumerable<Tile> query, string appearance)
    {
        return query.Where(x => x.Appearance == appearance);
    }
}