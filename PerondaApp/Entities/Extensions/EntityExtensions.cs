using System.Text.Json;

namespace PerondaApp.Entities.Extensions;

public static class EntityExtensions
{
    public static T? Copy<T>(this T itemToCopy) where T: IEntity
    {
        var json = JsonSerializer.Serialize<T>(itemToCopy);
        return JsonSerializer.Deserialize<T>(json);  // tu będzie kopia obiektu na nowej referencji
    }
}
