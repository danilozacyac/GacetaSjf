﻿using System;
using System.Linq;
using System.Windows.Data;

namespace GacetaSjf.Converters
{
    class PdfImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            int epoca = 0;
            Int32.TryParse(value.ToString(), out epoca);

            if (epoca == 0)
                return "/GacetaSjf;component/Resources/pdfDisable.png";
            else
                return "/GacetaSjf;component/Resources/GACETA OCTUBRE 2015.jpg";

        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}