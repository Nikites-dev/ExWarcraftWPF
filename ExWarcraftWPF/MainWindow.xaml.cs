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
        public Warrior warier;
        public Rogue rogue;
        public Wizard wizard;

      

        public MainWindow()
        {
        

            InitializeComponent();
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton pressed = (RadioButton)sender;
            textHero.Text = pressed.Content.ToString();
           
            if(pressed.Content.ToString() == "Warrior")
            {
                 warier = new Warrior();
                barStrensth.MaxHeight = warier.strensthMax;
                barStrensth.MinHeight = warier.strensthMin;


            } else if(pressed.Content.ToString() == "Rogue")
            {
                rogue = new Rogue();
            }
            else if (pressed.Content.ToString() == "Wizard")
            {
                wizard = new Wizard();
            }


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bool isEvent = false;
            btn = (Button)sender;


            if (textHero.Text.ToString() == "Warrior")
            {
                int strensth = warier.changeStrensth();

                warier.changeConstitution();
                warier.changeIntellisense();
                warier.changeConstitution();
                warier.changeDesterity();

                barStrensth.Value = warier.currentStrensth;
           

                Console.WriteLine($"strensth:  {strensth}");
                Console.WriteLine($"HP:  {warier.HP}; Attack: {warier.Attack}; PDet: {warier.PDet}; MAH: {warier.MAH}; MP: {warier.MP}");


               // MessageBox.Show($"HP:  {warier.HP}; Attack: {warier.Attack}; PDet: {warier.PDet}; MAH: {warier.MAH}; MP: {warier.MP}");

            }
            else if (textHero.Text.ToString() == "Rogue")
            {
                rogue = new Rogue();
            }
            else if (textHero.Text.ToString() == "Wizard")
            {
                wizard = new Wizard();
            }




           
        }



    }
}
