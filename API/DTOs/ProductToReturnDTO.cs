namespace API.DTOs
{
    public class ProductToReturnDTO
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string PictureUrl { get; set; }

        public string ProductBrand {get;set;}

        public string ProductType {get;set;}
    }
}