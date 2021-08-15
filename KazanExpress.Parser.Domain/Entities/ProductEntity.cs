using System.ComponentModel.DataAnnotations;

namespace KazanExpress.Parser.Domain.Entities
{
    public class ProductEntity : Entity
    {
        private const int TitleLength = 1024;
        private const int CategoryNameLength = 1024;

        private ProductEntity()
        { }
        public ProductEntity(long productId, 
            string title,
            long sellPrice, 
            long fullPrice, 
            double rating, 
            long ordersQuantity, 
            long rOrdersQuantity, 
            long charityCommission,
            bool isEco,
            string categoryName)
        {
            Id = productId;
            Title = title;
            SellPrice = sellPrice;
            FullPrice = fullPrice;
            Rating = rating;
            OrdersQuantity = ordersQuantity;
            ROrdersQuantity = rOrdersQuantity;
            CharityCommission = charityCommission;
            IsEco = isEco;
            CategoryName = categoryName;
        }

        [StringLength(TitleLength)]
        public string Title { get; private set; }

        public long SellPrice { get; private set; }

        public long FullPrice { get; private set; }
        public string CategoryName { get; private set; }

        public double Rating { get;  private set; }

        public long OrdersQuantity { get; private set; }

        public long ROrdersQuantity { get; private set; }

        public long CharityCommission { get; private set; }

        public bool IsEco { get; private set; }

        public void UpdateSellPrice(long sellPrice)
        {
            SellPrice = sellPrice;
            SetUpdated();
        }

        public void UpdateRating(double rating)
        {
            Rating = rating;
            SetUpdated();
        }

        public void UpdateOrdersQuantity(long ordersQty)
        {
            OrdersQuantity = ordersQty;
            SetUpdated();
        }

        public void UpdateROrdersQuantity(long rOrdersQty)
        {
            ROrdersQuantity = rOrdersQty;
            SetUpdated();
        }
    }
}