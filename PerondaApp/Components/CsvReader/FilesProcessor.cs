using System.Xml.Linq;
using PerondaApp.Components.CsvReader.Extensions;

namespace PerondaApp.Components.CsvReader;

public class FilesProcessor : CsvReader, IFilesProcessor// DataCarProvider
{
    private readonly ICsvReader _csvReader;

    //public FilesProcessor(ICsvReader csvReader)
    //{
    //    _csvReader = csvReader;
    //}

    //public void GenerateDataFromCsvFile()
    //{
    //    var cars = _csvReader.ProcessCars(@"Resources\Files\fuel.csv");
    //    var manufacturers = _csvReader.ProcessManufacturers(@"Resources\Files\manufacturers.csv");

    //    // GroupBy
    //    GroupManufacturersByName(cars);

    //    // Join
    //    JoinManufacturersAndCars(cars, manufacturers);

    //    // GroupJoin
    //    JoinManufacturersAndCarsGroupByManufacturer(cars, manufacturers);
    //}

    public void QeryCsvOrderByAverageCombinedByManufacturer()//List<Car> cars, List<Manufacturer> manufacturers
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

    public void QeryBmwXml()
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

    private void CreateFuelSchematXml()
    {
        var manufacturers = ProcessManufacturers("Resources\\Files\\manufacturers.csv");
        var cars = ProcessCars("Resources\\Files\\fuel.csv");

        var document = new XDocument();
        var records = new XElement("Manufacturers", manufacturers
            .Select(m =>
            new XElement("Manufacturer",
               new XAttribute("Name", m.Name),
                      new XAttribute("Country", m.Country),
               new XElement("Cars",
                   new XAttribute("country", m.Country),
                          new XAttribute("CombinedSum",
                          cars.Where(c => c.Manufacturer == m.Name).Sum(c => c.Combined)),
                          cars.Where(c => c.Manufacturer == m.Name)
                          .Select(c =>
                       new XElement("Car",
                       new XAttribute("Model", c.Name),
                              new XAttribute("Combined", c.Combined)
                   )))
           )));

        document.Add(records);
        document.Save("Resources\\Files\\fuelSchemat.xml");
        Console.WriteLine(records);
    }

    public void ViewXmlFile(string filePath)
    {
        var document = XDocument.Load(filePath);

        Console.WriteLine(document);
    }

    public void CreateXmlJoined()
    {
        var carsRecords = _csvReader.ProcessCars(@"Resources\Files\fuel.csv");
        var manufacturersRecords = _csvReader.ProcessManufacturers(@"Resources\Files\manufacturers.csv");

        var groupsJoined = manufacturersRecords.GroupJoin(
            carsRecords,
            manufacturer => manufacturer.Name,
            car => car.Manufacturer,
            (m, g) =>
                new
                {
                    Manufacturer = m,
                    Cars = g
                }
            )
        .OrderBy(x => x.Manufacturer.Name);

        var document = new XDocument();

        var manufacturers = new XElement("Manufacturers", groupsJoined
            .Select(x =>
                new XElement("Manufacturer",
                    new XAttribute("Name", x.Manufacturer.Name),
                    new XAttribute("Country", x.Manufacturer.Country),
                        new XElement("Cars",
                            new XAttribute("Country", x.Manufacturer.Country),
                            new XAttribute("CombinedSum", x.Cars.Sum(c => c.Combined)),
                                new XElement("Car", x.Cars
                                    .Select(c =>
                                   new XElement("Car",
                                       new XAttribute("Model", c.Name),
                                       new XAttribute("Combined", c.Combined))))))));

        document.Add(manufacturers);
        document.Save("fuel2.xml");
    }
}