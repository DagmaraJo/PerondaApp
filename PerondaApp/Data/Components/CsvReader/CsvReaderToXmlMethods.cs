using System.Xml.Linq;

namespace PerondaApp.Data.Components.CsvReader;

public class CsvReaderToXmlMethods : CsvReader, ICsvReader
{
    public void QeryCsvOrderAverageCombinedByManufacturer()
    {
        var cars = ProcessCars("Resources\\Files\\fuel.csv");
        var manufacturers = ProcessManufacturers("Resources\\Files\\manufacturers.csv");

        var groups = cars.GroupBy(x => x.Manufacturer)
            .Select(g => new
            {
                Name = g.Key,
                Max = g.Max(c => c.Combined),
                Average = g.Average(c => c.Combined)
            })
            .OrderBy(x => x.Average);

        foreach (var group in groups)
        {
            Console.WriteLine($"{group.Name}");
            Console.WriteLine($"\tMax:{group.Max}");
            Console.WriteLine($"\tAverage{group.Average}");
        }
    }

    public void QeryCsvCarCombinedStatisticsOrderByManufacturer()
    {
        var cars = ProcessCars("Resources\\Files\\fuel.csv");
        var manufacturers = ProcessManufacturers("Resources\\Files\\manufacturers.csv");

        var groups = manufacturers.GroupJoin(
            cars,
            manufacturers => manufacturers.Name,
            car => car.Manufacturer,
            (m, g) =>
            new
            {
                Manufacturer = m, 
                Cars = g     
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

    public void QeryCsvOrderDescCarsCombinedInCountry()
    {
        var cars = ProcessCars("Resources\\Files\\fuel.csv");
        var manufacturers = ProcessManufacturers("Resources\\Files\\manufacturers.csv");

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
            Console.WriteLine($"Country: {car.Country}");
            Console.WriteLine($"\t Name : {car.Name}");
            Console.WriteLine($"\t Combined : {car.Combined}");
        }
    }

    private void CreateNumberOfCarModelsByBrandXml()
    {
        var records = ProcessCars("Resources\\Files\\fuel.csv");

        var document = new XDocument();

        var cars = new XElement("Cars", records
            .Select(x =>
            new XElement("Car",
            new XAttribute("Name", x.Name),
                   new XAttribute("Combined", x.Combined),
                   new XAttribute("Manufacturer", x.Manufacturer))));

        document.Add(cars);
        document.Save("Resources\\Files\\fuelNumberOfCarModelsByBrand.xml");
    }

    private static void QeryBmwXml() 
    {
        var document = XDocument.Load("Resources\\Files\\fuelNumberOfCarModelsByBrand.xml");
        var names = document
            .Element("Cars")?
            .Elements("Car")
            .Where(x => x.Attribute("Manufacturer")?.Value == "BMW")
            .Select(x => x.Attribute("Name")?.Value);

        if (names != null)
        {
            foreach (var name in names)
            {
                Console.WriteLine(name);
            }
        }
    }
   
    private void CreateNoAttributesXml()
    {
        var records = ProcessCars("Resources\\Files\\fuel.csv");

        var document = new XDocument();

        var cars = new XElement("Cars", records
            .Select(x =>
            new XElement("Car"
            )
            ));

        document.Add(cars);
        document.Save("Resources\\Files\\fuelNoAttributesCars.xml");
    }

    private void CreateFuelXml()
    {
        var records = ProcessCars("Resources\\Files\\fuel.csv");

        var document = new XDocument();

        var cars = new XElement("Cars", records
            .Select(x =>
            new XElement("Car",
                   new XAttribute("Year", x.Year),
                          new XAttribute("Manufacturer", x.Manufacturer),
                          new XAttribute("Name", x.Name),
                          new XAttribute("Displacement", x.Displacement),
                          new XAttribute("Cylinders", x.Cylinders),
                          new XAttribute("City", x.City),
                          new XAttribute("Highway", x.Highway),
                          new XAttribute("Combined", x.Combined))));

        document.Add(cars);
        document.Save("Resources\\Files\\fuel.xml");
    }

    private void CreateNoAttributesSchematXml()
    {
        var cars = ProcessCars("Resources\\Files\\fuel.csv");
        var manufacturers = ProcessManufacturers("Resources\\Files\\manufacturers.csv");

        var document = new XDocument();

        var records = new XElement("Manufacturers", manufacturers
            .Select(m =>
            new XElement("Manufacturer",
            new XElement("Cars", cars
            .Select(g =>
            new XElement("Car")
            )
            ))));

        document.Add(records);
        document.Save("Resources\\Files\\fuelNoAttributesSchemat.xml");
    }
}