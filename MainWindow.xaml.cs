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

namespace lab2_zad1
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double Iloczyn(double a,double b)
        {
            return a * b;
        }
        double Kwadrat(double x)
        {
            return Iloczyn(x, x);
        }
        double PoleKola(double promien)
        {
            return Math.PI * Kwadrat(promien);
        }
        double ObjetoscWalca(double wysokosc, double promien)
        {
            return Iloczyn(PoleKola(promien), wysokosc);
        }
        double PrzekrojPionowy(double wysokosc)
        {
            return ObjetoscWalca(wysokosc, wysokosc / 2.0);
        }
        double Potega(double liczba, int potega)
        {
            if (potega == 0) return 1;
            if (potega < 0) throw new ArgumentException();
            return Potega(liczba, potega-1) * liczba;
        }

        void Prostokont(double szerokosc, double wysokosc, out double pole, out double obwod, out double przekatna)
        {
                pole = wysokosc * szerokosc;
                obwod = 2 * wysokosc + 2 * szerokosc;
                przekatna = Math.Sqrt(Math.Pow(wysokosc, 2) + Math.Pow(szerokosc, 2));
        }
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            double a = 1.5;
            double b = 2.5;
            int c = 2;
            //lbxPudlo.Items.Add(Iloczyn(a,b));
            //lbxPudlo.Items.Add(Kwadrat(a));
            //lbxPudlo.Items.Add(PoleKola(a));
            //lbxPudlo.Items.Add(ObjetoscWalca(a,b));
            //lbxPudlo.Items.Add(PrzekrojPionowy(a));
           

        }

        private void btnPotega_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double a = Convert.ToDouble(txtPotega.Text);
                int b = Convert.ToInt32(txtWykladnik.Text);
                lblWynik.Content = Potega(a, b);
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Źle");
            }
        }

        private void btnTest3_Click(object sender, RoutedEventArgs e)
        {
            double pole, obwod, przekatna;
            double s = Convert.ToDouble(txtSzerokosc.Text);
            double w = Convert.ToDouble(txtWysokosc.Text);
            Prostokont(s, w, out pole, out obwod, out przekatna);
            

        }
        void RysujLinie(double x1, double x2, double y1, double y2, Brush kolor, int grubosc)
        {
            var myLine = new Line();
            myLine.StrokeThickness = grubosc;
            myLine.Stroke = kolor;
            myLine.X1 = x1;
            myLine.X2 = x2;
            myLine.Y1 = y1;
            myLine.Y2 = y2;
            cvObrazek.Children.Add(myLine);
        }

        private void btnRysuj4_Click(object sender, RoutedEventArgs e)
        {
            int[,] tablica = new int[,] { { 10, 10, 10, 50 }, { 50, 50, 10, 50 }, { 10, 50, 10, 10 }, { 10, 50, 30, 30 } };
            Brush[] kolor = new Brush[] { Brushes.Green, Brushes.Green, Brushes.Black, Brushes.Red };

            for (int i= 0; i < 4; i++)
            {
                RysujLinie(tablica[i, 0], tablica[i, 1], tablica[i, 2], tablica[i, 3], kolor[i], 1);
            }
        }
        enum Dzialanie
        {
            Sum,
            Min,
            Max,
        }
        void Dzialania(Dzialanie rodzaj, params int[] dane)
        {
            lbxPudlo.Items.Clear();
            for(int i = 0; i < dane.Length; i++)
            {
                lbxPudlo.Items.Add(dane[i]);
            }
            switch (rodzaj)
            {
                case Dzialanie.Sum: MessageBox.Show(Convert.ToString(dane.Sum())); break;
                case Dzialanie.Min: MessageBox.Show(Convert.ToString(dane.Min())); break;
                case Dzialanie.Max: MessageBox.Show(Convert.ToString(dane.Max())); break;
            }
        }

        private void btnTest5_Click(object sender, RoutedEventArgs e)
        {
            int[] tablica = new int[] { 1, 2, 3, 4, 5 };
            if (rdnMax.IsChecked==true)
            {
                Dzialania(Dzialanie.Max, tablica);
            }
            if (rdnMin.IsChecked == true)
            {
               Dzialania(Dzialanie.Min, tablica);
            }
            if (rdnSum.IsChecked == true)
            {
                Dzialania(Dzialanie.Sum, tablica);
            }
        }
        void Gwiazda(double x, double y, double dlugosc)
        {
            double temp = dlugosc / 2;
            double temp3 = dlugosc / 3;
            int min = 10;
            Brush kolor = Brushes.Blue;
            if (dlugosc > min)
            {
                RysujLinie(x + temp, x - temp, y + ((dlugosc * Math.Sqrt(3)) / 2), y - ((dlugosc * Math.Sqrt(3)) / 2), kolor, 1);
                RysujLinie(x - temp, x + temp, y + ((dlugosc * Math.Sqrt(3)) / 2), y - ((dlugosc * Math.Sqrt(3)) / 2), kolor, 1);
                RysujLinie(x - dlugosc, x + dlugosc, y, y, kolor, 1);
                Gwiazda(x + temp, y - dlugosc, temp3);
                Gwiazda(x + temp, y + dlugosc, temp3);
                Gwiazda(x - temp, y - dlugosc, temp3);
                Gwiazda(x - temp, y + dlugosc, temp3);
                Gwiazda(x - dlugosc, y, temp3);
                Gwiazda(x + dlugosc, y, temp3);
            }
        }

        private void btnRysuj6_Click(object sender, RoutedEventArgs e)
        {
            Gwiazda(100, 100, 50);
        }
        void Zamiana(ref int a, ref int b)
        {
            int pom = a;
            a = b;
            b = pom;
        }

        private void btnTest7_Click(object sender, RoutedEventArgs e)
        {
            int a = 2;
            int b = 3;
            Zamiana(ref a, ref b);
            MessageBox.Show($"A = {a} B = {b}");
        }

        private void btnTest8_Click(object sender, RoutedEventArgs e)
        {
            lbxPudlo.Items.Clear();
            double suma = 0;
            double suma1 = 0;
            double suma2 = 0;
            double[,] tab = new double[,] { { 11, 12, 13 }, { 1, 2, 3 }, { 6, 7, 8 }, { 9, 4, 5 }, { 7, 4, 1 } };
            for (int i = 0; i < tab.GetLength(0); i++)
            {
                lbxPudlo.Items.Add($@"{tab[i, 0]} {tab[i, 1]} {tab[i, 2]} [{tab[i, 0]+tab[i, 1]+tab[i, 2]}]");
                suma += tab[i, 0];
                suma1 += tab[i, 1];
                suma2 += tab[i, 2];
            }
            lbxPudlo.Items.Add($@"[{suma}] [{suma1}] [{suma2}]");
        }
        
        private void btnJagged_Click(object sender, RoutedEventArgs e)
        {
            lbxTablica.Items.Clear();
            int[][] tab1 = new int[3][];
            tab1[0] = new int[6];
            tab1[1] = new int[5];
            tab1[2] = new int[3];
            int[] tabHelp = new int[] { 2, 3, 4, 5, 6, 8 };

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < tab1[i].GetLength(0); j++)
                {
                tab1[i][j] = tabHelp[j];
                }
                }
                for (int i = 0; i < 3; i++)
                {
                switch (i)
                {
                case 0:
                lbxTablica.Items.Add(tab1[i][0] + "\t" + tab1[i][1] + "\t" + tab1[i][2] + "\t" + tab1[i][3] + "\t" + tab1[i][4] + "\t" + tab1[i][5] + "\t[" + (tab1[i][0] + tab1[i][1] + tab1[i][2] + tab1[i][3] + tab1[i][4] + tab1[i][5]) + "]");
                break;
                case 1:
                lbxTablica.Items.Add(tab1[i][0] + "\t" + tab1[i][1] + "\t" + tab1[i][2] + "\t" + tab1[i][3] + "\t" + tab1[i][4] + "\t[" + (tab1[i][0] + tab1[i][1] + tab1[i][2] + tab1[i][3] + tab1[i][4]) + "]");
                break;
                case 2:
                lbxTablica.Items.Add(tab1[i][0] + "\t" + tab1[i][1] + "\t" + tab1[i][2] + "\t[" + (tab1[i][0] + tab1[i][1] + tab1[i][2]) + "]");
                    break;
                }
}

}
    }
}
