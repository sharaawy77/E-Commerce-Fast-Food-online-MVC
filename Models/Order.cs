using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fast_Food_online.Models
{
    public class Order
    {
        [Key]
        [BindNever]
        public int Id { get; set; }
        public virtual List<OrderItem> Items { get; set;}
        public string Address { get;set; }
        public string CustomerName { set; get; }
        public string CustomerPhone { set; get; }
        [BindNever]
        public DateTime orderdate { set; get; }
        [BindNever]
        public double OrderTotal { set; get; }
    }
}
