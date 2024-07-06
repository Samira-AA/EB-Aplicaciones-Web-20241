using EntityFrameworkCore.CreatedUpdatedDate.Contracts;

namespace si730ebu20211a046.API.Observability.Domain.Model.Aggregates;

public partial class ThingState:IEntityWithCreatedUpdatedDate
{
    public DateTimeOffset? CreatedDate { get; set; }
    public DateTimeOffset? UpdatedDate { get; set; }
}
