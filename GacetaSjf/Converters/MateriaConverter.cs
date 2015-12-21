using System;
using System.Linq;
using System.Windows.Data;
using GacetaSjf.Singletons;

namespace GacetaSjf.Converters
{
    public class MateriaConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            int materia = 0;
            Int32.TryParse(value.ToString(), out materia);

            if (materia == 0)
            {
                return String.Empty;
            }
            else
            {
                return (from n in MateriasSingleton.MateriasSin
                        where n.IdMateria == materia
                        select n.Materia).ToList()[0];
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}