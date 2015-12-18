using GacetaSjf.Singletons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace GacetaSjf.Converters
{
    public class VolumenConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            int volumen = 0;
            Int32.TryParse(value.ToString(), out volumen);

            return (from n in CompartidosSingleton.Volumenes
                    where n.IdElemento == volumen
                    select n.Descripcion).ToList()[0];

        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}