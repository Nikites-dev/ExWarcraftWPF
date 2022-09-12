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
using ExWarcraftWPF.enumUnits;

namespace ExWarcraftWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
  
    /// 

    public partial class MainWindow : Window
    {
        Button btn = new Button();
   
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bool isEvent = false;
            btn = (Button)sender;

            Warrior warier = new Warrior();
            int strensth = warier.changeStrensth();

            warier.changeConstitution();
            warier.changeIntellisense();
            warier.changeConstitution();
            warier.changeDesterity();


            Console.WriteLine($"strensth:  {strensth}");
            Console.WriteLine($"HP:  {warier.HP}; Attack: {warier.Attack}; PDet: {warier.PDet}; MAH: {warier.MAH}; MP: {warier.MP}");


            MessageBox.Show($"HP:  {warier.HP}; Attack: {warier.Attack}; PDet: {warier.PDet}; MAH: {warier.MAH}; MP: {warier.MP}");

        }

    }
}
