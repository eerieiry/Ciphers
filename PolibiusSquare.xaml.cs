using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
   
    public partial class PolibiusSquare : Window
    {
        private readonly char[,] polibiusMatrix = new char[5, 5];
        private ObservableCollection<string> encryptedTextList = new ObservableCollection<string>();

        public PolibiusSquare()
        {
            InitializeComponent();
            FillPolibiusMatrix();
            FillMatrixGrid();
        }
        private void FillPolibiusMatrix()
        {
            string keyword = KeywordTextBox.Text.ToUpper();
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string uniqueKeyword = "";

            foreach (char c in keyword)
            {
                if (Char.IsLetter(c) && uniqueKeyword.IndexOf(Char.ToUpper(c)) == -1)
                {
                    uniqueKeyword += Char.ToUpper(c);
                }
            }

            foreach (char c in alphabet)
            {
                if (uniqueKeyword.IndexOf(c) == -1)
                {
                    uniqueKeyword += c;
                }
            }

            int index = 0;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    polibiusMatrix[i, j] = uniqueKeyword[index++];
                }
            }
        }

        private void FillMatrixGrid()
        {
            MatrixGrid.Children.Clear();
            MatrixGrid.RowDefinitions.Clear();
            MatrixGrid.ColumnDefinitions.Clear();

            for (int i = 0; i < 5; i++)
            {
                MatrixGrid.RowDefinitions.Add(new RowDefinition());
                MatrixGrid.ColumnDefinitions.Add(new ColumnDefinition());
            }

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Label label = new Label();
                    label.Content = polibiusMatrix[i, j].ToString();
                    label.HorizontalContentAlignment = HorizontalAlignment.Center;
                    label.VerticalContentAlignment = VerticalAlignment.Center;
                    label.BorderBrush = Brushes.Black;
                    label.BorderThickness = new Thickness(1);
                    Grid.SetRow(label, i);
                    Grid.SetColumn(label, j);
                    MatrixGrid.Children.Add(label);
                }
            }
        }


        private string Encrypt(string plainText)
        {
            plainText = plainText.ToUpper();
            StringBuilder encryptedText = new StringBuilder();

            foreach (char c in plainText)
            {
                if (c == 'J')
                {
                    encryptedText.Append("24 ");
                }
                else if (Char.IsLetter(c))
                {
                    char upperC = Char.ToUpper(c);
                    for (int i = 0; i < 5; i++)
                    {
                        for (int j = 0; j < 5; j++)
                        {
                            if (polibiusMatrix[i, j] == upperC)
                            {
                                encryptedText.Append($"{i + 1}{j + 1} ");
                            }
                        }
                    }
                }
                else
                {
                    encryptedText.Append(c);
                }
            }

            return encryptedText.ToString();
        }

        private string Decrypt(string encryptedText)
        {
            encryptedText = encryptedText.Trim();
            StringBuilder decryptedText = new StringBuilder();

            string[] parts = encryptedText.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string part in parts)
            {
                if (part == "24")
                {
                    decryptedText.Append("I");
                }
                else if (part.Length == 2 && char.IsDigit(part[0]) && char.IsDigit(part[1]))
                {
                    int row = int.Parse(part[0].ToString()) - 1;
                    int col = int.Parse(part[1].ToString()) - 1;

                    if (row >= 0 && row < 5 && col >= 0 && col < 5)
                    {
                        decryptedText.Append(polibiusMatrix[row, col]);
                    }
                }
                else
                {
                    decryptedText.Append(part);
                }
            }

            return decryptedText.ToString();
        }

        private void EncryptButton_Click(object sender, RoutedEventArgs e)
        {
            EncryptedTextBox.Clear();
            FillPolibiusMatrix();
            FillMatrixGrid();
            string plainText = PlainTextBox.Text;
            string encryptedText = Encrypt(plainText);
            EncryptedTextBox.Text = encryptedText;
        }

   private void DecryptButton_Click(object sender, RoutedEventArgs e)
        {
            PlainTextBox.Clear();
            FillPolibiusMatrix();
            FillMatrixGrid();
            string encryptedText = EncryptedTextBox.Text;
            string keyword = KeywordTextBox.Text;
            string plainText = Decrypt(encryptedText);
            PlainTextBox.Text = plainText;
        }

        private void MainBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }

}

