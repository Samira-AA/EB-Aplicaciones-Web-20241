using si730ebu20211a046.API.Inventory.Domain.Model.Aggregates;
using si730ebu20211a046.API.Inventory.Domain.Model.Queries;
using si730ebu20211a046.API.Inventory.Domain.Repository;
using si730ebu20211a046.API.Inventory.Domain.Service;

namespace si730ebu20211a046.API.Inventory.Application.Internal.QueryService;

/// <summary>
/// Query service for Thing
/// </summary>
/// <param name="thingRepository"></param>
/// <author>Samira Alvarez Araguache</author>
/// <version>1.0.0</version>
public class ThingQueryServiceImpl (IThingRepository thingRepository): IThingQueryService
{
    /// <summary>
    /// Query to get all things
    /// </summary>
    /// <param name="query"></param>
    /// <returns></returns>
    public async Task<Thing> Handle(GetAllThingById query)
    {
        return await thingRepository.FindByIdAsync(query.Id);
    }
}
