﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GacetaSjf.Dao
{
    public class Temas
    {
        private int idTema;
        private string tema;
        private string temaStr;

        public int IdTema
        {
            get
            {
                return this.idTema;
            }
            set
            {
                this.idTema = value;
            }
        }

        public string Tema
        {
            get
            {
                return this.tema;
            }
            set
            {
                this.tema = value;
            }
        }

        public string TemaStr
        {
            get
            {
                return this.temaStr;
            }
            set
            {
                this.temaStr = value;
            }
        }
    }
}
