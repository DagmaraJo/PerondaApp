namespace PerondaApp.Data.Components.DataProviders.Extensions;

public static class TilesHelper //pomocnicza klasa do metod rozszerzalnych dla LINQ, które operuje na IEnumerable
{
    public static IEnumerable<Tile> ByColor(this IEnumerable<Tile> query, string color)
    {
        return query.Where(x => x.Color == color);
    }
}
