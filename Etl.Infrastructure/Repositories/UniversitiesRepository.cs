using Microsoft.EntityFrameworkCore;
using Etl.Domain.Entities.University;
using Etl.Application.UniversityManagment;

namespace Etl.Infrastructure.Repositories
{
    public class UniversitiesRepository : IUniversitiesRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public UniversitiesRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Guid> Add(University university,
                                    CancellationToken cancellationToken = default)
        {
            await _dbContext.Universities.AddAsync(university, cancellationToken);

            return university.Id.Value;
        }

        public async Task ClearDataBase()
        {
            await _dbContext.Universities.ExecuteDeleteAsync();
        }

        public async Task<IReadOnlyList<University>> GetByFilters(
            string name,
            string country)
        {
            return await _dbContext.Universities
                .Where(x => x.Name == name && x.Country == country)
                .ToListAsync();
        }

        public async Task SaveChanges(CancellationToken cancellationToken)
        {
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
