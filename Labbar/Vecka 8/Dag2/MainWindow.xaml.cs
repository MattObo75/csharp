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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static double totalPrice = 0;
        public MainWindow()
        {
            InitializeComponent();
            FillComboBoxWithValues();
        }        

        public void FillComboBoxWithValues()
        {
            try
            {
                using StreamReader sr = new StreamReader(@"X:\source\c#\Labbar\Vecka 8\Dag2\WpfPizzaOrder\pizzor.txt");
                string line = sr.ReadLine();
                string[] valuesText = new string[10]; //initialisera räknare i
                int i = 0;
                while (line != null)
                {
                    valuesText[i] = line;
                    line = sr.ReadLine();
                    ++i;
                } //skriver ut arrayen:
                string output = string.Empty;
                foreach (var item in valuesText)
                {
                    if (item != null)
                    {
                        output += item + "\n";
                        cmbPizza.Items.Add(item);
                    }
                }
                //MessageBox.Show(output);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
            }
        }
        private void cmdAddPizza_Click(object sender, RoutedEventArgs e)
        {
            double pizzaPrice = double.Parse(txtHidden.Text);
            totalPrice += pizzaPrice; 
            txtResult.Text = "Du har lagt till " + cmbPizza.Text + " i din beställning!";
            
            txtResult.Text += "\nTotalsumma: " + totalPrice + " kr";
        }

        private void cmdSendOrder_Click(object sender, RoutedEventArgs e)
        {
            txtResult.Text += "\nDin beställning har skickats! \nTack för att du beställer från oss!";
        }

        public void cmbPizza_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string chosenPizza = null;
            string chosenSize = null;
            string pizzaPrice = null;
            if (rbAlt1.IsChecked == true)
            {
                chosenSize = rbAlt1.Content.ToString();
                pizzaPrice = "65";
            }
            else if (rbAlt2.IsChecked == true)
            {
                chosenSize = rbAlt2.Content.ToString();
                pizzaPrice = "85";
            }
            else if (rbAlt3.IsChecked == true)
            {
                chosenSize = rbAlt3.Content.ToString();
                pizzaPrice = "105";
            }

            if (cmbPizza.SelectedIndex > -1)
            {
                chosenPizza = cmbPizza.SelectedItem.ToString();
            }
            txtShow.Text = chosenPizza + ", storlek " + chosenSize;
            txtHidden.Text = pizzaPrice;
        }

        private void cmdClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void cmdClear_Click(object sender, RoutedEventArgs e)
        {
            rbAlt1.IsChecked = false;
            rbAlt2.IsChecked = false;
            rbAlt3.IsChecked = false;
            cmbPizza.SelectedIndex = -1;
            txtShow.Text = "";
            txtResult.Text = "";
            txtHidden.Text = "";
        }

    }
}