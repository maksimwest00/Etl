using Etl.API.Controllers;
using Etl.Application.UniversityManagment.CreateUniversity;

namespace Etl.API.Services
{
    public class UploadService
    {
        private static string[] Countries =
        [
            "Russian Federation",
            "Norway",
            "Finland",
            "Estonia",
            "Latvia",
            "Lithuania",
            "Poland",
            "Belarus",
            "Kazakhstan",
            "Georgia"
        ];

        private SemaphoreSlim _semaphoreSlim;

        private HttpClient _httpClient;

        private readonly ILogger<UniversityController> _logger;

        public UploadService(
            ILogger<UniversityController> logger,
            HttpClient httpClient,
            int countThreads)
        {
            _logger = logger;
            _httpClient = httpClient;
            if (countThreads > 0)
            {
                _semaphoreSlim = new SemaphoreSlim(countThreads);
            }
            else
            {
                _semaphoreSlim = new SemaphoreSlim(1);
            }
        }

        public async Task<bool> Upload(
            CreateUniversityHandler handler,
            CancellationToken cancellationToken = default)
        {
            bool success = true;

            await handler.ClearDataBase();
            List<string> urls = new List<string>();
            foreach (string country in Countries)
            {
                var tmpUrl = $"http://universities.hipolabs.com/search?country={country}";
                urls.Add(tmpUrl);
            }
            Task<CreateUniversityRequest[]?>[] tasks = new Task<CreateUniversityRequest[]?>[urls.Count];
            for (int i = 0; i < urls.Count; i++)
            {
                tasks[i] = LoadDataAsync(handler, urls[i], cancellationToken);
            }
            var results = await Task.WhenAll(tasks);
            foreach (CreateUniversityRequest[]? result in results)
            {
                if (result != null)
                {
                    await handler.Handle(result, cancellationToken);
                }
                else
                {
                    success = false;
                }
            }

            return success;
        }

        private async Task<CreateUniversityRequest[]?> LoadDataAsync(
            CreateUniversityHandler handler,
            string url,
            CancellationToken cancellationToken = default)
        {
            await _semaphoreSlim.WaitAsync(cancellationToken);

            _logger.Log(LogLevel.Information, $"Начинаем загрузку данных с {url}...");
            CreateUniversityRequest[]? response = await _httpClient.GetFromJsonAsync<CreateUniversityRequest[]>(url);
            _logger.Log(LogLevel.Information, $"Загрузка с {url} завершена.");

            _semaphoreSlim.Release();

            return response;
        }
    }
}
