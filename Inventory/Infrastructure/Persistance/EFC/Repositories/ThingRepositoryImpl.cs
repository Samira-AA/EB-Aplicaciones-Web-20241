using Microsoft.EntityFrameworkCore;
using si730ebu20211a046.API.Inventory.Domain.Model.Aggregates;
using si730ebu20211a046.API.Inventory.Domain.Repository;
using si730ebu20211a046.API.Shared.Infrastructure.Persistance.EFC.Configuration;
using si730ebu20211a046.API.Shared.Infrastructure.Persistance.EFC.Repositories;

namespace si730ebu20211a046.API.Inventory.Infrastructure.Persistance.EFC.Repositories;

/// <summary>
/// Repository for Thing
/// </summary>
/// <param name="context"></param>
/// <author>Samira Alvarez Araguache</author>
/// <version>1.0.0</version>
public class ThingRepositoryImpl (AppDbContext context): BaseRepository<Thing>(context), IThingRepository
{
    public async Task<bool> ExistBySerialNumberAsync(Guid serialNumber)
    {
        return await context.Set<Thing>().AnyAsync(x => x.SerialNumberValObj.Value == serialNumber);
    }
}