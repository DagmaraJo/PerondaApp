namespace PerondaApp.Data.Components.CsvReader;

using PerondaApp.Data.Components.CsvReader.Models;

public interface ICsvReader
{
    List<Tile> ProcessTiles(string filePath);

    List<Manufacturer> ProcessManufacturers(string filePath);
}
