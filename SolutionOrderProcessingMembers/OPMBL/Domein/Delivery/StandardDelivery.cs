using OPMBL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPMBL.Domein.Delivery {
    public class StandardDelivery : IDelivery {

        public string Deliver(List<string> products) {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Standard delivery:");
            foreach (var p in products) {
                sb.AppendLine($"- {p}");
            }
            return sb.ToString();
        }

    }
}
