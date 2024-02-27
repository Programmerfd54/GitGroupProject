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

namespace GitOurProject
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string currentOperation = ""; // Текущая операция

        public MainWindow()
        {
            InitializeComponent();
            // Добавляем обработчики событий изменения текста в текстовых полях
            log.TextChanged += TextBox_TextChanged;
            log2.TextChanged += TextBox_TextChanged;
        }

       

        private void Equals_Click(object sender, RoutedEventArgs e)
        {
            PerformOperation();
        }
        double result = 0;
        private void PerformOperation()
        {
            
        }

        // Обработчик события изменения текста в текстовых полях
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            PerformOperation(); // Выполняем операцию при изменении текста
        }

        private void TextBox_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            foreach (char c in e.Text)
            {
                if (!char.IsDigit(c) && c != '.')
                {
                    e.Handled = true; // Отклоняем ввод, если символ не цифра и не точка
                    break;
                }
            }
        }


    }
}
