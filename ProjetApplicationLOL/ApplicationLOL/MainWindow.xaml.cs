using MetierAppliLOL;
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

namespace ApplicationLOL
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Initialize the main window, fill the championsList with created champions and Update all the main window listBoxes.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            foreach (Champion champion in Champion.Champions)
            {
                championsList.Add(champion);
            }

            UpdateListChampions();
            UpdateListFactions();
            UpdateListRoles();

        }

        /// <summary>
        /// The Champions list used to store the champions that are in the mListBoxChampions.
        /// </summary>
        List<Champion> championsList = new List<Champion>();

        /// <summary>
        /// Update the champion's list, subscribe to the MouseEnter event that 
        /// the Champion's UserControlInList may send and handle it with ChampionInListHovered
        /// </summary>
        private void UpdateListChampions()
        {
            mListBoxChampions.Items.Clear();

            foreach (Champion champion in championsList)
            {
                MyUserControls.UserControlChampionInList champInList = new MyUserControls.UserControlChampionInList() { Champion = champion };
                champInList.ChampionHovered += new EventHandler(ChampionInListHovered);
                mListBoxChampions.Items.Add(champInList);
                champion.PropertyChanged += Champion_PropertyChanged;
            }
        }

        /// <summary>
        /// Open a new tab when a Champion is selected in the list.
        /// </summary>
        /// <param name="sender">The UserControlChampionInList of the selected champion</param>
        /// <param name="e"></param>
        private void mListBoxChampions_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            MyUserControls.UserControlChampionInList champion = (sender as ListBox).SelectedItem as MyUserControls.UserControlChampionInList;

            if (champion == null)
            {
                return;
            }

            // Check if there already is a tabItem created with that Name.
            if (mTabControlMainWindow.Items.Cast<TabItem>().ToList().Exists(tabItem => tabItem.Name == champion.Champion.Name))
            {
                return;
            }

            TabItem newTab = new TabItem() { Name = champion.Champion.Name };
            newTab.DataContext = newTab;
            newTab.HeaderTemplate = Resources["tabItemHeaderTemplate"] as DataTemplate;
            newTab.Header = champion.Champion.Name;
            newTab.Content = new MyUserControls.UserControlTabChampion() { Champion = champion.Champion };
            newTab.Opacity = 0.5;
            mTabControlMainWindow.Items.Add(newTab);

            mTabControlMainWindow.SelectedItem = newTab;
        }


        /// <summary>
        /// Method that handle the arguments that the UserControlChampionInList might send with the ChampionHovered event.
        /// It'll display the hovered champion in the display section on the left with a quick resume of it's caracteristics.
        /// </summary>
        /// <param name="sender">The UserControlChampionInList of the hovered champion</param>
        /// <param name="e"></param>
        public void ChampionInListHovered(object sender, EventArgs e)
        {
            MyUserControls.UserControlChampionInList championHovered = sender as MyUserControls.UserControlChampionInList;

            if (championHovered == null)
            {
                return;
            }

            mViewBoxImageLogo.Visibility = Visibility.Hidden;
            mGridChampionSummary.Visibility = Visibility.Visible;

            mTextBlockChampionName.Text = championHovered.Champion.Name;
            mTextBlockChampionDignity.Text = championHovered.Champion.Dignity;
            mImageChampion.Source = new BitmapImage(new Uri("/MetierAppliLOL;component/Images/" + championHovered.Champion.IconPath, UriKind.Relative));

            mListBoxFactions.Items.Clear();
            foreach (Faction faction in championHovered.Champion.Factions)
            {
                mListBoxFactions.Items.Add(faction);

            }

            mListBoxRoles.Items.Clear();
            foreach (Role role in championHovered.Champion.Roles)
            {
                mListBoxRoles.Items.Add(role);
            }
        }

        /// <summary>
        /// Close the tab when its X button is clicked.
        /// </summary>
        /// <param name="sender">The clicked button</param>
        /// <param name="e"></param>
        private void mCloseTabButton_Click(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;
            String championName = (String)b.Tag;
            mTabControlMainWindow.Items.Remove(mTabControlMainWindow.Items.Cast<TabItem>().ToList().Where(item => item.Name == (String)b.Tag).First());

        }

        /// <summary>
        /// The text that the search box displays when unused.
        /// </summary>
        private String mSearchBoxBaseText = "Search";

        /// <summary>
        /// Empty the search box when someone click on it and the text is the one set in mSearchBoxBaseText.
        /// Also uncheck every filters as the Search Box is used to find a specific champion.
        /// </summary>
        /// <param name="sender">The TextBox of the search box</param>
        /// <param name="e"></param>
        private void mTextBoxSearch_GotFocus(object sender, RoutedEventArgs e)
        {
            foreach (CheckBox checkbox in mListBoxFiltersFactions.Items)
            {
                checkbox.IsChecked = false;
            }
            foreach (CheckBox checkbox in mListBoxFiltersRoles.Items)
            {
                checkbox.IsChecked = false;
            }

            if (mTextBoxSearch.Text == mSearchBoxBaseText)
            {
                mTextBoxSearch.Text = "";
            }
        }

        /// <summary>
        /// Replace a blank text in the search box by the base text specified in mSearchBox everytime the TextBox lose focus.
        /// </summary>
        /// <param name="sender">The TextBox of the search box. </param>
        /// <param name="e"></param>
        private void mTextBoxSearch_LostFocus(object sender, RoutedEventArgs e)
        {
            if (mTextBoxSearch.Text == "")
            {
                mTextBoxSearch.Text = mSearchBoxBaseText;
            }

        }

        /// <summary>
        /// Event : Triggered when the text in the textbox is changed. Will update the champion's list with
        /// Champions that have the searched text in their name.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mTextBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {

            TextBox SearchBox = sender as TextBox;

            if (SearchBox == null || SearchBox.Text == mSearchBoxBaseText)
            {
                return;
            }

            if (SearchBox.Text == "")
            {
                UpdateListChampions();
                return;
            }

            mListBoxChampions.SelectedIndex = -1;

            mListBoxChampions.Items.Clear();

            var ElementMatching = from i in Champion.Champions
                                  where i.Name.ToLower().Contains(SearchBox.Text.ToLower())
                                  select i;

            foreach (Champion champion in ElementMatching)
            {
                mListBoxChampions.Items.Add(new MyUserControls.UserControlChampionInList { Champion = champion });
            }
        }

        /// <summary>
        /// Event : when a property changed in a champion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Champion_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            Champion champion = sender as Champion;

            switch (e.Property)
            {
                case "Rating":
                    UpdateListChampions();
                    break;
            }
        }

        /// <summary>
        /// Update the different factions for the filters using the only ones the created champions have.
        /// </summary>
        private void UpdateListFactions()
        {
            mListBoxFiltersFactions.Items.Clear();

            var ListFactions = Enum.GetValues(typeof(Faction)).Cast<Faction>().Select(faction => (Faction)faction);

            List<Faction> ListFactions2 = new List<Faction>();
            foreach (Champion champion in Champion.Champions)
            {
                foreach (Faction faction in champion.Factions)
                {
                    ListFactions2.Add(faction);
                }
            }

            var ListFactions3 = ListFactions.Where(faction => ListFactions2.Contains(faction));

            foreach (Faction faction in ListFactions3)
            {
                CheckBox checkbox = new CheckBox() { Content = faction, Width = 120 };
                checkbox.Checked += CheckBox_Update;
                checkbox.Unchecked += CheckBox_Update;
                mListBoxFiltersFactions.Items.Add(checkbox);
            }
        }

        /// <summary>
        /// Update the different roles for the filters using the only ones the created champions have.
        /// </summary>
        private void UpdateListRoles()
        {
            mListBoxFiltersRoles.Items.Clear();

            var ListRoles = Enum.GetValues(typeof(Role)).Cast<Role>().Select(role => (Role)role);

            List<Role> ListRoles2 = new List<Role>();
            foreach (Champion champion in Champion.Champions)
            {
                foreach (Role role in champion.Roles)
                {
                    ListRoles2.Add(role);
                }
            }

            var ListRoles3 = ListRoles.Where(role => ListRoles2.Contains(role));

            foreach (Role role in ListRoles3)
            {
                CheckBox checkbox = new CheckBox() { Content = role, Width = 120 };
                checkbox.Checked += CheckBox_Update;
                checkbox.Unchecked += CheckBox_Update;
                mListBoxFiltersRoles.Items.Add(checkbox);
            }
        }

        /// <summary>
        /// Update the list of champions when a filter is checked or unchecked
        /// </summary>
        /// <param name="sender">CheckBox</param>
        /// <param name="e"></param>
        private void CheckBox_Update(object sender, RoutedEventArgs e)
        {
            mTextBoxSearch.Text = mSearchBoxBaseText;

            mListBoxChampions.Items.Clear();

            List<Faction> listFactionsChecked = new List<Faction>();
            foreach (CheckBox checkbox in mListBoxFiltersFactions.Items)
            {
                if ((bool)checkbox.IsChecked)
                {
                    listFactionsChecked.Add((Faction)checkbox.Content);
                }
            }
            listFactionsChecked.Distinct();

            List<Role> listRolesChecked = new List<Role>();
            foreach (CheckBox checkbox in mListBoxFiltersRoles.Items)
            {
                if ((bool)checkbox.IsChecked)
                {
                    listRolesChecked.Add((Role)checkbox.Content);
                }
            }
            listRolesChecked.Distinct();

            championsList.Clear();

            if (!listRolesChecked.Any() && !listFactionsChecked.Any())
            {
                foreach (Champion champion in Champion.Champions)
                {
                    championsList.Add(champion);
                }
            }
            else
            {
                foreach (Champion champion in Champion.Champions)
                {
                    if (!listFactionsChecked.Any())
                    {
                        if (champion.Roles.Intersect(listRolesChecked).Any())
                        {
                            championsList.Add(champion);
                        }
                    }
                    else if (!listRolesChecked.Any())
                    {
                        if (champion.Factions.Intersect(listFactionsChecked).Any())
                        {
                            championsList.Add(champion);
                        }
                    }
                    else
                    {
                        if (champion.Factions.Intersect(listFactionsChecked).Any() && champion.Roles.Intersect(listRolesChecked).Any())
                        {
                            championsList.Add(champion);
                        }
                    }
                }
            }
            UpdateListChampions();
        }

        /// <summary>
        /// Sort by alphabetical order
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mButtonName_Click(object sender, RoutedEventArgs e)
        {
            Button NameButton = sender as Button;
            mButtonRating.Content = "Rating";

            switch ((string)NameButton.Content)
            {
                case "Name":
                    NameButton.Content = "Name ↓";
                    championsList = championsList.OrderBy(x => x.Name).ToList();

                    UpdateListChampions();
                    break;
                case "Name ↓":
                    NameButton.Content = "Name ↑";
                    championsList = championsList.OrderByDescending(x => x.Name).ToList();

                    UpdateListChampions();

                    break;

                case "Name ↑":
                    NameButton.Content = "Name ↓";
                    championsList = championsList.OrderBy(x => x.Name).ToList();

                    UpdateListChampions();

                    break;
            }
        }

        /// <summary>
        /// Sort by rating
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mButtonRating_Click(object sender, RoutedEventArgs e)
        {
            Button RatingButton = sender as Button;
            mButtonName.Content = "Name";

            switch ((string)RatingButton.Content)
            {
                case "Rating":
                    RatingButton.Content = "Rating ↓";
                    championsList = championsList.OrderBy(x => x.Rating).ToList();
                    UpdateListChampions();
                    break;

                case "Rating ↓":
                    RatingButton.Content = "Rating ↑";
                    championsList = championsList.OrderByDescending(x => x.Rating).ToList();
                    UpdateListChampions();
                    break;

                case "Rating ↑":
                    RatingButton.Content = "Rating ↓";
                    championsList = championsList.OrderBy(x => x.Rating).ToList();
                    UpdateListChampions();
                    break;
            }

        }
    }
}
