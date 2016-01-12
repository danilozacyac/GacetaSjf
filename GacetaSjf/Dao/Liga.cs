using System;
using System.Linq;

namespace GacetaSjf.Dao
{
    public class Liga
    {
        private int ius;
        private int idRelacion;
        private string frase;
        private int seccion;
        private int posicion;
        private int tipo;

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

        public int IdRelacion
        {
            get
            {
                return this.idRelacion;
            }
            set
            {
                this.idRelacion = value;
            }
        }

        public string Frase
        {
            get
            {
                return this.frase;
            }
            set
            {
                this.frase = value;
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

        public int Posicion
        {
            get
            {
                return this.posicion;
            }
            set
            {
                this.posicion = value;
            }
        }

        public int Tipo
        {
            get
            {
                return this.tipo;
            }
            set
            {
                this.tipo = value;
            }
        }
    }
}
