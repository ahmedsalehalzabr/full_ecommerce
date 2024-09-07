namespace full_ecommerce.Data.Models
{
    public class BasketItem
    {
        public Guid Id { get; set; } // مفتاح فريد
        public Guid BasketId { get; set; } // ربط السلة
        public Basket Basket { get; set; } // السلة المرتبطة
        public Guid ItemId { get; set; } // ربط العنصر
        public Item Item { get; set; } // العنصر المرتبط
        public int Quantity { get; set; } // الكمية
    }

}
