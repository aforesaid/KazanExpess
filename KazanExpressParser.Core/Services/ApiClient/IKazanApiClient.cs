using System.Threading.Tasks;
using KazanExpressParser.Core.Services.ApiClient.Requests.GetCategories;
using KazanExpressParser.Core.Services.ApiClient.Requests.GetProductsByCategories;

namespace KazanExpressParser.Core.Services.ApiClient
{
    public interface IKazanApiClient
    {
        Task<ApiCategoryItem> GetCategories();
        Task<ApiProductsByCategoriesItem[]> GetProductsByCategoryId(int categoryId);
    }
}