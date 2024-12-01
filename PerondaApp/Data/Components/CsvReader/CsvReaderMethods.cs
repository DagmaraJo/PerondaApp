namespace PerondaApp.Data.Components.CsvReader;

internal class CsvReaderMethods : CsvReader, ICsvReader
{
    public void ClueMethods()
    {
        var cars = ProcessCars("Resources\\Files\\fuel.csv");
        var manufacturers = ProcessManufacturers("Resources\\Files\\manufacturers.csv");

        //var groups = cars.GroupBy(x => x.Manufacturer)
        //    .Select(g => new
        //    {
        //        Name = g.Key,
        //        Max = g.Max(c => c.Combined),
        //        Average = g.Average(c => c.Combined)
        //    })
        //    .OrderBy(x => x.Average);

        //foreach (var group in groups)
        //{
        //    Console.WriteLine($"{group.Name}");
        //    Console.WriteLine($"\tMax:{group.Max}");
        //    Console.WriteLine($"\tAverage{group.Average}");
        //}

        var carsInCountry = cars.Join(
            manufacturers,
            c => new { c.Manufacturer, c.Year },
            m => new { Manufacturer = m.Name, m.Year },
            (car, manufacturer) =>
            new
            {
                manufacturer.Country,
                car.Name,
                car.Combined
            })
            .OrderByDescending(x => x.Combined)
            .ThenBy(x => x.Name);

        foreach (var car in carsInCountry)
        {
            Console.WriteLine($"Country: {car.Country}");  //przechwycony kraj na listę <Car>
            Console.WriteLine($"\t Name : {car.Name}");
            Console.WriteLine($"\t Combined : {car.Combined}");
        }

        var groups = manufacturers.GroupJoin(
            cars,
            manufacturers => manufacturers.Name,
            car => car.Manufacturer,
            (m, g) =>
            new
            {                
                Manufacturer = m, //klucz
                Cars = g           //kolekcja
            })
            .OrderBy(x => x.Manufacturer.Name);

        foreach (var car in groups)
        {
            Console.WriteLine($"Manufacturer: {car.Manufacturer.Name}");
            Console.WriteLine($"\t Cars : {car.Cars.Count()}");
            Console.WriteLine($"\t Max : {car.Cars.Max(x => x.Combined)}");
            Console.WriteLine($"\t Min : {car.Cars.Min(x => x.Combined)}");
            Console.WriteLine($"\t Avg : {car.Cars.Average(x => x.Combined)}");
            Console.WriteLine();
        }
    }
}