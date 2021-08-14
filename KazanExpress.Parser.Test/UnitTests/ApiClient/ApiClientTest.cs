using System.Linq;
using System.Threading.Tasks;
using KazanExpressParser.Core.Services.ApiClient;
using Xunit;

namespace KazanExpress.Parser.Test.UnitTests.ApiClient
{
    public class ApiClientTest
    {
        private readonly IKazanApiClient _apiClient;
        public ApiClientTest()
        {
            _apiClient = new KazanApiClient();
        }

        [Fact]
        public async Task GetCategories()
        {
            var response = await _apiClient.GetCategories();
           
            Assert.NotEmpty(response.Children);
            Assert.NotNull(response);
        }

        [Fact]
        public async Task GetProductsByCategory()
        {
            const int categoryId = 1;

            var response = await _apiClient.GetProductsByCategoryId(categoryId, 10);
            
            Assert.NotEmpty(response);
            Assert.NotEmpty(response.First().Badges);
            Assert.NotNull(response.First().Offer);
        }
    }
}