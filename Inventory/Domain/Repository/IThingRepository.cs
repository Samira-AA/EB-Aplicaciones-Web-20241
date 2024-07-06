using si730ebu20211a046.API.Inventory.Domain.Model.Aggregates;
using si730ebu20211a046.API.Shared.Domain.Repositories;

namespace si730ebu20211a046.API.Inventory.Domain.Repository;

/// <summary>
/// Repository for Thing
/// </summary>
/// /// <author>Samira Alvarez Araguache</author>
/// <version>1.0.0</version>
public interface IThingRepository :IBaseRepository<Thing>
{
    Task<bool> ExistBySerialNumberAsync(Guid serialNumber);
}