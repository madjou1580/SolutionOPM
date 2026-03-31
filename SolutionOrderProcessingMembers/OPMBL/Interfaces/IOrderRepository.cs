using OPMBL.Domein;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPMBL.Interfaces {
    public interface IOrderRepository {

        List<Event> GetEvents();
        Member MemberLogin(string username);

        //decimal CalculatePrice(decimal basePrice);
        //string GetDeliveryType();
        //bool HasWelcomePackage();
        //bool HasNameTag();
        //List<string> GetServices();

    }
}
