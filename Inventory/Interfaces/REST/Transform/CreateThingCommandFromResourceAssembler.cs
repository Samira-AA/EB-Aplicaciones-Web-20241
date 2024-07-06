using si730ebu20211a046.API.Inventory.Domain.Model.Commands;
using si730ebu20211a046.API.Inventory.Interfaces.REST.Resources;

namespace si730ebu20211a046.API.Inventory.Interfaces.REST.Transform;

public class CreateThingCommandFromResourceAssembler
{
    public static CreateThingCommand ToCommandFromResource(CreateThingResource resource)
    {
        return new CreateThingCommand(resource.SerialNumber, resource.Model,resource.MaximumTemperatureThreshold, resource.MinimumTemperatureThreshold);
    }
}