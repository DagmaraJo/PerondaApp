using PerondaApp.Components.DataProviders;

namespace PerondaApp.Services;

public class CarSearchEngine : UserCommunicationBase, ICarSearchEngine
{
    private readonly ICarProvider _carProvider;

    public CarSearchEngine(ICarProvider carProvider)
    {
        _carProvider = carProvider;
    }

    public void SearchCarsByCriteria()
    {
        Console.WriteLine( "\n\t1 View All Car Models\t"); // WhereStartsWith(string prefix)


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

    private void ViewUniqueCarNames()
    {
        var names = _carProvider.GetUniqueNames();
        foreach (var name in names) 
        {
            Console.WriteLine(name);
        }
    }

    private void ViewUniqueCarProducer()
    {
        var items = _carProvider.GetUniqueNames();
        foreach (var item in items)
        {
            Console.WriteLine(item);
        }
    }

    private void OrderByNameDescending()
    {
        var names = _carProvider.GetUniqueNames();
        foreach (var name in names)
        {
            Console.WriteLine(name);
        }
    }

    private void ViewUniqueCarProduc()
    {
        var cars = _carProvider.DistinctByProducerOrdrByCombined();
        foreach (var car in cars)
        {
            Console.WriteLine($"======<  {car.Manufacturer}  >=======\n\tcombined {car.Combined}\n\t\t\t => car model: {car.Name}");
        }
    }
}