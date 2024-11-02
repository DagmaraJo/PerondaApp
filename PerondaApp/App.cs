using PerondaApp.Services;

namespace PerondaApp;

public class App : IApp
{
    private readonly IUserCommunication _userCommunication;
    private readonly IActions _actions;

    public App(
        IUserCommunication userCommunication,
        IActions actions)
    {
        _userCommunication = userCommunication;
        _actions = actions;
    }

    public void Run()
    {
        _userCommunication.ChooseOption();
        //_userCommunication.SubscribeToEvents();
        _actions.SubscribeToActions();
    }
}
