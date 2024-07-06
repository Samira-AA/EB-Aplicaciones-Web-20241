namespace si730ebu20211a046.API.Inventory.Domain.Model.ValueObjects;

/// <summary>
/// Record for Serial Number
/// </summary>
/// <param name="Value"></param>
/// /// <author>Samira Alvarez Araguache</author>
/// <version>1.0.0</version>
public record SerialNumber (Guid Value)
{
    public SerialNumber(string value) : this(Guid.Parse(value))
    {
    }
}
