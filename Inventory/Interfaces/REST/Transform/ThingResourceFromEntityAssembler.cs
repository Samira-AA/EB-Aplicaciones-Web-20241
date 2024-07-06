using si730ebu20211a046.API.Inventory.Domain.Model.Aggregates;
using si730ebu20211a046.API.Inventory.Interfaces.REST.Resources;

namespace si730ebu20211a046.API.Inventory.Interfaces.REST.Transform;

public class ThingResourceFromEntityAssembler
{
    public static ThingResource ToResourceFromEntity(Thing entity)
    {
        return new ThingResource(entity.Id, entity.SerialNumber, entity.Model, entity.OperationMode, entity.MaximumTemperatureThreshold, entity.MinimumTemperatureThreshold);
    }
}