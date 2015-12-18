using GacetaSjf.Dao;
using GacetaSjf.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GacetaSjf.Singletons
{
    public class CompartidosSingleton
    {
        private static List<DatosCompartidos> epocas;
        private static List<DatosCompartidos> volumenes;
        private static List<DatosCompartidos> instancias;

        private CompartidosSingleton()
        {
        }

        public static List<DatosCompartidos> Epocas
        {
            get
            {
                if (epocas == null)
                    epocas = new DatosCompartidosModel().GetEpocas();

                return epocas;
            }
        }


        public static List<DatosCompartidos> Volumenes
        {
            get
            {
                if (volumenes == null)
                    volumenes = new DatosCompartidosModel().GetVolumenes();

                return volumenes;
            }
        }

        public static List<DatosCompartidos> Instancias
        {
            get
            {
                if (instancias == null)
                    instancias = new DatosCompartidosModel().GetInstancias();

                return instancias;
            }
        }
    }
}
