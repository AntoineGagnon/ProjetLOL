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

namespace MyUserControls
{
    /// <summary>
    /// Logique d'interaction pour UserControlTabChampion.xaml
    /// </summary>
    public partial class UserControlTabChampion : UserControl
    {
        public UserControlTabChampion()
        {
            InitializeComponent();

        }

        private static String baseTextBox = "Write your thoughts about this champion here";

        public Champion Champion
        {
            get
            {
                return mChampion;
            }
            set
            {
                mChampion = value;
                mImageBigIcon.Source = new BitmapImage(new Uri("/MetierAppliLOL;component/Images/" + mChampion.IconPath, UriKind.Relative));
                mTextBlockChampionName.Text = mChampion.Name;
                mTextBlockChampionDignity.Text = mChampion.Dignity;


                mListBoxFactions.Items.Clear();
                foreach (Faction faction in mChampion.Factions)
                {
                    mListBoxFactions.Items.Add(faction.ToString().Replace('_',' '));
                }

                mListBoxRoles.Items.Clear();
                foreach (Role role in mChampion.Roles)
                {
                    mListBoxRoles.Items.Add(role);
                }

                mChampionRating.myChampion = mChampion;

                if (mChampion.Opinion == "")
                {
                    mTextBoxChampionOpinion.Text = baseTextBox;
                }
                else
                {
                    mTextBoxChampionOpinion.Text = mChampion.Opinion;
                }

                mImageSpellPassive.Source = new BitmapImage(new Uri("/MetierAppliLOL;component/Images/" + mChampion.Spells[0].IconPath, UriKind.Relative));

                mImageSpellQ.Source = new BitmapImage(new Uri("/MetierAppliLOL;component/Images/" + mChampion.Spells[1].IconPath, UriKind.Relative));

                mImageSpellW.Source = new BitmapImage(new Uri("/MetierAppliLOL;component/Images/" + mChampion.Spells[2].IconPath, UriKind.Relative));

                mImageSpellE.Source = new BitmapImage(new Uri("/MetierAppliLOL;component/Images/" + mChampion.Spells[3].IconPath, UriKind.Relative));

                mImageSpellR.Source = new BitmapImage(new Uri("/MetierAppliLOL;component/Images/" + mChampion.Spells[4].IconPath, UriKind.Relative));

                mSpellPassive.Spell = mChampion.Spells[0];

                mSpellQ.Spell = mChampion.Spells[1];

                mSpellW.Spell = mChampion.Spells[2];

                mSpellE.Spell = mChampion.Spells[3];

                mSpellR.Spell = mChampion.Spells[4];
            }

        }
        private Champion mChampion;



        private void mImageSpell_MouseEnter(object sender, MouseEventArgs e)
        {
            mStackPanelChampionOpinion.Visibility = Visibility.Hidden;

            Image mySpellIcon = sender as Image;

            switch (mySpellIcon.Name)
            {
                case "mImageSpellPassive":
                    mSpellPassive.Visibility = Visibility.Visible;
                    break;

                case "mImageSpellQ":
                    mSpellQ.Visibility = Visibility.Visible;
                    break;

                case "mImageSpellW":
                    mSpellW.Visibility = Visibility.Visible;
                    break;

                case "mImageSpellE":
                    mSpellE.Visibility = Visibility.Visible;
                    break;

                case "mImageSpellR":
                    mSpellR.Visibility = Visibility.Visible;
                    break;

                default:
                    mStackPanelChampionOpinion.Visibility = Visibility.Visible;
                    break;
            }

        }

        private void mImageSpell_MouseLeave(object sender, MouseEventArgs e)
        {
            mStackPanelChampionOpinion.Visibility = Visibility.Visible;

            Image mySpellIcon = sender as Image;

            switch (mySpellIcon.Name)
            {
                case "mImageSpellPassive":
                    mSpellPassive.Visibility = Visibility.Hidden;
                    break;

                case "mImageSpellQ":
                    mSpellQ.Visibility = Visibility.Hidden;
                    break;

                case "mImageSpellW":
                    mSpellW.Visibility = Visibility.Hidden;
                    break;

                case "mImageSpellE":
                    mSpellE.Visibility = Visibility.Hidden;
                    break;

                case "mImageSpellR":
                    mSpellR.Visibility = Visibility.Hidden;
                    break;

                default:
                    mStackPanelChampionOpinion.Visibility = Visibility.Hidden;
                    break;
            }

        }

        private void mTextBoxChampionOpinion_GotFocus(object sender, RoutedEventArgs e)
        {
            if (mTextBoxChampionOpinion.Text == baseTextBox)
            {
                mTextBoxChampionOpinion.Text = "";
            }
        }


        /// <summary>
        /// When the opinion textbox lose focus, it saves the changes in the Champion.Opinion attribute of the UserControl's champion.
        /// </summary>
        /// <param name="sender">The Commentary text box</param>
        /// <param name="e"></param>
        private void mTextBoxChampionOpinion_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox CommentaryTextBox = sender as TextBox;
            if (CommentaryTextBox.Text == "")
            {
                CommentaryTextBox.Text = baseTextBox;
            }
            else
            {
                mChampion.Opinion = CommentaryTextBox.Text;
            }

        }
    }
}
