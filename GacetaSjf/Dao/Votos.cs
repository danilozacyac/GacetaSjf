using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
