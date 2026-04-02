using OPMBL.Domein;
using OPMBL.Domein.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPMBL.Interfaces {
    public interface IRepository {

        List<Member> GetMembers();
        Member MemberLogin(string email);
        List<Event> GetEvents();

        void SaveOrder(Order order);
        void SaveDelivery(DeliveryInfo delivery);

        List<Order> GetOrders();
        List<DeliveryInfo> GetDeliveries();

        //decimal CalculatePrice(decimal basePrice);
        //string GetDeliveryType();
        //bool HasWelcomePackage();
        //bool HasNameTag();
        //List<string> GetServices();

    }
}
