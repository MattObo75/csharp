using System.IO;
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

namespace WpfPizzaOrder
{
    public partial class MainWindow : Window
    {
        private const decimal VAT_RATE = 0.25m;
        private decimal totalPrice = 0m;
        private int pizzaCount = 0;

        public MainWindow()
        {
            InitializeComponent();
            FillComboBoxWithValues();
            UpdateSummary();
        }

        // =========================
        // Läs pizzor från fil
        // =========================
        public void FillComboBoxWithValues()
        {
            try
            {
                using StreamReader sr = new StreamReader(
                    @"X:\source\c#\Labbar\Vecka 8\Dag2\WpfPizzaOrder\pizzor.txt");

                while (!sr.EndOfStream)
                {
                    cmbPizza.Items.Add(sr.ReadLine());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        // =========================
        // Hämta valt pris
        // =========================
        private decimal GetSelectedSizePrice()
        {
            if (rbSmall.IsChecked == true) return 65m;
            if (rbMedium.IsChecked == true) return 85m;
            if (rbLarge.IsChecked == true) return 105m;
            return 0m;
        }

        // =========================
        // Lägg till pizza
        // =========================
        private void cmdAddPizza_Click(object sender, RoutedEventArgs e)
        {
            if (cmbPizza.SelectedIndex == -1)
            {
                MessageBox.Show("Välj en pizza.");
                return;
            }

            decimal price = GetSelectedSizePrice();
            if (price == 0)
            {
                MessageBox.Show("Välj storlek.");
                return;
            }

            string size =
                rbSmall.IsChecked == true ? "Small" :
                rbMedium.IsChecked == true ? "Medium" :
                "Large";

            string pizza = cmbPizza.SelectedItem.ToString();
            string orderRow = $"{pizza} ({size}) - {price} kr";

            lstOrder.Items.Add(orderRow);

            totalPrice += price;
            pizzaCount++;

            cmdSendOrder.IsEnabled = true;
            UpdateSummary();
        }

        // =========================
        // Ta bort pizza
        // =========================
        private void cmdRemovePizza_Click(object sender, RoutedEventArgs e)
        {
            if (lstOrder.SelectedItem == null) return;

            string item = lstOrder.SelectedItem.ToString();

            // extrahera pris från text
            int index = item.LastIndexOf('-');
            decimal price = decimal.Parse(
                item.Substring(index + 1).Replace("kr", "").Trim());

            totalPrice -= price;
            pizzaCount--;

            lstOrder.Items.Remove(lstOrder.SelectedItem);

            if (pizzaCount == 0)
                cmdSendOrder.IsEnabled = false;

            UpdateSummary();
        }

        // =========================
        // Summering
        // =========================
        private void UpdateSummary()
        {
            decimal vat = totalPrice * VAT_RATE;
            decimal totalWithVat = totalPrice + vat;

            txtSummary.Text =
                $"Antal pizzor: {pizzaCount}\n" +
                $"Summa exkl moms: {totalPrice:F2} kr\n" +
                $"Moms (25%): {vat:F2} kr\n" +
                $"Att betala: {totalWithVat:F2} kr";
        }

        // =========================
        // Skicka beställning + kvitto
        // =========================
        private void cmdSendOrder_Click(object sender, RoutedEventArgs e)
        {
            decimal vat = totalPrice * VAT_RATE;
            decimal total = totalPrice + vat;

            string receipt = "KVITTO\n\n";

            foreach (var item in lstOrder.Items)
                receipt += item + "\n";

            receipt += "\n------------------\n";
            receipt += $"Antal: {pizzaCount}\n";
            receipt += $"Exkl moms: {totalPrice:F2} kr\n";
            receipt += $"Moms: {vat:F2} kr\n";
            receipt += $"TOTALT: {total:F2} kr\n";
            receipt += "\nTack för din beställning!";

            MessageBox.Show(receipt, "Beställning skickad");
        }

        // =========================
        // Rensa
        // =========================
        private void cmdClear_Click(object sender, RoutedEventArgs e)
        {
            lstOrder.Items.Clear();
            totalPrice = 0m;
            pizzaCount = 0;

            rbSmall.IsChecked = false;
            rbMedium.IsChecked = false;
            rbLarge.IsChecked = false;
            cmbPizza.SelectedIndex = -1;

            cmdSendOrder.IsEnabled = false;
            UpdateSummary();
        }

        private void cmdClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
