namespace si730ebu20211a046.API.Shared.Domain.Repositories;

public interface IUnitOfWork
{
    Task CompleteAsync();
}