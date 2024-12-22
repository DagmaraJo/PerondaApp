using DocumentFormat.OpenXml.Office2010.Excel;
using PerondaApp.Components.CsvReader;
using PerondaApp.Components.CsvReader.Extensions;
using PerondaApp.Components.DataProviders;
using PerondaApp.Data;
using PerondaApp.Data.Entities;
//using Car = PerondaApp.Data.Entities.Car;

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
        //Console.Write($"\n               Add new  Car  to the list\n" +
        //     " Please enter details  :\n   model name:  ", ConsoleColor.Blue);
        //var item = Console.ReadLine(); //ReadFirst("Mój samochód Add")!;
        //item.Name = Console.ReadLine();
        //item.Manufacturer = GetInputWrite(" model producent :").ToUpper();
        //Console.WriteLine($"   new model name:  {item.Name}");

        IntroAutoMotoText();
        Console.ReadKey();
        bool Exit = false;
        while (!Exit)
        {
            WritelineColor($"\n  S_ Statistic, V_ View All Cars, G_ View Grouped Cars, N_Find By Name, E_ Edit, U_ User Options\n\t\t\t\tX_ EXIT", ConsoleColor.DarkGreen);
            ConsoleKeyInfo key = Console.ReadKey();
            switch (key.Key)
            {
                case ConsoleKey.S:
                    ViewStatisticalSummariesFrom2016(); // ok
                    break;
                case ConsoleKey.N:
                    FindByName(); // ok  WritelineColor($"\n   Press  E_ Edit options >>\n", ConsoleColor.DarkYellow); EditData();
                    break;
                case ConsoleKey.C:
                    AddByCopyName(); // ok    EditData();
                    break;
                case ConsoleKey.V:
                    ViewAllCars(); // ok
                     break;
                case ConsoleKey.A:
                    EditCarDataaToDbContext();
                    break;
                case ConsoleKey.G:
                    ViewUniqueCarNames();//AddByCopyNameEdit();//ViewGroupedCarsFromDb();
                    break;
                case ConsoleKey.M:
                    SearchCarsByCriteria();
                    break;
                case ConsoleKey.U:
                    _userCommunication.SelectSection(); // spoko
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
        Console.ReadKey(); /*
        FindByName();
        var carsFromDb = _perondaAppDbContext.Cars.ToList();
        var input = GetInputFromUser("   edit data >>  Search what you want Change ").ToUpper();
        foreach (var carFromDb in carsFromDb)
        {
            _perondaAppDbContext.Cars.FirstOrDefault(c => c.Name == name);
        }


        WritelineColor($" ___entered data:\n\t car model: {Name}\n\t     brand: {manufacturer}   {year} comb.: {combined} {city} {displacement} {cylinders} {highway}\n", ConsoleColor.Cyan);
        //var input = GetInputFromUser("   edit data >>  C_ Create, R_ Read, U_ Update, D_ Delete, ");
        bool closeEdit = false;
        while (!closeEdit)
        {
            var input = GetInputFromUser("   edit data >>  C_ Create, R_ Read, U_ Update, D_ Delete, ").ToUpper();
            if (input == "C")
            {
                foreach (var car in cars)
                {
                    _perondaAppDbContext.Cars.Add(new()
                    {
                        Name = car.Name,
                        Manufacturer = car.Manufacturer,
                        Displacement = car.Displacement,
                        City = car.City,
                        Year = car.Year,
                        Combined = car.Combined,
                        Highway = car.Highway,
                        Cylinders = car.Cylinders,
                    });
                }
                _perondaAppDbContext.Cars.Add(item);
                _perondaAppDbContext.SaveChanges();
                break;
            }
            if (input == "R")
            {
                WritelineColor($"____entered data:\t brand {manufacturer}  car model {Name}   {year} comb.: {combined} {city} {displacement} {cylinders} {highway}\n", ConsoleColor.Cyan);

                if (input == "RR") { ViewGroupedCarsFromDb(); }
                if (input == "RRR") { _userCommunication.SelectSection(); }
            }
            if (input == "U") { _perondaAppDbContext.SaveChanges(); }
            if (input == "D") { _perondaAppDbContext.Cars.Remove(item); _perondaAppDbContext.SaveChanges(); }
            if (input == "H") { Run(); }
        }



        //if (input == "C")
        //{
        //    carRepository.Add(item);
        //    carRepository.Save();
        //}
        //if (input == "C") { if (input == "A") { item.Copy(); item.Id = 0; } _perondaAppDbContext.Cars.Add(item); _perondaAppDbContext.SaveChanges(); }
        if (input == "C") { item.Copy(); item.Id = 0; _perondaAppDbContext.Cars.Add(item); _perondaAppDbContext.SaveChanges(); }
        if (input == "R") { ViewGroupedCarsFromDb(); }
        if (input == "U") { _perondaAppDbContext.SaveChanges(); }
        if (input == "D") { _perondaAppDbContext.Cars.Remove(item); _perondaAppDbContext.SaveChanges(); }

        InsertCarData();
        InsertManufacturerData();
        ReadAllCars();
        ReadGroupedCarsFromDb();
        ViewGroupedCarsFromDb();
        EditCarNameFromDb();
        LoadSampleTiles();
        LoadManufacturerData();
        LoadCarData();
        _userCommunication.SelectSection(); 
        */
    }

    public void SearchCarsByCriteria()
    {
        Console.WriteLine("\n\t1 View All Car Models\t"); // WhereStartsWith(string prefix)


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
            Console.WriteLine($"======<  {car.Manufacturer}  >=======\n\tcombined {car.Combined}\n\t\t\t => car model: {car.Name}");
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

    public void EditData()
    {
         FindByName(); // "Cayman" !!
        bool editChoice = false;
        while (!editChoice)
        {
            var optionEdit = GetInputWrite("   edit data >>\n\tC_ Create, R_ Read, U_ Update, D_ Delete, P_ Paste\n").ToUpper();
            //if (optionEdit == "C") { AddToDb();}//InseratCarDetails(); _perondaAppDbContext.Add(car); _perondaAppDbContext.SaveChanges(); }
            //if (optionEdit == "R") { Console.WriteLine($"  {car}"); } 
            //if (optionEdit == "DD") { _perondaAppDbContext.Cars.Remove(item); _perondaAppDbContext.SaveChanges(); }
            if (optionEdit == "U") { _perondaAppDbContext.SaveChanges(); }
            if (optionEdit == "D") { _perondaAppDbContext.Cars.Add(new Car()); _perondaAppDbContext.SaveChanges(); }
            //if (optionEdit == "D") { _perondaAppDbContext.Cars.Remove(); _perondaAppDbContext.SaveChanges(); }
            if (optionEdit == "P") { AddByCopyName(); }
            if (optionEdit == "H") { Run(); }
        }
        //    var optionEdit = GetInputWrite("   edit data >>  C_ Create, R_ Read, U_ Update, D_ Delete, ").ToUpper();
        //if (optionEdit == "C") { _perondaAppDbContext.Cars.Add(new Car()); _perondaAppDbContext.SaveChanges(); }
        //if (optionEdit == "R") { Console.WriteLine($"  {car}"); }
        //if (optionEdit == "U") { _perondaAppDbContext.SaveChanges(); }
        //if (optionEdit == "D") { _perondaAppDbContext.Cars.Remove(new Car()); _perondaAppDbContext.SaveChanges(); }
    }

    private void AddToDb()
    {
        var name = ReadFirst("Cayman"); // <- (" ") wyrzuca błąd
        name!.Name = "Cayman";
        _perondaAppDbContext.Add(name!);
        _perondaAppDbContext.SaveChanges();
    }

    public void EditCarDataaToDbContext() // sprawdzam
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
        //InseratCarDetails2();
        //_perondaAppDbContext.Cars.Add(new Car()
        //{
        //    Year = car.Year,
        //    Manufacturer = car.Manufacturer,
        //    Name = car.Name,
        //    Displacement = car.Displacement,
        //    Cylinders = car.Cylinders,
        //    City = car.City,
        //    Highway = car.Highway,
        //    Combined = car.Combined,
        //});

        //new Car() = InseratCarDetails();


        //_perondaAppDbContext.Cars.Add(new Car());
        _perondaAppDbContext.SaveChanges();
    }

    private void AddByCopyNameEdit() //ok copy
    {
        WritelineColor($"\n\t\t\t [[__ Add  By  Copy __]]\n", ConsoleColor.DarkCyan);
        string name = GetInputWrite(" Enter model name to find:  ");
        var car = ReadFirst(name);

        WritelineColor($"____entered data:\tbrand {car!.Manufacturer}  car model {car.Name}   \n", ConsoleColor.Cyan);
        //InseratCarDetails2();
        var optionEdit = GetInputWrite("   edit data >>  C_ Create, R_ Read All Details, U_ Update, D_ Delete, ").ToUpper();
        if (optionEdit == "C")
        {
            Console.WriteLine($"\tCopied model car :\n {car}");
            //InseratCarDetails();
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
            InseratCarDetails();
            _perondaAppDbContext.SaveChanges();
        }
        if (optionEdit == "R")
        {
            WritelineColor($"\t\t found model car :\n  {car}\n", ConsoleColor.Cyan);
        }
        if (optionEdit == "U")
        {
            InseratCarDetails2();
            _perondaAppDbContext.SaveChanges();
        }
        if (optionEdit == "D")
        {
            _perondaAppDbContext.Cars.Remove(car); _perondaAppDbContext.SaveChanges();
        }
        if (optionEdit == "X")
        {
            Run();
        }
    }

    public void InsertCarData() //ok
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

    private void AddByCopyName()
    {
        WritelineColor($"\n\t\t\t [[__  A D D   C O P Y  __]]\n", ConsoleColor.DarkCyan);
        string name = GetInputWrite(" Enter model name to copy:  ");
        var car = ReadFirst(name);

        WritelineColor($"\t found model car :", ConsoleColor.DarkGray);
        WritelineColor($"  {car}\n", ConsoleColor.Cyan);

        _perondaAppDbContext.Cars.Add(new Car()  // chyba zły kod w tym miejscu
        {
            Year = car!.Year,
            Manufacturer = car.Manufacturer,
            Name = car.Name,
            Displacement = car.Displacement,
            Cylinders = car.Cylinders,
            City = car.City,
            Highway = car.Highway,
            Combined = car.Combined,
        });

        var userChoice = GetInputFromUser("  Enter C_ to confirm COPY, press any to leave").ToUpper();
        if (userChoice == "C") { _perondaAppDbContext.SaveChanges(); }

        WritelineColor($"\t Added a copy to the car list:", ConsoleColor.DarkGray);
        Console.WriteLine($"  {car}\n"); 
    }

    private void AddToDb2()
    {
        var name = ReadFirst("Cayman");
        name!.Name = "Cayman";
        _perondaAppDbContext.Add(name!);
        _perondaAppDbContext.SaveChanges();
    }

    private void RemoveCarByNameFromDb()
    {
        var cayman = ReadFirst("Mój samochód");
        _perondaAppDbContext.Cars.Remove(cayman!);
        _perondaAppDbContext.SaveChanges();
    }

    private void RenameCarNameFromDb()
    {
        var cayman = ReadFirst("Cayman");
        cayman!.Name = "Mój samochód";
        _perondaAppDbContext.SaveChanges();
    }

    private Car? ReadFirst(string name)
    {
        return _perondaAppDbContext.Cars.FirstOrDefault(c => c.Name == name);
    }

    private void ViewGroupedCarsFromDb() // qery -> groups
    {
        var groups = _perondaAppDbContext
            .Cars.GroupBy(x => x.Manufacturer) // całe LINQ
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

    private void ReadGroupedCarsFromDb()
    {
        var qery = _perondaAppDbContext        // IQeryable
            .Cars.GroupBy(x => x.Manufacturer)
            .Select(x => new
            {
                Name = x.Key,
                Cars = x.ToList()
            })
            .ToList();
    }

    private void ViewAllCars()
    {
        WritelineColor($"\t\t\t [[__ View All Cars __]]\n", ConsoleColor.DarkCyan);
        var carsFromDb = _perondaAppDbContext.Cars.ToList();// <-- strzał po dane 
        foreach (var carFromDb in carsFromDb)
        {
            Console.WriteLine($"\n  {carFromDb}");
        }
    }

    private void ReadAllCars()
    {
        //var carsFromDb = _perondaAppDbContext.Cars;   // odczyt <- wchodzi tylko DbSet
        // tu jest miejsce do Qery - zapytań i filtrowania

        var carsFromDb = _perondaAppDbContext.Cars.ToList();// <-- strzał po dane  
    }
}