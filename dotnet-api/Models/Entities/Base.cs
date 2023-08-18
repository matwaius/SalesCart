namespace dotnet_api.Models.Entities
{
    public class Base
    {
        public int id { get; set; }
    }

    public class Base_Order_Product
    {
        public int orderID { get; set; }
        public int productID { get; set; }
    }
}
