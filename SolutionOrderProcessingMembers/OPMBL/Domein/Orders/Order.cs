using OPMBL.Domein;
using OPMBL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPMBL.Domein.Orders {
    public abstract class Order {

        public Member Member { get; }
        public Event Event { get; }

        protected IDelivery DeliveryMethod { get; set; }

        protected Order(Member member, Event @event, IDelivery delivery) {
            Member = member;
            Event = @event;
            DeliveryMethod = delivery;
        }

        public abstract decimal OrderPrice { get; }
        public abstract List<string> GetProducts();
        public abstract string GetDeliveryType();
        public abstract bool HasWelcomePackage();
        public abstract bool HasNameTag();
        public abstract List<string> GetExtraServices();

        public virtual void ProcessOrder() {
            DeliveryMethod.Deliver(GetProducts());
        }

    }
}
