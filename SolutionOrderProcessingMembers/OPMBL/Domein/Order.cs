using OPMBL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPMBL.Domein {
    public class Order {

        public int Id { get; set; }      
        public DateTime OrderDate { get; set; }
        public decimal TicketPrice { get; set; }

        public Member Member { get; set; }
        public List<OrderLine> OrderLines { get; set; } = new();

        public Order(int id, DateTime orderDate, decimal ticketPrice, Member member, IOrderStrategy strategy)
        {
            Id = id;
            OrderDate = orderDate;
            TicketPrice = ticketPrice;
            Member = member;
        }

        public void AddOrderLine(OrderLine line) {
            OrderLines.Add(line);
        }
        
    }
}
