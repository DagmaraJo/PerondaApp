namespace PerondaApp.Data.Entities;

public class Person : EntityBase, IEntity
{
    //public Person()
    //{
    //}

    //public Person(string name)
    //{
    //}

    public string? FirstName { get; set; }

    public string? Surname { get; set;}

    public string? Position { get; set; }

    public string? Adress { get; private set; }

    public int? TelNumb { get; private set; }

    public string? EMail { get; private set; }

    public string FullName => $" {FirstName} {Surname}";

    public override string ToString() => $" ID: {Id}  {FullName}";
}


/*Tak, w języku C# można wygenerować wiele klas obiektów dziedziczących po bazie bez konieczności tworzenia ich w "drzewie" kodu. Jest to możliwe dzięki mechanizmowi refleksji, który umożliwia analizowanie i modyfikowanie struktury typów w trakcie działania programu.

Można użyć refleksji do dynamicznego tworzenia nowych klas przy użyciu funkcji takich jak `TypeBuilder` z przestrzeni nazw `System.Reflection.Emit`. Ten mechanizm umożliwia tworzenie klas w locie, bez konieczności predefiniowania ich w kodzie.

Przykładowo, można napisać funkcję, która generuje nową klasę dziedziczącą po bazie `BaseClass`:

```csharp
public static Type GenerateClass()
{
    // Tworzenie dynamicznej skompilowanej wersji nowej klasy
    string className = "NewClass";
    AssemblyName assemblyName = new AssemblyName(className);
    AssemblyBuilder assemblyBuilder = AssemblyBuilder.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Run);
    ModuleBuilder moduleBuilder = assemblyBuilder.DefineDynamicModule(className + "Module");
    TypeBuilder typeBuilder = moduleBuilder.DefineType(className, TypeAttributes.Public, typeof(BaseClass));

    // Tutaj można dodać pola, metody i właściwości dla nowej klasy

    return typeBuilder.CreateType();
}
```

Ta funkcja tworzy nową klasę o nazwie "NewClass" dziedziczącą po bazie `BaseClass`. Można dodawać pola, metody i właściwości do nowej klasy, tak samo jak robilibyśmy to w tradycyjny sposób.

Ten mechanizm jest przydatny w przypadku nieznanej liczby klas dziedziczących lub potrzeby tworzenia nowych klas dynamicznie podczas działania programu, na podstawie pewnych warunków lub danych wejściowych.
*/