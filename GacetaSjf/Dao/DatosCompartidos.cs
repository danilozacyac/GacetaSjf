using System;
using System.Linq;

namespace GacetaSjf.Dao
{
    public class DatosCompartidos
    {
        private int idElemento;
        private string descripcion;
        public int IdElemento
        {
            get
            {
                return this.idElemento;
            }
            set
            {
                this.idElemento = value;
            }
        }

        public string Descripcion
        {
            get
            {
                return this.descripcion;
            }
            set
            {
                this.descripcion = value;
            }
        }
    }
}
