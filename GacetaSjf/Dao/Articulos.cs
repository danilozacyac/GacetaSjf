using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GacetaSjf.Dao
{
    public class Articulos
    {
        private int ius;
        private int idRel;
        private int consec;
        private int idLey;
        private int idReforma;
        private int idArticulo;
        private int seccion;
        private string tituloLey;
        private string articuloShort;
        private List<string> partesArticulo = new List<string>();
        
        public int Ius
        {
            get
            {
                return this.ius;
            }
            set
            {
                this.ius = value;
            }
        }

        public int IdRel
        {
            get
            {
                return this.idRel;
            }
            set
            {
                this.idRel = value;
            }
        }

        public int Consec
        {
            get
            {
                return this.consec;
            }
            set
            {
                this.consec = value;
            }
        }

        public int IdLey
        {
            get
            {
                return this.idLey;
            }
            set
            {
                this.idLey = value;
            }
        }

        public int IdReforma
        {
            get
            {
                return this.idReforma;
            }
            set
            {
                this.idReforma = value;
            }
        }

        public int IdArticulo
        {
            get
            {
                return this.idArticulo;
            }
            set
            {
                this.idArticulo = value;
            }
        }

        public int Seccion
        {
            get
            {
                return this.seccion;
            }
            set
            {
                this.seccion = value;
            }
        }

        public string TituloLey
        {
            get
            {
                return this.tituloLey;
            }
            set
            {
                this.tituloLey = value;
            }
        }

        public string ArticuloShort
        {
            get
            {
                return this.articuloShort;
            }
            set
            {
                this.articuloShort = value;
            }
        }

        public List<string> PartesArticulo
        {
            get
            {
                return this.partesArticulo;
            }
            set
            {
                this.partesArticulo = value;
            }
        }
    }
}
