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

namespace Ciphers
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CeasarCipher_Open_Click(object sender, RoutedEventArgs e)
        {
            CaesarCipher caesarCipher = new CaesarCipher();
            caesarCipher.Show();
            this.Close();

        }

        private void PolibiusSquare_Open_Click(object sender, RoutedEventArgs e)
        {
            PolibiusSquare polibiusSquare = new PolibiusSquare();
            polibiusSquare.Show();
            this.Close();
        }

        private void Permutation_Open_Click(object sender, RoutedEventArgs e)
        {
            Permutation permutation = new Permutation();
            permutation.Show();
            this.Close();
        }

        private void TrithemiusCipher_Open_Click(object sender, RoutedEventArgs e)
        {
            TrithemiusCipher trithemiusCipher = new TrithemiusCipher();
            trithemiusCipher.Show();
            this.Close();
        }
    }
}
