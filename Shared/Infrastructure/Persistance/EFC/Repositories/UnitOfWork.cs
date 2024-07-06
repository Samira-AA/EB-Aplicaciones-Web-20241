using si730ebu20211a046.API.Shared.Domain.Repositories;
using si730ebu20211a046.API.Shared.Infrastructure.Persistance.EFC.Configuration;

namespace si730ebu20211a046.API.Shared.Infrastructure.Persistance.EFC.Repositories;

public class UnitOfWork(AppDbContext context) : IUnitOfWork
{

    public async Task CompleteAsync() => await context.SaveChangesAsync();
    
}