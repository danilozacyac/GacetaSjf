using System;
using System.Linq;
using System.Windows.Data;
using GacetaSjf.Singletons;

namespace GacetaSjf.Converters
{
    class FuenteConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            int fuente = 0;
            Int32.TryParse(value.ToString(), out fuente);

            if (fuente == 0)
            {
                return String.Empty;
            }
            else
            {
                return (from n in CompartidosSingleton.Fuentes
                        where n.IdElemento == fuente
                        select n.Descripcion).ToList()[0];
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}