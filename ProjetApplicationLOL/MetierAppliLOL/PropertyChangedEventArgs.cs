using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetierAppliLOL
{
    public class PropertyChangedEventArgs : EventArgs
    {

        public String Property
        {
            get;
            private set;
        }

        public PropertyChangedEventArgs(String property)
        {
            Property = property;
        }
    }
}
