namespace MauiConvertUIexercise
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
            Window.Title = "Omvandlare";
        }       
    }
}
