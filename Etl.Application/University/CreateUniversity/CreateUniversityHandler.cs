using Etl.Domain.Entities.University;
namespace Etl.Application.Universities.CreateUniversity
{
    public class CreateUniversityHandler
    {
        private readonly IUniversitiesRepository _universitiesRepository;

        public CreateUniversityHandler(IUniversitiesRepository volunteersRepository)
        {
            _universitiesRepository = volunteersRepository;
        }

        public async Task Handle(CreateUniversityRequest[] request,
                                 CancellationToken cancellationToken = default)
        {
            foreach (CreateUniversityRequest resultRequest in request)
            {
                var university = University.Create(
                    UniversityId.NewUniversityId(),
                    resultRequest.Name,
                    resultRequest.Country,
                    resultRequest.WebPages);

                await _universitiesRepository.Add(university, cancellationToken);
                await SaveChanges(cancellationToken);
            }
        }

        public async Task ClearDataBase()
        {
            await _universitiesRepository.ClearDataBase();
        }

        private async Task SaveChanges(CancellationToken cancellationToken = default)
        {
            await _universitiesRepository.SaveChanges(cancellationToken);
        }
    }
}
