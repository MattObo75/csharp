namespace WindowsForms2
{
    using System.Windows.Forms;
    using System.IO;
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            FillArrayWithValues();
        }

        private void cmdBeslut_Click(object sender, EventArgs e)
        {
            string input = txtVal.Text;
            //oavsett om du svarat "Ja" eller "ja" så ändas svaret till ja
            switch (input.ToLower())
            {
                case "ja":
                case "kanske":
                    MessageBox.Show("Toppen!");
                    break;
                case "nej":
                    MessageBox.Show("Tråkigt!");
                    break;
                default:
                    MessageBox.Show("Du angav inget av valen!");
                    break;
            }
        }

        public void FillArrayWithValues()
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
                        cmbDesserts.Items.Add(item);
                    }
                }
                //MessageBox.Show(output);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
            }
        }
        private void cmbDesserts_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Kontrollera att något faktiskt är valt
            if (cmbDesserts.SelectedItem != null)
            {
                txtVal.Text = cmbDesserts.SelectedItem.ToString();
            }
            else
            {
                txtVal.Text = string.Empty;
                // tomt om inget är valt
            }
        }

        private void cmdValtDessert_Click(object sender, EventArgs e)
        {
            string selectedDessert = txtVal.Text;
            if (!string.IsNullOrEmpty(txtVal.Text))
            {
                switch (selectedDessert)
                { 
                    case "Äppelpaj":                        
                        lblVal.ForeColor = Color.Green;
                        lblVal.Text = selectedDessert;
                        break;
                    case "Chockladglass":
                        lblVal.ForeColor = Color.Blue;
                        lblVal.Text = selectedDessert;
                        break;
                    case "Frukt":
                        lblVal.ForeColor = Color.Pink;
                        lblVal.Text = selectedDessert;
                        break;
                }
            }
            else
            {
                lblVal.Text = "Ingen dessert vald";
            }
        }
    }
}
