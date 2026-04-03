using OPMBL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPMBL.Domein.Delivery {
    public class ExpressDelivery : IDelivery {
        public string Deliver(List<string> products) {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Express delivery:");
            foreach (var p in products) {
                sb.AppendLine($"- {p}");
            }
            return sb.ToString();
        }
    }
}
