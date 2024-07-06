using si730ebu20211a046.API.Observability.Domain.Model.Aggregates;
using si730ebu20211a046.API.Shared.Domain.Repositories;

namespace si730ebu20211a046.API.Observability.Domain.Repository;
/// <summary>
/// Repository for Thing State
/// </summary>
/// <author>Samira Alvarez Araguache</author>
/// <version>1.0.0</version>
public interface IThingStateRepository :IBaseRepository<ThingState>
{
    Task<ThingState?> GetBySerialNumberAndCollectedAt(Guid serialNumber, DateTime collectedAt);
}