namespace KazanExpressParser.Core.Services.ApiClient
{
    public class ApiClientEndpoints
    {
        public const string BaseAddress = "https://api.kazanexpress.ru/api/";

        public const string GetCategories = "v2/main/search/category";

        public static string GetProductsByCategories(long categoryId, int page = 1, int sizeCount = 100)
        {
            return $"v2/main/search/product?size={sizeCount}&page={page}&&categoryId={categoryId}";
        }
    }
}