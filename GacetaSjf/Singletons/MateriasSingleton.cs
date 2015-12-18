using System;
using System.Collections.ObjectModel;
using System.Linq;
using GacetaSjf.Dao;

namespace GacetaSjf.Singletons
{
    public class MateriasSingleton
    {
        private static ObservableCollection<Materias> materias;

        private MateriasSingleton()
        {
        }

        public static ObservableCollection<Materias> MateriasSin
        {
            get
            {
                if (materias == null)
                    materias = new Materias().GetMaterias();

                return materias;
            }
        }
    }
}