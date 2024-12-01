using PerondaApp.Entities;
using PerondaApp.Repositories;

namespace PerondaApp.Services;

public class UserCommunicationBase
{
    public static string GetInputFromUser(string comment)
    {
        WritelineColor(comment, ConsoleColor.DarkCyan);
        string userInput = Console.ReadLine()!;
        return userInput;//.ToUpper()!;?
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

    public static void WhatToDoText<T>(IReadRepository<T> _repository) where T : class, IEntity
    {
        Console.WriteLine("    ----------------------------------------\n" +
        $"       press V   - to viev all {typeof(T).Name}s\n" +
        $"       press A   - to add new {typeof(T).Name}\n" +
        $"       press R   - to remove {typeof(T).Name}\n" +
        $"       press F   - to find {typeof(T).Name} by ID \n" +
        "                                           press H - Home\n" +
        "                                           press X - to leave\n");
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

    public static void InsertPersonalDetails<T>(IWriteRepository<T> _repository) where T : class, IEntity
    {
        WritelineColor($"     Add new  {typeof(T).Name}  to the list", ConsoleColor.DarkCyan);
        var firstName = GetInputWrite(" Please enter details  :\n     First Name:  ");
        var surname = GetInputWrite("        Surname:  ");
        var position = GetInputWrite("       position:  ");
        var company = GetInputWrite(" comp/bran/prod:  ");

        //var newItem = new Employee { FirstName = firstName, Surname = surname, Position = position, Company = company};
        //employeeRepository.Add(newItem);
        //employeeRepository.Save();
    }

    public static void AddNewPerson(IRepository<BusinessPartner> businessPartnerRepository)
    {
        //WritelineColor($"     Add new  {e.GetType().Name}  to the list", ConsoleColor.DarkCyan);
        WritelineColor($"               Add new  Person  to the list", ConsoleColor.Blue);
        var firstName = GetInputFromUser(" Please enter details  :\n     First Name:  ");
        var surname = GetInputFromUser("        Surname:  ");
        var position = GetInputFromUser("       position:  ");
        var company = GetInputFromUser(" comp/bran/prod:  ");

        var newItem = new BusinessPartner { FirstName = firstName, Surname = surname, Position = position, Company = company };
        businessPartnerRepository.Add(newItem);
        businessPartnerRepository.Save();
    }
}