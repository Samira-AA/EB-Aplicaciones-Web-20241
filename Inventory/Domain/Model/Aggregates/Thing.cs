using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using si730ebu20211a046.API.Inventory.Domain.Model.Commands;
using si730ebu20211a046.API.Inventory.Domain.Model.ValueObjects;

namespace si730ebu20211a046.API.Inventory.Domain.Model.Aggregates;

/// <summary>
/// Represents a thing in the system
/// <author> Samira Alvarez Araguache </author>
/// <version> 1.0.0 </version>
public partial class Thing
{
    [Required]
    public int Id { get; set; }
    
    [Required]
    public SerialNumber SerialNumberValObj { get; set; }
    
    public string SerialNumber => SerialNumberValObj.Value.ToString();
    
    [Required]
    [NotNull]
    public string Model { get; set; }

    [Required]
    public EOperationMode OperationModeEnum { get; set; }
    
    public string OperationMode => OperationModeEnum.ToString();
    
    [Required]
    [Range(-40.00, 85.00)]
    public decimal MaximumTemperatureThreshold { get; set; }
    
    [Required]
    [Range(0.00, 100.00)]
    public decimal MinimumTemperatureThreshold { get; set; }
    
    public Thing(){}

    public Thing(CreateThingCommand command)
    {
        SerialNumberValObj = new SerialNumber(command.SerialNumber);
        Model = command.Model;
        MaximumTemperatureThreshold = command.MaximumTemperatureThreshold;
        MinimumTemperatureThreshold = command.MinimumTemperatureThreshold;
    }
}