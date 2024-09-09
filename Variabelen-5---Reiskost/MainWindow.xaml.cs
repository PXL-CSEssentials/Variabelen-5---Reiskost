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
            float totVluchtprijs;
            float totVerblijfprijs;
            float totReisprijs;
            float korting;
            float teBetalen;

            //Berekening prijzen
            totVluchtprijs = float.Parse(baseFlightTextBox.Text) *
                float.Parse(numberOfPersonsTextBox.Text);

            totVerblijfprijs = float.Parse(basePriceTextBox.Text) *
                (float.Parse(numberOfDaysTextBox.Text)) *
                float.Parse(numberOfPersonsTextBox.Text);
            totReisprijs = totVluchtprijs + totVerblijfprijs;
            float kortingspercentage = float.Parse(reductionPercentageTextBox.Text);

            korting = totReisprijs * kortingspercentage / 100;
            teBetalen = totReisprijs - korting;

            // Afdruk
            // c: currency (munteenheid)
            resultTextBox.Text =
                $"REISKOST VOLGENS BESTELLING NAAR {destinationTextBox.Text} \r\n\r\n" +
                $"Totale vluchtprijs: {totVluchtprijs:c} \r\nTotale verblijfsprijs: {totVerblijfprijs:c} \r\n" +
                $"Totale reisprijs: {totReisprijs:c} \r\nKorting: {korting:c} \r\n\r\n" +
                $"Te betalen : {teBetalen:c}";
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
