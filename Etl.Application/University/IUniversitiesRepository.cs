using Etl.Domain.Entities.University;

namespace Etl.Application.Universities
{
    public interface IUniversitiesRepository
    {
        Task<Guid> Add(University university, CancellationToken cancellationToken = default);
        Task ClearDataBase();
        Task SaveChanges(CancellationToken cancellationToken);
    }
}
