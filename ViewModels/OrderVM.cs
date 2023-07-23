using Fast_Food_online.Models;

namespace Fast_Food_online.ViewModels
{
    public class OrderVM
    {
        public virtual List<OrderItem> Items { get; set; }
        public string Address { get; set; }
        public string CustomerName { set; get; }
        public string CustomerPhone { set; get; }
        public DateTime orderdate { set; get; }
        public double TotalPrice { set; get; }
        public int OrderID { set; get; }
        public string UserId { get; set; }

    }
}
