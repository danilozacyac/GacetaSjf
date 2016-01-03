using System;
using System.Linq;
using System.Windows.Data;
using GacetaSjf.Singletons;

namespace GacetaSjf.Converters
{
    class Instanciaconverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            int instancia = 0;
            Int32.TryParse(value.ToString(), out instancia);

            if (instancia == 0)
            {
                return String.Empty;
            }
            else
            {
                return (from n in CompartidosSingleton.Instancias
                        where n.IdElemento == instancia
                        select n.Descripcion).ToList()[0];
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}