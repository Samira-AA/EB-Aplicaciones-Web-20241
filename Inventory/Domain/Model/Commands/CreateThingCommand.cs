namespace si730ebu20211a046.API.Inventory.Domain.Model.Commands;

/// <summary>
/// Command to create a thing
/// </summary>
/// <param name="SerialNumber"></param>
/// <param name="Model"></param>
/// <param name="MaximumTemperatureThreshold"></param>
/// <param name="MinimumTemperatureThreshold"></param>
/// <author> Samira Alvarez Araguache </author>
/// <version> 1.0.0 </version>
public record CreateThingCommand(string SerialNumber, string Model, decimal MaximumTemperatureThreshold, decimal MinimumTemperatureThreshold);