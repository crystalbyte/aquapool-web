using System;
using System.Globalization;
using System.Windows.Data;

namespace Aquapool.Nbw {
    public class NegationConverter : IValueConverter {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            var b = (bool)value;
            return !b;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }

        #endregion
    }

    //public class StringToBoolConverter : IValueConverter {
    //    #region IValueConverter Members

    //    public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
    //        var s = value as string;
    //        return !string.IsNullOrEmpty(s) && bool.Parse(s);
    //    }

    //    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
    //        var xamlString = (string)value;
    //        return bool.Parse(xamlString);
    //    }

    //    #endregion
    //}
}
