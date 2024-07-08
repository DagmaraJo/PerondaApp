namespace PerondaApp.Data.Entities.Extensions;

using System.Text.Json;

public static class EntityExtensions
{
    public static T? Copy<T>(this T itemToCopy) where T : IEntity
    {
        var json = JsonSerializer.Serialize(itemToCopy);
        return JsonSerializer.Deserialize<T>(json);  // tu będzie kopia obiektu na nowej referencji
    }

    //static readonly Tile original = new Tile();
    //static readonly Tile copy = Tile.Copy();
}
