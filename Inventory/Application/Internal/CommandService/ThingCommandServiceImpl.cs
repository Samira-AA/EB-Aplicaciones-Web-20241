using si730ebu20211a046.API.Inventory.Domain.Model.Aggregates;
using si730ebu20211a046.API.Inventory.Domain.Model.Commands;
using si730ebu20211a046.API.Inventory.Domain.Repository;
using si730ebu20211a046.API.Inventory.Domain.Service;
using si730ebu20211a046.API.Shared.Domain.Repositories;

namespace si730ebu20211a046.API.Inventory.Application.Internal.CommandService;

/// <summary>
/// Command service for Thing
/// </summary>
/// <param name="thingRepository"></param>
/// <param name="unitOfWork"></param>
/// <author>Samira Alvarez Araguache</author>
/// <version>1.0.0</version>
public class ThingCommandServiceImpl (IThingRepository thingRepository, IUnitOfWork unitOfWork): IThingCommandService
{
    public async Task<Thing?> Handle(CreateThingCommand command)
    {
        Guid serialNumberGuid = Guid.Parse(command.SerialNumber);
        bool thingExists = await thingRepository.ExistBySerialNumberAsync(serialNumberGuid);
        if (thingExists)
        {
            throw new Exception("Thing already exists. Code must be unique.");
        }
        
        if(command.MaximumTemperatureThreshold < -40.00m || command.MaximumTemperatureThreshold > 85.00m)
        {
            throw new Exception("MaximumTemperatureThreshold must be a decimal between -40.00 and 85.00.");
        }
        if(command.MinimumTemperatureThreshold < 0.00m || command.MinimumTemperatureThreshold > 100.00m)
        {
            throw new Exception("MinimumTemperatureThreshold must be a decimal between 0.00 and 100.00.");
        }
        var thing = new Thing(command);
        await thingRepository.AddAsync(thing);
        await unitOfWork.CompleteAsync();
        return thing;
    }
}
