using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Variabelen_5___Reiskost
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            flightClassLabel.Visibility = Visibility.Hidden;
        }

        private void calculateButton_Click(object sender, RoutedEventArgs e)
        {
            //Declaratie variabelen     
            float totalFlightPrice;
            float totalResidencePrice;
            float totalTravelPrice;
            float reduction;
            float amountToPay;

            //Berekening prijzen
            totalFlightPrice = float.Parse(baseFlightTextBox.Text) *
                float.Parse(numberOfPersonsTextBox.Text);

            totalResidencePrice = float.Parse(basePriceTextBox.Text) *
                (float.Parse(numberOfDaysTextBox.Text)) *
                float.Parse(numberOfPersonsTextBox.Text);
            totalTravelPrice = totalFlightPrice + totalResidencePrice;
            float kortingspercentage = float.Parse(reductionPercentageTextBox.Text);

            reduction = totalTravelPrice * kortingspercentage / 100;
            amountToPay = totalTravelPrice - reduction;

            // Afdruk
            // c: currency (munteenheid)
            resultTextBox.Text =
                $"REISKOST VOLGENS BESTELLING NAAR {destinationTextBox.Text} \r\n\r\n" +
                $"Totale vluchtprijs: {totalFlightPrice:c} \r\nTotale verblijfsprijs: {totalResidencePrice:c} \r\n" +
                $"Totale reisprijs: {totalTravelPrice:c} \r\nKorting: {reduction:c} \r\n\r\n" +
                $"Te betalen : {amountToPay:c}";
        }

        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            baseFlightTextBox.Text = "0";
            destinationTextBox.Clear();
            destinationTextBox.Text = ""; // string.Empty
            flightClassTextBox.Text = "2";
            basePriceTextBox.Text = "0";
            numberOfDaysTextBox.Text = "1";
            numberOfPersonsTextBox.Text = "1";
            reductionPercentageTextBox.Text = "0";
            resultTextBox.Clear();
            // Focus geven aan tekstvak.         
            destinationTextBox.Focus();
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void flightClassTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            flightClassLabel.Visibility = Visibility.Visible;
        }

        private void flightClassTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            flightClassLabel.Visibility = Visibility.Hidden;
        }

    }
}
