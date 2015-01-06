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
using MetierAppliLOL;

namespace MyUserControls
{
    /// <summary>
    /// Logique d'interaction pour UserControlMarkWithStars.xaml
    /// </summary>
    public partial class UserControlMarkWithStars : UserControl
    {
        public UserControlMarkWithStars()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Path : YellowStar
        /// </summary>
        private static String YellowStar = "Images/YellowStar.png";

        /// <summary>
        /// Path : BlackStar
        /// </summary>
        private static String BlackStar = "Images/BlackStar.png";

        /// <summary>
        /// Allow the rating to be modified or not. Is used to prevent modifying in the UserControlChampionInList.
        /// </summary>
        public bool CanModifyRating = true;

        public Champion myChampion
        {
            get
            {
                return mMyChampion;
            }

            set
            {
                mMyChampion = value;
                NbStars = mMyChampion.Rating;
            }

        }
        private Champion mMyChampion;

        public int NbStars
        {
            get { return mNbStars; }
            set
            {
                mNbStars = value;

                if (mNbStars > 0)
                {
                    mImageStar1.Source = new BitmapImage(new Uri(YellowStar, UriKind.Relative));
                    if (mNbStars > 1)
                    {
                        mImageStar2.Source = new BitmapImage(new Uri(YellowStar, UriKind.Relative));
                        if (mNbStars > 2)
                        {
                            mImageStar3.Source = new BitmapImage(new Uri(YellowStar, UriKind.Relative));
                            if (mNbStars > 3)
                            {
                                mImageStar4.Source = new BitmapImage(new Uri(YellowStar, UriKind.Relative));
                                if (mNbStars > 4)
                                {
                                    mImageStar5.Source = new BitmapImage(new Uri(YellowStar, UriKind.Relative));
                                }
                                else
                                {
                                    mImageStar5.Source = new BitmapImage(new Uri(BlackStar, UriKind.Relative));
                                }
                            }
                            else
                            {
                                mImageStar4.Source = new BitmapImage(new Uri(BlackStar, UriKind.Relative));
                                mImageStar5.Source = new BitmapImage(new Uri(BlackStar, UriKind.Relative));
                            }
                        }
                        else
                        {
                            mImageStar3.Source = new BitmapImage(new Uri(BlackStar, UriKind.Relative));
                            mImageStar4.Source = new BitmapImage(new Uri(BlackStar, UriKind.Relative));
                            mImageStar5.Source = new BitmapImage(new Uri(BlackStar, UriKind.Relative));
                        }
                    }
                    else
                    {
                        mImageStar2.Source = new BitmapImage(new Uri(BlackStar, UriKind.Relative));
                        mImageStar3.Source = new BitmapImage(new Uri(BlackStar, UriKind.Relative));
                        mImageStar4.Source = new BitmapImage(new Uri(BlackStar, UriKind.Relative));
                        mImageStar5.Source = new BitmapImage(new Uri(BlackStar, UriKind.Relative));
                    }
                }
                else
                {
                    mImageStar1.Source = new BitmapImage(new Uri(BlackStar, UriKind.Relative));
                    mImageStar2.Source = new BitmapImage(new Uri(BlackStar, UriKind.Relative));
                    mImageStar3.Source = new BitmapImage(new Uri(BlackStar, UriKind.Relative));
                    mImageStar4.Source = new BitmapImage(new Uri(BlackStar, UriKind.Relative));
                    mImageStar5.Source = new BitmapImage(new Uri(BlackStar, UriKind.Relative));
                }
            }
        }
        private int mNbStars;

        private void mImageStar_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (!CanModifyRating)
            {
                return;
            }

            Image image = sender as Image;

            switch (image.Name)
            {
                case "mImageStar1":
                    NbStars = 1;
                    break;
                case "mImageStar2":
                    NbStars = 2;
                    break;
                case "mImageStar3":
                    NbStars = 3;
                    break;
                case "mImageStar4":
                    NbStars = 4;
                    break;
                case "mImageStar5":
                    NbStars = 5;
                    break;
            }

            myChampion.Rating = NbStars;
        }

        private void mImageStar_MouseEnter(object sender, MouseEventArgs e)
        {
            if (!CanModifyRating)
            {
                return;
            }

            Image image = sender as Image;

            switch (image.Name)
            {
                case "mImageStar1":
                    mImageStar1.Source = new BitmapImage(new Uri(YellowStar, UriKind.Relative));
                    mImageStar2.Source = new BitmapImage(new Uri(BlackStar, UriKind.Relative));
                    mImageStar3.Source = new BitmapImage(new Uri(BlackStar, UriKind.Relative));
                    mImageStar4.Source = new BitmapImage(new Uri(BlackStar, UriKind.Relative));
                    mImageStar5.Source = new BitmapImage(new Uri(BlackStar, UriKind.Relative));
                    break;
                case "mImageStar2":
                    mImageStar1.Source = new BitmapImage(new Uri(YellowStar, UriKind.Relative));
                    mImageStar2.Source = new BitmapImage(new Uri(YellowStar, UriKind.Relative));
                    mImageStar3.Source = new BitmapImage(new Uri(BlackStar, UriKind.Relative));
                    mImageStar4.Source = new BitmapImage(new Uri(BlackStar, UriKind.Relative));
                    mImageStar5.Source = new BitmapImage(new Uri(BlackStar, UriKind.Relative));
                    break;
                case "mImageStar3":
                    mImageStar1.Source = new BitmapImage(new Uri(YellowStar, UriKind.Relative));
                    mImageStar2.Source = new BitmapImage(new Uri(YellowStar, UriKind.Relative));
                    mImageStar3.Source = new BitmapImage(new Uri(YellowStar, UriKind.Relative));
                    mImageStar4.Source = new BitmapImage(new Uri(BlackStar, UriKind.Relative));
                    mImageStar5.Source = new BitmapImage(new Uri(BlackStar, UriKind.Relative));
                    break;
                case "mImageStar4":
                    mImageStar1.Source = new BitmapImage(new Uri(YellowStar, UriKind.Relative));
                    mImageStar2.Source = new BitmapImage(new Uri(YellowStar, UriKind.Relative));
                    mImageStar3.Source = new BitmapImage(new Uri(YellowStar, UriKind.Relative));
                    mImageStar4.Source = new BitmapImage(new Uri(YellowStar, UriKind.Relative));
                    mImageStar5.Source = new BitmapImage(new Uri(BlackStar, UriKind.Relative));
                    break;
                case "mImageStar5":
                    mImageStar1.Source = new BitmapImage(new Uri(YellowStar, UriKind.Relative));
                    mImageStar2.Source = new BitmapImage(new Uri(YellowStar, UriKind.Relative));
                    mImageStar3.Source = new BitmapImage(new Uri(YellowStar, UriKind.Relative));
                    mImageStar4.Source = new BitmapImage(new Uri(YellowStar, UriKind.Relative));
                    mImageStar5.Source = new BitmapImage(new Uri(YellowStar, UriKind.Relative));
                    break;
            }

        }

        private void mImageStar_MouseLeave(object sender, MouseEventArgs e)
        {
            NbStars = mNbStars;
        }
    }
}
