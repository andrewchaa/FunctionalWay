# FunctionalWay

[![NuGet](https://img.shields.io/nuget/v/FunctionalWay.svg?maxAge=3600)](https://www.nuget.org/packages/FunctionalWay/)

A collection of helper functions to write C# code in a functional way

## Examples

* [Pipe](#pipe)
* [Option<T>]

### Pipe

```csharp
public MoneyTransaction Parse(IList<string> columns)
{
    return new MoneyTransaction(
        columns[0].Pipe(c => DateTime.ParseExact(c, "dd MMM yy", CultureInfo.InvariantCulture)),
        columns[1].Trim(),
        columns[1].Trim().Pipe(FindCategory),
        columns[6]
            .Pipe(c => c.Trim())
            .Pipe(c => _logger.LogInformation($"Input: {c}"))
            .Pipe(c => !string.IsNullOrEmpty(c) ? decimal.Parse(c) : 0),
        0
    );
}
```

### Option<T>

```csharp
public async Task<Option<RestaurantEvents>> GetBy(
    Tenant tenant,
    RestaurantId restaurantId,
    RestaurantEventId restaurantEventId)
{
    using (var conn = _appSettings.ToTenantSpecificRestaurantEventsMySqlConnection(tenant))
    {
        await conn.OpenAsync();
        var restaurantEvent = await conn.QuerySingleOrDefaultAsync<RestaurantEvents>(
            @"SELECT *
                FROM RestaurantEvents
               WHERE EventId = @restaurantEventId
                 AND RestaurantId = @restaurantId",
            new
            {
                restaurantEventId = restaurantEventId.Id,
                restaurantId = restaurantId.Id
            });

        return restaurantEvent == null
            ? F.None
            : F.Some(restaurantEvent);
    }
}

```

