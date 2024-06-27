namespace PerondaApp.Components.CsvReader;

using PerondaApp.Components.CsvReader.Extensions;
using PerondaApp.Components.CsvReader.Models;

public class CsvReader : ICsvReader
{
    public List<Tile> ProcessTiles(string filePath) //procesowanie - obróbka pliku do odczytywania
    {
        if (!File.Exists(filePath))
        {
            return new List<Tile>();
        }

        var tiles = File.ReadAllLines(filePath) //string[]
            .Skip(1)
            .Where(x => x.Length > 1) //IEnumerable<string>
            .ToTile();

        return tiles.ToList();

        //var tiles = File.ReadAllLines(filePath)
        //    .Skip(1)
        //    .Where(x => x.Length > 1)
        //    .Select(x => new Tile());
    }

    public List<Manufacturer> ProcessManufacturers(string filePath)
    {
        if (!File.Exists(filePath))
        {
            return new List<Manufacturer>();
        }
        var manufacturers = File.ReadAllLines(filePath)
            .Where(x => x.Length > 1)
            .Select(x =>
            {
                var columns = x.Split(',');
                return new Manufacturer()
                {
                    Name = columns[0],
                    Country = columns[1],
                    Year = int.Parse(columns[2]),
                };
            });
        return manufacturers.ToList();
    }
}
