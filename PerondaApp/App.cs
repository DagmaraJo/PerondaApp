//using PerondaApp.Data.Components.CsvReader;
using PerondaApp.Data.Components.DataProviders;
using PerondaApp.Entities;
using PerondaApp.Repositories;
using PerondaApp.Services;

namespace PerondaApp;

public class App : IApp
{
    private readonly IRepository<Employee> _employeesRepository;
    private readonly IRepository<Tile> _tilesRepository;
    private readonly IRepository<BusinessPartner> _businessPartnerRepository;
    private readonly ITilesProvider _tilesProvider;
    private readonly IUserCommunication _userCommunication;
    private readonly IActions _actions;

    public App(
        IRepository<Employee> employeeRepository,
        IRepository<Tile> tilesRepository,
        IRepository<BusinessPartner> businessPartnerRepository,
        ITilesProvider tilesProvider,
        IUserCommunication userCommunication,
        IActions actions)
    {
        _employeesRepository = employeeRepository;
        _businessPartnerRepository = businessPartnerRepository;
        _tilesRepository = tilesRepository;
        _tilesProvider = tilesProvider;
        _userCommunication = userCommunication;
        _actions = actions;
    }

    public void Run()
    {
        _userCommunication.ChooseOption();
        //_userCommunication.SubscribeToEvents();
        _actions.SubscribeToEvents();
    }
}
