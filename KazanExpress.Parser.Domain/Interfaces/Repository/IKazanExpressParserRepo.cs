using System.Threading.Tasks;
using KazanExpress.Parser.Domain.Entities;

namespace KazanExpress.Parser.Domain.Interfaces.Repository
{
    public interface IKazanExpressParserRepo
    {
        public Task AddOrUpdateProducts(ProductEntity[] products);
    }
}