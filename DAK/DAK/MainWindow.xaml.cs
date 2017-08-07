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

namespace DAK
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
           
            double p, Ppc, Ppr, T, Tpc, Tpr,ROUpr,Z;
            const double A1 = 0.3265;
            const double A2 = -1.07;
            const double A3 = -0.5339;
            const double A4 = 0.01569;
            const double A5 = -0.05165;
            const double A6 = 0.5475;
            const double A7 = -0.7361;
            const double A8 = 0.1844;
            const double A9 = 0.1056;
            const double A10 = 0.6134;
            const double A11 = 0.7210;
            const double Tc1 = 190.6;
            const double Tc2 = 305.4;
            const double Tc3 = 369.8;
            const double Pc1 = 4.604;
            const double Pc2 = 4.88;
            const double Pc3 = 4.249;

            double y1 = Convert.ToDouble(textBox.Text);
            double y2 = Convert.ToDouble(textBox_Copy.Text);
            double y3 = Convert.ToDouble(textBox_Copy1.Text);
            p = Convert.ToDouble(textBox_Copy2.Text);
            T = Convert.ToDouble(textBox_Copy3.Text)+273;
            Ppc = y1 * Pc1 + y2 * Pc2 + y3 * Pc3;
            Tpc = y1 * Tc1 + y2 * Tc2 + y3 * Tc3;
            Ppr = p / Ppc;
            Tpr = T / Tpc;
            double y = Ppr / (Tpr - 0.6903);

            if (y > 5.56)
                ROUpr = 0.9872791 * Math.Pow(Ppr, 0.3022868)/ Math.Pow(10, 0.5491962*Tpr );
            else 
                ROUpr = 0.9420554 * Math.Pow(Ppr, 1.071221) / Math.Pow(10, 0.7627628 * Tpr);

            for(int i=1;i<5;i++)
            {
                double Fpr = -0.27 * Ppr / Tpr + ROUpr + (A1 + A2 / Tpr + A3 / Math.Pow(Tpr, 3) + A4 / Math.Pow(Tpr, 4) + A5 / Math.Pow(Tpr, 5)) * Math.Pow(ROUpr, 2) +
                    (A6 + A7 / Tpr + A8 / Math.Pow(Tpr, 2)) * Math.Pow(ROUpr, 3) - A9 * (A7 / Tpr + A8 / Math.Pow(Tpr, 2)) * Math.Pow(ROUpr, 6) +
                    A10 * (1 + A11 * Math.Pow(ROUpr, 2)) * (Math.Pow(ROUpr, 3) / Math.Pow(Tpr, 3)) * Math.Exp(-A11 * Math.Pow(ROUpr, 2));
                Double Fpr2 = 1 + 2 * (A1 + A2 / Tpr + A3 / Math.Pow(Tpr, 3) + A4 / Math.Pow(Tpr, 4) + A5 / Math.Pow(Tpr, 5)) * Math.Pow(ROUpr, 1) +
                    3 * (A6 + A7 / Tpr + A8 / Math.Pow(Tpr, 2)) * Math.Pow(ROUpr, 2) - A9 * 6 * (A7 / Tpr + A8 / Math.Pow(Tpr, 2)) * Math.Pow(ROUpr, 5) +
                    (A10 / Math.Pow(Tpr, 3)) * (3 * Math.Pow(ROUpr, 2) + A11 * (3 * Math.Pow(ROUpr, 4) - 2 * A11 * Math.Pow(ROUpr, 6))) * Math.Exp(-A11 * Math.Pow(ROUpr, 2));
                ROUpr = ROUpr - Fpr / Fpr2;
            }
            Z = 0.27 * Ppr / (Tpr * ROUpr); 
            textBox1.Text = $"{ROUpr }";
            textBox2.Text = $"{Z }";
        }


    }
}
