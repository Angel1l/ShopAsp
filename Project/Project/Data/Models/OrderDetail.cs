namespace Project.Data.Models
{
    public class OrderDetail
    {
        public int id { get; set; }
        public int orderID { get; set; }
        public int GunsID { get; set; }
        public int price { get; set; }      
        public virtual Guns guns { get; set; }
        public virtual Order order { get; set; }

    }
}
