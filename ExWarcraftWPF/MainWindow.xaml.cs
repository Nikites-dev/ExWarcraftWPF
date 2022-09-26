using System;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using ExWarcraftWPF.enumUnits;
using Microsoft.Win32;

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
           
            isUnit(pressed.Content.ToString()); 
        }

        public void isUnit(String unitType)
        {
            if(unitType == "Warrior")
            {
                //hero = new Warrior(0, 0, 0, 0);
                hero = new Warrior();
                SetProgressBarValue();


            } else if(unitType == "Rogue")
            {
                hero = new Rogue();
                SetProgressBarValue();
            }
            else if (unitType == "Wizard")
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

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MenuItem menuItem = (MenuItem)sender;

            if (menuItem.Header.ToString() == "Save local") {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
 
                saveFileDialog1.FileName = "testWarcraft";
                saveFileDialog1.DefaultExt = ".text";
                saveFileDialog1.Filter = "Текстик (*.txt)|*.txt";
 
                if (saveFileDialog1.ShowDialog() == true)
                {
                    using (StreamWriter sw = new StreamWriter(saveFileDialog1.OpenFile(), System.Text.Encoding.Default))
                    {
                        sw.Write($"{hero.GetType().Name}, {hero.CurrentStrensth}, {hero.CurrentDesterity}, {hero.CurrentConstitution}, {hero.CurrentIntellisense}");
                        sw.Close();
                    }
                }
                
                
            }

            else if(menuItem.Header.ToString() == "Save mongo db")
            {
                MessageBox.Show(menuItem.Header.ToString());
            }

            else if (menuItem.Header.ToString() == "Load local")
            {
                
                
                OpenFileDialog openFileDialog = new OpenFileDialog();
 
                openFileDialog.Filter = "Текстик (*.txt)|*.txt";
 
                if (openFileDialog.ShowDialog() == true)
                {
                    FileInfo fileInfo = new FileInfo(openFileDialog.FileName);

                    using (StreamReader reader = new StreamReader(fileInfo.Open(FileMode.Open, FileAccess.Read)))
                    {
                        String str = reader.ReadToEnd();

                        String[] unitInfo = str.Split(',');
                        reader.Close();
                        MessageBox.Show(str);
                        
                        isUnit(unitInfo[0]);

                        if(hero is Warrior warrior)
                        {
                            //warrior.CurrentStrensth = int.Parse(unitInfo[1]);
                            //warrior.CurrentDesterity = int.Parse(unitInfo[2]);
                            //warrior.CurrentConstitution = int.Parse(unitInfo[3]);
                            //warrior.CurrentIntellisense = int.Parse(unitInfo[4]);

                            warrior.setCharacter(int.Parse(unitInfo[1]) - warrior.strensthMin, int.Parse(unitInfo[2]) - warrior.desterityMin, int.Parse(unitInfo[3]) - warrior.constitutionMin, int.Parse(unitInfo[4]) - warrior.intellisenseMin);
                        }





                        SetProgressBarValue();



                    }
                }
                
                
                
            }

            else if (menuItem.Header.ToString() == "Load mongo db")
            {
                MessageBox.Show(menuItem.Header.ToString());
            }
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

                    barStrensth.Value = wizard.CurrentStrensth;
                    barDesterity.Value = wizard.CurrentDesterity;
                    barConstitution.Value = wizard.CurrentConstitution;
                    barIntel.Value = wizard.CurrentIntellisense;
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

                    barStrensth.Value = rogue.CurrentStrensth;
                    barDesterity.Value = rogue.CurrentDesterity;
                    barConstitution.Value = rogue.CurrentConstitution;
                    barIntel.Value = rogue.CurrentIntellisense;
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

                    barStrensth.Value = warrior.CurrentStrensth;
                    barDesterity.Value = warrior.CurrentDesterity;
                    barConstitution.Value = warrior.CurrentConstitution;
                    barIntel.Value = warrior.CurrentIntellisense;
                    break;
            }


            //barStrensth.Maximum = hero.StrensthMax;
            //barDesterity.Maximum = hero.DesterityMax;
            //barConstitution.Maximum = hero.ConstitutionMax;
            //barIntel.Maximum = hero.IntellisenseMax;

            //barStrensth.Minimum = hero.StrensthMin;
            //barDesterity.Minimum = hero.DesterityMin;
            //barConstitution.Minimum = hero.ConstitutionMin;
            //barIntel.Minimum = hero.IntellisenseMin;

            //barStrensth.Value = hero.CurrentStrensth;
            //barDesterity.Value = hero.CurrentDesterity;
            //barConstitution.Value = hero.CurrentConstitution;
            //barIntel.Value = hero.CurrentIntellisense;

        }

        public void SetTextCharacter()
        {

            //textHP.Text = "HP: " + hero.HP.ToString();
            //textMP.Text = "MP: " + hero.MP.ToString();
            //textPdet.Text = "PDet: " + hero.PDet.ToString();
            //textAttack.Text = "Attack: " + hero.Attack.ToString();
            //textMAH.Text = "MAH: " + hero.MAH.ToString();
            if (hero is Warrior warrior)
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




            //if (btn.Name == "btnStrensthP")
            //{
            //    hero.changeStrensth(true);
            //}
            //else if (btn.Name == "btnStrensthM")
            //{
            //    hero.changeStrensth(false);
            //}

            //if (btn.Name == "btnDesterityP")
            //{
            //    hero.changeDesterity(true);
            //}
            //else if (btn.Name == "btnDesterityM")
            //{
            //    hero.changeDesterity(false);
            //}

            //if (btn.Name == "btnConstitutP")
            //{
            //    hero.changeConstitution(true);
            //}
            //else if (btn.Name == "btnConstitutM")
            //{
            //    hero.changeConstitution(false);
            //}

            //if (btn.Name == "btnIntelP")
            //{
            //    hero.changeIntellisense(true);
            //}
            //else if (btn.Name == "btnIntelM")
            //{
            //    hero.changeIntellisense(false);
            //}





        }


    }
}
