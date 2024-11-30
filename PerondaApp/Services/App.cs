namespace PerondaApp.Services;

public class App : IApp
{
    private readonly IUserCommunication _userCommunication;

    public App(IUserCommunication userCommunication)
    {
        _userCommunication = userCommunication;
    }

    public void Run()
    {
        Console.WriteLine("   HELLO in App.Run()");

        Console.WriteLine("\n\n" +
                "                          Welcome to PerondaApp\n\n" +
                "      The Assortment section presents all Pereonda tile collections\n " +
                "             along with the possibility of placing orders.\n" +
                "   The HR department handles data regarding employees and business partners\n" +
                "         We invite you to familiarize yourself with the latest offer\n\n" +
                "  -------------------------------------------------------------------------");
        _userCommunication.SelectSection();
    }
}