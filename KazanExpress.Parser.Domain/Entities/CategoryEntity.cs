using System.ComponentModel.DataAnnotations;

namespace KazanExpress.Parser.Domain.Entities
{
    public class CategoryEntity : Entity
    {
        private const int ProductIdsLength = 40;

        public CategoryEntity(long categoryId, long productAmount, bool adult, bool eco, string title, string productIds)
        {
            Id = categoryId;
            ProductAmount = productAmount;
            Adult = adult;
            Eco = eco;
            Title = title;
            ProductIds = productIds;
        }
        public long ProductAmount { get; private set; }
        
        public bool Adult { get; private set; }
        
        public bool Eco { get; private set; }
        
        public string Title { get; private set; }
        
        [StringLength(ProductIdsLength)]
        public string ProductIds { get; set; }

        public void UpdateProductAmount(long productAmount)
        {
            ProductAmount = productAmount;
            SetUpdated();
        }
    }
}