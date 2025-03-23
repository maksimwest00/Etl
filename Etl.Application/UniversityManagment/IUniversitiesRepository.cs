using Etl.Domain.Entities.University;

namespace Etl.Application.UniversityManagment
{
    public interface IUniversitiesRepository
    {
        Task<Guid> Add(University university, CancellationToken cancellationToken = default);
        Task ClearDataBase();
        Task SaveChanges(CancellationToken cancellationToken);
        Task<IReadOnlyList<University>> GetByFilters(string name,
                                                     string country);
    }
}
