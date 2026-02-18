namespace MauiConvertUI
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            Window.Width = 500;
        }
        /*
        private void OnFeetToMeterClicked(object sender, EventArgs e)
        {
            if (double.TryParse(InputEntry.Text, out double feet))
            {
                double meters = feet * 0.3048;
                ResultLabel.Text = $"{feet} feet = {meters:F2} meter";
            }
            else
            {
                ResultLabel.Text = "Ogiltigt värde!";
            }
        }
        private void OnMeterToFeetClicked(object sender, EventArgs e)
        {
            if (double.TryParse(InputEntry.Text, out double meters))
            {
                double feet = meters / 0.3048;
                ResultLabel.Text = $"{meters} meter = {feet:F2} feet";
            }
            else
            {
                ResultLabel.Text = "Ogiltigt värde!";
            }
        } */
    }
}
