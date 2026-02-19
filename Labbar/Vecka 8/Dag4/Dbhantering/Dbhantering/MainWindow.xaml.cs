using Microsoft.Win32;
using Npgsql; // PostgreSQL data provider
using PdfSharp.Drawing;
using PdfSharp.Fonts;
using PdfSharp.Pdf;
using System.Data;
using System.Data;
using System.IO;
using System.Net.NetworkInformation;
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

namespace Dbhantering
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {     
        // Byt till din databas info, postgres är allas användarnamn
        // Om du har lösenord, fortsätt med Password=ditt_lösenord
        private string connectionString =
            "Host=192.168.0.249;Port=5432;Username=postgres;Database=zoo_db";        
        public MainWindow()
        {
            GlobalFontSettings.UseWindowsFontsUnderWindows = true;
            InitializeComponent();
            LoadTables();
            FillComboBoxWithValues();
        }
        private void RunButton_Click(object sender, RoutedEventArgs e)
        {
            string query = QueryTextBox.Text;
            if (string.IsNullOrWhiteSpace(query))
            {
                MessageBox.Show("Skriv en fråga först.");
                return;
            }
            try
            {
                using (var conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        using (var adapter = new NpgsqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            ResultDataGrid.ItemsSource = dt.DefaultView;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fel: {ex.Message}");
            }
        }
        // Ladda alla tabeller i databasen
        private void LoadTables()
        {
            try
            {
                using (var conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();
                    var cmdSelect = new NpgsqlCommand(
                    "SELECT table_name FROM information_schema.tables WHERE table_schema='public' ORDER BY table_name;", conn);
                    using (var readerSelect = cmdSelect.ExecuteReader())
                    {
                        while (readerSelect.Read())
                        {
                            TablesComboBox.Items.Add(readerSelect.GetString(0));
                        }
                    }

                    showDatabase.Text = conn.Database + ", username@host: " + conn.UserName + "@" + conn.Host; 
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fel vid hämtning av tabeller: {ex.Message}");
            }
        }
        // När användaren väljer en tabell
        private void TablesComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (TablesComboBox.SelectedItem != null && QueryComboBox.SelectedItem != null)
            {
                string selectedQuery = QueryComboBox.SelectedItem.ToString();
                string selectedTable = TablesComboBox.SelectedItem.ToString();

                switch (selectedQuery)
                {
                    case "SELECT":
                        QueryTextBox.Text = $"{selectedQuery} kolumn\nFROM \"{selectedTable}\"\nWHERE villkor;";
                        break;
                    case "UPDATE":
                        QueryTextBox.Text = $"{selectedQuery} \"{selectedTable}\"\nSET kolumn\nWHERE villkor;";
                        break;
                    case "DELETE":
                        QueryTextBox.Text = $"{selectedQuery} FROM \"{selectedTable}\"\nWHERE villkor;";
                        break;
                    case "CREATE TABLE":
                        QueryTextBox.Text = $"{selectedQuery} \"{selectedTable}\" (\nkeys\n);";
                        break;
                }
            }

            if (TablesComboBox.SelectedItem != null && QueryComboBox.SelectedItem == null)
            {
                string selectedTable = TablesComboBox.SelectedItem.ToString();
                QueryTextBox.Text = $"\"{selectedTable}\";";
            }

            
        }

        public void FillComboBoxWithValues()
        {
            try
            {
                string[] queryText = ["SELECT","UPDATE","DELETE","CREATE TABLE"]; 
                
                //skriver ut arrayen:
                string output = string.Empty;
                foreach (var item in queryText)
                {
                    if (item != null)
                    {
                        output += item + "\n";
                        QueryComboBox.Items.Add(item);
                    }
                }
                //MessageBox.Show(output);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
            }
        }
        private void ReportButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Kontrollera om datagrid är tom
                if (ResultDataGrid.ItemsSource == null)
                {
                    MessageBox.Show("Datagriden är tom. Kör en fråga först.");
                    return;
                }

                DataView dataView = ResultDataGrid.ItemsSource as DataView;

                if (dataView == null || dataView.Count == 0)
                {
                    MessageBox.Show("Datagriden innehåller ingen data.");
                    return;
                }

                DataTable table = dataView.ToTable();

                // Dialog för att välja filnamn
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "PDF filer (*.pdf)|*.pdf";
                saveDialog.FileName = "Rapport.pdf";

                if (saveDialog.ShowDialog() != true)
                    return;

                // Skapa PDF
                PdfDocument document = new PdfDocument();
                document.Info.Title = "Databasrapport";

                PdfPage page = document.AddPage();
                XGraphics gfx = XGraphics.FromPdfPage(page);

                XFont headerFont = new XFont("Arial", 10, XFontStyleEx.Bold);
                XFont font = new XFont("Arial", 10);

                double y = 40;
                double x = 40;
                double rowHeight = 20;
                double colWidth = 100;

                // Rita kolumnrubriker
                for (int i = 0; i < table.Columns.Count; i++)
                {
                    gfx.DrawString(
                        table.Columns[i].ColumnName,
                        headerFont,
                        XBrushes.Black,
                        new XRect(x + (i * colWidth), y, colWidth, rowHeight),
                        XStringFormats.TopLeft);
                }

                y += rowHeight;

                // Rita rader
                foreach (DataRow row in table.Rows)
                {
                    for (int i = 0; i < table.Columns.Count; i++)
                    {
                        gfx.DrawString(
                            row[i]?.ToString(),
                            font,
                            XBrushes.Black,
                            new XRect(x + (i * colWidth), y, colWidth, rowHeight),
                            XStringFormats.TopLeft);
                    }

                    y += rowHeight;

                    // Ny sida om slut på utrymme
                    if (y > page.Height - 40)
                    {
                        page = document.AddPage();
                        gfx = XGraphics.FromPdfPage(page);
                        y = 40;
                    }
                }

                document.Save(saveDialog.FileName);

                MessageBox.Show("Rapport skapad!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fel vid skapande av rapport: " + ex.Message);
            }
        }
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void ResultDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}