using MyTraceLib.Tables;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace MyTraceLib.Services
{
    public class CostcoApiService
    {
        private static string _apiKey { get; set; } = "caBZhTkDXtH0cKNQs4zqF7kFJeuy36nFrcL8OsEfpxt98";
        private static int maxConcurrency = 100;
        public CostcoApiService(string apiKey = "caBZhTkDXtH0cKNQs4zqF7kFJeuy36nFrcL8OsEfpxt98")
        {
            _apiKey = apiKey;
        }

        private static async Task<CostcoProductResponsePage?> GetProductPageAsync(int offset = 0)
        {
            using var client = new HttpClient();
            string requestUri = $"https://api.bazaarvoice.com/data/products.json?passkey={_apiKey}&locale=en_AU&allowMissing=true&apiVersion=5.4&limit=100&offset={offset}";
            var response = await client.GetAsync(requestUri);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            //PrintService.PrintInfo(responseBody);
            return JsonConvert.DeserializeObject<CostcoProductResponsePage>(responseBody);
        }

        public static async Task<List<CostcoProduct>> GetAllCostcoProductsAsync(int initialOffset = 0)
        {
            var initialResponse = await GetProductPageAsync(initialOffset);
            if (initialResponse == null || initialResponse.Results == null)
                throw new InvalidOperationException("Failed to fetch initial data from API.");

            int totalResults = initialResponse.TotalResults;
            PrintService.PrintInfo($"Starting product data fetch: {totalResults} total items to retrieve.");

            List<CostcoProductResult> allResults = new List<CostcoProductResult>(initialResponse.Results);
            List<Task<CostcoProductResponsePage?>> tasks = new List<Task<CostcoProductResponsePage?>>();

            for (int offset = initialResponse.Limit; offset < totalResults; offset += initialResponse.Limit * maxConcurrency)
            {
                tasks.Clear();
                for (int i = 0; i < maxConcurrency && offset + i * initialResponse.Limit < totalResults; i++)
                {
                    int currentOffset = offset + i * initialResponse.Limit;
                    tasks.Add(GetProductPageAsync(currentOffset));
                }

                var responses = await Task.WhenAll(tasks);
                foreach (var response in responses)
                {
                    if (response?.Results != null)
                    {
                        allResults.AddRange(response.Results);
                    }
                }
                PrintService.PrintInfo($"Fetched {allResults.Count} of {totalResults} products");
            }
            List<CostcoProduct> products = new List<CostcoProduct>();
            foreach (var productResult in allResults)
            {
                var entity = new CostcoProduct
                {
                    CostcoProductId = productResult.Id ?? Guid.NewGuid().ToString(),
                    Name = productResult.Name,
                    Active = productResult.Active,
                    StockCode = productResult.Id,
                    Brand = productResult.Brand?.Name,
                    BrandExternalId = productResult.BrandExternalId,
                    EANs = productResult.EANs?.ToArray(),
                    ManufacturerPartNumbers = productResult.ManufacturerPartNumbers?.ToArray(),
                    UPCs = productResult.UPCs?.ToArray(),
                    ImageUrl = productResult.ImageUrl,
                    ProductPageUrl = productResult.ProductPageUrl
                };

                products.Add(entity);
            }
            return products;
        }

        private static async Task<CostcoBrandResponsePage?> GetBrandPageAsync(int offset = 0)
        {
            using var client = new HttpClient();
            string requestUri = $"https://api.bazaarvoice.com/data/brands.json?passkey={_apiKey}&locale=en_AU&allowMissing=true&apiVersion=5.4&limit=100&offset={offset}";
            var response = await client.GetAsync(requestUri);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<CostcoBrandResponsePage>(responseBody);
        }

        public static async Task<List<CostcoBrand>> GetAllCostcoBrandsAsync()
        {
            int initialOffset = 0;
            var initialResponse = await GetBrandPageAsync(initialOffset);
            if (initialResponse == null || initialResponse.Results == null || initialResponse.Results.Length == 0)
                throw new InvalidOperationException("Failed to fetch initial data from API.");

            int totalResults = initialResponse.TotalResults;
            PrintService.PrintInfo($"Starting brand data fetch: {totalResults} total items to retrieve.");

            List<CostcoBrandResult> allResults = new List<CostcoBrandResult>(initialResponse.Results);
            List<Task<CostcoBrandResponsePage?>> tasks = new List<Task<CostcoBrandResponsePage?>>();

            for (int offset = initialResponse.Limit; offset < totalResults; offset += initialResponse.Limit * maxConcurrency)
            {
                tasks.Clear();
                for (int i = 0; i < maxConcurrency && offset + i * initialResponse.Limit < totalResults; i++)
                {
                    int currentOffset = offset + i * initialResponse.Limit;
                    tasks.Add(GetBrandPageAsync(currentOffset));
                }

                var responses = await Task.WhenAll(tasks);
                foreach (var response in responses)
                {
                    if (response?.Results != null)
                    {
                        allResults.AddRange(response.Results);
                        PrintService.PrintInfo($"Fetched {allResults.Count} of {totalResults} brands");
                    }
                }
            }
            List<CostcoBrand> brands = new List<CostcoBrand>();
            foreach (var brandResult in allResults)
            {
                var entity = new CostcoBrand
                {
                    CostcoBrandId = brandResult.Id ?? Guid.NewGuid().ToString(),
                    Name = brandResult.Name,
                    InternalId = brandResult.Id ?? "NoID"
                };
                brands.Add(entity);
            }
            return brands;
        }
    }
}
