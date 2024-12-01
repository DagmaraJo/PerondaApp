namespace PerondaApp.Data.Components.CsvReader;

using PerondaApp.Data.Components.CsvReader.Models;

public interface ICsvReader
{
    List<Car> ProcessCars(string filePath);

    List<Manufacturer> ProcessManufacturers(string filePath);
}