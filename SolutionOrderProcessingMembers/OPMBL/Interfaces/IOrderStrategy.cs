using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPMBL.Interfaces {
    public interface IOrderStrategy {

        decimal CalculatePrice(decimal basePrice);
        string GetDeliveryType();
        bool HasWelcomePackage();
        bool HasNameTag();
        List<string> GetServices();

    }
}
