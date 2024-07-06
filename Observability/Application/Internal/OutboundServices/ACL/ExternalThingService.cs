using si730ebu20211a046.API.Inventory.Domain.Model.Aggregates;
using si730ebu20211a046.API.Inventory.Domain.Model.ValueObjects;
using si730ebu20211a046.API.Inventory.Interfaces.ACL.Services;

namespace si730ebu20211a046.API.Observability.Application.Internal.OutboundServices.ACL;

/// <summary>
/// External service to fetch Thing by Serial Number
/// </summary>
/// <param name="thingContextFacade"></param>
/// <author>Samira Alvarez Araguache</author>
/// <version>1.0.0</version>
public class ExternalThingService (IThingContextFacade thingContextFacade)
{
    public async Task<SerialNumber?> FetchThingBySerialNumber(Guid serialNumber)
    {
        bool thingExists = await thingContextFacade.ExistsThingAsync(serialNumber);
        if (thingExists)
        {
            return new SerialNumber(serialNumber);
        }
        else
        {
            return null;
        }
    }
}