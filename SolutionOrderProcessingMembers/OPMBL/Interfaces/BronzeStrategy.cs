using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPMBL.Interfaces {
    public class BronzeStrategy : IOrderStrategy{

        public decimal CalculatePrice(decimal basePrice) => basePrice + 100;

        public string GetDeliveryType() => "Standard";

        public bool HasWelcomePackage() => false;

        public bool HasNameTag() => true;

        public List<string> GetServices() {
            return new List<string>();
        }

    }
}
