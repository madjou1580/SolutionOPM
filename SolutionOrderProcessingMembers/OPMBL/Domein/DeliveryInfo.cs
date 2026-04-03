using OPMBL.Domein.Orders;
using System.Collections.Generic;

namespace OPMBL.Domein {
    public class DeliveryInfo {
        public int Id { get; set; }
        public string DeliveryType { get; set; }
        public bool IncludesWelcomePackage { get; set; }
        public bool IncludesNameTag { get; set; }
        public List<string> ExtraServices { get; set; }

        public Order Order { get; set; }

        public DeliveryInfo(int id, Order order) {
            Id = id;
            Order = order;
            DeliveryType = order.GetDeliveryType();
            IncludesWelcomePackage = order.HasWelcomePackage();
            IncludesNameTag = order.HasNameTag();
            ExtraServices = order.GetExtraServices();
        }
    }
}