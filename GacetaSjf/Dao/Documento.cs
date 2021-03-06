﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace GacetaSjf.Dao
{
    public class Documento
    {
        private int ius;
        private string textoListaIndice;
        private string rubro;
        private string asunto;
        private string promovente;
        private int sala;
        private int epoca;
        private int volumen;
        private int fuente;
        private int pagina;
        private string mes;
        private List<string> partes;
        private List<Anexos> anexos;


        public string TextoListaIndice
        {
            get
            {
                return this.textoListaIndice;
            }
            set
            {
                this.textoListaIndice = value;
            }
        }

        public string Mes
        {
            get
            {
                return this.mes;
            }
            set
            {
                this.mes = value;
            }
        }

        public List<Anexos> Anexos
        {
            get
            {
                return this.anexos;
            }
            set
            {
                this.anexos = value;
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
