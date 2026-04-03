using OPMBL.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace OPMWPF {
    /// <summary>
    /// Interaction logic for ControlWindow.xaml
    /// </summary>
    public partial class ControlWindow : Window {
        private readonly OrderManager _manager;

        public ControlWindow(OrderManager manager) {
            InitializeComponent();
            _manager = manager;
            LoadData();
        }

        private void LoadData() {
            dgMembers.ItemsSource = _manager.GetMembers();
            dgEvents.ItemsSource = _manager.GetEvents();

            dgOrders.ItemsSource = _manager.GetOrders()
                .Select(o => new {
                    Member = o.Member.Name,
                    Status = o.Member.Status,
                    Event = o.Event.Name,
                    Price = o.OrderPrice
                })
                .ToList();

            dgDeliveries.ItemsSource = _manager.GetDeliveries()
                .Select(d => new {
                    d.Id,
                    Member = d.Order.Member.Name,
                    Event = d.Order.Event.Name,
                    d.DeliveryType,
                    d.IncludesWelcomePackage,
                    d.IncludesNameTag,
                    ExtraServices = string.Join(", ", d.ExtraServices)
                })
                .ToList();
        }
    }
}
