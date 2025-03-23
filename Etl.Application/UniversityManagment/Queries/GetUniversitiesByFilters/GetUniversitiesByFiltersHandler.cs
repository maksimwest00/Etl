using Etl.Domain.Entities.University;

namespace Etl.Application.UniversityManagment.Queries.GetUniversitiesByFilters
{
    public record GetUniversitiesByFiltersResponse(string name, string country, string stie);

    public class GetUniversitiesByFiltersHandler
    {
        private readonly IUniversitiesRepository _universitiesRepository;

        public GetUniversitiesByFiltersHandler(
            IUniversitiesRepository universitiesRepository)
        {
            _universitiesRepository = universitiesRepository;
        }

        public async Task<IReadOnlyList<GetUniversitiesByFiltersResponse>> Handle(
            string name,
            string country,
            CancellationToken cancellationToken = default)
        {
            var universities = await _universitiesRepository.GetByFilters(name, country);
            return universities.Select(u => new GetUniversitiesByFiltersResponse(u.Name, u.Country, u.Site)).ToList();
        }
    }
}
