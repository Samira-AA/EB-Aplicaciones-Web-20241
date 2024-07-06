using Microsoft.AspNetCore.Mvc;
using si730ebu20211a046.API.Inventory.Domain.Model.Queries;
using si730ebu20211a046.API.Inventory.Domain.Service;
using si730ebu20211a046.API.Inventory.Interfaces.REST.Resources;
using si730ebu20211a046.API.Inventory.Interfaces.REST.Transform;

namespace si730ebu20211a046.API.Inventory.Interfaces;

/// <summary>
/// Controller for Thing
/// </summary>
/// <param name="thingCommandService"></param>
/// <param name="thingQueryService"></param>
/// <author>Samira Alvarez Araguache</author>
/// <version>1.0.0</version>
[ApiController]
[Route("api/v1/[controller]")]
public class ThingController (IThingCommandService thingCommandService, IThingQueryService thingQueryService) : ControllerBase
{
    
    /// <summary>
    /// Method to create a Thing
    /// </summary>
    /// <param name="resource"></param>
    /// <returns></returns>
    [HttpPost]
    [ProducesResponseType(201)]
    public async Task<IActionResult> CreateThing(CreateThingResource resource)
    {
        var createThingCommand = CreateThingCommandFromResourceAssembler.ToCommandFromResource(resource);
        var thing = await thingCommandService.Handle(createThingCommand);
        var thingResource = ThingResourceFromEntityAssembler.ToResourceFromEntity(thing);
        return StatusCode(201, thingResource);
    }
    
    
    /// <summary>
    /// Method to get a Thing by Id
    /// </summary>
    /// <param name="thingId"></param>
    /// <returns></returns>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<ThingResource>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetThingById(int thingId)
    {
        var thing = await thingQueryService.Handle(new GetAllThingById(thingId));
        if (thing is null) return BadRequest();
        var thingResource = ThingResourceFromEntityAssembler.ToResourceFromEntity(thing);
        return Ok(thingResource);
    }
    
}