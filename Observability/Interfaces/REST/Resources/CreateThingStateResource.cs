namespace si730ebu20211a046.API.Observability.Interfaces.REST.Resources;

public record CreateThingStateResource( string SerialNumber, int CurrentOperationMode, decimal CurrentTemperature, decimal CurrentHumidity, DateTime CollectedAt);