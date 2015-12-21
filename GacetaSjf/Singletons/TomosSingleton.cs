using System;
using System.Collections.ObjectModel;
using System.Linq;
using GacetaSjf.Dao;

namespace GacetaSjf.Singletons
{
    public class TomosSingleton
    {
        private static ObservableCollection<Tomos> tomos;

        private TomosSingleton()
        {
        }

        public static ObservableCollection<Tomos> Tomos
        {
            get
            {
                if (tomos == null)
                    tomos = new Tomos().GetTomos();

                return tomos;
            }
        }
    }
}