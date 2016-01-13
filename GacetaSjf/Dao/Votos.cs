using System;
using System.Linq;

namespace GacetaSjf.Dao
{
    public class Votos : Documento
    {
        private int tipoVoto;
        private string emisor;

        public int TipoVoto
        {
            get
            {
                return this.tipoVoto;
            }
            set
            {
                this.tipoVoto = value;
            }
        }

        public string Emisor
        {
            get
            {
                return this.emisor;
            }
            set
            {
                this.emisor = value;
            }
        }
    }
}
