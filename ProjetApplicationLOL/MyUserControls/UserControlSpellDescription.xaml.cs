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
    /// Logique d'interaction pour UserControlSpellDescription.xaml
    /// </summary>
    public partial class UserControlSpellDescription : UserControl
    {
        public UserControlSpellDescription()
        {
            InitializeComponent();
        }

        public Spell Spell
        {
            get
            {
                return mSpell;
            }
            set
            {
                mSpell = value;
                mTextBlockSpellName.Text = mSpell.Name;
                mTextBlockSpellDescription.Text = mSpell.Description;
            }
        }
        private Spell mSpell;
    }
}
