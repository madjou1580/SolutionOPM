using OPMBL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPMBL.Domein.Delivery {
    public class StandardDelivery : IDelivery {

        public void Deliver(List<string> products) {
            Console.WriteLine("Standard delivery:");
            foreach (var p in products) Console.WriteLine(p);
        }

    }
}
