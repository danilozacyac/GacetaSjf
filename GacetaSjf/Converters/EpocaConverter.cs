using GacetaSjf.Singletons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

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