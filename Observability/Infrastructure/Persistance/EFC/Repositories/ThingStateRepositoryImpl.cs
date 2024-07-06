using Microsoft.EntityFrameworkCore;
using si730ebu20211a046.API.Observability.Domain.Model.Aggregates;
using si730ebu20211a046.API.Observability.Domain.Repository;
using si730ebu20211a046.API.Shared.Infrastructure.Persistance.EFC.Configuration;
using si730ebu20211a046.API.Shared.Infrastructure.Persistance.EFC.Repositories;

namespace si730ebu20211a046.API.Observability.Infrastructure.Persistance.EFC.Repositories;

/// <summary>
/// Repository for Thing State
/// </summary>
/// <param name="context"></param>
/// <author>Samira Alvarez Araguache</author>
/// <version>1.0.0</version>
public class ThingStateRepositoryImpl (AppDbContext context): BaseRepository<ThingState>(context), IThingStateRepository
{
    public async Task<ThingState?> GetBySerialNumberAndCollectedAt(Guid serialNumber, DateTime collectedAt)
    {
        return await context.ThingStates
            .SingleOrDefaultAsync(ts => ts.ThingSerialNumber.Value == serialNumber && ts.CollectedAt.Date == collectedAt.Date);
    }
}