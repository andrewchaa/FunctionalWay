# FunctionalWay

[![NuGet](https://buildstats.info/nuget/FunctionalWay)](https://www.nuget.org/packages/FunctionalWay/)

A collection of helper functions to write C# code in a functional way

## Examples

* [Pipe](#pipe)
* [Option](#option)


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

### Option

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

var restaurantEvent = await _repository.GetBy(@event.Tenant.To<Tenant>(), 
        new RestaurantId(restaurantId), @event.RestaurantEventId);
await restaurantEvent.Match(
    None: () =>
    {
        _logger.LogWarning($"Cannot find an existing restaurant {restaurantId} for restaurant event {@event.RestaurantEventId}");
        return F.UnitAsync();
    },
    Some: e => _repository.Update(@event.Tenant.To<Tenant>(),
        e.EventId,
        e.RestaurantId,
        EventStatus.Completed));
}

```

You can use Map to apply func to the inner value.

```csharp
TempOfflineType = TempOffline.Map(v => v.To<TempOfflineType>());
```

#### IsSome, IsNone

```
duration.Match(
    None: () => { },
    Some: d =>
        DateTime.Today.AddDays(1).AddHours(5)
            .Pipe(tomorrow5Am => LocalDateTime.FromLocal(tenant, tomorrow5Am))
            .Pipe(localDateTime => new EventAction(localDateTime, localDateTime.ToUtc(), ActionType.BringOnline))
            .Pipe(eventAction => Actions.Add(eventAction))
    );

if (duration.IsSome || !endDateTime.HasValue)
    return;

```
