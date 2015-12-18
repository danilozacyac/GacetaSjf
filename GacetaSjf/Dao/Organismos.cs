using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace GacetaSjf.Dao
{
    public class Organismos
    {
        private int idOrganismo;
        private string organismo;
        private ObservableCollection<Organismos> children;

        public int IdOrganismo
        {
            get
            {
                return this.idOrganismo;
            }
            set
            {
                this.idOrganismo = value;
            }
        }

        public string Organismo
        {
            get
            {
                return this.organismo;
            }
            set
            {
                this.organismo = value;
            }
        }

        public ObservableCollection<Organismos> Children
        {
            get
            {
                return this.children;
            }
            set
            {
                this.children = value;
            }
        }
    }
}
