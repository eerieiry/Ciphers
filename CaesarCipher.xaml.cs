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
using System.Windows.Shapes;

namespace Ciphers
{
  
    public partial class CaesarCipher : Window
    {
        public CaesarCipher()
        {
            InitializeComponent();
        }

        // "Зашифровати"
        private void EncryptButton_Click(object sender, RoutedEventArgs e)
        {
            int shift;
            if (!int.TryParse(ShiftTextBox.Text, out shift))
            {
                MessageBox.Show("Введіть число.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            string inputText = InputTextBox.Text;
            string encryptedText = Encrypt(inputText, shift);
            OutputTextBox.Text = encryptedText;
        }

        // "Розшифрувати"
        private void DecryptButton_Click(object sender, RoutedEventArgs e)
        {
            int shift;
            if (!int.TryParse(ShiftTextBox.Text, out shift))
            {
                MessageBox.Show("Введіть число.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            string inputText = InputTextBox.Text;
            string decryptedText = Decrypt(inputText, shift);
            OutputTextBox.Text = decryptedText;
        }

        // Шифрування
        private string Encrypt(string input, int shift)
        {
            StringBuilder encryptedText = new StringBuilder();

            foreach (char c in input)
            {
                if (char.IsLetter(c))

                {
                    if (shift > 26)
                    {
                        shift %= 26;
                    }
                    char shiftedChar = (char)(c + shift);
                    if ((char.IsLower(c) && shiftedChar > 'z') || (char.IsUpper(c) && shiftedChar > 'Z'))
                    {
                        shiftedChar = (char)(c - (26 - shift));
                    }
                    encryptedText.Append(shiftedChar);
                }
                else
                {
                    encryptedText.Append(c);
                }
            }

            return encryptedText.ToString();
        }

        // Розшифрування
        private string Decrypt(string input, int shift)
        {
            return Encrypt(input, -shift);
        }

        private void MainBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
