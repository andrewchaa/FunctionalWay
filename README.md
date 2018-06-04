# FunctionalWay

[![NuGet](https://img.shields.io/nuget/v/FunctionalWay.svg?maxAge=3600)](https://www.nuget.org/packages/FunctionalWay/)

A collection of helper functions to write C# code in a functional way

## Examples

### Map & Tee

```csharp
public MoneyTransaction Parse(IList<string> columns)
{
    return new MoneyTransaction(
        columns[0].Map(c => DateTime.ParseExact(c, "dd MMM yy", CultureInfo.InvariantCulture)),
        columns[1].Trim(),
        columns[1].Trim().Map(FindCategory),
        columns[6]
            .Map(c => c.Trim())
            .Tee(c => _logger.LogInformation($"Input: {c}"))
            .Map(c => !string.IsNullOrEmpty(c) ? decimal.Parse(c) : 0),
        0
    );
}

```
