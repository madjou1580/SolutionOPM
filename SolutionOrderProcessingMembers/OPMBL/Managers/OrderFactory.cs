using OPMBL.Domein;
using OPMBL.Domein.Delivery;
using OPMBL.Domein.Orders;
using OPMBL.Enums;
using OPMBL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPMBL.Managers {
    public static class OrderFactory {

        public static Order CreateOrder(Member member, Event @event) {
            IDelivery delivery = member.Status switch {
                MemberStatus.Gold => new ExpressDelivery(),
                MemberStatus.Silver => new ExpressDelivery(),
                MemberStatus.Bronze => new StandardDelivery(),
                _ => new StandardDelivery()
            };

            return member.Status switch {
                MemberStatus.Gold => new GoldOrder(member, @event, delivery),
                MemberStatus.Silver => new SilverOrder(member, @event, delivery),
                MemberStatus.Bronze => new BronzeOrder(member, @event, delivery),
                _ => new StandardOrder(member, @event, delivery)
            };
        }

    }
}
