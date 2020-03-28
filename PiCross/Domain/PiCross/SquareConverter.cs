using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace PiCross.PiCross
{
    class SquareConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
       {
           var square = (Square)value;
           if (square == Square.EMPTY )
           {
               return Brushes.White;
           }
           else if (square == Square.FILLED )
           {
               return Brushes.Black;
           }
           else
           {
               return Brushes.Gray;
           }
       }

       public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
       {
           throw new NotImplementedException();
       }
    }
}
