﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Xml.Linq;
using ExWarcraftWPF.enumUnits;
using ExWarcraftWPF.MongoDB;
using ExWarcraftWPF.res;
using Microsoft.Win32;

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
        
        public MainWindow()
        {
            InitializeComponent();
            List<Item> listWeapon = new List<Item> { new Item("Glock", 1), new Item("Knife", 1), new Item("Cucumber", 13) };
            ComboBox cmbBoxWeapon = (ComboBox)this.FindName("cmbBoxWeapon");

            ComboBox cmbBoxHero = (ComboBox)this.FindName("cmbBoxHero");
            cmbBoxHero.ItemsSource = MongoDBAction.AddListHeroes();
            inventoryListBox = (ListBox)this.FindName("ListBoxInventory");
            
            textBox = (TextBox)this.FindName("boxItemName");
            textCnt = (TextBlock)this.FindName("textItemCnt");
            boxName = (TextBox)this.FindName("btnName");
            
            cmbBoxWeapon.ItemsSource = listWeapon.Select(item => item.ItemName);
            inventoryListBox.SelectionChanged += ListBoxInventory_SelectionChanged;
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton pressed = (RadioButton)sender;
            textHero.Text = pressed.Content.ToString();
            boxName.Text = "";
            isUnit(pressed.Content.ToString());
            SetTextCharacter();
            SetProgressBarValue();
            ListBox inventoryListBox = (ListBox)this.FindName("ListBoxInventory");
            inventoryListBox.Items.Clear();
        }

        public void isUnit(String unitType)
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

                        isUnit(unitInfo[0]);
                        hero.setCharacter(int.Parse(unitInfo[1]), int.Parse(unitInfo[2]), int.Parse(unitInfo[3]), int.Parse(unitInfo[4]));

                        SetProgressBarValue();
                        SetTextCharacter();
                    }
                }
            }

            else if (menuItem.Header.ToString() == "Load mongo db")
            {
                Unit lHero = MongoDBAction.FindByName(boxName.Text);
                isUnit(MongoDBAction.FindByName(boxName.Text).GetType().Name);

                hero.setCharacter(lHero.CurrentStrensth, lHero.CurrentDesterity, lHero.CurrentConstitution, lHero.CurrentIntellisense);
                SetProgressBarValue();
                SetTextCharacter();
                
                hero.Inventory = lHero.Inventory;

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
            ComboBox cmbBoxHero = (ComboBox)this.FindName("cmbBoxHero");
            cmbBoxHero.ItemsSource = MongoDBAction.AddListHeroes();

            Unit lHero = MongoDBAction.FindByName(cmbBoxHero.Text);
            isUnit(MongoDBAction.FindByName(cmbBoxHero.Text).GetType().Name);

            hero.setCharacter(lHero.CurrentStrensth, lHero.CurrentDesterity, lHero.CurrentConstitution, lHero.CurrentIntellisense);
            SetProgressBarValue();
            SetTextCharacter();
            
            boxName.Text = cmbBoxHero.Text;
            hero.Inventory = lHero.Inventory;

            ListBox inventoryListBox = (ListBox)this.FindName("ListBoxInventory");
            inventoryListBox.Items.Clear();

            foreach (var itemUnit in hero.Inventory)
            {
                inventoryListBox.Items.Add(itemUnit.ItemName + " | " + itemUnit.ItemCount);
            }
        }

        private void cmbBoxWeapon_SelectionChanged(object sender, SelectionChangedEventArgs e)
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
    }
}
