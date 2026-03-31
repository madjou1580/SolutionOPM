using OPMBL.Domein;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPMBL.Managers {
    public class OrderService {

        public Order CreateOrder(Member member, Event event, int quantity) {

            var order = new Order {
                Member = member,
                OrderDate = DateTime.Now,
            };
            
            var line = new OrderLine {
                Event = event,
                Quantity = quantity,
                PricePerTicket = event.TicketPrice
            };

            order.AddOrderLine(line);

            return order;

        }

    }
}
