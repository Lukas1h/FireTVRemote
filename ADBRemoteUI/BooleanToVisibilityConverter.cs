using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace ADBRemoteUI {
    class BooleanToVisibilityConverter : IValueConverter {

        public static string Positive = "Positive";
        public static string Negative = "Negative";

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            var boolVal = value as bool?;
            var convParam = parameter as string;
            if (convParam == Positive) {
                return boolVal == null ? Visibility.Hidden : (boolVal == true ? Visibility.Visible : Visibility.Collapsed);
            }

            return boolVal == null ? Visibility.Hidden : (boolVal == false ? Visibility.Visible : Visibility.Collapsed);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }
    }
}
