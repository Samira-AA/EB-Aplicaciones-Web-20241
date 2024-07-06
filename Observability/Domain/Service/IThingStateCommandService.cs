using si730ebu20211a046.API.Observability.Domain.Model.Aggregates;
using si730ebu20211a046.API.Observability.Domain.Model.Commands;

namespace si730ebu20211a046.API.Observability.Domain.Service;

/// <summary>
/// Command service for Thing State
/// </summary>
/// <author>Samira Alvarez Araguache</author>
/// <version>1.0.0</version>
public interface IThingStateCommandService
{
    Task<ThingState?> Handle(CreateThingStateCommand command);
}