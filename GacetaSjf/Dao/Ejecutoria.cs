using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GacetaSjf.Dao
{
    public class Ejecutoria
    {
        private int ius;
        private string rubro;
        private string asunto;
        private string promovente;
        private int sala;
        private int epoca;
        private int volumen;
        private int fuente;
        private int pagina;
        private List<string> partes;

        public int Epoca
        {
            get
            {
                return this.epoca;
            }
            set
            {
                this.epoca = value;
            }
        }

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

        public string Rubro
        {
            get
            {
                return this.rubro;
            }
            set
            {
                this.rubro = value;
            }
        }

        public string Asunto
        {
            get
            {
                return this.asunto;
            }
            set
            {
                this.asunto = value;
            }
        }

        public string Promovente
        {
            get
            {
                return this.promovente;
            }
            set
            {
                this.promovente = value;
            }
        }

        public int Sala
        {
            get
            {
                return this.sala;
            }
            set
            {
                this.sala = value;
            }
        }

        public int Volumen
        {
            get
            {
                return this.volumen;
            }
            set
            {
                this.volumen = value;
            }
        }

        public int Fuente
        {
            get
            {
                return this.fuente;
            }
            set
            {
                this.fuente = value;
            }
        }

        public int Pagina
        {
            get
            {
                return this.pagina;
            }
            set
            {
                this.pagina = value;
            }
        }

        public List<string> Partes
        {
            get
            {
                return this.partes;
            }
            set
            {
                this.partes = value;
            }
        }
    }
}
