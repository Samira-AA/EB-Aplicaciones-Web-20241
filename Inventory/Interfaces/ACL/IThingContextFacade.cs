namespace si730ebu20211a046.API.Inventory.Interfaces.ACL.Services;

/// <summary>
/// Facade for Thing Context
/// </summary>
/// <author>Samira Alvarez Araguache</author>
/// <version>1.0.0</version>
public interface IThingContextFacade
{
    Task<bool> ExistsThingAsync(Guid thingSerialNumber);
}