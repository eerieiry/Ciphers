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

    public partial class TrithemiusCipher : Window
    {
        public TrithemiusCipher()
        {
            InitializeComponent();
        }
        private void EncryptButton_Click(object sender, RoutedEventArgs e)
        {
            string plainText = PlainTextBox.Text;
            int shift;

            if (!int.TryParse(ShiftTextBox.Text, out shift))
            {
                MessageBox.Show("Введіть число.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            string encryptedText = Encrypt(plainText, shift);
            EncryptedTextBox.Text = encryptedText;
        }

        private void DecryptButton_Click(object sender, RoutedEventArgs e)
        {
            string encryptedText = EncryptedTextBox.Text;
            int shift;

            if (!int.TryParse(ShiftTextBox.Text, out shift))
            {
                MessageBox.Show("Введіть число.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            string decryptedText = Decrypt(encryptedText, shift);
            PlainTextBox.Text = decryptedText;
        }

        private string Encrypt(string text, int shift)
        {
            StringBuilder result = new StringBuilder();

            foreach (char c in text)
            {
                if (char.IsLetter(c))
                {

                    if (shift > 26)
                    {
                        shift %= 26;
                    }
                    char shiftedChar = (char)(c + shift);
                    if ((char.IsUpper(c) && shiftedChar > 'Z') || (char.IsLower(c) && shiftedChar > 'z'))
                    {
                        shiftedChar = (char)(c - (26 - shift));
                    }
                    result.Append(shiftedChar);
                    shift++;
                }
                else
                {
                    result.Append(c);
                }
            }

            return result.ToString();
        }

        private string Decrypt(string text, int shift)
        {
            StringBuilder result = new StringBuilder();

            foreach (char c in text)
            {
                if (char.IsLetter(c))
                {

                    if (shift > 26)
                    {
                        shift %= 26;
                    }
                    char shiftedChar = (char)(c - shift);
                    if ((char.IsUpper(c) && shiftedChar > 'Z') || (char.IsLower(c) && shiftedChar > 'z'))
                    {
                        shiftedChar = (char)(c - (26 - shift));
                    }
                    else if ((char.IsUpper(c) && shiftedChar < 'A') || (char.IsLower(c) && shiftedChar < 'a'))
                    {
                        shiftedChar = (char)(c + (26 - shift));

                    }
                    result.Append(shiftedChar);
                    shift++;
                }

                else
                {
                    result.Append(c);
                }
            }

            return result.ToString();
        }

        private void MainBack_Click(object sender, RoutedEventArgs e)
        {

            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
