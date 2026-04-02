using OPMBL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPMBL.Domein.Orders {
    public class SilverOrder : Order {

        public SilverOrder(Member member, Event @event, IDelivery delivery)
        : base(member, @event, delivery) { }

        public override decimal OrderPrice => Event.TicketPrice * 2m;

        public override List<string> GetProducts() {
            return new List<string>
            {
                $"Ticket voor {Member.Name}",
                $"Welkomstpakket voor {Member.Name}",
                $"Naamplaat: {Member.Name}",
                $"Uitnodiging diner voor {Member.Name}"
            };
        }

        public override string GetDeliveryType() => "Express";
        public override bool HasWelcomePackage() => true;
        public override bool HasNameTag() => true;
        public override List<string> GetExtraServices() => new List<string> { "Pre-event dinner" };

    }
}
