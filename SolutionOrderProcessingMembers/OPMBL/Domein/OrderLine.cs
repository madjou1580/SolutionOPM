using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPMBL.Domein {
    public class OrderLine {
    
        public int Quantity { get; set; }
        public decimal PricePerTicket { get; set; }

        public Event Event { get; set; }

        public decimal GetSubtotal() {
            return Quantity * PricePerTicket;
        }

    }
}
