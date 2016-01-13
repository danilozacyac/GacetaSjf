using System;
using System.Linq;
using System.Windows.Data;
using GacetaSjf.Singletons;

namespace GacetaSjf.Converters
{
    public class EpocaConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            int epoca = 0;
            Int32.TryParse(value.ToString(), out epoca);

            return (from n in CompartidosSingleton.Epocas
                    where n.IdElemento == epoca
                    select n.Descripcion).ToList()[0];

        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}