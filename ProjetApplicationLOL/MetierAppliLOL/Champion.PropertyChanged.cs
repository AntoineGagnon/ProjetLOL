using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetierAppliLOL
{
    public partial class Champion
    {

        public EventHandler<PropertyChangedEventArgs> PropertyChanged;

        public void OnPropertyChanged(PropertyChangedEventArgs args)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, args);
            }
        }

        private void OnPropertyChanged(String property)
        {
            OnPropertyChanged(new PropertyChangedEventArgs(property));
        }
    }
}
