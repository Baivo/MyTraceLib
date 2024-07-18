using MyTraceLib.Tables;
using Newtonsoft.Json;

namespace MyTraceLib.Services
{
    public static class FunctionsService
    {
        private static readonly string FunctionsCode = "jX7ieFKp6eNhVUHzQEUqq4rt7XRczZ-J3etU7jmbEGHVAzFuHhhsYQ==";
        private static readonly string BaseUrl = "https://mytracefunctions.azurewebsites.net/api/";

        private static readonly Dictionary<string, string> FunctionUrls = new Dictionary<string, string>
        {
            { nameof(RequestProductByBarcodeAsync), "RequestProductByBarcode" },
            { nameof(GetSimilarProductsAsync), "GetSimilarProducts" },
            { nameof(GetColesProductPageAsync), "GetColesProductPage" },
            { nameof(GetColesBrandPageAsync), "GetColesBrandPage" },
            { nameof(GetCostcoProductPageAsync), "GetCostcoProductPage" },
            { nameof(GetCostcoBrandPageAsync), "GetCostcoBrandPage" },
        };

        private static string GetFunctionUrl(string functionName, string parameters = "")
        {
            if (FunctionUrls.TryGetValue(functionName, out string functionPath))
            {
                return $"{BaseUrl}{functionPath}?code={FunctionsCode}{parameters}";
            }
            throw new InvalidOperationException($"Function URL for {functionName} not found.");
        }

        public static async Task<WoolworthsProduct?> RequestProductByBarcodeAsync(string barcode)
        {
            using (HttpClient client = new HttpClient())
            {
                string functionUrl = GetFunctionUrl(nameof(RequestProductByBarcodeAsync), $"&barcode={barcode}");
                HttpResponseMessage response = await client.GetAsync(functionUrl);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();

                    if (content.Contains("Product not found"))
                    {
                        return null;
                    }

                    WoolworthsProduct? product = JsonConvert.DeserializeObject<WoolworthsProduct>(content);
                    return product;
                }
                else
                {
                    PrintService.PrintFailure($"RequestProductByBarcode failed with status code: {response.StatusCode}");
                    return null;
                }
            }
        }

        public static async Task<List<WoolworthsProduct>> GetSimilarProductsAsync(string barcode)
        {
            using (HttpClient client = new HttpClient())
            {
                string functionUrl = GetFunctionUrl(nameof(GetSimilarProductsAsync), $"&barcode={barcode}");
                HttpResponseMessage response = await client.GetAsync(functionUrl);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();

                    if (content.Contains("Product not found") || content.Contains("No matching products found"))
                    {
                        return new List<WoolworthsProduct>();
                    }

                    List<WoolworthsProduct> matchingProducts = JsonConvert.DeserializeObject<List<WoolworthsProduct>>(content);
                    return matchingProducts;
                }
                else
                {
                    PrintService.PrintFailure($"{functionUrl} failed with status code: {response.StatusCode}");
                    return new List<WoolworthsProduct>();
                }
            }
        }

        public static async Task<ColesProductResponsePage?> GetColesProductPageAsync(int offset)
        {
            using (HttpClient client = new HttpClient())
            {
                string functionUrl = GetFunctionUrl(nameof(GetColesProductPageAsync), $"&offset={offset}");
                HttpResponseMessage response = await client.GetAsync(functionUrl);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<ColesProductResponsePage>(content);
                }
                else
                {
                    PrintService.PrintFailure($"{functionUrl} failed with status code: {response.StatusCode}");
                    return null;
                }
            }
        }

        public static async Task<ColesBrandResponsePage?> GetColesBrandPageAsync(int offset)
        {
            using (HttpClient client = new HttpClient())
            {
                string functionUrl = GetFunctionUrl(nameof(GetColesBrandPageAsync), $"&offset={offset}");
                HttpResponseMessage response = await client.GetAsync(functionUrl);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<ColesBrandResponsePage>(content);
                }
                else
                {
                    PrintService.PrintFailure($"{functionUrl} failed with status code: {response.StatusCode}");
                    return null;
                }
            }
        }
        public static async Task<CostcoProductResponsePage?> GetCostcoProductPageAsync(int offset)
        {
            using (HttpClient client = new HttpClient())
            {
                string functionUrl = GetFunctionUrl(nameof(GetCostcoProductPageAsync), $"&offset={offset}");
                HttpResponseMessage response = await client.GetAsync(functionUrl);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<CostcoProductResponsePage>(content);
                }
                else
                {
                    PrintService.PrintFailure($"{functionUrl} failed with status code: {response.StatusCode}");
                    return null;
                }
            }
        }

        public static async Task<CostcoBrandResponsePage?> GetCostcoBrandPageAsync(int offset)
        {
            using (HttpClient client = new HttpClient())
            {
                string functionUrl = GetFunctionUrl(nameof(GetCostcoBrandPageAsync), $"&offset={offset}");
                HttpResponseMessage response = await client.GetAsync(functionUrl);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<CostcoBrandResponsePage>(content);
                }
                else
                {
                    PrintService.PrintFailure($"{functionUrl} failed with status code: {response.StatusCode}");
                    return null;
                }
            }
        }
    }
}
