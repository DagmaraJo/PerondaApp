namespace PerondaApp.Components.CsvReader;

using PerondaApp.Components.CsvReader.Models;

public interface ICsvReader
{
    List<Tile>ProcessTiles(string filePath);

    List<Manufacturer> ProcessManufacturers(string filePath);
}
