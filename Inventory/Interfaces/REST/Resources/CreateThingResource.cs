namespace si730ebu20211a046.API.Inventory.Interfaces.REST.Resources;

public record CreateThingResource (string SerialNumber, string Model, decimal MaximumTemperatureThreshold, decimal MinimumTemperatureThreshold)
{
    
}