namespace si730ebu20211a046.API.Inventory.Interfaces.REST.Resources;

public record ThingResource (int Id, string SerialNumber, string Model, string OperationMode, decimal MaximumTemperatureThreshold, decimal MinimumTemperatureThreshold)
{
    
}