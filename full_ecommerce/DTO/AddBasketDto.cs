namespace full_ecommerce.DTO
{
    public class AddBasketDto
    {
       
         // قائمة معرفات العناصر التي يتم إضافتها إلى السلة
        public Guid UserId { get; set; }  // معرف المستخدم
        public Guid ItemId { get; set; }  // معرف العنصر
        public string Title { get; set; }  // عنوان العنصر
        public decimal Price { get; set; }  // سعر العنصر
        public int Quantity { get; set; }

    }
}
