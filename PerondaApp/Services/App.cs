using PerondaApp.Data.Components.CsvReader;
using System.Xml.Linq;

namespace PerondaApp.Services;

public class App : IApp
{
    //private readonly IUserCommunication _userCommunication;
    private readonly ICsvReader _csvReader;

    public App(//IUserCommunication userCommunication,
        ICsvReader csvReader)
    {
        //_userCommunication = userCommunication;
        _csvReader = csvReader;
    }

    public void Run()
    {
       //_userCommunication.SelectSection();

        //var manufacturers = _csvReader.ProcessManufacturers("Resources\\Files\\manufacturers.csv");

        CreateXml();

        QeryXml();
    }

    private static void QeryXml()
    {
        var document = XDocument.Load("Resources\\Files\\fuel2.xml");
        var names = document
            .Element("Cars")?
            .Elements("Car")
            .Where(x => x.Attribute("Manufacturer")?.Value == "BMW")
            .Select(x => x.Attribute("Name")?.Value);

        foreach (var name in names)
        {
            Console.WriteLine(name);
        }
    }

    private void CreateXml()
    {
        var records = _csvReader.ProcessCars("Resources\\Files\\fuel.csv");

        var document = new XDocument();

        var cars = new XElement("Cars", records
            .Select(x =>
            new XElement("Car",
            new XAttribute("Name", x.Name),
                   new XAttribute("Combined", x.Combined),
                   new XAttribute("Manufacturer", x.Manufacturer))));

        document.Add(cars);
        document.Save("Resources\\Files\\fuel2.xml");
    }
}