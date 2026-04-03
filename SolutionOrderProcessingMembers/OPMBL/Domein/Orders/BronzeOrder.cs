using OPMBL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPMBL.Domein.Orders {
    public class BronzeOrder : Order {

        public BronzeOrder(Member member, Event @event, IDelivery delivery)
        : base(member, @event, delivery) { }

        public override decimal OrderPrice => Event.TicketPrice + 100m;

        public override List<string> GetProducts() {
            return new List<string>
            {
                $"Ticket voor {Member.Name}",
                $"Naamplaat: {Member.Name}"
            };
        }

        public override string GetDeliveryType() => "Standard";
        public override bool HasWelcomePackage() => false;
        public override bool HasNameTag() => true;
        public override List<string> GetExtraServices() => new List<string>();

    }
}
