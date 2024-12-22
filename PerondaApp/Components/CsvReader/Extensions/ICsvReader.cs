namespace PerondaApp.Components.CsvReader.Extensions;

using PerondaApp.Components.CsvReader.Models;

public interface ICsvReader
{
    List<Car> ProcessCars(string filePath);

    List<Manufacturer> ProcessManufacturers(string filePath);
}