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
    /// Logique d'interaction pour UserControlTabHeader.xaml
    /// </summary>
    public partial class UserControlTabHeader : UserControl
    {
        public event EventHandler CloseTab;

        public UserControlTabHeader()
        {
            InitializeComponent();
        }

        public String textTab
        {
            get { return mTextTab; }
            set
            {
                mTextTab = value;
                mTabText.Text = mTextTab;
            }
        }
        private String mTextTab;

        private void mCloseTabButton_Click(object sender, RoutedEventArgs e)
        {
            if (CloseTab != null)
            {
                CloseTab(this, new EventArgs());
            }

        }
    }
}
