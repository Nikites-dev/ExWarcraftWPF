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
            switch (hero)
            {
                case Wizard wizard:
                    barStrensth.Maximum = wizard.strensthMax;
                    barDesterity.Maximum = wizard.desterityMax;
                    barConstitution.Maximum = wizard.constitutionMax;
                    barIntel.Maximum = wizard.intellisenseMax;
                        
                    barStrensth.Minimum = wizard.strensthMin;
                    barDesterity.Minimum = wizard.desterityMin;
                    barConstitution.Minimum = wizard.constitutionMin;
                    barIntel.Minimum = wizard.intellisenseMin;

                    barStrensth.Value = wizard.currentStrensth;
                    barDesterity.Value = wizard.currentDesterity;
                    barConstitution.Value = wizard.currentConstitution;
                    barIntel.Value = wizard.currentIntellisense;
                    break;
                
                case Rogue rogue:
                    barStrensth.Maximum = rogue.strensthMax;
                    barDesterity.Maximum = rogue.desterityMax;
                    barConstitution.Maximum = rogue.constitutionMax;
                    barIntel.Maximum = rogue.intellisenseMax;
                        
                    barStrensth.Minimum = rogue.strensthMin;
                    barDesterity.Minimum = rogue.desterityMin;
                    barConstitution.Minimum = rogue.constitutionMin;
                    barIntel.Minimum = rogue.intellisenseMin;
                    
                    barStrensth.Value = rogue.currentStrensth;
                    barDesterity.Value = rogue.currentDesterity;
                    barConstitution.Value = rogue.currentConstitution;
                    barIntel.Value = rogue.currentIntellisense;
                    break;
                
                case Warrior warrior:
                    barStrensth.Maximum = warrior.strensthMax;
                    barDesterity.Maximum = warrior.desterityMax;
                    barConstitution.Maximum = warrior.constitutionMax;
                    barIntel.Maximum = warrior.intellisenseMax;
                        
                    barStrensth.Minimum = warrior.strensthMin;
                    barDesterity.Minimum = warrior.desterityMin;
                    barConstitution.Minimum = warrior.constitutionMin;
                    barIntel.Minimum = warrior.intellisenseMin;
                    
                    barStrensth.Value = warrior.currentStrensth;
                    barDesterity.Value = warrior.currentDesterity;
                    barConstitution.Value = warrior.currentConstitution;
                    barIntel.Value = warrior.currentIntellisense;
                    break;
            }
        }

        public void SetTextCharacter()
        {
            switch (hero)
            {
                case Wizard wiz:
                    textHP.Text = "HP: " + wiz.HP.ToString();
                    textMP.Text = "MP: " + wiz.MP.ToString();
                    textPdet.Text = "PDet: " + wiz.PDet.ToString();
                    textAttack.Text = "Attack: " + wiz.Attack.ToString();
                    textMAH.Text = "MAH: " + wiz.MAH.ToString();
                    break;
                case Rogue rogue:
                    textHP.Text = "HP: " + rogue.HP.ToString();
                    textMP.Text = "MP: " + rogue.MP.ToString();
                    textPdet.Text = "PDet: " + rogue.PDet.ToString();
                    textAttack.Text = "Attack: " + rogue.Attack.ToString();
                    textMAH.Text = "MAH: " + rogue.MAH.ToString();
                    break;
                case Warrior warrior:
                    textHP.Text = "HP: " + warrior.HP.ToString();
                    textMP.Text = "MP: " + warrior.MP.ToString();
                    textPdet.Text = "PDet: " + warrior.PDet.ToString();
                    textAttack.Text = "Attack: " + warrior.Attack.ToString();
                    textMAH.Text = "MAH: " + warrior.MAH.ToString();
                    break;
            }
        }

        public void PerformAction()
        {
            switch (hero)
            {
                case Wizard wiz:
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

                    break;
                }
                case Rogue rogue:
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

                    break;
                }
                case Warrior warrior:
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

                    break;
                }
            }
        }


    }
}
