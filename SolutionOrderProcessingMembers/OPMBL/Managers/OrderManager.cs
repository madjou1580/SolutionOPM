using OPMBL.Domein;
using OPMBL.Domein.Orders;
using OPMBL.Interfaces;
using System.Collections.Generic;

namespace OPMBL.Managers {
    public class OrderManager {
        private readonly IRepository _repository;

        public OrderManager(IRepository repository) {
            _repository = repository;
        }

        public Member Login(string email) => _repository.MemberLogin(email);

        public List<Event> GetEvents() => _repository.GetEvents();

        public List<Member> GetMembers() => _repository.GetMembers();

        public List<Order> GetOrders() => _repository.GetOrders();

        public List<DeliveryInfo> GetDeliveries() => _repository.GetDeliveries();

        public (Order order, DeliveryInfo delivery, decimal total) CreateOrder(Member member, Event @event) {
            Order order = OrderFactory.CreateOrder(member, @event);
            DeliveryInfo delivery = new DeliveryInfo(_repository.GetDeliveries().Count + 1, order);

            _repository.SaveOrder(order);
            _repository.SaveDelivery(delivery);

            return (order, delivery, order.OrderPrice);
        }
    }
}