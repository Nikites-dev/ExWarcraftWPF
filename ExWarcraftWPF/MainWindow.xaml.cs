using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using System.Xml.Linq;
using ExWarcraftWPF.enumUnits;
using ExWarcraftWPF.MongoDB;
using ExWarcraftWPF.res;
using ExWarcraftWPF.res.EquipType;
using Microsoft.Win32;
using ExWarcraftWPF.WindowRes;


namespace ExWarcraftWPF
{
    public partial class MainWindow : Window
    {


        Button btn = new Button();
        public Unit hero = null;
        ListBox inventoryListBox;

        public TextBox textBox;
        TextBox boxName;
        public TextBlock textCnt;

        List<String> strAbility;

        List<Equipment> equipment1;
        List<Equipment> equipment2;
        List<Equipment> equipment3;
        List<Equipment> equipmentCommon;

        List<Equipment> allProducts2;
        List<Equipment> allProducts3;
        
        double txtHP = 0;
        double txtMP = 0;
        double txtAttack = 0;
        double txtPdet = 0;
        double txtMAH = 0;
        
        public MainWindow()
        {
            InitializeComponent();
            List<Item> listWeapon = new List<Item> { new Item("Glock", 1), new Item("Knife", 1), new Item("Cucumber", 13) };
            strAbility = new List<String> { "nausea", "regeneration", "resistance", "hunger", "invisibility", "weakness", "wither", "poison", "luck", "slow_falling", "water_breathing", "night_vision", "fire_resistance", "jump_boost"};
            ComboBox cmbBoxWeapon = (ComboBox)this.FindName("cmbBoxWeapon");
            //ComboBox eqComboBox = (ComboBox) this.FindName("cmbBoxEquipment");
            ComboBox cmbBoxHero = (ComboBox)this.FindName("cmbBoxHero");

            cmbBoxHero.ItemsSource = MongoDBAction.AddListHeroes();
            inventoryListBox = (ListBox)this.FindName("ListBoxInventory");
            
            textBox = (TextBox)this.FindName("boxItemName");
            textCnt = (TextBlock)this.FindName("textItemCnt");
            boxName = (TextBox)this.FindName("btnName");
            
            cmbBoxWeapon.ItemsSource = listWeapon.Select(item => item.ItemName);
            inventoryListBox.SelectionChanged += ListBoxInventory_SelectionChanged;
            
            equipment1 = new List<Equipment> { new LeatherHelmet(), new LeatherArmor(), new Revolver()};
            equipment2 = new List<Equipment> { new IronHelmet(), new IronArmor(), new Musket() };
            equipment3 = new List<Equipment> { new ModernHelmet(), new ModernArmor(), new SniperRifle()};

            var allProducts2 = new List<Equipment>(equipment1.Count + equipment2.Count);
            allProducts2.AddRange(equipment1);
            allProducts2.AddRange(equipment2);

            var allProducts3 = new List<Equipment>(equipment1.Count + equipment2.Count + equipment3.Count);
            allProducts3.AddRange(equipment1);
            allProducts3.AddRange(equipment2);
            allProducts3.AddRange(equipment3);
            
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            cmbBoxHero.SelectedValue = false;
            cmbBoxWeapon.SelectedValue = false;
            cmbBoxAbility.SelectedValue = false;
            cmbBoxEquipment.SelectedValue = false;
            
            RadioButton pressed = (RadioButton)sender;
            textHero.Text = pressed.Content.ToString();
            boxName.Text = "";
            IsUnit(pressed.Content.ToString());
            SetTextCharacter();
            SetProgressBarValue();
            ListBox inventoryListBox = (ListBox)this.FindName("ListBoxInventory");
            inventoryListBox.Items.Clear();
          
            
            ListBox listBoxEquipment = (ListBox)this.FindName("listBoxEquipment");
            listBoxEquipment.Items.Clear();

            dopHP.Text = " ";
            dopMP.Text = " ";
            dopAttack.Text = " ";
            dopPdet.Text = " ";
            dopMAH.Text = " ";
            
            txtHP = 0;
            txtMP = 0;
            txtAttack = 0;
            txtPdet = 0;
            txtMAH = 0;
            
            barExperience.Value = 0;
            txtLevel.Text = "0Lvl.";
            
        }

        public void IsUnit(String unitType)
        {
            if (unitType == "Warrior")
            {
                hero = new Warrior();
            }
            else if (unitType == "Rogue")
            {
                hero = new Rogue();
            }
            else if (unitType == "Wizard")
            {
                hero = new Wizard();
            }
            textHero.Text = hero.GetType().Name;
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

            if (menuItem.Header.ToString() == "Save local")
            {
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

            else if (menuItem.Header.ToString() == "Save mongo db")
            {
                hero.Name = boxName.Text;
                MessageBox.Show(menuItem.Header.ToString());
                MongoDBAction.AddToDatabase(hero);

                ComboBox cmbBoxHero = (ComboBox)this.FindName("cmbBoxHero");
                cmbBoxHero.ItemsSource = MongoDBAction.AddListHeroes();
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

                        IsUnit(unitInfo[0]);
                        hero.setCharacter(int.Parse(unitInfo[1]), int.Parse(unitInfo[2]), int.Parse(unitInfo[3]), int.Parse(unitInfo[4]));

                        SetProgressBarValue();
                        SetTextCharacter();
                    }
                }
            }

            else if (menuItem.Header.ToString() == "Load mongo db")
            {
                Unit lHero = MongoDBAction.FindByName(boxName.Text);
                IsUnit(MongoDBAction.FindByName(boxName.Text).GetType().Name);

                hero.setCharacter(lHero.CurrentStrensth, lHero.CurrentDesterity, lHero.CurrentConstitution, lHero.CurrentIntellisense);
                SetProgressBarValue();
                SetTextCharacter();
                
                hero.Inventory = lHero.Inventory;
                hero.Equipments = lHero.Equipments;

                ListBox inventoryListBox = (ListBox)this.FindName("ListBoxInventory");
                inventoryListBox.Items.Clear();

                foreach (var itemUnit in hero.Inventory)
                {
                    inventoryListBox.Items.Add(itemUnit.ItemName + " | " + itemUnit.ItemCount);
                }
            }
            else if (menuItem.Header.ToString() == "Update")
            {
                ComboBox cmbBoxHero = (ComboBox)this.FindName("cmbBoxHero");
                cmbBoxHero.ItemsSource = MongoDBAction.AddListHeroes();

                MongoDBAction.UpdateByName(cmbBoxHero.Text, hero);
                MessageBox.Show("update success!:  " + cmbBoxHero.Text);
            }
            
            else if (menuItem.Header.ToString() == "Create much")
            {
              
                CreateMuch winMuch = new CreateMuch();
                winMuch.Show();
                
                this.Close();
             
            }
        }

        public void SetProgressBarValue()
        {
            barStrensth.Maximum = hero.StrensthMax;
            barDesterity.Maximum = hero.DesterityMax;
            barConstitution.Maximum = hero.ConstitutionMax;
            barIntel.Maximum = hero.IntellisenseMax;

            barStrensth.Minimum = hero.StrensthMin;
            barDesterity.Minimum = hero.DesterityMin;
            barConstitution.Minimum = hero.ConstitutionMin;
            barIntel.Minimum = hero.IntellisenseMin;

            barStrensth.Value = hero.CurrentStrensth;
            barDesterity.Value = hero.CurrentDesterity;
            barConstitution.Value = hero.CurrentConstitution;
            barIntel.Value = hero.CurrentIntellisense;
        }

        public void SetTextCharacter()
        {
            textHP.Text = "HP: " + hero.HP;
            textMP.Text = "MP: " + hero.MP;
            textPdet.Text = "PDet: " + hero.PDet;
            textAttack.Text = "Attack: " + hero.Attack;
            textMAH.Text = "MAH: " + hero.MAH;
        }

        public void PerformAction()
        {
            if (btn.Name == "btnStrensthP")
            {
                hero.changeStrensth(true);
            }
            else if (btn.Name == "btnStrensthM")
            {
                hero.changeStrensth(false);
            }

            if (btn.Name == "btnDesterityP")
            {
                hero.changeDesterity(true);
            }
            else if (btn.Name == "btnDesterityM")
            {
                hero.changeDesterity(false);
            }

            if (btn.Name == "btnConstitutP")
            {
                hero.changeConstitution(true);
            }
            else if (btn.Name == "btnConstitutM")
            {
                hero.changeConstitution(false);
            }

            if (btn.Name == "btnIntelP")
            {
                hero.changeIntellisense(true);
            }
            else if (btn.Name == "btnIntelM")
            {
                hero.changeIntellisense(false);
            }
        }

        private void cmbBoxHero_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // dopHP.Text = " ";
            // dopMP.Text = " ";
            // dopAttack.Text = " ";
            // dopPdet.Text = " ";
            // dopMAH.Text = " ";
            
            txtHP = 0;
            txtMP = 0;
            txtAttack = 0;
            txtPdet = 0;
            txtMAH = 0;
            
            
            ComboBox cmbBoxHero = (ComboBox)this.FindName("cmbBoxHero");
            try
            {
                cmbBoxHero.ItemsSource = MongoDBAction.AddListHeroes();
            }
            catch (Exception ex)
            {
                cmbBoxHero.ItemsSource = null;
            }
           

            ComboBox cmbBoxAbility = (ComboBox)this.FindName("cmbBoxAbility");
   

            Unit lHero = MongoDBAction.FindByName(cmbBoxHero.Text);
            IsUnit(MongoDBAction.FindByName(cmbBoxHero.Text).GetType().Name);

            hero.setCharacter(lHero.CurrentStrensth, lHero.CurrentDesterity, lHero.CurrentConstitution, lHero.CurrentIntellisense);
            SetProgressBarValue();
            SetTextCharacter();
            
            boxName.Text = cmbBoxHero.Text;
            hero.Inventory = lHero.Inventory;
            hero.Exp = lHero.Exp;
            hero.Equipments = lHero.Equipments;
            setEquipmentAbilities();

         

            ListBox inventoryListBox = (ListBox)this.FindName("ListBoxInventory");
            inventoryListBox.Items.Clear();

            foreach (var itemUnit in hero.Inventory)
            {
                inventoryListBox.Items.Add(itemUnit.ItemName + " | " + itemUnit.ItemCount);
            }
            ProgressBar barLevel = (ProgressBar)this.FindName("barExperience");

            setLevel(barLevel);
            barExperience.Value = hero.Exp;
            txtLevel.Text = hero.Level + "Lvl.";


            List<string> list = new List<string>();

            for (int i = 0; i < hero.Level+2; i++)
            {
                list.Add(strAbility[i]);
            }
            cmbBoxAbility.ItemsSource = list;

            ComboBox eqComboBox = (ComboBox)this.FindName("cmbBoxEquipment");
            var listEq = GetLimitEquipment();
            eqComboBox.ItemsSource = listEq.Select(equipment => equipment.EqpmtLevel + " " + equipment.EqpmtName);

        
            
            ListBox listBoxEquipment = (ListBox)this.FindName("listBoxEquipment");
            listBoxEquipment.Items.Clear();

            foreach (var itemUnit in hero.Equipments)
            {
                listBoxEquipment.Items.Add(itemUnit.EqpmtLevel + " | " + itemUnit.EqpmtName);
            }


        
            
            //CategoryHighlightStyleSelector styleSelector = new CategoryHighlightStyleSelector(hero);

        }

        private void CmbBoxWeapon_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            List<Item> listWeapon = new List<Item> { new Item("Glock", 1), new Item("Knife", 1), new Item("Cucumber", 13) };
            ComboBox cmbBoxWeapon = (ComboBox)this.FindName("cmbBoxWeapon");

            cmbBoxWeapon.ItemsSource = listWeapon.Select(item => item.ItemName);

            foreach (var item in listWeapon)
            {
                if (item.ItemName == cmbBoxWeapon.Text)
                {
                    hero.AddToInvertory(new Item(item.ItemName, item.ItemCount));
                }
            }

            ListBox inventoryListBox = (ListBox)this.FindName("ListBoxInventory");
            inventoryListBox.Items.Clear();

            foreach (var itemUnit in hero.inventory)
            {
                inventoryListBox.Items.Add(itemUnit.ItemName + " | " + itemUnit.ItemCount);
            }
        }

        private void btnItem_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;

            switch (btn.Name)
            {
                case "btnItemM":
                    try
                    {
                        textItemCnt.Text = Convert.ToString(int.Parse(textItemCnt.Text)-1);
                    }
                    catch (Exception exception)
                    {
                        textItemCnt.Text = "0";
                    }
                    break;
                case "btnItemP":
                    try
                    {
                        textItemCnt.Text = Convert.ToString(int.Parse(textItemCnt.Text)+1);
                    }
                    catch (Exception exception)
                    {
                        textItemCnt.Text = "0";
                    }
                    break;
                case "btnItemDelete":
                {
                    ListBox inventoryListBox = (ListBox)this.FindName("ListBoxInventory");
                    var item = hero.Inventory.Find(x => x.ItemName == textBox.Text);

                    hero.Inventory.Remove(item);
                    inventoryListBox.Items.Clear();
                    
                    foreach (var itemUnit in hero.inventory)
                    {
                        inventoryListBox.Items.Add(itemUnit.ItemName + " | " + itemUnit.ItemCount);
                    }
                    MessageBox.Show(hero.Inventory.Count.ToString());
                    break;
                }
                case "btnItemAdd":
                {
                    ListBox inventoryListBox = (ListBox)this.FindName("ListBoxInventory");
             
                    inventoryListBox.Items.Clear();
                    hero.AddToInvertory(new Item(boxItemName.Text, int.Parse(textItemCnt.Text)));
                
                    inventoryListBox = (ListBox)this.FindName("ListBoxInventory");
                    inventoryListBox.Items.Clear();

                    foreach (var itemUnit in hero.inventory)
                    {
                        inventoryListBox.Items.Add(itemUnit.ItemName + " | " + itemUnit.ItemCount);
                    }
                    break;
                }
                case "btnItemUpdate":
                {
                    ListBox inventoryListBox = (ListBox)this.FindName("ListBoxInventory");
                
                    foreach (var item in hero.Inventory)
                    {
                        if (item.ItemName == textBox.Text)
                        {
                            item.ItemCount = int.Parse(this.textItemCnt.Text);
                        }
                    }
                
                    inventoryListBox.Items.Clear();

                    foreach (var itemUnit in hero.inventory)
                    {
                        inventoryListBox.Items.Add(itemUnit.ItemName + " | " + itemUnit.ItemCount);
                    }
                    break;
                }
            }
        }

        private void ListBoxInventory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBox list = (ListBox)sender;
            String[] strItem = Convert.ToString(list.SelectedItem).Split('|');
            textBox.Text = strItem[0].Trim();

            try
            {
                textItemCnt.Text = strItem[1].Trim();
            }
            catch (Exception exception)
            {
                textItemCnt.Text = "0";
            }
        }

        private void btnUp_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;

            if (hero == null)
            {
                MessageBox.Show("Choose unit !!!");
                hero = new Warrior();
                hero.Level = 0;
            }

            ProgressBar barLevel = (ProgressBar)this.FindName("barExperience");

            switch (btn.Name)
            {
                case "btnUp100":
                    hero.Exp += 100;
                 
                    break;
                case "btnUp200":
                    hero.Exp += 200;

                    break;
                case "btnUp1000":
                    hero.Exp += 1000;
                    break;
           }

            hero.Level = hero.Exp;

            setLevel(barLevel);

            List<string> list = new List<string>();

            for (int i = 0; i < hero.Level + 2; i++)
            {
                list.Add(strAbility[i]);
            }
            cmbBoxAbility.ItemsSource = list;
            //if (hero.Exp > nextLvl * 1000 * nextLvl - hero.Level * 1000)
            //{
            //    hero.Level++;
            //}


            //barLevel.Minimum = nextLvl * 1000 * hero.Level - hero.Level * 1000;
            //barLevel.Maximum = nextLvl * 1000 * nextLvl - hero.Level * 1000;

            //btnUp100.Content = barExperience.Minimum;
            //btnUp200.Content = barExperience.Maximum;

         


            barExperience.Value = hero.Exp;
            txtLevel.Text = hero.Level + "Lvl.";
        }

        private void setLevel(ProgressBar barLevel)
        {
            if (hero.Exp > 0 && hero.Exp < 1000)
            {
                hero.Level = 0;
                barLevel.Minimum = 0;
                barLevel.Maximum = 1000;
            }

            else if (hero.Exp > 1000 && hero.Exp < 3000)
            {
                hero.Level = 1;
                barLevel.Minimum = 1000;
                barLevel.Maximum = 3000;
            }

            else if (hero.Exp >= 3000 && hero.Exp < 6000)
            {
                hero.Level = 2;
                barLevel.Minimum = 3000;
                barLevel.Maximum = 6000;
            }

            else if (hero.Exp >= 6000 && hero.Exp < 10000)
            {
                hero.Level = 3;
                barLevel.Minimum = 6000;
                barLevel.Maximum = 10000;
            }

            else if (hero.Exp >= 10000 && hero.Exp < 15000)
            {
                hero.Level = 4;
                barLevel.Minimum = 10000;
                barLevel.Maximum = 15000;
            }

            else if (hero.Exp >= 15000 && hero.Exp < 210000)
            {
                hero.Level = 5;
                barLevel.Minimum = 15000;
                barLevel.Maximum = 21000;
            }
        }

        private void cmbBoxEquipment_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox eqComboBox = (ComboBox)this.FindName("cmbBoxEquipment");
            var listEq = GetLimitEquipment();
            
            eqComboBox.ItemsSource = listEq.Select(equipment => equipment.EqpmtLevel + " " + equipment.EqpmtName);
                
            
            
            
            
            foreach (var equipment in listEq)
            {
                if (IsEquipmentAvailable(equipment.EqpmtType))
                {
                    
                        if (equipment.EqpmtLevel + " " + equipment.EqpmtName == eqComboBox.Text)
                        {
                            if (IsEquipmentOpen(equipment) == 0)
                            {
                                switch (equipment.GetType().Name)
                                {
                                    case "Revolver":
                                        hero.AddToEquipments(new Revolver());
                                        break;
                                    case "Musket":
                                        hero.AddToEquipments(new Musket());
                                        break;
                                    case "SniperRifle":
                                        hero.AddToEquipments(new SniperRifle());
                                        break;
                                    
                                    case "LeatherHelmet":
                                        hero.AddToEquipments(new LeatherHelmet());
                                        break;
                                    case "IronHelmet":
                                        hero.AddToEquipments(new IronHelmet());
                                        break;
                                    case "ModernHelmet":
                                        hero.AddToEquipments(new ModernHelmet());
                                        break;
                                    
                                    case "LeatherArmor":
                                        hero.AddToEquipments(new LeatherArmor());
                                        break;
                                    case "IronArmor":
                                        hero.AddToEquipments(new IronArmor());
                                        break;
                                    case "ModernArmor":
                                        hero.AddToEquipments(new ModernArmor());
                                        break;
                                }

                                setEquipmentAbilities();
                                
                                MessageBox.Show(equipment.EqpmtName);
                                break;
                        }
                    }
                }
                //MessageBox.Show(equipment.EqpmtName + " | " + eqComboBox.Text);
            }
            
            ListBox listBoxEquipment = (ListBox)this.FindName("listBoxEquipment");
            listBoxEquipment.Items.Clear();

            foreach (var itemUnit in hero.Equipments)
            {
                listBoxEquipment.Items.Add(itemUnit.EqpmtLevel + " | " + itemUnit.EqpmtName);
            }
        }

        public List<Equipment> GetLimitEquipment()
        {
            equipment1 = new List<Equipment> { new LeatherHelmet(), new LeatherArmor(), new Revolver()};
            equipment2 = new List<Equipment> { new IronHelmet(), new IronArmor(), new Musket() };
            equipment3 = new List<Equipment> { new ModernHelmet(), new ModernArmor(), new SniperRifle()};
            
            var allProducts2 = new List<Equipment>(equipment1.Count + equipment2.Count);
            allProducts2.AddRange(equipment1);
            allProducts2.AddRange(equipment2);

            var allProducts3 = new List<Equipment>(equipment1.Count + equipment2.Count + equipment3.Count);
            allProducts3.AddRange(equipment1);
            allProducts3.AddRange(equipment2);
            allProducts3.AddRange(equipment3);
            
            

            List<Equipment> listEq = new List<Equipment>();

            if (hero.Level <= 1)
            {
                listEq = equipment1;
            }
            else if (hero.Level > 1 && hero.Level <= 3)
            {
                listEq = allProducts2;
            }
            else if (hero.Level > 3)
            {
                listEq = allProducts3;
            }
            else
            {
                listEq = equipment1;
            }
            
            return listEq;
        }

        public bool IsEquipmentAvailable(String eqpmtType)
        {
            foreach (var itemUnit in hero.Equipments)
            {
                if (itemUnit.EqpmtType == eqpmtType)
                {
                    //MessageBox.Show("false");
                    return false;
                }
            }
            return true;
        }
        
        public int IsEquipmentOpen(Equipment equipment)
        {
            List<String> needList = new List<string>();
            int countNeed = 0;
            
            if (hero.CurrentDesterity >= equipment.Desterity) { }
            else
            {
                needList.Add("you need Desterity:" + (equipment.Desterity - hero.CurrentDesterity).ToString());
                countNeed++; 
            }
            
            if (hero.CurrentStrensth >= equipment.Strensth) { }
            else
            {
                needList.Add("you need Strensth:" + (equipment.Strensth - hero.CurrentStrensth).ToString());
                countNeed++; 
            }
            
            if (hero.CurrentConstitution >= equipment.Constitution) {  }
            else
            {
                needList.Add("you need Constitution:" + (equipment.Constitution - hero.CurrentConstitution).ToString());
                countNeed++;
            }
            
            if (hero.CurrentIntellisense >= equipment.Intellisense) {  }
            else
            {
                needList.Add("you need Intellisense:" + (equipment.Intellisense - hero.CurrentIntellisense).ToString());
                countNeed++;
            }
            

            if (countNeed != 0)
            {
                String strNeed = "";
                foreach (var strMsg in needList)
                {
                    strNeed += strMsg + Environment.NewLine;
                }

                MessageBox.Show(strNeed);
            }
            
            return countNeed;
        }

        public void setEquipmentAbilities()
        {

            foreach (var equipment in hero.equipment)
            {
                hero.HP += equipment.HP;
                hero.MP += equipment.MP;
                hero.Attack += equipment.Attack;
                hero.PDet += equipment.PDet;
                hero.MAH += equipment.MAH;


                dopHP.Text = equipment.HP.ToString();

                txtHP  += equipment.HP;
                txtMP  += equipment.MP;
                txtAttack  += equipment.Attack;
                txtPdet  += equipment.PDet;
                txtMAH  += equipment.MAH;
                
                dopHP.Text = "+" + txtHP.ToString();
                dopMP.Text = "+" + txtMP.ToString();
                dopAttack.Text = "+" + txtAttack.ToString();
                dopPdet.Text = "+" + txtPdet.ToString();
                dopMAH.Text = "+" + txtMAH.ToString();
                
                if (txtHP == 0)
                {
                    dopHP.Text = " ";
                }
                
                if (txtMP == 0)
                {
                    dopMP.Text = " ";
                }
                
                if (txtAttack == 0)
                {
                    dopAttack.Text = " ";
                }
                
                if (txtPdet == 0)
                {
                    dopPdet.Text = " ";
                }
                
                if (txtMAH == 0)
                {
                    dopMAH.Text = " ";
                }
                
              
               
            }
            
            
            SetTextCharacter();

        }

        private void cmbBoxAbility_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            List<string> list = new List<string>();

            for (int i = 0; i < hero.Level + 2; i++)
            {
                list.Add(strAbility[i]);
            }
            cmbBoxAbility.ItemsSource = list;
        }

        private void listBoxAbility_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBox list = (ListBox)sender;
            String strItem = Convert.ToString(list.SelectedItem);
        

          //  MessageBox.Show(strItem);
            
            var listEq = GetLimitEquipment();
            
                //eqComboBox.ItemsSource = listEq.Select(equipment => equipment.EqpmtLevel + " " + equipment.EqpmtName);
            
            
            foreach (var equipment in listEq)
            {
                if (IsEquipmentAvailable(equipment.EqpmtType))
                {
                    
                        if (equipment.EqpmtLevel + " " + equipment.EqpmtName == sender.ToString())
                        {
                            if (IsEquipmentOpen(equipment) == 0)
                            {
                                switch (equipment.GetType().Name)
                                {
                                    case "Revolver":
                                        hero.AddToEquipments(new Revolver());
                                        break;
                                    case "Musket":
                                        hero.AddToEquipments(new Musket());
                                        break;
                                    case "SniperRifle":
                                        hero.AddToEquipments(new SniperRifle());
                                        break;
                                    
                                    case "LeatherHelmet":
                                        hero.AddToEquipments(new LeatherHelmet());
                                        break;
                                    case "IronHelmet":
                                        hero.AddToEquipments(new IronHelmet());
                                        break;
                                    case "ModernHelmet":
                                        hero.AddToEquipments(new ModernHelmet());
                                        break;
                                    
                                    case "LeatherArmor":
                                        hero.AddToEquipments(new LeatherArmor());
                                        break;
                                    case "IronArmor":
                                        hero.AddToEquipments(new IronArmor());
                                        break;
                                    case "ModernArmor":
                                        hero.AddToEquipments(new ModernArmor());
                                        break;
                                }

                                setEquipmentAbilities();
                                
                                MessageBox.Show(equipment.EqpmtName);
                                break;
                        }
                    }
                }
                //MessageBox.Show(equipment.EqpmtName + " | " + eqComboBox.Text);
            }
            
            ListBox listBoxEquipment = (ListBox)this.FindName("listBoxEquipment");
            listBoxEquipment.Items.Clear();

            foreach (var itemUnit in hero.Equipments)
            {
                listBoxEquipment.Items.Add(itemUnit.EqpmtLevel + " | " + itemUnit.EqpmtName);
            }


          

        }

     
    }

    public class CategoryHighlightStyleSelector : StyleSelector
    {
        public Style EconomyClassStyle { get; set; }
        public Style MiddleClassStyle { get; set; }
        public Style BuisnessClassStyle { get; set; }
        public Style PremiumClassStyle { get; set; }

        public Unit Hero { get; set; }


        public CategoryHighlightStyleSelector()
        {
    
        }

        public CategoryHighlightStyleSelector(Unit hero)
        {
            Hero = hero;
        }
        
        public override Style SelectStyle(object item, DependencyObject container)
        {

            // Revolver musket = new Revolver();
         
             
            
            Random rnd = new Random();
           
          
                int xRnd = rnd.Next(1, 5);
                switch ( xRnd)
                {
                    case 1:
                        return EconomyClassStyle;
                    case 2:
                        return MiddleClassStyle;
                    case 3:
                        return BuisnessClassStyle;
                    case 4:
                        return PremiumClassStyle;
                    default:
                        return null;
                }
            }
    }
}
