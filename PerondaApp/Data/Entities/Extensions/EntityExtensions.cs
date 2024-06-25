﻿using System.Text.Json;
using PerondaApp.Data.Entities;

namespace PerondaApp.Data.Entities.Extensions;

public static class EntityExtensions
{
    public static T? Copy<T>(this T itemToCopy) where T : IEntity
    {
        var json = JsonSerializer.Serialize(itemToCopy);
        return JsonSerializer.Deserialize<T>(json);  // tu będzie kopia obiektu na nowej referencji
    }
}
