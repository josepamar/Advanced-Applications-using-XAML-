using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml.Data;

namespace Extensions
{
    public class BoolToColorConverter : IValueConverter
    {
        public Color TrueColor { get; set; }
        public Color FalseColor { get; set; }
    
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            Color ReturnValue = Colors.Transparent;
            if(value is bool)
            {
                ReturnValue = ((bool)value) ? this.TrueColor : this.FalseColor;
            }
            return ReturnValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            bool ReturnValue = default(bool);
            if(value is Color)
            {
                if ((Color)value == this.TrueColor) ReturnValue = true;
                else if ((Color)value == this.FalseColor) ReturnValue = false;
            }
            return ReturnValue;
        }
    }
}
