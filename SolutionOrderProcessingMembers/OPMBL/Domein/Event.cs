using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPMBL.Domein {
    public class Event {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public DateTime Date { get; set; }
        public decimal TicketPrice { get; set; }

        public Event(int id, string name, string adress, DateTime date, decimal ticketPrice) {
            Id = id;
            Name = name;
            Adress = adress;
            Date = date;
            TicketPrice = ticketPrice;
        }
    }
}
