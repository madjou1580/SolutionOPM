using OPMBL.Domein;
using OPMBL.Managers;
using OPMDL;
using System;

namespace OPMUI {
    internal class Program {
        static void Main(string[] args) {
            MockRepository repo = new MockRepository();
            OrderManager manager = new OrderManager(repo);

            bool running = true;

            while (running) {
                Console.Clear();
                Console.WriteLine("======================================");
                Console.WriteLine(" ORDER PROCESSING MEMBERS SYSTEM");
                Console.WriteLine("======================================");
                Console.WriteLine("1. Login en event inschrijving");
                Console.WriteLine("2. Controle scherm");
                Console.WriteLine("0. Afsluiten");
                Console.Write("Maak een keuze: ");

                string choice = Console.ReadLine();

                switch (choice) {
                    case "1":
                        LoginAndCreateOrder(manager);
                        break;
                    case "2":
                        ShowControlScreen(manager);
                        break;
                    case "0":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Ongeldige keuze.");
                        Pause();
                        break;
                }
            }
        }

        static void LoginAndCreateOrder(OrderManager manager) {
            Console.Clear();
            Console.WriteLine("=== LOGIN ===");
            Console.Write("Geef je email in: ");
            string email = Console.ReadLine();

            Member member = manager.Login(email);

            if (member == null) {
                Console.WriteLine("Lid niet gevonden.");
                Pause();
                return;
            }

            Console.WriteLine($"\nWelkom {member.Name} ({member.Status})");
            Console.WriteLine("\n=== EVENTS ===");

            var events = manager.GetEvents();
            for (int i = 0; i < events.Count; i++) {
                Console.WriteLine($"{i + 1}. {events[i].Name} - {events[i].Address} - {events[i].Date.ToShortDateString()} - €{events[i].TicketPrice}");
            }

            Console.Write("\nKies een eventnummer: ");
            if (!int.TryParse(Console.ReadLine(), out int eventChoice)) {
                Console.WriteLine("Ongeldige invoer.");
                Pause();
                return;
            }

            eventChoice--;

            if (eventChoice < 0 || eventChoice >= events.Count) {
                Console.WriteLine("Ongeldige keuze.");
                Pause();
                return;
            }

            Event selectedEvent = events[eventChoice];

            var (order, delivery, total) = manager.CreateOrder(member, selectedEvent);

            Console.WriteLine("\n=== BESTELLING ===");
            Console.WriteLine($"Lid: {member.Name}");
            Console.WriteLine($"Status: {member.Status}");
            Console.WriteLine($"Event: {selectedEvent.Name}");
            Console.WriteLine($"Totaal prijs: €{total}");

            Console.WriteLine("\nProducten:");
            foreach (var product in order.GetProducts()) {
                Console.WriteLine($"- {product}");
            }

            Console.WriteLine($"\nLeveringstype: {delivery.DeliveryType}");
            Console.WriteLine($"Welkomstpakket: {(delivery.IncludesWelcomePackage ? "Ja" : "Nee")}");
            Console.WriteLine($"Naamplaat: {(delivery.IncludesNameTag ? "Ja" : "Nee")}");

            if (delivery.ExtraServices.Count > 0) {
                Console.WriteLine("Extra services:");
                foreach (var service in delivery.ExtraServices) {
                    Console.WriteLine($"- {service}");
                }
            }

            Console.WriteLine("\n=== ORDER PROCESSING ===");
            order.ProcessOrder();

            Console.WriteLine("\nBestelling succesvol opgeslagen.");
            Pause();
        }

        static void ShowControlScreen(OrderManager manager) {
            Console.Clear();
            Console.WriteLine("=== CONTROLE SCHERM ===");

            Console.WriteLine("\n--- LEDEN ---");
            foreach (var m in manager.GetMembers()) {
                Console.WriteLine($"{m.Id} | {m.Name} | {m.Email} | {m.Status} | {m.Address}");
            }

            Console.WriteLine("\n--- EVENTS ---");
            foreach (var e in manager.GetEvents()) {
                Console.WriteLine($"{e.Id} | {e.Name} | {e.Address} | {e.Date.ToShortDateString()} | €{e.TicketPrice}");
            }

            Console.WriteLine("\n--- BESTELLINGEN ---");
            var orders = manager.GetOrders();
            if (orders.Count == 0) {
                Console.WriteLine("Geen bestellingen.");
            } else {
                int i = 1;
                foreach (var o in orders) {
                    Console.WriteLine($"{i}. {o.Member.Name} | {o.Member.Status} | {o.Event.Name} | €{o.OrderPrice}");
                    i++;
                }
            }

            Console.WriteLine("\n--- LEVERINGEN ---");
            var deliveries = manager.GetDeliveries();
            if (deliveries.Count == 0) {
                Console.WriteLine("Geen leveringen.");
            } else {
                foreach (var d in deliveries) {
                    Console.WriteLine($"ID: {d.Id} | Lid: {d.Order.Member.Name} | Event: {d.Order.Event.Name} | Type: {d.DeliveryType}");
                    Console.WriteLine($"   Welcome package: {(d.IncludesWelcomePackage ? "Ja" : "Nee")}");
                    Console.WriteLine($"   Name tag: {(d.IncludesNameTag ? "Ja" : "Nee")}");

                    if (d.ExtraServices.Count > 0) {
                        Console.WriteLine($"   Services: {string.Join(", ", d.ExtraServices)}");
                    }
                }
            }

            Pause();
        }

        static void Pause() {
            Console.WriteLine("\nDruk op een toets om verder te gaan...");
            Console.ReadKey();
        }
    }
}