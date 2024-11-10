namespace PerondaApp.Services;

public class UserCommunicationBase
{
    public static string GetInputFromUser(string comment)
    {
        WritelineColor(comment, ConsoleColor.Blue);
        string userInput = Console.ReadLine();
        return userInput;
    }

    public static void WritelineColor(string text, ConsoleColor foregroundColor)
    {
        Console.ForegroundColor = foregroundColor;
        Console.WriteLine(text);
        Console.ResetColor();
    }

    public static void SelectTextInColor()
    {
        WritelineColor(
                "                          select resource section:\n" +
                "    ----------------------------------------------------------------------\n" +
                "          PERONDA FULL RANGE                     HR MANAGMENT BRANCH\n" +
                "   press A _ Assortment offer             press E _ Employess\n" +
                "   press O _ Orders and complaints        press B _ BUSINESS Partners\n\n" +
                "                                                         press X - to leave", ConsoleColor.Cyan);
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

    public void WhatToDoText(object e)  // static ?
    {
        //object e = null;
        Console.WriteLine(
        $"       press V   - to viev all {e.GetType().Name}s\n" +  // {typeof(T)}
        $"       press A   - to add new {e}s\n" +
        $"       press D   - to delete {e}s\n" +
        $"       press R   - to remove {e}s\n" +
        $"       press F   - to find {e}s by ID \n" +
        "                                           press H - Home\n" +
        "                                           press X - to leave\n");
    }

    public static void ChooseOptionText() //<T>(IRepository<T> repository) where T : class, IEntity
    {
        object e = null;
        Console.WriteLine("    ----------------------------------------------------------------------\n" +
        $"       Enter  V   - to viev all \n" +  // {typeof(T)}
        $"       Enter  A   - to add new  \n" +
        $"       Enter  D   - to delete \n" +
        $"       Enter  R   - to remove \n" +
        $"       Enter  F   - to find  by ID \n" +
        "                                           Enter  H  - Home\n" +
        "                                           Enter  X  - to leave\n");
    }

    public static void HrEmployeeText()
    {
        Console.WriteLine("\n\n" +
            "                                                 HR MANAGMENT BRANCH\n" +
            " Choose option :      E M P L O Y E E S  "); ChooseOptionText();
    }

    public static void HrBusinessPartnerText()
    {
        Console.WriteLine($"\n\n" +
            "                                                 HR MANAGMENT BRANCH\n" +
            " Choose option :      B U S I N E S S  *  Partners ");
        ChooseOptionText();
    }

    public static void AsortmenText()
    {
        Console.WriteLine("\n\n" +
            "                                                    MANAGMENT BRANCH\n" +
            " Choose option :       A S O R T M E N T  Offer ");
    }

    public static void WriteItemAdded(object e)
    {
        WritelineColor($"  new  {e}  successfully added  ", ConsoleColor.Green);
    }

    public static void WriteItemRemoved(object e)
    {
        WritelineColor($" {e} just REMOVED", ConsoleColor.DarkCyan);
    }

    public static void AddNewItemText(object e)
    {
        WritelineColor($"     Add new  {e.GetType().Name}s  to the list", ConsoleColor.DarkCyan);
        WritelineColor($"               Add new  Person  to the list", ConsoleColor.Blue);
        GetInputFromUser(" Please enter details  :\t     First Name:  ");
        GetInputFromUser("         Surname:  ");
        GetInputFromUser("       position:  ");
        GetInputFromUser(" comp/bran/prod:  ");
    }

    public static void InsertPersonDataText()
    {
        Console.WriteLine(" Please enter details  :   ");
        Console.Write("      full name:  ");
        var fullName = Console.ReadLine();
        Console.Write("       position:  ");
        var position = Console.ReadLine();
        Console.Write(" comp/bran/prod:  ");
        var _ = Console.ReadLine();
    }
}

//    Console.WriteLine(" Please enter details  : ");
//    GetInputFromUser("      full name:  ");
//    GetInputFromUser("       position:  ");
//    GetInputFromUser(" comp/bran/prod:  ");


//static void RemoveEmployeeById(IRepository<Employee> employeeRepository) // aktualne
//{
//    Console.WriteLine("Insert personal ID to remove:");
//    var input = Console.ReadLine();
//    var id = int.Parse(input);

//    var item = employeeRepository.GetById(id);

//    if (item is not null)
//    {
//        employeeRepository.Remove(item);
//        employeeRepository.Save();
//        string action = " | - | removed ] ";
//        object e = item;
//        employeeRepository.SaveAudit(action, e);
//        WriteItemRemoved(e);
//    }
//}


//static void ChooseOption(IReadRepository<IEntity> repository)
//{
//    ChooseOptionText();
//    bool Exit = false;
//    while (!Exit)
//    {
//        //HrBusinessPartnerText();
//        //ChooseOptionText();  // ok
//        WritelineColor("      What do you want to do ?  ", ConsoleColor.DarkCyan);
//        var userInput = Console.ReadLine()?.ToUpper();
//        switch (userInput) 
//        {
//            case "V":
//                WriteAllToConsole(repository); break;
//            case "F":
//                GetItemById(repository); break;
//            case "A":
//                AddNewItemText(); break;
//            case "D":
//            //RemoveItem(repository); break;
//            case "R":
//            ///RemoveItemById(repository); break;
//            case "H":
//                SelectSection(); break;
//            case "X":
//                break;
//            default:
//                WritelineColor($"\n      Invalid operation.\n", ConsoleColor.Red);
//                break;
//        }
//    }
//}


//var userChoice = GetInputFromUser("  What You want To do ?   Enter V, A, R, D or F").ToUpper();
//if (userChoice == "V")
//{
//    WriteAllToConsole(_tileRepository);
//    break;
//}
//if (userChoice == "A")
//{
//    AddNewItem(_tileRepository);
//    break;
//}
//if (userChoice == "R")
//{
//    RemoveItem(_tileRepository);
//    break;
//}
//if (userChoice == "F")
//{
//    GetItemById(_tileRepository);
//    break;
//}
//break;