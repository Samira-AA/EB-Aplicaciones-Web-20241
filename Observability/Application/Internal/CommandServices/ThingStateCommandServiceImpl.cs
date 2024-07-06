using si730ebu20211a046.API.Observability.Application.Internal.OutboundServices.ACL;
using si730ebu20211a046.API.Observability.Domain.Model.Aggregates;
using si730ebu20211a046.API.Observability.Domain.Model.Commands;
using si730ebu20211a046.API.Observability.Domain.Repository;
using si730ebu20211a046.API.Observability.Domain.Service;
using si730ebu20211a046.API.Shared.Domain.Repositories;

namespace si730ebu20211a046.API.Observability.Application.Internal.CommandServices;

/// <summary>
/// Service to handle ThingState commands
/// </summary>
/// <param name="thingStateRepository"></param>
/// <param name="externalThingService"></param>
/// <param name="unitOfWork"></param>
/// /// <author>Samira Alvarez Araguache</author>
/// <version>1.0.0</version>
public class ThingStateCommandServiceImpl (IThingStateRepository thingStateRepository, ExternalThingService externalThingService ,IUnitOfWork unitOfWork): IThingStateCommandService
{
    
    /// <summary>
    /// Handle the CreateThingStateCommand
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public async Task<ThingState?> Handle(CreateThingStateCommand command)
    {
        Guid ThingSerialNumberGuid = Guid.Parse(command.SerialNumber);
        var thing = await externalThingService.FetchThingBySerialNumber(ThingSerialNumberGuid);
        if (thing == null)
        {
            throw new Exception("There's no Thing with the provided Serial Number");
        }
        if (command.CollectedAt.Date > DateTime.Now.Date)
        {
            throw new Exception("State Date cannot be in the future");
        }
        if (command.CurrentOperationMode < 0 || command.CurrentOperationMode > 2)
        {
            throw new Exception("CurrentOperationMode must be an integer between 0 and 2");
        }

        var existingThingState = await thingStateRepository.GetBySerialNumberAndCollectedAt(ThingSerialNumberGuid, command.CollectedAt.Date);
        if (existingThingState != null)
        {
            throw new Exception("A ThingState with the same Serial Number and CollectedAt already exists");
        }
        
        var thingState = new ThingState(command);
        await thingStateRepository.AddAsync(thingState);
        await unitOfWork.CompleteAsync();
        return thingState;
    }
}
