using si730ebu20211a046.API.Inventory.Domain.Repository;

namespace si730ebu20211a046.API.Inventory.Interfaces.ACL.Services.Services;

/// <summary>
/// Facade for Thing Context
/// </summary>
/// <param name="thingRepository"></param>
/// <author>Samira Alvarez Araguache</author>
/// <version>1.0.0</version>
public class ThingContextFacade (IThingRepository thingRepository) : IThingContextFacade
{
    
    /// <summary>
    /// Implementation of ExistsThingAsync
    /// </summary>
    /// <param name="serialNumber"></param>
    /// <returns></returns>
    public async Task<bool> ExistsThingAsync(Guid serialNumber)
    {
        return await thingRepository.ExistBySerialNumberAsync(serialNumber);
    }
}
