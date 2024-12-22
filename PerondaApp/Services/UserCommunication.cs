using PerondaApp.Components.CsvReader.Extensions;
using PerondaApp.Data;
using PerondaApp.Data.Entities;
using PerondaApp.Data.Repositories;
using PerondaApp.Data.Repositories.Extensions;

namespace PerondaApp.Services;

public class UserCommunication : UserCommunicationBase, IUserCommunication
{
    private readonly PerondaAppDbContext _perondaAppDbContext;
    private readonly IRepository<Car> _carRepository;
    private readonly IRepository<Manufacturer> _manufacturerRepository;

    public UserCommunication(ICsvReader csvReader,
        PerondaAppDbContext perondaAppDbContext,
        IRepository<Car> carRepository,
        IRepository<Manufacturer> manufacturerRepository)
    {
        _perondaAppDbContext = perondaAppDbContext;
        _carRepository = carRepository;
        _manufacturerRepository = manufacturerRepository;
    }

    public void SelectSection()
    {
        bool CloseApp = false;
        while (!CloseApp)
        {
            SelectSectionAutoMotoText();
            ConsoleKeyInfo key = Console.ReadKey();
            switch (key.Key)
            {
                case ConsoleKey.C:
                    CrudOptions(_carRepository);
                    break;
                case ConsoleKey.M:
                    CrudOptions(_manufacturerRepository);
                    break;
                case ConsoleKey.Escape:
                    return;
                default:
                    WritelineColor($"\n      Invalid operation.\n", ConsoleColor.Red);
                    break;
            }
        }
    }

    public void CrudOptions<T>(IRepository<T> repository) where T : class, IEntity
    {
        repository.GetAll();
        repository.SequenceEvents();
        Console.WriteLine($"   The {typeof(T).Name} Department :   E D I T I O N\t   >>  Esc - return \n    ----------------------------------------------------------------------");
        Console.WriteLine($"    C _Create New {typeof(T).Name}  R _Read Name & Edit  U _Update  D _Delete  F _Find  V _View All  \n");
        ConsoleKeyInfo key = Console.ReadKey();
        switch (key.Key)
        {
            case ConsoleKey.C:
                AddNewCar();
                break;
            case ConsoleKey.R:
                FindCarIdByNameWithEditOptions();
                break;
            case ConsoleKey.U:
                SelectFieldToChangeCarData();
                break;
            case ConsoleKey.D:
                repository.RemoveItem();
                break;
            case ConsoleKey.F:
                FindItemByOptions(repository);
                break;
            case ConsoleKey.V:
                repository.WriteAllToConsole();
                break;
            case ConsoleKey.Escape:
                return;
            default:
                WritelineColor($"\n      Invalid operation.\n", ConsoleColor.Red);
                break;
        }
    }

    public string FindCarIdByNameWithEditOptions()
    {
        WritelineColor($"\n\t\tFind By Name\n", ConsoleColor.DarkCyan);
        
        string oldName = GetInputWrite(" Enter model name to find:  ");
        var item = ReadFirstName(oldName); 
        string oldProducer = item!.Manufacturer!;   // obsłużyć stringa !! *System.NullReferenceException: „Object reference not set to an instance of an object.” item było null.
        double oldDisp = item.Displacement;
        WritelineColor($"\t found model car :", ConsoleColor.DarkGray);
        WritelineColor($"\t\t\tID {item!.Id}  model: {item.Name}  producer: {item.Manufacturer}", ConsoleColor.Cyan);
        WritelineColor("   X Exit      edit data >> ", ConsoleColor.DarkYellow);
        bool closeOptions = false;
        while (!closeOptions) 
        {
            var optionEdit = GetInputWrite("\t\t\t >>  C _Create Copy  R _Read All Info  U _Update  D _Delete  A _Add New").ToUpper();
            if (optionEdit == "C")
            {
                _perondaAppDbContext.Cars.Add(new Car() 
                {                             
                    Name = item.Name,
                    Manufacturer = item.Manufacturer,
                    Displacement = item.Displacement,
                    City = item.City,
                    Year = item.Year,
                    Combined = item.Combined,
                    Highway = item.Highway,
                    Cylinders = item.Cylinders,
                });
                Console.WriteLine($"\tCopied model car : {item.Name}   producer : {item.Manufacturer}");
            }
            if (optionEdit == "R") { Console.WriteLine($"\n  {item}"); }
            if (optionEdit == "U")
            {
                    string newName = GetInputWrite("   edit data >>\tUpdate >   Skip fields you want to keep unchanged by pressing Enter\n   model name:  ");
                    if (newName == "") { item.Name = oldName; } else { item.Name = newName; }
                    string newProducer = GetInputWrite(" manufacturer:  ");
                    if (newProducer == "") { item.Manufacturer = oldProducer; } else { item.Manufacturer = newProducer; }

                    var doubleDisp = GetInputWrite(" displacement:  ");
                    var isParsed = double.TryParse(doubleDisp, out double outputNewValue);
                    if (!isParsed) { item.Displacement = oldDisp; }
                    if (isParsed) { item.Displacement = outputNewValue; }
                    _perondaAppDbContext.SaveChanges();
                WritelineColor("\n   [_____ u p d a t e   c o m p l i t e d _____]\n", ConsoleColor.DarkYellow);
                WritelineColor($"____entered data:", ConsoleColor.DarkGray);
                    Console.WriteLine($"\t\t{newName}\t{newProducer}  {outputNewValue}");
                    WritelineColor($"  Press M  _More fields to Update", ConsoleColor.Green); 
            }
            if (optionEdit == "D") { _carRepository.Remove(item); } 
            if (optionEdit == "M") { SelectFieldToChangeCarData(); break; }
            if (optionEdit == "A") { AddNewCar(); }
            if (optionEdit == "X") { break; }
        }
        return item!.Name!;
    }

    private Car? ReadFirstName(string name)
    {
        return _perondaAppDbContext.Cars.FirstOrDefault(c => c.Name == name);
    }

    public void AddNewCar()
    {
        WritelineColor($"\n\t\t [[__ Create new Car __]]\n", ConsoleColor.DarkCyan);
        var car = InseratCarDetails();
        _carRepository.Add(new Car
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

    public static T? FindItemByOptions<T>(IRepository<T> repository) where T : class, IEntity
    {
        WritelineColor("  [___ Find Options ___]", ConsoleColor.DarkGray);
        //var itemFound = repository.FindItemByName();
        //var item = itemFound;
        //if (itemFound == null) { repository.FindItemById(); return item; }
        //WritelineColor("\n  Find  N _Name\t Find  I _Id    Esc - return\n", ConsoleColor.DarkGray);
        //ConsoleKeyInfo key = Console.ReadKey();
        //switch (key.Key)
        //{
        //    case ConsoleKey.Escape:
        //        break;
        //    case ConsoleKey.N:
        //        repository.FindItemByName(); //return itemFound;
        //        break;
        //    case ConsoleKey.I:
        //        repository.FindItemById(); //return itemId;
        //        break;
        //    default:
        //        WritelineColor($"\n      Invalid operation.\n", ConsoleColor.Red);
        //        break;
        //}
        //return item;
        bool closeFind = false;
        while (!closeFind)
        {
            WritelineColor("\t\t\tN _Find Name  I _Find Id   > Esc - return", ConsoleColor.DarkGray);
            ConsoleKeyInfo key = Console.ReadKey();
            switch (key.Key)
            {
                case ConsoleKey.Escape:
                    closeFind = true;
                    break;
                case ConsoleKey.N:
                    repository.FindItemByName(); 
                    break;
                case ConsoleKey.I:
                    repository.FindItemById(); 
                    break;
                default:
                    WritelineColor($"\n      Invalid operation.\n", ConsoleColor.Red);
                    break;
            }
        }
        var itemFound = repository.FindItemByName();
        var item = itemFound;
        if (itemFound == null) { repository.FindItemById(); }
        return item;
    }

    public void SelectFieldToChangeCarData()
    {
        WritelineColor("\t\t[[__ U P D A T A __]]\n", ConsoleColor.DarkCyan);
        var car = FindItemByOptions(_carRepository);
        //string name = GetInputWrite(" Enter model name to find:  ");
        //var car = ReadFirstName(name);
        bool closeUpdata = false;
        while (!closeUpdata)
        {
            WritelineColor("  Fields for changing data :\n\tN _Name\tM _Manufacturer\tC _City\t  F1_ Combined\n\tY _Year\tD _Displacement\t H _Highway\tF2_ Cylinders\n", ConsoleColor.DarkGray);
            ConsoleKeyInfo key = Console.ReadKey();
            switch (key.Key)
            {
                case ConsoleKey.N:
                    var newName = GetInputWrite("   model name:  ");
                    car!.Name = newName;
                    //if (newName == "") { car!.Name = name; } else { car!.Name = newName; }
                    break;
                case ConsoleKey.M:
                    var manufacturer = GetInputWrite(" manufacturer:  ");
                    car!.Manufacturer = manufacturer;
                    break;
                case ConsoleKey.D:
                    //var displacement = double.Parse(GetInputWrite(" displacement:  "));
                    //car!.Displacement = displacement;
                    double oldDisp = car!.Displacement;
                    var doubleDisp = GetInputWrite(" displacement:  ");
                    var isParsed = double.TryParse(doubleDisp, out double outputNewValue);
                    if (!isParsed) { car.Displacement = oldDisp; }
                    if (isParsed) { car.Displacement = outputNewValue; }
                    break;
                case ConsoleKey.C:
                    var city = int.Parse(GetInputWrite("         city:  "));
                    car!.City = city;
                    break;
                case ConsoleKey.Y:
                    var year = int.Parse(GetInputWrite("         year:  "));
                    car!.Year = year;
                    break;
                case ConsoleKey.H:
                    var highway = int.Parse(GetInputWrite("      highway:  "));
                    car!.Highway = highway;
                    break;
                case ConsoleKey.F1:
                    var combined = int.Parse(GetInputWrite("     combined:  "));
                    car!.Combined = combined;
                    break;
                case ConsoleKey.F2:
                    var cylinders = int.Parse(GetInputWrite("    cylinders:  "));
                    car!.Cylinders = cylinders;
                    break;
                default:
                    WritelineColor($"\n      Invalid operation.\n", ConsoleColor.Red);
                    break;
            }
            SaveText();
            var saveOption = GetInputWrite(" Do you want Save Changes? ").ToUpper();

            if (saveOption == "S")
            {
                _carRepository.Save();
                WritelineColor("\t [____ u p d a t e   c o m p l i t e d ____]\n", ConsoleColor.DarkYellow);
                WritelineColor("  " + car, ConsoleColor.DarkGray);
                return;
            }
            if (saveOption == "Q")
            {
                continue;
            }
            if (saveOption == "X")
            {
                return;
            }
        }
    }
}