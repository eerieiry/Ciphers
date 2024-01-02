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
using static System.Net.Mime.MediaTypeNames;

namespace Ciphers
{
    /// <summary>
    /// Логика взаимодействия для Permutation.xaml
    /// </summary>
    public partial class Permutation : Window
    {
        public Permutation()
        {
            InitializeComponent();
        }
        

        private void MainBack_Click(object sender, RoutedEventArgs e)
        {
           
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
        }

        private void EncryptButton_Click(object sender, RoutedEventArgs e)
        {
            string plainText = PlainTextBox.Text.ToUpper();
            string key = KeyTextBox.Text;
            int[] arrkey = new int[key.Length];
            int count = 0;
            int maxDigit = 0;

            foreach (char c in key)
            {
                if (char.IsDigit(c))
                {
                    arrkey[count] = int.Parse(c.ToString()) - 1;
                    count++;
                    int digit = int.Parse(c.ToString());
                    if (digit > maxDigit)
                    {
                        maxDigit = digit;
                    }
                }
            }

            int numRows = (plainText.Length / maxDigit) - 1;
            char[][] arrmain = new char[numRows][];
            for (int i = 0; i < numRows; i++)
            {
                arrmain[i] = new char[maxDigit];
            }

            int row = 0;
            int col = 0;
            foreach (char c in plainText)
            {
                if (char.IsLetter(c))
                {
                    arrmain[row][col] = c;
                    col++;
                    if (col == maxDigit)
                    {
                        col = 0;
                        row++;
                    }
                }
            }

            string cipher = "";

            for (int i = 0; i < numRows; i++)
            {
                for (int j = 0; j < maxDigit; j++)
                {
                    if (arrkey[j] >= 0 && arrkey[j] < maxDigit)
                    {
                        cipher += arrmain[i][arrkey[j]];
                    }
                }
            }

            EncryptedTextBox.Text = cipher;
        }



        private void DecryptButton_Click(object sender, RoutedEventArgs e)
        {
            
                string cipher = EncryptedTextBox.Text;
                string key = KeyTextBox.Text;

                int[] arrkey = new int[key.Length];
                int count = 0;
                int maxDigit = 0;

                foreach (char c in key)
                {
                    if (char.IsDigit(c))
                    {
                        arrkey[count] = int.Parse(c.ToString()) - 1;
                        count++;
                        int digit = int.Parse(c.ToString());
                        if (digit > maxDigit)
                        {
                            maxDigit = digit;
                        }
                    }
                }

                int numRows = (cipher.Length / maxDigit);
                char[][] arrmain = new char[numRows][];
                for (int i = 0; i < numRows; i++)
                {
                    arrmain[i] = new char[maxDigit];
                }

                int row = 0;
                int col = 0;
                int cipherIndex = 0;

                while (cipherIndex < cipher.Length)
                {
                    if (row < numRows && col < maxDigit)
                    {
                        char c = cipher[cipherIndex];
                        if (char.IsLetter(c))
                        {
                            arrmain[row][arrkey[col]] = c;
                        }

                        col++;
                        if (col == maxDigit)
                        {
                            col = 0;
                            row++;
                        }
                    }

                    cipherIndex++;
                }

                string decryptedText = "";

                for (int i = 0; i < numRows; i++)
                {
                    for (int j = 0; j < maxDigit; j++)
                    {
                        if (i < numRows && j < maxDigit)
                        {
                            decryptedText += arrmain[i][j];
                        }
                    }
                }

            PlainTextBox.Text = decryptedText;
           
        }
    
    }
}
