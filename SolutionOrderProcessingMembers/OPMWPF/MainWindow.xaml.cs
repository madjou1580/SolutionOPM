using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using OPMBL.Domein;
using OPMBL.Managers;
using OPMDL;

namespace OPMWPF {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        private readonly MockRepository _repository;
        private readonly OrderManager _manager;
        private Member _loggedInMember;

        public MainWindow() {
            InitializeComponent();

            _repository = new MockRepository();
            _manager = new OrderManager(_repository);

            lstEvents.ItemsSource = _manager.GetEvents();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e) {
            string email = txtEmail.Text.Trim();

            if (string.IsNullOrWhiteSpace(email)) {
                MessageBox.Show("Geef een email in.");
                return;
            }

            _loggedInMember = _manager.Login(email);

            if (_loggedInMember == null) {
                MessageBox.Show("Lid niet gevonden.");
                txtMemberInfo.Text = "Geen lid ingelogd.";
                return;
            }

            txtMemberInfo.Text = $"Naam: {_loggedInMember.Name}\n" +
                                 $"Email: {_loggedInMember.Email}\n" +
                                 $"Adres: {_loggedInMember.Address}\n" +
                                 $"Status: {_loggedInMember.Status}";
        }

        private void btnCreateOrder_Click(object sender, RoutedEventArgs e) {
            if (_loggedInMember == null) {
                MessageBox.Show("Log eerst in.");
                return;
            }

            if (lstEvents.SelectedItem == null) {
                MessageBox.Show("Kies eerst een event.");
                return;
            }

            Event selectedEvent = (Event)lstEvents.SelectedItem;

            var (order, delivery, total) = _manager.CreateOrder(_loggedInMember, selectedEvent);

            txtPrice.Text = $"Totaal prijs: €{total}";
            txtDeliveryType.Text = $"Leveringstype: {delivery.DeliveryType}";
            txtWelcomePackage.Text = $"Welkomstpakket: {(delivery.IncludesWelcomePackage ? "Ja" : "Nee")}";
            txtNameTag.Text = $"Naamplaat: {(delivery.IncludesNameTag ? "Ja" : "Nee")}";

            txtExtraServices.Text = delivery.ExtraServices.Any()
                ? $"Extra services: {string.Join(", ", delivery.ExtraServices)}"
                : "Extra services: Geen";

            lstProducts.ItemsSource = null;
            lstProducts.ItemsSource = order.GetProducts();

            string deliveryMessage = order.ProcessOrder();
            MessageBox.Show(deliveryMessage, "Delivery Processing");

            MessageBox.Show("Bestelling succesvol aangemaakt.");
        }

        private void btnControl_Click(object sender, RoutedEventArgs e) {
            ControlWindow controlWindow = new ControlWindow(_manager);
            controlWindow.ShowDialog();
        }

    }
}