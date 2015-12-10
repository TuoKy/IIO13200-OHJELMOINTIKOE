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

namespace H3408_T1b
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Laske_Click(object sender, RoutedEventArgs e)
        {
            Logiikka uusis = new Logiikka();
            tulos.Text = "";
            char[] temp = teksti.Text.ToLower().ToCharArray();

            int[] tempasd = uusis.checkThis(temp);
            int kokmaara = 0;

            foreach(int i in tempasd)
            {
                tulos.Text = tulos.Text + i.ToString() + " ";
                if(i != 0)
                {
                    kokmaara++;
                }
            }
            tulos.Text = tulos.Text + "Yhteensä: " + kokmaara.ToString() + " Eri merkkiä";
        }
    }
}
