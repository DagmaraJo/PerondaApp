namespace PerondaApp.Components.CsvReader.Extensions;

using PerondaApp.Components.CsvReader.Models;
using System.Globalization;

public static class TileExtensions
{
    public static IEnumerable<Tile> ToTile(this IEnumerable<string> source)
    {
        foreach (var line in source)
        {
            var columns = line.Split(',');

            yield return new Tile
            {
                Year = int.Parse(columns[0]),
                Manufacturer = columns[1],
                Name = columns[2],
                Displacement = double.Parse(columns[3], CultureInfo.InvariantCulture),
                Parameters = int.Parse(columns[4]),
                City = int.Parse(columns[5]),
                Highway = int.Parse(columns[6]),
                Combined = int.Parse(columns[7]),
            };
        }
    }
}
