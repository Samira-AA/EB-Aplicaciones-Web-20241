using si730ebu20211a046.API.Inventory.Domain.Model.Aggregates;
using si730ebu20211a046.API.Inventory.Domain.Model.Queries;

namespace si730ebu20211a046.API.Inventory.Domain.Service;


/// <summary>
/// Query service for Thing
/// </summary>
/// <author>Samira Alvarez Araguache</author>
/// <version>1.0.0</version>
public interface IThingQueryService
{
    Task<Thing> Handle(GetAllThingById query);
}