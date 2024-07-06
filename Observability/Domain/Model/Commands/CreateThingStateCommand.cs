namespace si730ebu20211a046.API.Observability.Domain.Model.Commands;

/// <summary>
/// Command to create a Thing State
/// </summary>
/// <param name="SerialNumber"></param>
/// <param name="CurrentOperationMode"></param>
/// <param name="CurrentTemperature"></param>
/// <param name="CurrentHumidity"></param>
/// <param name="CollectedAt"></param>
/// <author>Samira Alvarez Araguache</author>
/// <version>1.0.0</version>
public record CreateThingStateCommand(string SerialNumber, int CurrentOperationMode, decimal CurrentTemperature, decimal CurrentHumidity, DateTime CollectedAt);