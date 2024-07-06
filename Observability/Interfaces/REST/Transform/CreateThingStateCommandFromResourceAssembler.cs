using si730ebu20211a046.API.Observability.Domain.Model.Commands;
using si730ebu20211a046.API.Observability.Interfaces.REST.Resources;

namespace si730ebu20211a046.API.Observability.Interfaces.REST.Transform;

public class CreateThingStateCommandFromResourceAssembler
{
    public static CreateThingStateCommand ToCommandFromResource(CreateThingStateResource resource)
    {
        return new CreateThingStateCommand(resource.SerialNumber, resource.CurrentOperationMode, resource.CurrentTemperature, resource.CurrentHumidity, resource.CollectedAt);
    }
}