using System;
using System.Linq;

namespace GacetaSjf.Dao
{
    public class Anexos
    {
        private int tipo;
        private string archivo;
        private int posicion;
        private int tamanio;
        private string frase;
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

        public string Archivo
        {
            get
            {
                return this.archivo;
            }
            set
            {
                this.archivo = value;
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

        public int Tamanio
        {
            get
            {
                return this.tamanio;
            }
            set
            {
                this.tamanio = value;
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
    }
}
