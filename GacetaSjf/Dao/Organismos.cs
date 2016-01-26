using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace GacetaSjf.Dao
{
    public class Organismos
    {
        private int idOrganismo;
        private string organismo;
        private string tag;
        private string cKey;
        private int idPadre;
        private int nivel;
        private Organismos parent;
        private ObservableCollection<Organismos> children;


        public Organismos()
        {

        }

        public Organismos(Organismos parent)
        {
            this.parent = parent;
        }
        
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

        public string Tag
        {
            get
            {
                return this.tag;
            }
            set
            {
                this.tag = value;
            }
        }

        public string CKey
        {
            get
            {
                return this.cKey;
            }
            set
            {
                this.cKey = value;
            }
        }

        public int IdPadre
        {
            get
            {
                return this.idPadre;
            }
            set
            {
                this.idPadre = value;
            }
        }

        public int Nivel
        {
            get
            {
                return this.nivel;
            }
            set
            {
                this.nivel = value;
            }
        }

        public Organismos Parent
        {
            get
            {
                return this.parent;
            }
            set
            {
                this.parent = value;
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
