using OPMBL.Domein;
using OPMBL.Domein.Orders;
using OPMBL.Enums;
using OPMBL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OPMDL {
    public class MockRepository : IRepository {
        private List<Order> orders = new();
        private List<DeliveryInfo> deliveries = new();

        public List<Member> Members { get; set; } = new List<Member>
        {
            new Member(1, "Alice", "alice@test.be", "Gent", MemberStatus.Standard),
            new Member(2, "Bob", "bob@test.be", "Antwerp", MemberStatus.Bronze),
            new Member(3, "Tom", "tom@test.be", "Brussel", MemberStatus.Silver),
            new Member(4, "Lisa", "lisa@test.be", "Leuven", MemberStatus.Gold)
        };

        public List<Event> Events { get; set; } = new List<Event>
        {
            new Event(1, "Rock Concert", "Gent", new DateTime(2026, 5, 4), 45m),
            new Event(2, "Gala", "Antwerp", new DateTime(2026, 6, 30), 80m),
            new Event(3, "Business Dinner", "Brussel", new DateTime(2026, 9, 12), 120m)
        };

        public List<Member> GetMembers() => Members;

        public Member MemberLogin(string email) {
            return Members.FirstOrDefault(m => m.Email.ToLower() == email.ToLower());
        }

        public List<Event> GetEvents() => Events;

        public void SaveOrder(Order order) => orders.Add(order);

        public void SaveDelivery(DeliveryInfo delivery) => deliveries.Add(delivery);

        public List<Order> GetOrders() => orders;

        public List<DeliveryInfo> GetDeliveries() => deliveries;
    }
}