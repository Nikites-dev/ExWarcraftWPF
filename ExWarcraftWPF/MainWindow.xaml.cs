using System.Windows;
using System.Windows.Controls;
using ExWarcraftWPF.enumUnits;

namespace ExWarcraftWPF
{

    public partial class MainWindow : Window
    {
        Button btn = new Button();
        public customMain hero = null;
      

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
                 hero = new Warrior();
                SetProgressBarValue();


            } else if(pressed.Content.ToString() == "Rogue")
            {
                hero = new Rogue();
                SetProgressBarValue();
            }
            else if (pressed.Content.ToString() == "Wizard")
            {
                hero = new Wizard();

                SetProgressBarValue();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bool isEvent = false;
            btn = (Button)sender;

            PerformAction();
            SetProgressBarValue();
            SetTextCharacter();
        }

        public void SetProgressBarValue()
        {
                if (hero is Wizard wizard)
                {
                    barStrensth.MaxHeight = wizard.strensthMax;
                    barStrensth.MinHeight = wizard.strensthMin;

                    barStrensth.Value = wizard.currentStrensth;
                    barDesterity.Value = wizard.currentDesterity;
                    barConstitution.Value = wizard.currentConstitution;
                    barIntel.Value = wizard.currentIntellisense;

                }else if (hero is Rogue rogue)
                {
                    barStrensth.MaxHeight = rogue.strensthMax;
                    barStrensth.MinHeight = rogue.strensthMin;

                    barStrensth.Value = rogue.currentStrensth;
                    barDesterity.Value = rogue.currentDesterity;
                    barConstitution.Value = rogue.currentConstitution;
                    barIntel.Value = rogue.currentIntellisense;
                }
                else if (hero is Warrior warrior)
                {
                    barStrensth.MaxHeight = warrior.strensthMax;
                    barStrensth.MinHeight = warrior.strensthMin;

                    barStrensth.Value = warrior.currentStrensth;
                    barDesterity.Value = warrior.currentDesterity;
                    barConstitution.Value = warrior.currentConstitution;
                    barIntel.Value = warrior.currentIntellisense;
                }


        }

        public void SetTextCharacter()
        {
            if (hero is Wizard wiz)
            {
                textHP.Text = "HP: " + wiz.HP.ToString();
                textMP.Text = "MP: " + wiz.MP.ToString();
                textPdet.Text = "PDet: " + wiz.PDet.ToString();
                textAttack.Text = "Attack: " + wiz.Attack.ToString();
                textMAH.Text = "MAH: " + wiz.MAH.ToString();
            } else if(hero is Rogue rogue)
            {
                textHP.Text = "HP: " + rogue.HP.ToString();
                textMP.Text = "MP: " + rogue.MP.ToString();
                textPdet.Text = "PDet: " + rogue.PDet.ToString();
                textAttack.Text = "Attack: " + rogue.Attack.ToString();
                textMAH.Text = "MAH: " + rogue.MAH.ToString();
            }
            else if (hero is Warrior warrior)
            {
                textHP.Text = "HP: " + warrior.HP.ToString();
                textMP.Text = "MP: " + warrior.MP.ToString();
                textPdet.Text = "PDet: " + warrior.PDet.ToString();
                textAttack.Text = "Attack: " + warrior.Attack.ToString();
                textMAH.Text = "MAH: " + warrior.MAH.ToString();
            }
        }

        public void PerformAction()
        {
            if (hero is Wizard wiz)
            {
                if (btn.Name == "btnStrensthP")
                {
                    wiz.changeStrensth(true);
                }
                else if (btn.Name == "btnStrensthM")
                {
                    wiz.changeStrensth(false);
                }

                if (btn.Name == "btnDesterityP")
                {
                    wiz.changeDesterity(true);
                }
                else if (btn.Name == "btnDesterityM")
                {
                    wiz.changeDesterity(false);
                }

                if (btn.Name == "btnConstitutP")
                {
                    wiz.changeConstitution(true);
                }
                else if (btn.Name == "btnConstitutM")
                {
                    wiz.changeConstitution(false);
                }

                if (btn.Name == "btnIntelP")
                {
                    wiz.changeIntellisense(true);
                }
                else if (btn.Name == "btnIntelM")
                {
                    wiz.changeIntellisense(false);
                }
            }

            else if (hero is Rogue rogue)
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
            }

            else if (hero is Warrior warrior)
            {
                if (btn.Name == "btnStrensthP")
                {
                    warrior.changeStrensth(true);
                }
                else if (btn.Name == "btnStrensthM")
                {
                    warrior.changeStrensth(false);
                }

                if (btn.Name == "btnDesterityP")
                {
                    warrior.changeDesterity(true);
                }
                else if (btn.Name == "btnDesterityM")
                {
                    warrior.changeDesterity(false);
                }

                if (btn.Name == "btnConstitutP")
                {
                    warrior.changeConstitution(true);
                }
                else if (btn.Name == "btnConstitutM")
                {
                    warrior.changeConstitution(false);
                }

                if (btn.Name == "btnIntelP")
                {
                    warrior.changeIntellisense(true);
                }
                else if (btn.Name == "btnIntelM")
                {
                    warrior.changeIntellisense(false);
                }
            }


           
        }


    }
}
