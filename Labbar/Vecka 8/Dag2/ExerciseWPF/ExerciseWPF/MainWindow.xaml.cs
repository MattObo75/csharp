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

namespace ExerciseWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void cmdClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void cmdAdd_Click(object sender, RoutedEventArgs e)
        {
            //det finns två sätt att deklarera variabler,
            // det ena är en initiering och det andra är initiering
            // och tilldelning av värdet samtidigt.
            double firstNum = 0;
            firstNum = double.Parse(txtBox1.Text);
            double secondNum = double.Parse(txtBox2.Text);
            txtBoxResult.Text = "=" + (firstNum + secondNum);
            txtBoxShow.Text = firstNum + "+" + secondNum;
        }

        private void cmdSubtract_Click(object sender, RoutedEventArgs e)
        {
            //det finns två sätt att deklarera variabler,
            // det ena är en initiering och det andra är initiering
            // och tilldelning av värdet samtidigt.
            double firstNum = 0;
            firstNum = double.Parse(txtBox1.Text);
            double secondNum = double.Parse(txtBox2.Text);
            txtBoxResult.Text = "=" + (firstNum - secondNum);
            txtBoxShow.Text = firstNum + "-" + secondNum;
        }
        private void cmdMultiply_Click(object sender, RoutedEventArgs e)
        {
            //det finns två sätt att deklarera variabler,
            // det ena är en initiering och det andra är initiering
            // och tilldelning av värdet samtidigt.
            double firstNum = 0;
            firstNum = double.Parse(txtBox1.Text);
            double secondNum = double.Parse(txtBox2.Text);
            txtBoxResult.Text = "=" + (firstNum * secondNum);
            txtBoxShow.Text = firstNum + "*" + secondNum;
        }

        private void cmdDivide_Click(object sender, RoutedEventArgs e)
        {
            //det finns två sätt att deklarera variabler,
            // det ena är en initiering och det andra är initiering
            // och tilldelning av värdet samtidigt.
            double firstNum = 0;
            firstNum = double.Parse(txtBox1.Text);
            double secondNum = double.Parse(txtBox2.Text);
            txtBoxResult.Text = "=" + (firstNum / secondNum);
            txtBoxShow.Text = firstNum + "/" + secondNum;
        }

    }
}