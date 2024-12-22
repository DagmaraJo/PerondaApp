using PerondaApp.Data.Entities;

namespace PerondaApp.Services;

public class UserCommunicationBase
{
    public static string GetInputFromUser(string comment)
    {
        WritelineColor(comment, ConsoleColor.DarkCyan);
        string userInput = Console.ReadLine()!;
        return userInput;
    }

    public static string GetInputWrite(string comment)
    {
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.Write(comment);
        Console.ResetColor();
        string userInput = Console.ReadLine()!;
        return userInput!;
    }

    public static void WritelineColor(string text, ConsoleColor foregroundColor)
    {
        Console.ForegroundColor = foregroundColor;
        Console.WriteLine(text);
        Console.ResetColor();
    }

    public static void IntroText()
    {
        Console.WriteLine("\n\n" +
                "                          Welcome to PerondaApp\n\n" +
                "      The Assortment section presents all Pereonda tile collections\n " +
                "             along with the possibility of placing orders.\n" +
                "   The HR department handles data regarding employees and business partners\n" +
                "         We invite you to familiarize yourself with the latest offer\n\n" +
                "  -------------------------------------------------------------------------");
    }

    public static void SelectSectionText()
    {
        Console.WriteLine(
                "                          select resource section:\n" +
                "    ----------------------------------------------------------------------\n" +
                "          PERONDA FULL RANGE                     HR MANAGMENT BRANCH\n" +
                "   press A _ Assortment offer             press E _ Employess\n" +
                "   press O _ Orders and complaints        press B _ BUSINESS Partners\n\n" +
                "                                                         press X - to leave");
    }

    public static void HrEmployeeText()
    {
        Console.WriteLine("\n\n                                                 HR MANAGMENT BRANCH\n" +
            " Choose option :      E M P L O Y E E S  ");
    }

    public static void HrBusinessPartnerText()
    {
        Console.WriteLine($"\n\n                                                 HR MANAGMENT BRANCH\n" +
            " Choose option :      B U S I N E S S  *  Partners ");
    }

    public static void AsortmenText()
    {
        Console.WriteLine("\n\n                                                    MANAGMENT BRANCH\n" +
            " Choose option :       A S O R T M E N T  Offer ");
    }

    public static void SelectSectionAutoMotoText()
    {
        Console.WriteLine(
                "                          select resource section:\n" +
                "    ----------------------------------------------------------------------\n" +
                "                                 AUTO-MOTO \n" +
                "   press C _ Cars \n" +
                "   press M _ Manufacturers                         >>  ESC - return \n");
    }

    public static Car InseratCarDetails() 
    {
       // WritelineColor($"   [[__ UserBase___ I N S E R T   D A T A __]]\n", ConsoleColor.DarkCyan);
        Car car = new()
        {
            Name = GetInputWrite(" Please enter details  :\n   model name:  "),
            Manufacturer = GetInputWrite(" manufacturer:  "),
            Displacement = double.Parse(GetInputWrite(" displacement:  ")),
            City = int.Parse(GetInputWrite("         city:  ")),
            Year = int.Parse(GetInputWrite("         year:  ")),
            Cylinders = int.Parse(GetInputWrite("    cylinders:  ")),
            Highway = int.Parse(GetInputWrite("      highway:  ")),
            Combined = int.Parse(GetInputWrite("     combined:  "))
        };
        return car;
    }

    public static Car InseratCarDetails2()
    {
        WritelineColor($"    UserBase_______Add new  Car  to the list\n", ConsoleColor.DarkCyan);
        var name = GetInputWrite(" Please enter details  :\n   model name:  ");
        var manufacturer = GetInputWrite(" manufacturer:  ");
        var displacement = GetInputWrite(" displacement:  ");
        var city = GetInputWrite("         city:  "); 
        var year = GetInputWrite("         year:  "); 
        var cylinders = GetInputWrite("    cylinders:  ");
        var highway = GetInputWrite("      highway:  ");
        var combined = GetInputWrite("     combined:  ");

        Car car = new Car
        {
            Name = name,
            Manufacturer = manufacturer,
            Displacement = double.Parse(displacement),
            City = int.Parse(city),
            Year = int.Parse(year),
            Cylinders = int.Parse(cylinders),
            Highway = int.Parse(highway),
            Combined = int.Parse(combined)
        };
        return car;
    }

    public static void IntroAutoMotoText()
    {
        WritelineColor("\n\tThis is a training version of a console application based on *EF Core based on *EF Core using LINQ and its elementary CRUD methods, which means that you can perform Create, Read, Update and Delete data operations here." +
                "\n\tExamples of business entities are The Manufacturer and The Car Classes, and their complementation / resources / is stored in csv files." +
                "\n\tConnecting to the database is supported by *SQL EXPRESS Server - all Microsoft system tools, of course.\n\t\t\t\t\t\t\t\t\t*EF - Entity Framework\n\t\t\t\t\t\t\t\t\t*LINQ - Language Integrated Query\n\t\t\t\t\t\t\t\t\t*SQL - Structured Query Language" +
                "\n Press any and follow the console instructions", ConsoleColor.DarkGray);
        WritelineColor("\n\n\n\n\t\t\t\t\t Welcome to MotoApp !\n\n\n\n\n", ConsoleColor.White);
        WritelineColor("  X ------------------------------------------------------------------------------------------------------------", ConsoleColor.DarkGray);
    }

    public static void SaveText()
    {
        Console.WriteLine("\t\t\t|===================|  |================================|");
        Console.WriteLine("\t\t\t|  S _Save Changes  |  |  Q ~~ continue     X - return  |");
        Console.WriteLine("\t\t\t|===================|  |================================|");
    }
}