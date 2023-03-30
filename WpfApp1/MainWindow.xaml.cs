using System;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Random random = new Random();
        int[] masEl = { 0, 0, 0, 0, 0 };
        public MainWindow()
        {
            InitializeComponent();
            randEl();
            elInCanv();
            generationVira();
        }

        public void randEl() // генерация элементов
        {
            for (int i = 0; i < masEl.Length; i++)
            {
            met: int newEl = random.Next(10);
                for (int j = 0; j < masEl.Length; j++)
                {
                    if (masEl[j] == newEl)
                    {
                        goto met;
                    }
                }
                masEl[i] = newEl;
            }
        }

        public void elInCanv() // элементы в канвас
        {
            int margin = 10;
            for (int i = 0; i < masEl.Length; i++)
            {
                TextBlock tb = new TextBlock()
                {
                    Text = masEl[i].ToString(),
                    Margin = new Thickness(5, margin, 0, 0)
                };
                cnv.Children.Add(tb);
                margin += 15;
            }
        }

        public void generationVira() // генерация выражений
        {
            int[] dopmas = { -1, -1, -1, -1, -1 };
            char[] masSinb = { 'п', 'н' };
            for (int j = 0; j < masEl.Length; j++)
            {
                char znak1 = masSinb[random.Next(2)];
                char znak2 = masSinb[random.Next(2)];
            met: int el = random.Next(5);
                for (int g = 0; g < masEl.Length; g++)
                {
                    if (el == dopmas[g])
                    {
                        goto met;
                    }
                }
                dopmas[j] = el;
                TextBlock tb = new TextBlock()
                {
                    Text = masEl[el] + " " + znak1 + " " + 'A',
                    Margin = new Thickness(5,0,0,0)
                };
                sp.Children.Add(tb);

                TextBlock tb2 = new TextBlock()
                {
                    Text = masEl[el] + " " + znak2 + " " + 'B',
                    Margin = new Thickness(25,0,0,0)
                };
                sp.Children.Add(tb2);
            }
            dopmas = new int[] { -1, -1, -1, -1, -1 };
        }
    }
}
