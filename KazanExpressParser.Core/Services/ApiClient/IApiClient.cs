using System.Threading.Tasks;
using KazanExpressParser.Core.Services.ApiClient.Requests.GetCategories;

namespace KazanExpressParser.Core.Services.ApiClient
{
    public interface IApiClient
    {
        Task<ApiCategoryItem> GetCategories();
    }
}