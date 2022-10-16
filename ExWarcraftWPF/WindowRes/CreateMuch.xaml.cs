using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using ExWarcraftWPF.enumUnits;
using ExWarcraftWPF.MongoDB;
using ExWarcraftWPF.res;

namespace ExWarcraftWPF.WindowRes
{
    public partial class CreateMuch : Window
    {
        public Unit hero = null;
        private List<Unit> listHeroes = new List<Unit>();
        private List<String> listNamesHeroes = new List<String>();

        private List<Unit> teamUnit1 = new List<Unit>();
        private List<Unit> teamUnit2 = new List<Unit>();

        private int clickIsFirst = 0;
        public String chooseHero = "";

        public CreateMuch()
        {
            InitializeComponent();
            
            listNamesHeroes = MongoDBAction.AddListHeroes();
            foreach (var itemHero in listNamesHeroes)
            {
                Unit lHero = MongoDBAction.FindByName(itemHero);
                listHeroes.Add(lHero);
            }
            ShowHeroList();
        }
        
        
        private void btnAutho_Click(object sender, RoutedEventArgs e)
        {
            if (clickIsFirst == 1)
            {
                ResetView();
            }
            clickIsFirst = 1;
            SetAuthoGenerate();
            
            while (true) 
            {
                if (IsContinue()) { break; }
                else
                {
                    ResetView();
                    SetAuthoGenerate();
                }
            }
        }

        private void SetAuthoGenerate()
        {
            List<Unit> list = listHeroes;
            Random rndHero = new Random();
            Random rndTeam = new Random();
            
            int isTeam1Full = 0;
            int isTeam2Full = 0;
            int isFull = 0;
            
            while (isFull != 2)
            {
                var currentHero = listHeroes[rndHero.Next(0, listHeroes.Count)];
                
                if (rndTeam.Next(0, 2) == 0)
                {
                    if (teamUnit1.Count <= 5)
                    {
                        teamUnit1.Add(currentHero);
                        ShowTeamList(1);
                    }
                    else
                    {
                        isTeam1Full = 1;
                    }
                }
                else
                {
                    if (teamUnit2.Count <= 5)
                    {
                        teamUnit2.Add(currentHero);
                        ShowTeamList(2);
                    }
                    else
                    {
                        isTeam2Full = 1;
                    }
                }
                listHeroes.Remove(hero);
                isFull = isTeam1Full + isTeam2Full;
            }
            txtAverage1.Text = string.Format("{0:N1}", CalculateAverageLvl(teamUnit1));
            txtAverage2.Text = string.Format("{0:N1}", CalculateAverageLvl(teamUnit2));
            ShowHeroList();
        }
        
        private bool IsContinue()
        {
            if (Math.Abs(CalculateAverageLvl(teamUnit1) - CalculateAverageLvl(teamUnit2)) < 1.0)
            {
                btnContinue.Background = Brushes.PaleGreen;
                return true;
            }
            else
            {
                btnContinue.Background = Brushes.Crimson;
                return false;
            }
        }


        private double CalculateAverageLvl(List<Unit> team)
        {
            double averageTeam = 0;

            foreach (var hero in team)
            {
                averageTeam += hero.Level;
            }
            averageTeam /= team.Count;
            return averageTeam;
        }

        private void ShowTeamList(int team)
        {
            if (team == 1)
            {
                listBoxTeam1.Items.Clear();

                foreach (var itemHero in teamUnit1)
                {
                    hero = itemHero;
                    setLevel(itemHero.Exp);
                    listBoxTeam1.Items.Add(itemHero.Level + " | " + itemHero.Name);
                } 
            }
            else
            {
                listBoxTeam2.Items.Clear();

                foreach (var itemHero in teamUnit2)
                {
                    hero = itemHero;
                    setLevel(itemHero.Exp);
                    listBoxTeam2.Items.Add(itemHero.Level + " | " + itemHero.Name);
                } 
            }
        }

        private void ShowHeroList()
        {
            listBoxHero.Items.Clear();

            foreach (var itemHero in listHeroes)
            {
                hero = itemHero;
                setLevel(itemHero.Exp);
                listBoxHero.Items.Add(itemHero.Level + " | " + itemHero.Name);
            }
        }
        
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MenuItem menuItem = (MenuItem) sender;

            if (menuItem.Header.ToString() == "back")
            {
                MainWindow winMain = new MainWindow();
                winMain.Show();
                this.Close();
            } 
            
            else if (menuItem.Header.ToString() == "reset")
            {
               ResetView();
            }
            
        }

        private void listBoxHero_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBox list = (ListBox)sender;
            String[] strItem = Convert.ToString(list.SelectedItem).Split('|');
            
           try
           {
               chooseHero = strItem[1].Trim();
           }
           catch (Exception exception)
           {
               chooseHero = " ";
           }
        }

        public void ResetView()
        {
            listNamesHeroes.Clear();
            listNamesHeroes = MongoDBAction.AddListHeroes();
            listHeroes.Clear();
            teamUnit1.Clear();
            teamUnit2.Clear();
            txtAverage1.Text = "";
            txtAverage2.Text = "";
                
            foreach (var itemHero in listNamesHeroes)
            {
                Unit lHero = MongoDBAction.FindByName(itemHero);
                listHeroes.Add(lHero);
            }
            ShowHeroList();
            ShowTeamList(1);
            ShowTeamList(2);
        }
        
        private void setLevel(int exp)
        {
            if (exp > 0 && exp < 1000)
            {
                hero.Level = 0;
            }

            else if (exp > 1000 && exp < 3000)
            {
                hero.Level = 1;
            }

            else if (exp >= 3000 && exp < 6000)
            {
                hero.Level = 2;
            }

            else if (exp >= 6000 && exp < 10000)
            {
                hero.Level = 3;
            }

            else if (exp >= 10000 && exp < 15000)
            {
                hero.Level = 4;
            }

            else if (exp >= 15000 && exp < 210000)
            {
                hero.Level = 5;
            }
        }

        private void btnAddTeam_Click(object sender, RoutedEventArgs e)
        {
            Button btnTeam = (Button)sender;
            Unit currentHero = null;

            foreach (var heroItem in listHeroes)
            {
                if (heroItem.Name == chooseHero)
                {
                    currentHero = heroItem;
                }
            }

            if (btnTeam.Name == "btnAddTeam1")
            {
                teamUnit1.Add(currentHero);
                ShowTeamList(1);
                listHeroes.Remove(currentHero);
            }
            
            else if (btnTeam.Name == "btnAddTeam2")
            {
                teamUnit2.Add(currentHero);
                ShowTeamList(2);
                listHeroes.Remove(currentHero);
            }
            ShowHeroList();
            IsContinue();
            txtAverage1.Text = string.Format("{0:N1}", CalculateAverageLvl(teamUnit1));
            txtAverage2.Text = string.Format("{0:N1}", CalculateAverageLvl(teamUnit2));
        }
    }
}
