using PerondaApp.Entities;
using PerondaApp.Repositories;

namespace PerondaApp.Services;

public class UserCommunication : UserCommunicationBase, IUserCommunication
{
    private readonly IRepository<Tile> _tileRepository;
    private readonly ICriteriaProvider _criteriaProvider;

    public UserCommunication(
        IRepository<Tile> tileRepository,
        ICriteriaProvider criteriaProvider)
    {
        _tileRepository = tileRepository;
        _criteriaProvider = criteriaProvider;
    }

    //employeeRepository.ItemAdded += EmployeeRepositoryOnItemAdded;
    //employeeRepository.ItemRemoved += EmployeeRepositoryOnItemRemoved;

    public void SelectSection()
    {
        bool CloseApp = false;
        while (!CloseApp)
        {
            SelectSectionText();
            var userChoice = GetInputWrite("        Enter  O  and go to FindByCriteria()\n").ToUpper();
            if (userChoice == "A")
            {
                WriteAllToConsole(_tileRepository);
                break;
            }
            if (userChoice == "O")
            {
                _criteriaProvider.FindByCriteria();
                break;
            }
            if (userChoice == "X")
            {
                //CloseApp = true;
                return; // break; 2 razy kazali zamykać
            }
        }
    }

    public static void WriteAllToConsole<T>(IReadRepository<T> repository) where T : class, IEntity
    {
        WritelineColor($"  Viev all:    _The {typeof(T).Name}s list_ ", ConsoleColor.DarkCyan);
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
            WritelineColor("\n      This list is empty.",ConsoleColor.Red);
        }
    }
}