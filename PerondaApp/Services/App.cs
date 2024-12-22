using PerondaApp.Components.CsvReader;
using PerondaApp.Components.CsvReader.Extensions;
using PerondaApp.Components.DataProviders;
using PerondaApp.Data;
using PerondaApp.Data.Entities;

namespace PerondaApp.Services;

public class App : UserCommunicationBase, IApp
{
    private readonly PerondaAppDbContext _perondaAppDbContext;
    private readonly ICsvReader _csvReader;
    private readonly IFilesProcessor _filesProcessor;
    private readonly IUserCommunication _userCommunication;
    private readonly ICarProvider _carProvider;

    public App(PerondaAppDbContext perondaAppDbContext, ICsvReader csvReader, IFilesProcessor filesProcessor, IUserCommunication userCommunication, ICarProvider carProvider)
    {
        _perondaAppDbContext = perondaAppDbContext;
        _csvReader = csvReader;
        //_perondaAppDbContext.Database.EnsureDeleted();
        _perondaAppDbContext.Database.EnsureCreated();
        _userCommunication = userCommunication;
        _filesProcessor = filesProcessor;
        _carProvider = carProvider;
    }

    public void Run()
    {
        IntroAutoMotoText();
        Console.ReadKey();
        bool Exit = false;
        while (!Exit)
        {
            WritelineColor($"\n  S_ Statistic, V_ View All Cars, G_ View Grouped Cars, N_Find By Name, M_Find More, E_ Edit, U_ User Options\n\t\t\t\tX_ EXIT", ConsoleColor.DarkGreen);
            ConsoleKeyInfo key = Console.ReadKey();
            switch (key.Key)
            {
                case ConsoleKey.S:
                    ViewStatisticalSummariesFrom2016(); 
                    break;
                case ConsoleKey.N:
                    FindByName(); 
                    break;
                case ConsoleKey.V:
                    ViewAllCars(); 
                     break;
                case ConsoleKey.E:
                    EditCarDataaToDbContext();
                    break;
                case ConsoleKey.G:
                    ViewGroupedCarsFromDb();
                    break;
                case ConsoleKey.M:
                    SearchCarsByCriteria();
                    break;
                case ConsoleKey.U:
                    _userCommunication.SelectSection();
                    break;
                case ConsoleKey.X:
                    Environment.Exit(0);
                    break;
                //default:
                //    WritelineColor($"\n      Invalid operation.\n", ConsoleColor.Red);
                //    break; 
            }
        }
        Console.WriteLine("  ~~ closing the program ~~ press any key to leave");
        Console.ReadKey(); 
    }

    public void SearchCarsByCriteria()
    {
        Console.WriteLine("\n\t1 View All Car Models\t\n\t2 View All Car Models\t\n\t3 View All Car Models\t\n\t4 View All Car Models\t");


        ConsoleKeyInfo key = Console.ReadKey();
        switch (key.Key)
        {
            case ConsoleKey.NumPad1:
                ViewUniqueCarNames();
                break;
            case ConsoleKey.NumPad2:
                ViewUniqueCarProducer();
                break;
            case ConsoleKey.NumPad3:
                OrderByNameDescending();
                break;
            case ConsoleKey.NumPad4:
                ViewUniqueCarProduc();
                break;
            case ConsoleKey.Escape:
                return;
            default:
                WritelineColor($"\n      Invalid operation.\n", ConsoleColor.Red);
                break;
        }
    }

    public void ViewUniqueCarNames()
    {
        foreach (var car in _carProvider.GetUniqueNames())
        {
            Console.WriteLine(car);
        }
    }

    public void ViewUniqueCarProducer()
    {
        foreach (var item in _carProvider.GetUniqueNames())
        {
            Console.WriteLine(item);
        }
    }

    private void OrderByNameDescending()
    {
        foreach (var name in _carProvider.GetUniqueNames())
        {
            Console.WriteLine(name);
        }
    }

    private void ViewUniqueCarProduc()
    {
        foreach (var car in _carProvider.DistinctByProducerOrdrByCombined())
        {
            Console.WriteLine($"=== combined {car.Combined} ==<  {car.Manufacturer}  >=======\n\t\t => car model: {car.Name}\n");
        }
    }

    public string FindByName() 
    {
        WritelineColor($"\n\t\t [[__ Find By Name __]]\n", ConsoleColor.DarkCyan);

        string name = GetInputWrite(" Enter model name to find:  ");
        var car = ReadFirst(name);

        WritelineColor($"\t found model car :", ConsoleColor.DarkGray);
        WritelineColor($"  {car}\n", ConsoleColor.Cyan);

        return car!.Name!;
    }

    private Car? FindId2(int id) => _perondaAppDbContext.Cars.SingleOrDefault(x => x.Id == id);

    public void EditCarDataaToDbContext() 
    {
        WritelineColor($"\n\t\t\t [[__ Add new  Car  to the list __]]\n" +
             " Please enter details  :", ConsoleColor.DarkCyan);
        string name = GetInputWrite(" Enter model name to find:  ");
        var car = ReadFirst(name);
        new Car
        {
            Name = GetInputWrite(" Please enter details  :\n   model name:  "),
            Manufacturer = GetInputWrite(" manufacturer:  "),
            Displacement = double.Parse(GetInputWrite(" displacement:  ")),
            City = int.Parse(GetInputWrite("         city:  ")),
            Year = int.Parse(GetInputWrite("         year:  ")),
            Cylinders = int.Parse(GetInputWrite("    cylinders:  ")),
            Highway = int.Parse(GetInputWrite("      highway:  ")),
            Combined = int.Parse(GetInputWrite("     combined:  "))
        };
        WritelineColor($"____entered data:\tbrand {car!.Manufacturer}  car model {car.Name}   \n", ConsoleColor.Cyan);
        _perondaAppDbContext.SaveChanges();
    }

    public void InsertCarData() 
    {
        var cars = _csvReader.ProcessCars("Resources\\Files\\fuel.csv");
        foreach (var car in cars)
        {
            _perondaAppDbContext.Cars.Add(new Car()
            {
                Year = car.Year,
                Manufacturer = car.Manufacturer,
                Name = car.Name,
                Displacement = car.Displacement,
                Cylinders = car.Cylinders,
                City = car.City,
                Highway = car.Highway,
                Combined = car.Combined,
            });
        }
        _perondaAppDbContext.SaveChanges();
    }

    //public void InsertManufacturerData()
    //{
    //    var manufacturers = _csvReader.ProcessManufacturers("Resources\\Files\\manufacturers.csv");

    //    foreach (var manufacturer in manufacturers)
    //    {
    //        _perondaAppDbContext.Manufacturer.Add(new()
    //        {
    //            Name = manufacturer.Name,
    //            Country = manufacturer.Country,
    //            Year = manufacturer.Year,
    //        });
    //    }
    //    _perondaAppDbContext.SaveChanges();
    //}

    public void ViewStatisticalSummariesFrom2016()
    {
        Console.WriteLine("\n\t\t\t [[__Car Production Statistics From 2016 Year__\n ");
        bool closeStatistics = false;
        while (!closeStatistics)
        {
            WritelineColor($"\n\t\t [[__ Car Production Statistics From 2016 Year __]]\n", ConsoleColor.DarkCyan);
            Console.WriteLine($"\t1_ General Statistics - Max & Average Combined By Producer\n\t2_ Detailed Statistics - Cars Count, Max, Min & Average Combined By Producer in alphabetical order\n\t3_ Desc. Combined ~~ country/ model car" +
                $"\n\t4_ BMW model names\n\t5_ Open/View files >>  fuelSchemat.xml\n\t6_ Open/View files >>  fuelNumberOfCarModelsByBrand.xml\n\t7_ Open/View files >>  fuel.xml \t\t _______ Esc - return\n");
            ConsoleKeyInfo keyStatistics = Console.ReadKey();
            switch (keyStatistics.Key)
            {
                case ConsoleKey.NumPad1:
                    _filesProcessor.QeryCsvOrderByAverageCombinedByManufacturer();
                    break;
                case ConsoleKey.NumPad2:
                    _filesProcessor.QeryCsvCarCombinedStatisticsOrderByManufacturer();
                    break;
                case ConsoleKey.NumPad3:
                    _filesProcessor.QeryCsvOrderDescCarsCombinedInCountry();
                    break;
                case ConsoleKey.NumPad4:
                    _filesProcessor.QeryBmwXml();
                    break;
                case ConsoleKey.NumPad5:
                    _filesProcessor.ViewXmlFile("Resources\\Files\\fuelSchemat.xml");
                    break;
                case ConsoleKey.NumPad6:
                    _filesProcessor.ViewXmlFile("Resources\\Files\\fuelNumberOfCarModelsByBrand.xml"); 
                    break;
                case ConsoleKey.NumPad7:
                    _filesProcessor.ViewXmlFile("Resources\\Files\\fuel.xml");
                    break;
                case ConsoleKey.Escape: return;
            }
        }
    }

    private Car? ReadFirst(string name)
    {
        return _perondaAppDbContext.Cars.FirstOrDefault(c => c.Name == name);
    }

    private void ViewGroupedCarsFromDb()
    {
        var groups = _perondaAppDbContext
            .Cars.GroupBy(x => x.Manufacturer) 
            .Select(x => new
            {
                Name = x.Key,
                Cars = x.ToList()
            })
            .ToList();

        foreach (var group in groups)
        {
            Console.WriteLine(group.Name);
            Console.WriteLine("=======");
            foreach (var car in group.Cars)
            {
                Console.WriteLine($"\t {car.Name}: {car.Combined}");
            }
            Console.WriteLine();
        }
    }

    private void ViewAllCars()
    {
        WritelineColor($"\t\t\t [[__ View All Cars __]]\n", ConsoleColor.DarkCyan);
        var carsFromDb = _perondaAppDbContext.Cars.ToList();
        foreach (var carFromDb in carsFromDb)
        {
            Console.WriteLine($"\n  {carFromDb}");
        }
    }
}