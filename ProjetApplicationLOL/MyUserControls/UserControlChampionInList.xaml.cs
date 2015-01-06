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
    /// Logique d'interaction pour UserControlChampionInList.xaml
    /// </summary>
    public partial class UserControlChampionInList : UserControl
    {
        public UserControlChampionInList()
        {
            InitializeComponent();
        }

        public Champion Champion
        {
            get
            {
                return mChampion;
            }
            set
            {
                mChampion = value;
                mIconChampion.Source = new BitmapImage(new Uri("/MetierAppliLOL;component/Images/" + mChampion.IconPath, UriKind.Relative));
                mTextBlockName.Text = mChampion.Name;

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
                mChampionRating.CanModifyRating = false;
            }

        }
        private Champion mChampion;

        public event EventHandler ChampionHovered;

        private void Grid_MouseEnter(object sender, MouseEventArgs e)
        {
            if (this.ChampionHovered != null)
            {
                this.ChampionHovered(this, new EventArgs());
            }

        }
    }
}
