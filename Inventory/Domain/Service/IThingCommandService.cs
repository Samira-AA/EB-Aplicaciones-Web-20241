using si730ebu20211a046.API.Inventory.Domain.Model.Aggregates;
using si730ebu20211a046.API.Inventory.Domain.Model.Commands;

namespace si730ebu20211a046.API.Inventory.Domain.Service;

/// <summary>
/// Command service for Thing
/// </summary>
/// <author>Samira Alvarez Araguache</author>
/// <version>1.0.0</version>
public interface IThingCommandService
{
    Task<Thing?> Handle(CreateThingCommand command);
}