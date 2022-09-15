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

                barStrensth.Value = warier.currentStrensth;
                barDesterity.Value = warier.currentDesterity;
                barConstitution.Value = warier.currentConstitution;
                barIntel.Value = warier.currentIntellisense;


            } else if(pressed.Content.ToString() == "Rogue")
            {
                rogue = new Rogue();
                barStrensth.MaxHeight = rogue.strensthMax;
                barStrensth.MinHeight = rogue.strensthMin;

                barStrensth.Value = rogue.currentStrensth;
                barDesterity.Value = rogue.currentDesterity;
                barConstitution.Value = rogue.currentConstitution;
                barIntel.Value = rogue.currentIntellisense;
            }
            else if (pressed.Content.ToString() == "Wizard")
            {
                wizard = new Wizard();
                barStrensth.MaxHeight = wizard.strensthMax;
                barStrensth.MinHeight = wizard.strensthMin;

                barStrensth.Value = wizard.currentStrensth;
                barDesterity.Value = wizard.currentDesterity;
                barConstitution.Value = wizard.currentConstitution;
                barIntel.Value = wizard.currentIntellisense;
            }


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bool isEvent = false;
            btn = (Button)sender;


            if (textHero.Text.ToString() == "Warrior")
            {

                if (btn.Name == "btnStrensthP")
                {
                    warier.changeStrensth(true);
                } else if(btn.Name == "btnStrensthM")
                {
                    warier.changeStrensth(false);
                }

                if (btn.Name == "btnDesterityP")
                {
                    warier.changeDesterity(true);
                }
                else if (btn.Name == "btnDesterityM")
                {
                    warier.changeDesterity(false);
                }

                if (btn.Name == "btnConstitutP")
                {
                    warier.changeConstitution(true);
                }
                else if (btn.Name == "btnConstitutM")
                {
                    warier.changeConstitution(false);
                }

                if (btn.Name == "btnIntelP")
                {
                    warier.changeIntellisense(true);
                }
                else if (btn.Name == "btnIntelM")
                {
                    warier.changeIntellisense(false);
                }


                barStrensth.Value = warier.currentStrensth;
                barDesterity.Value = warier.currentDesterity;
                barConstitution.Value = warier.currentConstitution;
                barIntel.Value = warier.currentIntellisense;


                textHP.Text ="HP: " + warier.HP.ToString();
                textMP.Text ="MP: " + warier.MP.ToString();
                textPdet.Text ="PDet: " + warier.PDet.ToString();
                textAttack.Text ="Attack: " + warier.Attack.ToString();
                textMAH.Text ="MAH: " + warier.MAH.ToString();
            
            }
            else if (textHero.Text.ToString() == "Rogue")
            {
                if (btn.Name == "btnStrensthP")
                {
                    rogue.changeStrensth(true);
                }
                else if (btn.Name == "btnStrensthM")
                {
                    rogue.changeStrensth(false);
                }

                if (btn.Name == "btnDesterityP")
                {
                    rogue.changeDesterity(true);
                }
                else if (btn.Name == "btnDesterityM")
                {
                    rogue.changeDesterity(false);
                }

                if (btn.Name == "btnConstitutP")
                {
                    rogue.changeConstitution(true);
                }
                else if (btn.Name == "btnConstitutM")
                {
                    rogue.changeConstitution(false);
                }

                if (btn.Name == "btnIntelP")
                {
                    rogue.changeIntellisense(true);
                }
                else if (btn.Name == "btnIntelM")
                {
                    rogue.changeIntellisense(false);
                }


                barStrensth.Value = rogue.currentStrensth;
                barDesterity.Value = rogue.currentDesterity;
                barConstitution.Value = rogue.currentConstitution;
                barIntel.Value = rogue.currentIntellisense;


                textHP.Text = "HP: " + rogue.HP.ToString();
                textMP.Text = "MP: " + rogue.MP.ToString();
                textPdet.Text = "PDet: " + rogue.PDet.ToString();
                textAttack.Text = "Attack: " + rogue.Attack.ToString();
                textMAH.Text = "MAH: " + rogue.MAH.ToString();
            }

            else if (textHero.Text.ToString() == "Wizard")
            {
                PerformAction(wizard);

                barStrensth.Value = wizard.currentStrensth;
                barDesterity.Value = wizard.currentDesterity;
                barConstitution.Value = wizard.currentConstitution;
                barIntel.Value = wizard.currentIntellisense;


                textHP.Text = "HP: " + wizard.HP.ToString();
                textMP.Text = "MP: " + wizard.MP.ToString();
                textPdet.Text = "PDet: " + wizard.PDet.ToString();
                textAttack.Text = "Attack: " + wizard.Attack.ToString();
                textMAH.Text = "MAH: " + wizard.MAH.ToString();
            }
        }

        public void PerformAction(customMain typeHero)
        {
             if (btn.Name == "btnStrensthP")
                {
                typeHero.changeStrensth(true);
                }
                else if (btn.Name == "btnStrensthM")
                {
                typeHero.changeStrensth(false);
                }

                if (btn.Name == "btnDesterityP")
                {
                typeHero.changeDesterity(true);
                }
                else if (btn.Name == "btnDesterityM")
                {
                typeHero.changeDesterity(false);
                }

                if (btn.Name == "btnConstitutP")
                {
                typeHero.changeConstitution(true);
                }
                else if (btn.Name == "btnConstitutM")
                {
                typeHero.changeConstitution(false);
                }

                if (btn.Name == "btnIntelP")
                {
                typeHero.changeIntellisense(true);
                }
                else if (btn.Name == "btnIntelM")
                {
                typeHero.changeIntellisense(false);
                }
        }


    }
}
