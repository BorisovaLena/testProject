using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Random random = new Random();
        int[] masEl = { 0, 0, 0, 0, 0 };
        int rez = -1;
        public MainWindow()
        {
            InitializeComponent();
            randEl();
            elInCanv();
            generationVira();
            yslovie();
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

        bool b = false;
        private void el3_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if(b==false)
            {
                el3.Fill = Brushes.Green;
                el3_Copy.Fill = Brushes.Green;
                el3_Copy1.Fill = Brushes.Green;
                el3_Copy2.Fill = Brushes.Green;
                el3_Copy3.Fill = Brushes.Green;
                el3_Copy4.Fill = Brushes.Green;
                el3_Copy5.Fill = Brushes.Green;
                el3_Copy6.Fill = Brushes.Green;
                el3_Copy7.Fill = Brushes.Green;
                el3_Copy8.Fill = Brushes.Green;
                b = true;
            }
            else
            {
                el3.Fill = Brushes.White;
                el3_Copy.Fill = Brushes.White;
                el3_Copy1.Fill = Brushes.White;
                el3_Copy2.Fill = Brushes.White;
                el3_Copy3.Fill = Brushes.White;
                el3_Copy4.Fill = Brushes.White;
                el3_Copy5.Fill = Brushes.White;
                el3_Copy6.Fill = Brushes.White;
                el3_Copy7.Fill = Brushes.White;
                el3_Copy8.Fill = Brushes.White;
                b = false;
            }
            
        }

        bool b1 = false;
        private void el4_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if(b1==false)
            {
                el4.Fill = Brushes.Green;
                b1 = true;
            }
            else
            {
                el4.Fill = Brushes.White;
                b1 = false;
            }
        }

        bool b2 = false;
        private void el5_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (b2 == false)
            {
                el5.Fill = Brushes.Green;
                b2 = true;
            }
            else
            {
                el5.Fill = Brushes.White;
                b2 = false;
            }
        }

        public void yslovie() // генерация условия
        {
            string[] masZnak = { "A ∪ B", "A ∩ B","множество A", "множество B" };
            rez = random.Next(4);
            yslov.Text = "Закрасте "+masZnak[rez] + ".";
        }

        public void proverka() // проверка
        {
            switch(rez)
            {
                case 0:
                    if(el5.Fill==Brushes.Green && el4.Fill == Brushes.Green && el3.Fill == Brushes.Green)
                    {
                        MessageBox.Show("Молодец");
                    }
                    else
                    {
                        MessageBox.Show("Лох");
                    }
                    break;
                case 1:
                    if (el3.Fill == Brushes.Green && el5.Fill == Brushes.White && el4.Fill == Brushes.White)
                    {
                        MessageBox.Show("Молодец");
                    }
                    else
                    {
                        MessageBox.Show("Лох");
                    }
                    break;
                case 2:
                    if (el4.Fill == Brushes.Green && el3.Fill == Brushes.Green && el5.Fill == Brushes.White)
                    {
                        MessageBox.Show("Молодец");
                    }
                    else
                    {
                        MessageBox.Show("Лох");
                    }
                    break;
                case 3:
                    if (el5.Fill == Brushes.Green && el3.Fill == Brushes.Green && el4.Fill == Brushes.White)
                    {
                        MessageBox.Show("Молодец");
                    }
                    else
                    {
                        MessageBox.Show("Лох");
                    }
                    break;
            }
        }

        private void prov_Click(object sender, RoutedEventArgs e)
        {
            proverka();
            randEl();
            elInCanv();
            generationVira();
            yslovie();
        }
    }
}
