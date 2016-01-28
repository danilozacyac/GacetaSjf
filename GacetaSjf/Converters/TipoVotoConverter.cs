using System;
using System.Linq;
using System.Windows.Data;
using GacetaSjf.Singletons;

namespace GacetaSjf.Converters
{
    public class TipoVotoConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            int tipo = 0;
            Int32.TryParse(value.ToString(), out tipo);

            return (from n in CompartidosSingleton.TipoVotos
                    where n.IdElemento == tipo
                    select n.Descripcion).ToList()[0];

        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}