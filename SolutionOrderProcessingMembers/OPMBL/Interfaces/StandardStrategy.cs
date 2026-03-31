using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPMBL.Interfaces {
    public class StandardStrategy : IOrderStrategy {

        public decimal CalculatePrice(decimal basePrice) => basePrice;

        public string GetDeliveryType() => "Standard";

        public bool HasWelcomePackage() => false;

        public bool HasNameTag() => false;

        public List<string> GetServices() {
            return new List<string>();
        }

    }
}
