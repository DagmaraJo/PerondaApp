using Microsoft.Extensions.DependencyInjection;
using PerondaApp;
using PerondaApp.Components.DataProviders;
using PerondaApp.Data.Entities;
using PerondaApp.Data.Repositories;
using PerondaApp.Data;
using PerondaApp.Data.Repositories.Extensions;
using System.Text;
using Newtonsoft.Json;

//var services = new ServiceCollection();
//services.AddSingleton<IApp, App>();
//services.AddSingleton<IRepository<Employee>, ListRepository<Employee>>();
//services.AddSingleton<IRepository<Tile>, ListRepository<Tile>>();
//services.AddSingleton<ITilesProvider, TilesProvider>();
//services.AddSingleton<ICsvReader, CsvReader>();


//var serviceProvider = services.BuildServiceProvider();
//var app = serviceProvider.GetService<IApp>()!;
//app.Run();



//static void WriteAllToConsole(IReadRepository<EntityBase> repository) //*ostatnie przesłane
//{
//    var items = repository.GetAll();
//    foreach (var item in items)
//    {
//        Console.WriteLine(item);
//    }
//}

//var itemAddedCallback = new ItemAddedCallback(EmployeeAddedNonG); //metoda EmployeeAdded przekazana jako callBack do parametru delegata niegenerycznego
//var itemAdded = new ItemAdded<Employee>(EmployeeAdded);  // EmployeeAddedGener            _________ / / ___________           generycznego
var employeeRepository = new ResourcesSQlRepository<Employee>(new PerondaAppDbContext()); //, itemAddedCallback, itemAdded);
//var employeeRepository = new SqlRepositoryMyVersion<Employee>(new PerondaAppDbContext(), itemAddedCallback, itemAdded);
AddEmployee(employeeRepository);   // .AddBach
ItemAddedCalback(employeeRepository);   // informuja o ścieżce obiektu 
WriteAllToConsole(employeeRepository);

static void EmployeeAddedNonG(object item)  // rzutowanie obiektu boksing 
{
    var employee = (Employee)item;  // unikać castowania
    string text = $" [ {DateTime.UtcNow} | + | {item} added ]";
    using (var writer = File.AppendText(IRepository<IEntity>.fileName))
    {
        writer.WriteLine(text);
    }
    Console.WriteLine(text);
}

static void EmployeeAdded(Employee item)  // od razu jest określony objekt Employee
{
    var employee = item;
    Console.WriteLine($"{item} added   _gener");
    Console.WriteLine($" added {item.GetType().Name} {item} _gener");
}

static void AddEmployee(IRepository<Employee> repository)
{
    var employee = new[]
    {
        new Employee { FirstName = "Konrad" },
        new Employee { FirstName = "Ewa" },
        new Employee { FirstName = "Marek" }
    };

    repository.AddBatch(employee);  // domyślnie jest to AdBach<T> generyczna

    //"string".AddBatch(employee);
}

static void AddEmployeer<T>(IRepository<Employee> repository)
{
    var employee = new[]
    {
        new Employee { FirstName = "Konrad" },
        new Employee { FirstName = "Ewa" },
        new Employee { FirstName = "Marek" }
    };

    repository.AddBatch(employee);  // domyślnie jest to AdBach<T> generyczna

    //"string".AddBatch(employee);
}

static void ItemAddedCalback(object item)
{
    //var item = (EntityBase)item;
    string s = $" {DateTime.UtcNow} | + |  added {item.GetType()}";

    Console.WriteLine(s);

    //Employee item = (Employee)item;
    //Console.WriteLine(item.ToString());

    //var item = (Employee)item;   // nieobsługiwany wyjątek
    //var businessPartner = (BusinessPartner)item;


    //Console.WriteLine($"{item.ToString} added");
    //Console.WriteLine(employee.FirstName + employee.Surname);
    //Console.WriteLine(employee.ToString());
}


static void WriteAllToConsole(IReadRepository<EntityBase> repository) //*ostatnie przesłane
{
    var items = repository.GetAll();
    foreach (var item in items)
    {
        Console.WriteLine(item);
    }
}

//static void SaveAction(IRepository<EntityBase> repository)
//{
//    using (var writer = File.AppendText(IRepository<IEntity>.fileName))
//    {
//        writer.WriteLine();
//        //NewItemAdded?.Invoke(this, new EventArgs());
//    }
//}

static string GetInputFromUser(ref string? input, string comment)
{
    Console.WriteLine(comment); 
    if (String.IsNullOrEmpty(input)) 
    {
        Console.WriteLine($"  This input can not be empty.");
    }
    return Console.ReadLine()!;
}

static void EmptyInputWarning(ref string? input, string inputName)
{
    while (String.IsNullOrEmpty(input))
    {
        WritelineColor($"This input can not be empty.", ConsoleColor.Red);
        //input = GetInputFromUser($"{inputName}:");
    }
}

static void WritelineColor(string text, ConsoleColor foregroundColor, ConsoleColor backgroundColor = default)
{
    Console.ForegroundColor = foregroundColor;
    Console.BackgroundColor = backgroundColor;
    Console.WriteLine(text);
    Console.ResetColor();
}








//war employeeRepository = new SqlRepository<Employee>(new PerondaAppDbContext());

//var businessPartnerRepository = new SqlRepository<BusinessPartner>(new PerondaAppDbContext());//, itemAdded);

//var emp = new ItemAdded(EmployeeAdded);
//var businessP= new ItemAdded(BusinessPartnerAdded);

//employeeRepository.ItemAdded += EmployeeRepositoryOnItemAdded;

//void EmployeeRepositoryOnItemAdded(object? sender, Employee e)
//{
//    Console.WriteLine($"Employee added =>{e.FirstName} from {sender?.GetType().Name}");
//}



//static void AddEmployees(IRepository<Employee> employeeRepository)  s liczba mnoga !?
//{
//    employeeRepository.Add(new Employee { FirstName = "Dorota" });
//employeeRepository.Add(new Employee { FirstName = "Fabian" });
//employeeRepository.Add(new Employee { FirstName = "Sebastian" });
//employeeRepository.Add(new Employee { FirstName = "Katarzyna" });
//employeeRepository.Add(new Employee { FirstName = "łukasz" });
//employeeRepository.Add(new Manager { FirstName = "Magda" });
//employeeRepository.Add(new Employee { FirstName = "Adam" });
//employeeRepository.Add(new Employee { FirstName = "Piotr" });
//employeeRepository.Add(new Employee { FirstName = "Zuzia" });
//employeeRepository.Add(new Manager { FirstName = "Przemek" });
//employeeRepository.Add(new Manager { FirstName = "Tomek" });
//employeeRepository.Add(new Manager { FirstName = "Ricardo" });
//employeeRepository.Save();
//}

//static void AddBusinessPartners(IRepository<BusinessPartner> businessPartnerRepository) s liczba mnoga
//{
//    businessPartnerRepository.Add(new BusinessPartner { Name = "Carrea" });
//    businessPartnerRepository.Add(new BusinessPartner { Name = "Opoczno" });
//    businessPartnerRepository.Add(new BusinessPartner { Name = "Nexterio" });
//    businessPartnerRepository.Add(new BusinessPartner { Name = "Leroy Marlin" });
//    businessPartnerRepository.Save();
//}

//AddEmployee(employeeRepository);
//AddBusinessPartner(businessPartnersRepository);

static void GetEmployeeById(IRepository<Employee> employeeRepository)
{
    var employee = employeeRepository.GetById(6);
    Console.WriteLine(employee);
}

//bool Exit = false;
//while (!Exit)
//{
//    Console.WriteLine("\n     MANAGMENT BRANCH - resource list" +
//        "\n" +
//        "   Choose option :\n" +
//        "      press A   - to viev all employees\n" +
//        "      press B   - to viev all business partners\n" +
//        "      press C   - to add new employees\n" +
//        "      press D   - to add new business partners\n" +
//        "      press E   - to remove new employees\n" +
//        "      press F   - to remove new business partners\n" +
//        "      press G   - to find employee by ID\n" +
//        "      press H   - to find business partner by ID\n\n" +
//        "                                                         press Esc - to leave\n\n");

//    string name;
//    ConsoleKeyInfo key = Console.ReadKey();
//    switch (key.Key)
//    {
//        case ConsoleKey.A:
//            WriteAllToConsole(employeeRepository); break;
//        case ConsoleKey.B:
//            WriteAllToConsole(businessPartnerRepository); break;
//        case ConsoleKey.C:
//            AddEmployee(employeeRepository); break;
//        case ConsoleKey.D:
//            AddNewBusinessPartner(out string fullName, out name, out string position, businessPartnerRepository); 
//            break;
//        case ConsoleKey.NumPad1:
//            RemoveEmployee(employeeRepository); break;
//        case ConsoleKey.NumPad2:
//            RemoveBusinessPartner(businessPartnerRepository); break;
//        case ConsoleKey.U:
//            WriteAllToConsole(employeeRepository); break;
//        case ConsoleKey.F:
//            GetEmployeeById(employeeRepository); break;
//        case ConsoleKey.Escape:
//            Exit = true;
//            Environment.Exit(0); break;
//        default:
//            Console.Clear();
//            Console.WriteLine("\n\n\n      Invalid operation.    ");
//            break;
//    }
//}
////*ostatnie przesłane




//var repository = new SqlRepoToFileTxt<Employee>(new PerondaAppDbContext(), itemAddedCallback);
//var employeeRepository = new ResourcesRepository<Employee>(new PerondaAppDbContext(), itemAddedCallback);
//AddEmployee(out string name);
//var employeeRepository = new SqlRepository<Employee>(new PerondaAppDbContext());
//ItemAdded(repository);
//AddEmployee(repository);

//static void AddEmployee(out string name)
//{
//    Console.Clear();
//    Console.Write("\n\n   Please insert employee name   :  ");
//    name = Console.ReadLine();
//    if (!string.IsNullOrEmpty(name))
//    {
//        var item = new Employee { FirstName = name = Console.ReadLine() };
//        Console.WriteLine("New Employee Added" + item);
//    }
//}

//static void ShowNewEmployee(SqlRepoToFileTxt<Employee>? employeeRepository)
//{
//    var newEmp = new Employee { FirstName = Console.ReadLine() };
//    employeeRepository.Add(newEmp);
//    employeeRepository.Save();
//    WriteAllToConsole(employeeRepository);
//    Console.WriteLine($"New Employee Added : {newEmp.ToString}");
//}





static void InsertFullName(out string fullName, out string name, out string position)
{
    Console.Clear();
    Console.Write("\n\n   Please insert personal details  :   ");
    fullName = Console.ReadLine();
    name = Console.ReadLine();
    position = Console.ReadLine();
}
static void InsertData(out string name, out string secondname, out string surname)
{
    Console.Write("\n\n   Please insert Employee's  :  ");
    name = Console.ReadLine();
    Console.Write("\n\n   Please insert composer's second name  :  ");
    secondname = Console.ReadLine();
    Console.Write("\n\n   Please insert composer's last name    :  ");
    surname = Console.ReadLine();
}


//static void AddNewBusinessPartner( out string fullName, out string name, out string position, SqlRepositoryMyVersion<BusinessPartner> repository)
//{
//    Console.Write("\n\n   Please insert personal details  :   ");
//    //string fullName, name, position;
//    fullName = Console.ReadLine(); 
//    name = Console.ReadLine(); 
//    position = Console.ReadLine();
//    if (!string.IsNullOrEmpty(fullName))
//    {
//        string FullName = fullName;
//        string Name = name,
//        Position = position;

//        var businessPartner = new ItemAdded(repository);



//        Console.WriteLine($" New Business Partner Added : {businessPartner}");

//        var textAudit = $" | + |  {businessPartner} added";
//        Console.WriteLine(textAudit);
//        //DateTime currentDate = DateTime.Now;
//        using (var writer = File.AppendText(IRepository<IEntity>.auditFileName))
//        {
//            writer.WriteLine($" [ {DateTime.UtcNow} {textAudit} ]");
//        }

//        //using (var writer = File.AppendText("Files\\Audit.txt"))
//        //{
//        //    writer.WriteLine($"  [ {DateTime.UtcNow} {textAudit} ]");
//        //}

//    }
//}

static void RemoveEmployee(IRepository<Employee> employeeRepository)
{
    employeeRepository.Remove(new Employee { FirstName = "Magda" });
    employeeRepository.Remove(new Employee { FirstName = "Sebastian" });
    employeeRepository.Save();
}

static void RemoveBusinessPartner(IRepository<BusinessPartner> businessPartnersRepository)
{
    businessPartnersRepository.Remove(new BusinessPartner { Name = "Magda" });
    businessPartnersRepository.Remove(new BusinessPartner { Name = "Sebastian" });
}

void RemoveItem<T>(IRepository<EntityBase> repository) where T : class, IEntity
{

}

//static void SaveInAuditFile(SqlRepoToFileTxt<Employee> itemAddedCallback)
//{
//    AddEmployees(employeeRepository);
//}

//static void SaveAudit(object sender, EventArgs e)
//{
//    var path = "Audit.txt"; // AppendAllText

//    using (FileStream fileStream = File.Create(path))
//    {
//        var text = "123";
//        var content = Encoding.UTF8.GetBytes(text);
//        fileStream.Write(content, 0, content.Length);
//    }

//    using (var writer = File.AppendText((IRepository<IEntity>.auditFileName)))
//    {
//        writer.WriteLine($"[{DateTime.UtcNow}]\t{info} :\n    [{e}]");
//    }
//}                   ZuZ

//static void AddEmployee(IRepository<Employee> repository)
//{
//    //var employee = new[]
//    //{
//    //    new Employee { FirstName = "Konrad" },
//    //    new Employee { FirstName = "Ewa" },
//    //    new Employee { FirstName = "Marek" }
//    //};

//    //repository.AddBatch(employee);  // domyślnie jest to AdBach<T> generyczna
//    //"string".AddBatch(employee);
//    //var text = $"{employee.ToString} added";

//    //Console.WriteLine(employee.ToString + "added");
//    //Console.WriteLine(text);


//    //string json = JsonConvert.SerializeObject(employee);
//    //string path = "ścieżka/do/Employees.json";
//    //File.WriteAllText(path, json);
//}

void EmployeeAdded2(object item) // liczba mnoga  employeeS addBatch - wiele obiektów na raz
{
    //Employee employee = (Employee)item;
    //Console.WriteLine(employee.ToString);
    //Console.WriteLine(employee.ToString());
    var employee = (Employee)item;
    var textAudit = $"{employee.FirstName} added";
    Console.WriteLine($"{employee.ToString} added");

    var text = $"{employee.ToString} added";




    DateTime currentDate = DateTime.Now;
    string dateString = currentDate.ToString("yyyy-MM-dd HH:mm:ss");
    using (StreamWriter file = new StreamWriter("Resources\\Files\\Audit.txt"))
    {
        file.WriteLine($" [ {dateString} | + | Employee added {employee.FirstName} ]");
    }

    //using (StreamWriter file = new StreamWriter("Files//Audit.txt", true))  jeśli chcemy date na końcu pliku



    //string json = JsonSerializer.Serialize(employee);
    //Console.WriteLine(json);



    //using (var writer = File.AppendText(fullFileName))
    //{
    //    writer.WriteLine(text);
    //    ItemAdded?.Invoke(this, new EventArgs());   źle tu
    //}
}

void BusinessPartnerAdded(object item) 
{
    //Employee employee = (Employee)item;
    //Console.WriteLine(employee.ToString);
    //Console.WriteLine(employee.ToString());
    var businessPartner = (BusinessPartner)item;
    var textAudit = $"{businessPartner.FullName} added";
    Console.WriteLine($"{businessPartner.ToString} added");

    var text = $"{businessPartner.ToString} added";




    DateTime currentDate = DateTime.Now;
    string dateString = currentDate.ToString("yyyy-MM-dd HH:mm:ss");
    using (StreamWriter file = new StreamWriter("Resources\\Files\\Audit.txt"))
    {
        file.WriteLine($" [ {dateString} | + | Employee added {businessPartner.FullName} ]");
    }
}




//static void AddEmployee(IRepository<Employee> employeeRepository)
//{
//    Console.Write("Employee Name: ");
//    string name = Console.ReadLine();
//    Console.Write("Employee Surname: ");
//    //string surname = Console.ReadLine();
//    Console.Write("Employee Age: ");
//    if (!int.TryParse(Console.ReadLine(), out int age) || age < 0)
//    {
//        Console.WriteLine("Invalid Age, Please enter a valid age");
//        return;
//    }

//    var newEmployee = new Employee { FirstName = name };//, Surname = surname, Age = age, };
//    employeeRepository.Add(newEmployee);
//    employeeRepository.Save();
//    Console.WriteLine("Employee Added");
//}

static void AddTiles(IRepository<Tile> tilesRepository)
{
    Console.Write("Enter Car Model: ");
    string name = Console.ReadLine();
    Console.Write("Enter Car Country: ");
    string color = Console.ReadLine();
    string type = Console.ReadLine();
    Console.Write("Enter Car Year: ");
    if (!int.TryParse(Console.ReadLine(), out int year) || year < 0)
    {
        Console.WriteLine("Invalid Year, Please enter a valid year");
        return;
    }

    var newTile = new Tile
    {
        Name = name,
        Color = color,
        Type = type
    };
    tilesRepository.Add(newTile);
    tilesRepository.Save();
    Console.WriteLine("Tiles Added");



    //using Newtonsoft.Json;
    //Następnie, aby zapisać obiekt Employee w formacie JSON, możemy użyć metody JsonConvert.SerializeObject.Przykładowy kod może wyglądać tak:

    //Employee employee = new Employee();
    //employee.Name = "John";
    //employee.LastName = "Doe";
    //employee.Age = 30;

    //string json = JsonConvert.SerializeObject(employee);
}