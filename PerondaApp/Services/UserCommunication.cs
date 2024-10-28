using PerondaApp.Data.Components.DataProviders;
using PerondaApp.Entities;
using PerondaApp.Repositories;
using PerondaApp.Repositories.Extensions;

namespace PerondaApp.Services;

public class UserCommunication : IUserCommunication
{
    //private static object repository;
    //private static object id;
    //private static string action;
    private readonly IRepository<Employee> _employeeRepository;
    private readonly IRepository<BusinessPartner> _businessPartnerRepository;
    private readonly IRepository<Tile> _tileRepository;
    //private readonly IRepository<IEntity> _repository;
    private readonly ITilesProvider? _tilesProvider;
    //private readonly IActions _actions;

    public UserCommunication(IRepository<Employee> employeeRepository, //IRepository<IEntity> repository,
        IRepository<BusinessPartner> businessPartnerRepository,
        IRepository<Tile> tileRepository,
        ITilesProvider tilesProvider //,IActions actions
        )
    {
        _employeeRepository = employeeRepository;
        _businessPartnerRepository = businessPartnerRepository;
        _tileRepository = tileRepository;
        //_repository = repository;
        _tilesProvider = tilesProvider;
        //_actions = actions;

        //_itemRepository.ItemAdded += (sender, e) =>
        //{
        //    SaveItemAddedInAudit(e);
        //};

        //_itemRepository.ItemRemoved += (sender, e) =>
        //{
        //    SaveItemRemovedInAudit(e);
        //};
    }

    //public void SubscribeToEvents()
    //{
    //    _employeeRepository.ItemAdded += (sender, e) =>
    //    {
    //        SaveItemAddedInAudit(e);
    //    };

    //    _businessPartnerRepository.ItemAdded += (sender, e) =>
    //    {
    //        SaveItemAddedInAudit(e);
    //    };

    //    _tileRepository.ItemAdded += (sender, e) =>
    //    {
    //        SaveItemAddedInAudit(e);
    //    };

    //    _employeeRepository.ItemRemoved += (sender, e) =>
    //    {
    //        SaveItemRemovedInAudit(e);
    //    };

    //    _businessPartnerRepository.ItemRemoved += (sender, e) =>
    //    {
    //        SaveItemRemovedInAudit(e);
    //    };

    //    _tileRepository.ItemRemoved += (sender, e) =>
    //    {
    //        SaveItemRemovedInAudit(e);
    //    };
    //}

    public void ChooseOption()
    {
        Console.WriteLine("\n\n" +
                "                       Welcome to PerondaApp\n\n" +
                "      The Assortment section presents all Pereonda tile collections\n " +
                "             along with the possibility of placing orders.\n" +
                "   The HR department handles data regarding employees and business partners\n" +
                "         We invite you to familiarize yourself with the latest offer\n\n" +
                "    ----------------------------------------------------------------------\n");
        bool Exit = false;
        while (!Exit)
        {
            Console.WriteLine("\n" +
                "                         select resource section:\n" +
                "    ----------------------------------------------------------------------\n" +
                "          PERONDA FULL RANGE                     HR MANAGMENT BRANCH\n" +
                "   press A _ Assortment offer             press E _ Employess\n" +
                "   press O _ Orders and complaints        press B _ BUSINESS Partners\n\n" +
                "                                                         press X - to leave\n\n");

            var userInput = Console.ReadLine()?.ToUpper();
            switch (userInput)
            {
                case "A":
                    AsortmentOffer(_tileRepository); break;
                case "B":
                    HrBusinessP(_businessPartnerRepository); break;
                case "E":
                    HrEmployee(_employeeRepository); break;
                case "O":
                    OrdersAndComplaints(_tilesProvider); break;
                case "X":
                    Exit = true;
                    Environment.Exit(0); break;
                default:
                    Console.WriteLine("\n\n\n      Invalid operation.    \n");
                    break;
            }
        }

        void HrEmployee(IRepository<Employee> EmployeeRepository)
        {
            bool Exit = false;
            while (!Exit)
            {
                Console.Clear();
                Console.WriteLine("\n\n" +
                "                                                 HR MANAGMENT BRANCH\n" +
                "                     E M P L O Y E E S  \n" +
                "    ----------------------------------------------------------------------\n" +
                "   Choose option :\n" +
                "           press V   - to viev all employees\n" +
                "           press A   - to add new employee\n" +
                "           press R   - to remove employee\n" +
                "           press F   - to find employee by ID\n" +
                "                                                         press H - Home\n\n" +
                "                                                         press X - to leave\n\n");
                var userInput = Console.ReadLine()?.ToUpper();
                switch (userInput)
                {
                    case "V":
                        WriteAllToConsole(_employeeRepository); break;
                    //case "B":
                      //  WriteAllToConsole(_businessPartnerRepository); break;
                    case "A":
                        AddEmployee(_employeeRepository); break;
                    case "D":
                        //AddBusinessPartner(_businessPartnerRepository); break;
                    case "R":
                        RemoveEmployeeById(_employeeRepository); break;
                    case "5":
                  //      RemoveBusinessPartnerById(_businessPartnerRepository); break;
                    case "19":
                        GetItemById((IRepository<IEntity>)_employeeRepository); break;
                    case "16":
                        GetItemById((IRepository<IEntity>)_businessPartnerRepository); break;
                    case "H":
                        ChooseOption(); break;
                    case "X":
                        Exit = true;
                        Environment.Exit(0); break;
                    default:
                        Console.WriteLine("\n\n\n      Invalid operation.   \n ");
                        break;
                }
            }
        }

        void HrBusinessP(IRepository<BusinessPartner> businessPartnerRepository)
        {
            bool Exit = false;
            while (!Exit)
            {
                Console.WriteLine("\n\n" +
                "                                                 HR MANAGMENT BRANCH\n" +
                "    *  B U S I N E S S   P a r t n e r s  * \n" +
                "    ----------------------------------------------------------------------\n" +
                "   Choose option :\n" +
                    "      press V   - to viev all Business Partners\n" +
                    "      press A   - to add new Business Partner\n" +
                    "      press R   - to remove Business Partner\n" +
                    "      press F   - to find Business Partner by ID\n" +
            "                                                         press H - Home\n\n" +
            "                                                         press X - to leave\n\n");
                var userInput = Console.ReadLine()?.ToUpper();
                switch (userInput)
                {
                    case "v":
                        WriteAllToConsole(_businessPartnerRepository); break;
                    case "A":
                        AddBusinessPartner(_businessPartnerRepository); break;
                    case "R":
                        RemoveBusinessPartnerById(_businessPartnerRepository); break;
                    case "16":
                        GetItemById((IRepository<IEntity>)_businessPartnerRepository); break;
                    case "H":
                        ChooseOption(); break;
                    case "X":
                        Exit = true;
                        Environment.Exit(0); break;
                    default:
                        Console.WriteLine("\n\n\n      Invalid operation.   \n ");
                        break;
                }
            }
        }

        //static void InsertPersonalDetails(out string name, out string surname, out string position)
        //{
        //    name = null;
        //    surname = null;
        //    position = null;
        //    Console.Clear();
        //    Console.Write("\n\n   Please insert personal details  :   ");
        //    Console.Write("\n  name:  ");
        //    name = Console.ReadLine();
        //    Console.Write("\n  surname:  ");
        //    surname = Console.ReadLine();
        //    Console.Write("\n  position:  ");
        //    position = Console.ReadLine();
        //    _ = new Person { FirstName = name, Surname = surname, Position = position };
        //}

        //static void AddBusinessPartner2(IRepository<BusinessPartner> businessPartnerRepository)
        //{
        //    InsertPersonalDetails(out _, out _, out _); // to nie przekazuje danych personalnych
        //    Console.Write("\n  Insert Business Partner company name:  ");
        //    var companyName = Console.ReadLine();
        //    _ = new BusinessPartner { FirstName = name, Surname = surname, Position = position, CompanyName = companyName };
        //    var _items = businessPartnerRepository.GetAll();
        //    if (_items is not null)
        //    {
        //        //_employeeRepository.Add(_items);
        //        businessPartnerRepository.Save();
        //        string action = " | + |  added  ] ";
        //        object e = _items;
        //        businessPartnerRepository.Save();
        //        businessPartnerRepository.SaveAudit(action, e);
        //        WriteItemAdded(e);
        //    }
        //}

        //static void AddPerson(IRepository<IEntity> repository)
        //{
        //    InsertPersonalDetails(out _, out string position);
        //    var _items = repository.GetAll();
        //    if (_items is not null)
        //    {
        //        repository.Add(_items);
        //        repository.Save();
        //        string action = " | + |  added  ] ";
        //        object e = _items;
        //        repository.SaveAudit(action, e);
        //        WriteItemAdded(e);
        //    }
        //}

        //void AddEmployee(IRepository<Employee> _employeeRepository) => AddPerson(_employeeRepository);

        //static void AddItem(IRepository<IEntity> repository, IRepository<Employee> employeeRepository, IRepository< BusinessPartner> businessPartnerRepository)
        //{
        //    var item = new Item { }; //

        //    //var item = repository.GetAll();
        //    //if (item is not null)
        //    //{
        //    //    repository.Add(item);
        //    //    repository.Save();
        //    //    string action = " | + |  added  ] ";
        //    //    object e = item;
        //    //    repository.SaveAudit(action, e);
        //    //    WriteItemAdded(e);
        //    //}
        //}

        //void AddEmployee(IRepository<Employee> _employeeRepository)
        //{
        //    InsertPersonalDetails(out _, out string position);
        //    var _item = _employeeRepository.GetAll();
        //    AddItem(IRepository < IEntity > _repository);

        ////   employeeRepository.Add(employee);
        //    employeeRepository.Save();

        //}

        //void AddEmployee(IRepository<Employee> _employeeRepository) => AddPerson(_employeeRepository);

        static void AddEmployee(IRepository<Employee> employeeRepository)
        {
            Console.WriteLine(" Please insert personal details  :   ");
            Console.Write("         name:  ");
            var name = Console.ReadLine();

            Console.Write("      surname:  ");
            var surname = Console.ReadLine();

            Console.Write("     position:  ");
            var position = Console.ReadLine();

            var item = new Employee { FirstName = name, Surname = surname, Position = position };
            if (item is not null)
                {
                employeeRepository.Add(item);
                employeeRepository.Save();
                string action = " | + |  added  ] ";
                object e = item;
                employeeRepository.SaveAudit(action, e);
                WriteItemAdded(e);
            }
        }

        void RemoveEmployeeById(IRepository<Employee> employeeRepository)
        {
            Console.WriteLine("Insert personal ID to remove:");
            var input = Console.ReadLine();
            var id = int.Parse(input);

            var item = employeeRepository.GetById(id);

            if (item is not null)
            {
                employeeRepository.Remove(item);
                employeeRepository.Save();
                string action = " | - | removed ] ";
                object e = item;
                employeeRepository.SaveAudit(action, e);
                WriteItemRemoved(e);
            }
        }

        //static void AddEmployee2(IRepository<Employee> employeeRepository, string action)
        //{
        //    Console.Write("\n   Please insert personal details  :   ");
        //    Console.Write("         name:  ");
        //    var name = Console.ReadLine();
        //    Console.Write("      surname:  ");
        //    var surname = Console.ReadLine();
        //    Console.Write("     position:  ");
        //    var position = Console.ReadLine();

        //    var items = new Employee { FirstName = name, Surname = surname, Position = position };
        //    //employeeRepository.AddBatchWithSaveAuditAndInfoColor(items, action);
        //}

        static void AddBusinessPartner(IRepository<BusinessPartner> businessPartnerRepository) //ok
        {
            Console.Write("   Insert Business Partner first name:  ");
            var name = Console.ReadLine();

            Console.Write("      Insert Business Partner surname:  ");
            var surname = Console.ReadLine();

            Console.Write("     Insert Business Partner position:  ");
            var position = Console.ReadLine();

            Console.Write(" Insert Business Partner company name:  ");
            var companyName = Console.ReadLine();

            var item = new BusinessPartner { FirstName = name, Surname = surname, Position = position, CompanyName = companyName };

            businessPartnerRepository.Add(item);
            businessPartnerRepository.Save();
            if (item is not null)
            {
                //businessPartnerRepository.Add(item);
                //businessPartnerRepository.Save();
                string action = " | + |  added  ] ";
                object e = item;
                businessPartnerRepository.SaveAudit(action, e);
                WriteItemAdded(e);
            }
        }

        static void RemoveBusinessPartnerById(IRepository<BusinessPartner> businessPartnerRepository)
        {
            Console.WriteLine("Insert Business Partner ID to remove:");
            var input = Console.ReadLine();
            var id = int.Parse(input);

            var item = businessPartnerRepository.GetById(id);

            if (item is not null)
            {
                businessPartnerRepository.Remove(item);
                businessPartnerRepository.Save();
                string action = " | - | removed ] ";
                object e = item;
                businessPartnerRepository.SaveAudit(action, e);
                WriteItemRemoved(e);
            }
        }

        static void GetItemById(IRepository<IEntity> repository)
        {
            Console.Write("Insert ID : ");
            var input = Console.ReadLine();
            var id = int.Parse(input);

            repository.Read();
            var item = repository.GetById(id);

            if (item is not null)
            {
                repository.GetById(id);
                Console.WriteLine(item);
            }
        }

        static void WriteItemAdded(object e)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"  new  {e}  successfully added  ");
            Console.ResetColor();
        }

        static void WriteItemRemoved(object e)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($" {e} just REMOVED");
            Console.ResetColor();
        }

        static void WriteAllToConsole(IReadRepository<IEntity> repository) // IReadRepository
        {
            repository.Read();
            var items = repository.GetAll();
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
        }

        //static void WriteAllToConsole(IRepository<IEntity> repository)
        //{
        //    //repository.Read();
        //    var items = repository.GetAll();
        //    foreach (var item in items)
        //    {
        //        Console.WriteLine(item);
        //    }
        //}

        //static void SaveItemAddedInAudit(string action, object e)
        //{
        //    żle ->//{ e.GetType}
        //    //string text = $" [ {DateTime.UtcNow} | + | {e.GetType} added ]";
        //    //using (var writer = File.AppendText(IRepository<IEntity>.fileName))
        //    //{
        //    //    writer.WriteLine($" [ {DateTime.UtcNow} | + |  added  ] {e.GetType} ]");
        //    //}
        //    //Console.ForegroundColor = ConsoleColor.Green;
        //    //Console.WriteLine($"  new  {e.GetType}  successfully added  ");
        //    //Console.ResetColor();

        //    //object value = new Item();

        //    //var item = new Item();
        //    repository.AddBatch(e);
        //    //repository.Save();
        //    //object e = item;
        //    if (e is not null)
        //    {

        //        //object e = item;
        //        repository.SaveAudit(" | + |  added  ] ", e);
        //        WriteItemAdded(e);
        //    }
        //}

        //static void SaveItemRemovedInAudit(string action, object e)
        //{
        //    //var item = repository.GetById(id);
        //    //var item = new Item();
        //    repository.RemoveBatch(e);
        //    //repository.Remove1(e);
        //    //repository.GetAll(e);

        //    if (e is not null)
        //    {
        //        //repository.Remove(item);
        //        //object value1 = repository.Save();
        //        object value = repository.SaveAudit(" | - | removed ] ", e);
        //        WriteItemRemoved(e);
        //    }
        //}

        void AsortmentOffer(IRepository<Tile> tileRepository) 
            => Console.WriteLine("  Option under construction");

        void OrdersAndComplaints(object tileProvider) 
            => Console.WriteLine("  Option under construction");

        void HrBusiness(IRepository<BusinessPartner> businessPartnerRepository) 
            => Console.WriteLine("  Option under construction");
    }



    //// yesterday all worked ok

    //static void WriteItemAdde(object e)
    //{
    //    Console.ForegroundColor = ConsoleColor.Green;
    //    Console.WriteLine($"  new  {e}  successfully added  ");
    //    Console.ResetColor();
    //}

    //static void SaveItemAddedInAudit(object e)
    //{
    //    string text = $" [ {DateTime.UtcNow} | + | {e.GetType} added ]";
    //    using (var writer = File.AppendText(IRepository<IEntity>.fileName))
    //    {
    //        writer.WriteLine($" [ {DateTime.UtcNow} | + |  added  ] {e.GetType} ]");
    //    }
    //    Console.ForegroundColor = ConsoleColor.Green;
    //    Console.WriteLine($"  new  {e.GetType}  successfully added  ");
    //    Console.ResetColor();
    //}
    //static void WriteItemRemove(object e)
    //{
    //    Console.ForegroundColor = ConsoleColor.Red;
    //    Console.WriteLine($" {e} just REMOVED");
    //    Console.ResetColor();
    //}

    //public void SaveAudit(string action, object e)
    //{
    //    string auditText = $" [ {DateTime.UtcNow} {action} {e.GetType} ]";
    //    using (var writer = File.AppendText(IRepository<IEntity>.fileName))
    //    {
    //        writer.WriteLine(auditText);
    //    }
    //}

    //public void ChooseOption()
    //{
    //bool Exit = false;
    //while (!Exit)
    //{
    //Console.WriteLine("\n     MANAGMENT BRANCH - resource list" +
    //    "\n" +
    //    "   Choose option :\n" +
    //    "      press A   - to viev all employees\n" +
    //    "      press B   - to viev all business partners\n" +
    //    "      press C   - to add new employees\n" +
    //    "      press D   - to add new business partners\n" +
    //    "      press E   - to remove employees\n" +
    //    "      press F   - to remove business partners\n" +
    //    "      press G   - to find employee by ID\n" +
    //    "      press H   - to find business partner by ID\n\n" +
    //    "                                                         press X - to leave\n\n");

    //var userInput = Console.ReadLine()?.ToUpper();
    //switch (userInput)
    //{
    //    case "A":
    //        WriteAllToConsole(_employeeRepository); break;
    //    case "B":
    //        WriteAllToConsole(_businessPartnerRepository); break;
    //    case "C":
    //        AddEmployee(_employeeRepository); break;
    //    case "D":
    //        AddBusinessPartner(_businessPartnerRepository); break;
    //    case "E":
    //        RemoveEmployee(_employeeRepository); break;
    //    case "F":
    //        RemoveBusinessPartner(_businessPartnerRepository); break;
    //    case "G":
    //        GetEmployeeById(_employeeRepository); break;
    //    case "H":
    //        GetBusinessPartnerById(_businessPartnerRepository); break;
    //    case "X":
    //        Exit = true;
    //        Environment.Exit(0); break;
    //    default:
    //        Console.Clear();
    //        Console.WriteLine("\n\n\n      Invalid operation.    ");
    //        break;
    //}



    //static void AddBusinessPartner(IRepository<BusinessPartner> businessPartnerRepository)
    //{
    //    Console.WriteLine("Insert Business Partner first name:");
    //    var name = Console.ReadLine();

    //    Console.WriteLine("Insert Business Partner surname:");
    //    var surname = Console.ReadLine();

    //    Console.WriteLine("Insert Business Partner position");
    //    var position = Console.ReadLine();

    //    Console.Write("\n  Insert Business Partner company name:  ");
    //    var companyName = Console.ReadLine();

    //    var businessPartner = new BusinessPartner { FirstName = name, Surname = surname, Position = position, CompanyName = companyName };

    //    businessPartnerRepository.Add(businessPartner);
    //    businessPartnerRepository.Save();
    //}

    //static void RemoveBusinessPartner(IRepository<BusinessPartner> businessPartnerRepository)
    //{
    //    Console.WriteLine("Insert Business Partner ID to remove:");
    //    var input = Console.ReadLine();
    //    var id = int.Parse(input);

    //    var businessPartnerToRemove = businessPartnerRepository.GetById(id);

    //    if (businessPartnerToRemove is not null)
    //    {
    //        businessPartnerRepository.Remove(businessPartnerToRemove);
    //        businessPartnerRepository.Save();
    //    }
    //}

    //static void WriteAllToConsole(IReadRepository<IEntity> repository)
    //{
    //    repository.Read();
    //    var items = repository.GetAll();
    //    foreach (var item in items)
    //    {
    //        Console.WriteLine(item);
    //    }
    //}

    //static void GetEmployeeById(IRepository<Employee> employeeRepository)
    //{
    //    Console.Write("Insert employee ID : ");
    //    var input = Console.ReadLine();
    //    var id = int.Parse(input);

    //    employeeRepository.Read();
    //    var employee = employeeRepository.GetById(id);

    //    if (employee is not null)
    //    {
    //        employeeRepository.GetById(id);
    //        Console.WriteLine(employee);
    //    }
    //}

    //static void GetBusinessPartnerById(IRepository<BusinessPartner> businessPartnerRepository)
    //{
    //    Console.Write("Insert Business Partner ID : ");
    //    var input = Console.ReadLine();
    //    var id = int.Parse(input);

    //    businessPartnerRepository.Read();
    //    var businessPartner = businessPartnerRepository.GetById(id);

    //    if (businessPartner is not null)
    //    {
    //        businessPartnerRepository.GetById(id);
    //        Console.WriteLine(businessPartner);
    //    }
    //}
    //}
    //}




    /////// last sent comit from PROGRAM class

    ////void EmployeeRepositoryOnItemAdded(object? sender, Employee e)
    ////{
    ////    string text = $" [ {DateTime.UtcNow} | + | {e} added ]";
    ////    using (var writer = File.AppendText(IRepository<IEntity>.fileName))
    ////    {
    ////        writer.WriteLine(text);
    ////    }
    ////    Console.WriteLine(text);
    ////}

    ////void EmployeeRepositoryOnItemRemoved(object? sender, Employee e)
    ////{
    ////    string text = $" [ {DateTime.UtcNow} | - | {e} removed ]";
    ////    using (var writer = File.AppendText(IRepository<IEntity>.fileName))
    ////    {
    ////        writer.WriteLine(text);
    ////    }
    ////    Console.WriteLine(text);
    ////}

    //static void AddEmployee(IRepository<Employee> employeeRepository)
    //{
    //    Console.WriteLine("Insert employee first name:");
    //    var name = Console.ReadLine();

    //    Console.WriteLine("Insert employee surname:");
    //    var surname = Console.ReadLine();

    //    Console.WriteLine("Insert employee position");
    //    var position = Console.ReadLine();

    //    var employee = new Employee { FirstName = name, Surname = surname, Position = position };

    //    employeeRepository.Add(employee);
    //    employeeRepository.Save();
    //}

    //static void RemoveEmployee(IRepository<Employee> employeeRepository)
    //{
    //    Console.WriteLine("Insert employee ID to remove:");
    //    var input = Console.ReadLine();
    //    var id = int.Parse(input);

    //    var employeeToRemove = employeeRepository.GetById(id);

    //    if (employeeToRemove is not null)
    //    {
    //        employeeRepository.Remove(employeeToRemove);
    //        employeeRepository.Save();
    //    }
    //}

    ////void BusinessPartnerRepositoryOnItemAdded(object? sender, BusinessPartner e)
    ////{
    ////    string text = $" [ {DateTime.UtcNow} | + | {e} added ]";
    ////    using (var writer = File.AppendText(IRepository<IEntity>.fileName))
    ////    {
    ////        writer.WriteLine(text);
    ////    }
    ////    Console.WriteLine(text);
    ////}

    ////static void BusinessPartnerRepositoryOnItemRemoved(object? sender, BusinessPartner e)
    ////{
    ////    string text = $" [ {DateTime.UtcNow} | - | {e} removed ]";
    ////    using (var writer = File.AppendText(IRepository<IEntity>.fileName))
    ////    {
    ////        writer.WriteLine(text);
    ////    }
    ////    Console.WriteLine(text);
    ////}

    //static void AddBusinessPartner(IRepository<BusinessPartner> businessPartnerRepository)
    //{
    //    Console.WriteLine("Insert Business Partner first name:");
    //    var name = Console.ReadLine();

    //    Console.WriteLine("Insert Business Partner surname:");
    //    var surname = Console.ReadLine();

    //    Console.WriteLine("Insert Business Partner position");
    //    var position = Console.ReadLine();

    //    Console.Write("\n  Insert Business Partner company name:  ");
    //    var companyName = Console.ReadLine();

    //    var businessPartner = new BusinessPartner { FirstName = name, Surname = surname, Position = position, CompanyName = companyName };

    //    businessPartnerRepository.Add(businessPartner);
    //    businessPartnerRepository.Save();
    //}

    //static void RemoveBusinessPartner(IRepository<BusinessPartner> businessPartnerRepository)
    //{
    //    Console.WriteLine("Insert Business Partner ID to remove:");
    //    var input = Console.ReadLine();
    //    var id = int.Parse(input);

    //    var businessPartnerToRemove = businessPartnerRepository.GetById(id);

    //    if (businessPartnerToRemove is not null)
    //    {
    //        businessPartnerRepository.Remove(businessPartnerToRemove);
    //        businessPartnerRepository.Save();
    //    }
    //}

    //static void WriteAllToConsole(IReadRepository<IEntity> repository)
    //{
    //    var items = repository.GetAll();
    //    foreach (var item in items)
    //    {
    //        Console.WriteLine(item);
    //    }
    //}

    //static void GetEmployeeById(IRepository<Employee> employeeRepository)
    //{
    //    Console.Write("Insert employee ID : ");
    //    var input = Console.ReadLine();
    //    var id = int.Parse(input);

    //    employeeRepository.Read();
    //    var employee = employeeRepository.GetById(id);

    //    if (employee is not null)
    //    {
    //        employeeRepository.GetById(id);
    //        Console.WriteLine(employee);
    //    }
    //}

    //static void GetBusinessPartnerById(IRepository<BusinessPartner> businessPartnerRepository)
    //{
    //    Console.Write("Insert Business Partner ID : ");
    //    var input = Console.ReadLine();
    //    var id = int.Parse(input);

    //    businessPartnerRepository.Read();
    //    var businessPartner = businessPartnerRepository.GetById(id);

    //    if (businessPartner is not null)
    //    {
    //        businessPartnerRepository.GetById(id);
    //        Console.WriteLine(businessPartner);
    //    }
    //}
}