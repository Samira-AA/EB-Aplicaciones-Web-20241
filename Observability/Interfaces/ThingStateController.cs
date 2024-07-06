using Microsoft.AspNetCore.Mvc;
using si730ebu20211a046.API.Inventory.Domain.Service;
using si730ebu20211a046.API.Observability.Domain.Service;
using si730ebu20211a046.API.Observability.Interfaces.REST.Resources;
using si730ebu20211a046.API.Observability.Interfaces.REST.Transform;

namespace si730ebu20211a046.API.Observability.Interfaces;

/// <summary>
/// Controller class for ThingState
/// </summary>
/// <param name="thingStateCommandService"></param>
/// <author>Samira Alvarez Araguache</author>
/// <version>1.0.0</version>
[ApiController]
[Route("api/v1/thing-states")]
public class ThingStateController (IThingStateCommandService thingStateCommandService) : ControllerBase
{
    /// <summary>
    /// Creates a new ThingState in the database and returns the created ThingState.
    /// </summary>
    /// <param name="resource"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> CreateThingState(CreateThingStateResource resource)
    {
        var command = CreateThingStateCommandFromResourceAssembler.ToCommandFromResource(resource);
        var thingState = await thingStateCommandService.Handle(command);
        var thingStateResource = ThingStateResourceFromEntityAssembler.ToResourceFromEntity(thingState);
        return StatusCode(201, thingStateResource);
    }
    
}
