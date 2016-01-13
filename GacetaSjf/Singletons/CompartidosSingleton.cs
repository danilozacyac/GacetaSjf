using System;
using System.Collections.Generic;
using System.Linq;
using GacetaSjf.Dao;
using GacetaSjf.Model;

namespace GacetaSjf.Singletons
{
    public class CompartidosSingleton
    {
        private static List<DatosCompartidos> epocas;
        private static List<DatosCompartidos> volumenes;
        private static List<DatosCompartidos> instancias;
        private static List<DatosCompartidos> instanciasTesis;
        private static List<DatosCompartidos> fuentes;

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


        public static List<DatosCompartidos> InstanciasTesis
        {
            get
            {
                if (instanciasTesis == null)
                {
                    instanciasTesis = new List<DatosCompartidos>();
                    instanciasTesis.Add(new DatosCompartidos() { IdElemento = 6, Descripcion = "Pleno" });
                    instanciasTesis.Add(new DatosCompartidos() { IdElemento = 1, Descripcion = "1a. Sala" });
                    instanciasTesis.Add(new DatosCompartidos() { IdElemento = 2, Descripcion = "2a. Sala" });
                    instanciasTesis.Add(new DatosCompartidos() { IdElemento = 50, Descripcion = "Plenos de Circuito" });
                    instanciasTesis.Add(new DatosCompartidos() { IdElemento = 7, Descripcion = "Tribunales Colegiados" });
                }
                return instanciasTesis;
            }
        }


        public static List<DatosCompartidos> Fuentes
        {
            get
            {
                if (fuentes == null)
                    fuentes = new DatosCompartidosModel().GetFuentes();

                return fuentes;
            }
        }
    }
}
