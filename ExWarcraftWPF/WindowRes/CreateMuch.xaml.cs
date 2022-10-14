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
using System.Windows.Shapes;
using ExWarcraftWPF.enumUnits;
using ExWarcraftWPF.MongoDB;
using ExWarcraftWPF.res;


namespace ExWarcraftWPF.WindowRes
{
    /// <summary>
    /// Interaction logic for CreateMuch.xaml
    /// </summary>
    public partial class CreateMuch : Window
    {
        public Unit hero = null;
        
        private List<Unit> listHeroes = new List<Unit>();
        private List<String> listNamesHeroes = new List<String>();

        private List<Unit> teamUnit1 = new List<Unit>();
        private List<Unit> teamUnit2 = new List<Unit>();

        private int clickIsFirst = 0;

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
                listNamesHeroes.Clear();
                listNamesHeroes = MongoDBAction.AddListHeroes();
                listHeroes.Clear();
                teamUnit1.Clear();
                teamUnit2.Clear();
                
                foreach (var itemHero in listNamesHeroes)
                {
                    Unit lHero = MongoDBAction.FindByName(itemHero);
                    listHeroes.Add(lHero);
                }
                ShowHeroList();
               
            }

            clickIsFirst = 1;
            
            
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
                //MessageBox.Show(isTeam1Full + " | " + isTeam2Full);
            }
            
            
            
            
            
            ShowHeroList();
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
        }

        private void listBoxHero_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
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

        
    }
}
