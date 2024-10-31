using DocumentFormat.OpenXml.Office.CustomUI;
using PerondaApp.Data.Components.DataProviders;
using PerondaApp.Entities;
using PerondaApp.Repositories;
using PerondaApp.Repositories.Extensions;

namespace PerondaApp.Services;

public class UserCommunication : IUserCommunication
{
    private readonly IRepository<Employee> _employeeRepository;
    private readonly IRepository<BusinessPartner> _businessPartnerRepository;
    private readonly IRepository<Tile> _tileRepository;
    private readonly ITilesProvider? _tilesProvider;

    public UserCommunication(IRepository<Employee> employeeRepository,
        IRepository<BusinessPartner> businessPartnerRepository,
        IRepository<Tile> tileRepository,
        ITilesProvider tilesProvider)
    {
        _employeeRepository = employeeRepository;
        _businessPartnerRepository = businessPartnerRepository;
        _tileRepository = tileRepository;
        _tilesProvider = tilesProvider;
    }

    public void ChooseOption()
    {

        static void WriteAllToConsole(IReadRepository<IEntity> repository)
        {
            repository.Read();
            var items = repository.GetAll();
            if (items != null)
            {
                foreach (var item in items)
                {
                    Console.WriteLine(item);
                }
            }
            else
            {
                Console.WriteLine("/n      This list is empty.");
            }
        }

        static void GetItemById(IReadRepository<IEntity> repository)
        {
            Console.Write("Insert ID : ");
            var input = Console.ReadLine();
            var id = int.Parse(input);

            repository.Read();
            repository.GetAll();
            var item = repository.GetById(id);

            if (item is not null)
            {
                repository.GetById(id);
                Console.WriteLine(item);
            }
        }

        void AddItem1<T>(IWriteRepository<T> repository, T[] items, string action)
            where T : class, IEntity
        {
            repository.AddBatchWithSaveAuditAndInfoColor(items, action);
            //repository.Save();
            //string action = " | + |  added  ] ";
            //object e = items;
            //repository.SaveAudit(action, e);
            //WriteItemAdded(e);
        }

        void RemoveItem<T>(IRepository<T> repository, T[] items)
            where T : class, IEntity
        {
            foreach (var item in items)
            {
                repository.Add(item);
            }
            repository.Save();
            string action = " | + |  added  ] ";
            object e = items;
            repository.SaveAudit(action, e);
            WriteItemAdded(e);
        }

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

        static void RemoveEmployeeById(IRepository<Employee> employeeRepository)
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

        static void AddBusinessPartner(IRepository<BusinessPartner> businessPartnerRepository) //ok
        {
            Console.Write("   Insert Business Partner first name:  ");
            var name = Console.ReadLine();

            Console.Write("      Insert Business Partner surname:  ");
            var surname = Console.ReadLine();

            Console.Write("     Insert Business Partner position:  ");
            var position = Console.ReadLine();

            Console.Write(" Insert Business Partner company name:  ");
            var company = Console.ReadLine();

            var item = new BusinessPartner { FirstName = name, Surname = surname, Position = position, Company = company };

            businessPartnerRepository.Add(item);
            businessPartnerRepository.Save();
            if (item is not null)
            {
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

        static void AddTile(IRepository<Tile> tileRepository)
        {
            Console.WriteLine(" Please insert details  :   ");
            Console.Write("         name:  ");
            var name = Console.ReadLine();

            Console.Write("        color:  ");
            var color = Console.ReadLine();

            Console.Write("         type:  ");
            var type = Console.ReadLine();

            Console.Write("         cost:  ");
            var cost = Console.ReadLine();

            Console.Write("        price:  ");
            var price = Console.ReadLine();

            var tile = new Tile { Name = name, Color = color, Type = type, StandardCost = decimal.Parse(cost), ListPrice = decimal.Parse(price) };

            if (tile is not null)
            {
                tileRepository.Add(tile);
                tileRepository.Save();
                string action = " | + |  added  ] ";
                object e = tile;
                tileRepository.SaveAudit(action, e);
                WriteItemAdded(e);
            }
        }

        void RemoveTileById(IRepository<Tile> tileRepository)
        {
            Console.WriteLine("  Insert ID to remove:");
            var input = Console.ReadLine();
            var id = int.Parse(input);

            tileRepository.Read();
            tileRepository.GetAll();
            var item = tileRepository.GetById(id);

            if (item is not null)
            {
                tileRepository.Remove(item);
                tileRepository.Save();
                string action = " | - | removed ] ";
                object e = item;
                tileRepository.SaveAudit(action, e);
                WriteItemRemoved(e);
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

        

        

        void HrEmployee(IRepository<Employee> EmployeeRepository)
        {
            bool Exit = false;
            while (!Exit)
            {
                Console.WriteLine("\n\n" +
                "                                                 HR MANAGMENT BRANCH\n" +
                " Choose option :      E M P L O Y E E S  \n" +
                "    ----------------------------------------------------------------------\n\n" +
                "       press V   - to viev all employees\n" +
                "       press A   - to add new employee\n" +
                "       press R   - to remove employee\n" +
                "       press F   - to find employee by ID\n" +
                "                                                         press H - Home\n\n" +
                "                                                         press X - to leave\n");
                var userInput = Console.ReadLine()?.ToUpper();
                switch (userInput)
                {
                    case "V":
                        WriteAllToConsole(_employeeRepository); break;
                    case "F":
                        GetItemById(_employeeRepository); break;
                    case "A":
                        AddEmployee(_employeeRepository); break;
                    case "R":
                        RemoveEmployeeById(_employeeRepository); break;
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
                " Choose option :      B U S I N E S S  *  Partners  \n" +
                "    ----------------------------------------------------------------------\n\n" +
                "       press V   - to viev all employees\n" +
                "       press A   - to add new employee\n" +
                "       press R   - to remove employee\n" +
                "       press F   - to find employee by ID\n" +
                "                                                         press H - Home\n\n" +
                "                                                         press X - to leave\n");
                var userInput = Console.ReadLine()?.ToUpper();
                switch (userInput)
                {
                    case "V":  // tu był błąd małe v
                        WriteAllToConsole(_businessPartnerRepository); break;
                    case "F":
                        GetItemById(_businessPartnerRepository); break; // unikać castowania ( rzutowanie ) w tym miejscu
                    case "A":
                        AddBusinessPartner(_businessPartnerRepository); break;
                    case "R":
                        RemoveBusinessPartnerById(_businessPartnerRepository); break;
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

        void AsortmentOffer(IRepository<Tile> tileRepository)
        {
            bool Exit = false;
            while (!Exit)
            {
                Console.WriteLine("\n\n" +
                "                                                    MANAGMENT BRANCH\n" +
                " Choose option :       A S O R T M E N T  Offer  \n" +
                "    ----------------------------------------------------------------------\n" +
                "       press V   - to viev all collection tiles \n" +
                "       press A   - to add new tile\n" +
                "       press R   - to remove tile\n" +
                "       press F   - to find tile by ID\n" +
                "                                                         press H - Home\n\n" +
                "                                                         press X - to leave\n");
                var userInput = Console.ReadLine()?.ToUpper();
                switch (userInput)
                {
                    case "V":
                        WriteAllToConsole(_tileRepository); break;
                    case "F":
                        GetItemById(_tileRepository); break;
                    case "A":
                        AddTile(_tileRepository); break;
                    case "R":
                        RemoveTileById(_tileRepository); break;
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

        void OrdersAndComplaints(object tileProvider) => Console.WriteLine(" Option under construction");

        Console.WriteLine("\n\n" +
                "                          Welcome to PerondaApp\n\n" +
                "      The Assortment section presents all Pereonda tile collections\n " +
                "             along with the possibility of placing orders.\n" +
                "   The HR department handles data regarding employees and business partners\n" +
                "         We invite you to familiarize yourself with the latest offer\n\n" +
                "    ----------------------------------------------------------------------");
        bool Exit = false;
        while (!Exit)
        {
            Console.WriteLine(
                "                          select resource section:\n" +
                "    ----------------------------------------------------------------------\n" +
                "          PERONDA FULL RANGE                     HR MANAGMENT BRANCH\n" +
                "   press A _ Assortment offer             press E _ Employess\n" +
                "   press O _ Orders and complaints        press B _ BUSINESS Partners\n\n" +
                "                                                         press X - to leave\n\n");
            //"                                                 HR MANAGMENT BRANCH\n" +
            //"   Choose option :       E M P L O Y E E S  \n" +
            //"    ----------------------------------------------------------------------\n" +
            //"           press V   - to viev all employees\n" +
            //"           press A   - to add new employee\n" +
            //"           press R   - to remove employee\n" +
            //"           press F   - to find employee by ID\n\n" +
            //"   Choose option :    *  B U S I N E S S   P a r t n e r s  * \n" +
            //"    ----------------------------------------------------------------------\n" +
            //"      press 1   - to viev all Business Partners\n" +
            //"      press 2   - to add new Business Partner\n" +
            //"      press 3   - to remove Business Partner\n" +
            //"      press 4   - to find Business Partner by ID\n" +
            //"                                                         press X - to leave\n\n");

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

            //var userInput = Console.ReadLine()?.ToUpper();
            //switch (userInput)
            //{
            //    case "V":
            //        WriteAllToConsole(_employeeRepository); break;
            //    case "1":
            //        WriteAllToConsole(_businessPartnerRepository); break;
            //    case "11":
            //        WriteAllToConsole(_tileRepository); break;
            //    case "A":
            //        AddEmployee(_employeeRepository); break;
            //    case "2":
            //        AddBusinessPartner(_businessPartnerRepository); break;
            //    case "22":
            //        AddTile(_tileRepository); break;
            //    case "R":
            //        RemoveEmployeeById(_employeeRepository); break;
            //    case "3":
            //        RemoveBusinessPartnerById(_businessPartnerRepository); break;
            //    case "33":
            //        GetItemById(_employeeRepository); break;
            //    case "4":
            //        GetItemById(_businessPartnerRepository); break;
            //    case "44":
            //        GetItemById(_businessPartnerRepository); break;
            //    case "H":
            //        ChooseOption(); break;
            //    case "X":
            //        Exit = true;
            //        Environment.Exit(0); break;
            //    default:
            //        Console.WriteLine("\n\n\n      Invalid operation.   \n ");
            //        break;
            //}
        }

        void WhatNow(IRepository<IEntity> repository, out int id)
        {
            id = 0;
        }

        static void AddBatch<T>(IRepository<T> repository, T[] items)
            where T : class, IEntity
        {
            foreach (var item in items)
            {
                repository.Add(item);
            }
            repository.Save();
        }  //from RepositoryExtensions

        static void AddEmployees(IRepository<Employee> repository)
        {
            var employees = new[]
            {
                new Employee { FirstName = "Adam" },
                new Employee { FirstName = "Piotr" },
                new Employee { FirstName = "Zuzia" }
            };

            repository.AddBatch(employees);
            //    //employeeRepository.Add(new Employee { FirstName = "Adam" });
            //    //employeeRepository.Add(new Employee { FirstName = "Piotr" });
            //    //employeeRepository.Add(new Employee { FirstName = "Zuzia" });
            //    //employeeRepository.Save();
            //"string".AddBatch(employees);
        }

        static void AddManyNewTiles(IWriteRepository<Tile> tileRepository)
        {
            tileRepository.Add(new Tile { Name = "Tomek" });
            tileRepository.Add(new Tile { Name = "Przemek" });
            tileRepository.Save();
        }


        //void AddPerson(IRepository<IEntity> repository) //, out string name, out string surname, out string position)
        //{
        //    //name = null;
        //    //surname = null;
        //    //position = null;
        //    Console.WriteLine(" Please insert personal details  :   ");
        //    Console.Write("         name:  ");
        //    var name = Console.ReadLine();

        //    Console.Write("      surname:  ");
        //    var surname = Console.ReadLine();

        //    Console.Write("     position:  ");
        //    var position = Console.ReadLine();

        //    var item = new Person { FirstName = name, Surname = surname, Position = position };
        //    if (item is not null)
        //    {
        //        repository.Add(item);
        //        repository.Save();
        //        string action = " | + |  added  ] ";
        //        object e = item;
        //        repository.SaveAudit(action, e);
        //        WriteItemAdded(e);
        //    }
        //}

        //static void AddItem<T>(IRepository<T> repository)
        //    where T : class, IEntity
        //{
        //    Console.WriteLine(" Please insert details  :   ");
        //    Console.Write("         name:  ");
        //    var name = Console.ReadLine();

        //    Console.Write("      surname:  ");
        //    var surname = Console.ReadLine();

        //    Console.Write("     position:  ");
        //    var position = Console.ReadLine();

        //    var item = new[] repository; // item.GetType().Name     // 2 x Żle

        //    if (item is not null)
        //    {
        //        repository.AddBatch(item);
        //        //repository.Save();  nie potrzebne

        //        string action = " | + |  added  ] ";
        //        object e = item;
        //        repository.SaveAudit(action, e);
        //        WriteItemAdded(e);
        //    }
        //}


        //static void GetEmployeeById(IReadRepository<Employee> employeeRepository) //ok
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
    }
}