using EntityFrameworkCore.CreatedUpdatedDate.Contracts;

namespace si730ebu20211a046.API.Inventory.Domain.Model.Aggregates;

/// <summary>
/// Audit entity for Thing
/// </summary>
/// <author>Samira Alvarez Araguache</author>
/// <version>1.0.0</version>
public partial class Thing:IEntityWithCreatedUpdatedDate
{
    public DateTimeOffset? CreatedDate { get; set; }
    public DateTimeOffset? UpdatedDate { get; set; }
}