using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPMBL.Domein {
    public class Delivery {

        public int Id { get; set; }   
        public string DeliveryType { get; set; }
        public bool IncludesWelcomePackage { get; set; }
        public bool IncludesNameTag { get; set; }
        public List<string> ExtraServices { get; set; }

        public Order Order { get; set; }
<<<<<<< Updated upstream
=======

        public Delivery(int id, Order order, IOrderRepository strategy)
        {
            Id = id;
            Order = order;
            DeliveryType = strategy.GetDeliveryType();
            IncludesWelcomePackage = strategy.HasWelcomePackage();
            IncludesNameTag = strategy.HasNameTag();
            ExtraServices = strategy.GetServices();
        }
>>>>>>> Stashed changes
    }
}
