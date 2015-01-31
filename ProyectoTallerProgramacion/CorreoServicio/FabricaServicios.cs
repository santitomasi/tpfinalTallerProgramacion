using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorreoServicio
{
    /// <summary>
    /// Clase singleton utilizada para crear y mantener una instancia de cada implementación de Iservicio.
    /// </summary>
    public class FabricaServicios 
    {
        //Atributo utilizado para lograr mantener una única instancia de la clase.
        private static FabricaServicios cInstancia = null;

        //Atributo de tipo diccionario responsable de relacionar los nombres de los servicios con los mismos.
        private IDictionary<string, IServicio> iServicios;

        /// <summary>
        /// Constructor de la clase FabricaExportadores responsable de colocar en el diccionario
        /// los exportadores con sus respectivos nombres.
        /// </summary>
        private FabricaServicios()
            {
                this.iServicios = new Dictionary<string, IServicio>();

                Gmail servicioGmail = new Gmail();
                Yahoo servicioYahoo = new Yahoo();

                this.iServicios.Add("GMAIL", servicioGmail);
                this.iServicios.Add("YAHOO", servicioYahoo);
            }

        /// <summary>
        /// Propiedad utilizada para lograr mantener una únca instancia de la clase FabricaServicios.
        /// </summary>
        public static FabricaServicios Instancia
        {
            get
            {
                if (cInstancia == null)
                {
                    cInstancia = new FabricaServicios();
                }
                return cInstancia;
            }
        }

        /// <summary>
        /// Metodo responsable de buscar y devolverte un servicio dependiendo del nombre como parametro.
        /// </summary>
        /// <param name="nombre">nombre de tipo string que hace referencia al servicio a buscar.</param>
        /// <returns>Devuelve un servicio de tipo IServicio buscado.</returns>
        public IServicio GetServicio(string nombre)
        {
            //Le pedimos al diccionario con el nombre como clave que nos devuelva el servicio asociado.
            IServicio servicio = this.iServicios[nombre];

            return servicio;
        }
    }
}
