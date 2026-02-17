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

namespace ExerciseWPFCombo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            FillComboBoxWithValues();
        }

        private void cmdGetvalue_Click(object sender, RoutedEventArgs e)
        {
            string chosenDessert = null;
            if (rbAlt1.IsChecked == true)
            {
                chosenDessert = rbAlt1.Content.ToString();
            }
            else if (rbAlt2.IsChecked == true)
            {
                chosenDessert = rbAlt2.Content.ToString();
            }
            else if (rbAlt3.IsChecked == true)
            {
                chosenDessert = rbAlt3.Content.ToString();
            }
            MessageBox.Show("Du valde " + chosenDessert);
        }

        public void FillComboBoxWithValues()
        {
            try
            {
                using StreamReader sr = new StreamReader(@"X:\source\c#\Labbar\Vecka 8\Dag1\dessert.txt");
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
                        cmbValues.Items.Add(item);
                    }
                }
                //MessageBox.Show(output);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
            }
        }

        private void cmbValues_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string chosenDessert = null;
            if (cmbValues.SelectedIndex > -1)
            {
                chosenDessert = cmbValues.SelectedItem.ToString();
            }
            txtResult.Text = "Du valde: " + chosenDessert;
        }
    }
}