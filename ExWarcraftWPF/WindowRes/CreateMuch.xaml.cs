using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using ExWarcraftWPF.enumUnits;
using ExWarcraftWPF.MongoDB;
using ExWarcraftWPF.res;
using ExWarcraftWPF.Match;
using ExWarcraftWPF.MongoDB;
using ExWarcraftWPF.MongoDBa;

namespace ExWarcraftWPF.WindowRes
{
    public partial class CreateMuch : Window
    {
        public MatchInfo match = new MatchInfo();
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
            ShowMatchInfo();
            match.ListHeroes = listHeroes;
            match.TeamUnit1 = teamUnit1;
            match.TeamUnit2 = teamUnit2;

            listNamesHeroes = MongoDBAction.AddListHeroes();
            foreach (var itemHero in listNamesHeroes)
            {
                Unit lHero = MongoDBAction.FindByName(itemHero);
                match.ListHeroes.Add(lHero);
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
                if (IsContinue())
                {
                    break;
                }
                else
                {
                    ResetView();
                    SetAuthoGenerate();
                }
            }
        }

        private void SetAuthoGenerate()
        {
            List<Unit> list = match.ListHeroes;
            Random rndHero = new Random();
            Random rndTeam = new Random();

            int isTeam1Full = 0;
            int isTeam2Full = 0;
            int isFull = 0;

            while (isFull != 2)
            {
                var currentHero = match.ListHeroes[rndHero.Next(0, match.ListHeroes.Count)];

                if (rndTeam.Next(0, 2) == 0)
                {
                    if (match.TeamUnit1.Count <= 5)
                    {
                        match.TeamUnit1.Add(currentHero);
                        ShowTeamList(1);
                    }
                    else
                    {
                        isTeam1Full = 1;
                    }
                }
                else
                {
                    if (match.TeamUnit2.Count <= 5)
                    {
                        match.TeamUnit2.Add(currentHero);
                        ShowTeamList(2);
                    }
                    else
                    {
                        isTeam2Full = 1;
                    }
                }

                match.ListHeroes.Remove(hero);
                isFull = isTeam1Full + isTeam2Full;
            }

            txtAverage1.Text = string.Format("{0:N1}", CalculateAverageLvl(match.TeamUnit1));
            txtAverage2.Text = string.Format("{0:N1}", CalculateAverageLvl(match.TeamUnit2));
            ShowHeroList();
        }

        private bool IsContinue()
        {
            if (Math.Abs(CalculateAverageLvl(match.TeamUnit1) - CalculateAverageLvl(match.TeamUnit2)) < 1.0)
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

                foreach (var itemHero in match.TeamUnit1)
                {
                    hero = itemHero;
                    setLevel(itemHero.Exp);
                    listBoxTeam1.Items.Add(itemHero.Level + " | " + itemHero.Name);
                }
            }
            else
            {
                listBoxTeam2.Items.Clear();

                foreach (var itemHero in match.TeamUnit2)
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

            foreach (var itemHero in match.ListHeroes)
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
            ListBox list = (ListBox) sender;
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
            match.ListHeroes.Clear();
            match.TeamUnit1.Clear();
            match.TeamUnit2.Clear();
            txtAverage1.Text = "";
            txtAverage2.Text = "";
            
            btnAutho.Visibility = Visibility.Visible;
            btnContinue.Visibility = Visibility.Visible;
            btnAddTeam1.Visibility = Visibility.Visible;
            btnAddTeam2.Visibility = Visibility.Visible;

            foreach (var itemHero in listNamesHeroes)
            {
                Unit lHero = MongoDBAction.FindByName(itemHero);
                match.ListHeroes.Add(lHero);
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
            Button btnTeam = (Button) sender;
            Unit currentHero = null;

            foreach (var heroItem in match.ListHeroes)
            {
                if (heroItem.Name == chooseHero)
                {
                    currentHero = heroItem;
                }
            }

            if (btnTeam.Name == "btnAddTeam1")
            {
                match.TeamUnit1.Add(currentHero);
                ShowTeamList(1);
                match.ListHeroes.Remove(currentHero);
            }

            else if (btnTeam.Name == "btnAddTeam2")
            {
                match.TeamUnit2.Add(currentHero);
                ShowTeamList(2);
                match.ListHeroes.Remove(currentHero);
            }

            ShowHeroList();
            IsContinue();
            txtAverage1.Text = string.Format("{0:N1}", CalculateAverageLvl(match.TeamUnit1));
            txtAverage2.Text = string.Format("{0:N1}", CalculateAverageLvl(match.TeamUnit2));
        }

        private void cmbBoxMatchInfo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        { 
            ResetView();
           
            //listHeroes.Clear();

            MatchDb matchInfo = MongoDBAction.FindByDateMatch(cmbBoxMatchInfo.Text);

            btnAutho.Visibility = Visibility.Hidden;
            btnContinue.Visibility = Visibility.Hidden;
            btnAddTeam1.Visibility = Visibility.Hidden;
            btnAddTeam2.Visibility = Visibility.Hidden;

            try
            {
                foreach (var hero in matchInfo.ListHeroes)
                {
                    match.ListHeroes.Add(CharacterToUnit(hero));
                }
                
                foreach (var hero in matchInfo.TeamUnit1)
                {
                    match.TeamUnit1.Add(CharacterToUnit(hero));
                }
                
                foreach (var hero in matchInfo.TeamUnit2)
                {
                    match.TeamUnit2.Add(CharacterToUnit(hero));
                }
             
                ShowHeroList();
                ShowTeamList(1);
                ShowTeamList(2);
                
                txtAverage1.Text = string.Format("{0:N1}", CalculateAverageLvl(match.TeamUnit1));
                txtAverage2.Text = string.Format("{0:N1}", CalculateAverageLvl(match.TeamUnit2));

            }
            catch (Exception exception)
            {
                ShowHeroList();
            }



            cmbBoxMatchInfo.Items.Clear();
            ShowMatchInfo();
        }


        public Unit CharacterToUnit(CharacterDb unit)
        {
            if (unit == null)
            {
                return null;
            }

            switch (unit.ClassName)
            {
                case "Warrior":
                    return new Warrior(unit.Strength,
                            unit.Dexterity,
                            unit.Constitution,
                            unit.Intellisense,
                            unit.Items,
                            unit.Exp,
                            unit.Equipments)
                        {Name = unit.Name};

                case "Wizard":
                    return new Wizard(unit.Strength,
                            unit.Dexterity,
                            unit.Constitution,
                            unit.Intellisense,
                            unit.Items,
                            unit.Exp,
                            unit.Equipments)
                        {Name = unit.Name};

                case "Rogue":
                    return new Rogue(unit.Strength,
                            unit.Dexterity,
                            unit.Constitution,
                            unit.Intellisense,
                            unit.Items,
                            unit.Exp,
                            unit.Equipments)
                        {Name = unit.Name};
                default: return null;
            }
            return null;
        }







        private void btnContinue_Click(object sender, RoutedEventArgs e)
        {
          
            
            if (Math.Abs(CalculateAverageLvl(match.TeamUnit1) - CalculateAverageLvl(match.TeamUnit2)) < 1.0)
            {
                DateTime time = DateTime.Now;

                match.Date = time.ToString();
                MongoDBAction.AddMatchInfo(match);
                ShowMatchInfo();
                
                MessageBox.Show("success!");
            }
            else
            {
                MessageBox.Show("no blalance!");
            }
            
            
        }

        private void ShowMatchInfo()
        {
            cmbBoxMatchInfo.Items.Clear();
            List<String> listMatch = MongoDBAction.GetListMatchInfo();

            foreach (var match in listMatch)
            {
                cmbBoxMatchInfo.Items.Add(match);
            }
        }

        private void listBoxTeam1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBox list = (ListBox) sender;
            String[] strItem = Convert.ToString(list.SelectedItem).Split('|');

            try
            {
                foreach (var unit in teamUnit1)
                {
                    if (unit.Name == strItem[1].Trim())
                    {
                      
                        MainWindow mainWindow = new MainWindow(unit);
                        mainWindow.Show();
                    }
                }
            }
            catch (Exception exception)
            {
                chooseHero = " ";
            }

            
            
            
        }

        private void listBoxTeam2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBox list = (ListBox) sender;
            String[] strItem = Convert.ToString(list.SelectedItem).Split('|');

            try
            {
                foreach (var unit in teamUnit2)
                {
                    if (unit.Name == strItem[1].Trim())
                    {
                        MainWindow mainWindow = new MainWindow(unit);
                        mainWindow.Show();
                    }
                }
            }
            catch (Exception exception)
            {
                chooseHero = " ";
            }
        }

        private void btnHeroInfo_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
