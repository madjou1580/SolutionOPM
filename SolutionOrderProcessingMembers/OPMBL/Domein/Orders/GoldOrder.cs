using OPMBL.Domein;
using OPMBL.Interfaces;
using System.Collections.Generic;

namespace OPMBL.Domein.Orders {
    public class GoldOrder : Order {
        public GoldOrder(Member member, Event @event, IDelivery delivery)
            : base(member, @event, delivery) {
        }

        public override decimal OrderPrice => Event.TicketPrice * 3m;

        public override List<string> GetProducts() {
            return new List<string>
            {
                $"Ticket voor {Member.Name}",
                $"Welkomstpakket voor {Member.Name}",
                $"Naamplaat: {Member.Name}",
                $"Uitnodiging diner voor {Member.Name}",
                $"Afhaalservice voor {Member.Name}"
            };
        }

        public override string GetDeliveryType() => "Express";
        public override bool HasWelcomePackage() => true;
        public override bool HasNameTag() => true;
        public override List<string> GetExtraServices() => new List<string> { "Pre-event dinner", "Pickup service" };
    }
}