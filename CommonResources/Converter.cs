using MahApps.Metro.Converters;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace CommonResources
{
    public class ToLowerConverter : MarkupConverter
    {
        protected override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var val = value as string;
            return val != null ? val.ToLower() : value;
        }

        protected override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }

    // ----     ----    ----    ----    ----    ----    ----    ----    ----    ----    ----
    public class BoolToVisibilityConverter : IValueConverter
    {
        public static readonly BoolToVisibilityConverter Instance = new BoolToVisibilityConverter();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((bool)value == true)
            {
                return Visibility.Visible;
            }
            else
            {
                return Visibility.Collapsed;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }
    // ----     ----    ----    ----    ----    ----    ----    ----    ----    ----    ----

    public class InvertBoolToVisibilityConverter : IValueConverter
    {
        public static readonly InvertBoolToVisibilityConverter Instance = new InvertBoolToVisibilityConverter();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((bool)value == true)
            {
                return Visibility.Collapsed;
            }
            else
            {
                return Visibility.Visible;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }
    // ----     ----    ----    ----    ----    ----    ----    ----    ----    ----    ----

    public class ColorToBrushConverter : IValueConverter
    {
        public static readonly ColorToBrushConverter Instance = new ColorToBrushConverter();

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is Color)
                return new SolidColorBrush((Color)value);
            else
                return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

    }

    // ----     ----    ----    ----    ----    ----    ----    ----    ----    ----    ----

    public class FirstShownToResultsVisibleConverter : IValueConverter
    {
        public static readonly FirstShownToResultsVisibleConverter Instance = new FirstShownToResultsVisibleConverter();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((bool)value == true)
            {
                return Visibility.Collapsed;
            }
            else
            {
                return Visibility.Visible;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }

    // ----     ----    ----    ----    ----    ----    ----    ----    ----    ----    ----

    public class LastShownToResultsVisibleConverter : IValueConverter
    {
        public static readonly LastShownToResultsVisibleConverter Instance = new LastShownToResultsVisibleConverter();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((bool)value == true)
            {
                return Visibility.Visible;
            }
            else
            {
                return Visibility.Collapsed;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }

    // ----     ----    ----    ----    ----    ----    ----    ----    ----    ----    ----
    public class BoolToStringConverter : IValueConverter
    {
        public static readonly BoolToStringConverter Instance = new BoolToStringConverter();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((bool)value == true)
            {
                return "Correct";
            }
            else
            {
                return "Wrong";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }

    public class BoolToColorConverter : IValueConverter
    {
        public static readonly BoolToColorConverter Instance = new BoolToColorConverter();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((bool)value)
            {
                {
                    return new BrushConverter().ConvertFromString("#CC119EDA") as SolidColorBrush;
                }
            }
            return new BrushConverter().ConvertFromString("#CCE51400") as SolidColorBrush;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

    }


    public class BoolToFontWeightConverter : IValueConverter
    {
        public static readonly BoolToFontWeightConverter Instance = new BoolToFontWeightConverter();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((bool)value)
            {
                {
                    return FontWeights.Bold;
                }
            }
            return FontWeights.Normal;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

    }


    public class BoolToFontSizeConverter : IValueConverter
    {
        public static readonly BoolToFontSizeConverter Instance = new BoolToFontSizeConverter();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((bool)value)
            {
                {
                    return (double)new FontSizeConverter().ConvertFrom("11pt");
                }
            }
            return (double)new FontSizeConverter().ConvertFrom("9pt");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

    }


   
}
