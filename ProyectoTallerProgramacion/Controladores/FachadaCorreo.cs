using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistencia;
using DataTransferObject;
using Exportacion;
using CorreoServicio;


namespace Controladores
{
    /// <summary>
    /// Clase controladora de fachada. Interactúa con los Correos entre la persistencia y la interfaz.
    /// </summary>
    public class FachadaCorreo
    {
        /// <summary>
        /// Atributo que almacena la instancia de la fachada.
        /// </summary>
        private static FachadaCorreo cInstancia = null;

        /// <summary>
        /// Atributo que almacena la instancia del administrador de exportadores-
        /// </summary>
        Exportador.FabricaExportadores fabricaExportadores = Exportador.FabricaExportadores.Instancia;

        /// <summary>
        /// Atributo DAOFactory para interactuar con la Base de Datos.
        /// </summary>
        private DAOFactory factory;

        /// <summary>
        /// Metodo para exportar un correo al sistema de archivos.
        /// </summary>
        /// <param name="pCorreo">correo a exportarse.</param>
        /// <param name="pRuta">ruta en donde exportarse el correo.</param>
        /// <param name="pExportador">nombre del exportador a ser utilizado.</param>
        public void ExportarCorreo(CorreoDTO pCorreo,string pRuta, string pExportador)
        {            
            Exportador.IExportador exportador = fabricaExportadores.GetExportador(pExportador);
            exportador.Exportar(pCorreo,pRuta);
        }

        /// <summary>
        /// Metodo para enviar un correo.
        /// </summary>
        /// <param name="pCorreo"></param>
        public void EnviarCorreo(CorreoDTO pCorreo)
        {
            CuentaDTO pCuenta = FachadaABMCuenta.Instancia.ObtenerCuenta(pCorreo.CuentaOrigen);
            ServicioCorreo servicio = (ServicioCorreo) FabricaServicios.Instancia.GetServicio(pCuenta.Servicio);
            servicio.Contraseña = pCuenta.Contraseña;
            servicio.Direccion = pCuenta.Direccion;
            servicio.EnviarCorreo(pCorreo);
        }

        /// <summary>
        /// Metodo para determinar si un correo ya existe en la base de datos.
        /// </summary>
        /// <param name="pCorreo">Correo a buscar en la base de datos.</param>
        /// <returns>False si el correo no existe en la base, true de lo contrario.</returns>
        public bool Existe(CorreoDTO pCorreo)
        {
            bool encontrado = false;
            try
            {
                factory = DAOFactory.Instancia;
                factory.IniciarConexion();
                factory.ComenzarTransaccion();
                encontrado = factory.CorreoDAO.Existe(pCorreo);
                factory.Commit();
                return encontrado;
            }
            catch (Exception exception)
            {
                factory.RollBack();

                //Se relanza la excepción porque en este punto no se puede tratar
                throw exception;
            }
            finally
            {
                // Haya o no un error, se cierra la transacción.
                factory.FinalizarConexion();
            }
        }

        /// <summary>
        /// Metodo para descargar los correos de una cuenta y cuargarlos en la base de datos.
        /// </summary>
        /// <param name="pCorreo"></param>
        public void DescargarCorreos(CuentaDTO pCuenta)
        {
            // Obtiene una instancia del servicio al que pertenece la cuenta e invoca al metodo 
            // Descargar correos pasandole como parametro la cuenta de la cual se desea descargar los correos
            IList<CorreoDTO> pCorreos = FabricaServicios.Instancia.GetServicio(pCuenta.Servicio).DescargarCorreos(pCuenta);

            foreach (CorreoDTO pCorreo in pCorreos)     //nose si son necesarios dos ciclos!!!
            {
                
                // Ver si el correo no esta ya en la baseeeee ¿¿¿??? 
                if (!(Existe(pCorreo)))
                {
                    CrearCorreo(pCorreo);
                }               
            }

        }



        /// <summary>
        /// Metodo para dar de alta un correo.
        /// </summary>
        /// <param name="pCorreo">Clase DTO con los datos del correo a dar de alta.</param>
        public void CrearCorreo(CorreoDTO pCorreo)
        {
            try
            {
                                
                factory = DAOFactory.Instancia;
                factory.IniciarConexion();
                factory.ComenzarTransaccion();
                factory.CorreoDAO.AgregarCorreo(pCorreo);
                factory.Commit();
            }
            catch (Exception exception)
            {
                factory.RollBack();

                //Se relanza la excepción porque en este punto no se puede tratar
                throw exception;
            }
            finally
            {
                // Haya o no un error, se cierra la transacción.
                factory.FinalizarConexion();
            }
        }

        /// <summary>
        /// Método para listar todos los correos de la Base de Datos.
        /// </summary>
        /// <returns>Una lista con todos los correos de la base de datos.</returns>
        public IList<CorreoDTO> ListarCorreos()
        {
            try
            {
                factory = DAOFactory.Instancia;
                factory.IniciarConexion();

                //Se devuelven los correos.
                return factory.CorreoDAO.ObtenerCorreos();
            }
            finally
            {
                //Haya o no un error, se cierra la transacción.
                factory.FinalizarConexion();
            }
        }

        /// <summary>
        /// Método para listar todos los correos de la cuenta <paramref name="pCuenta"/>.
        /// </summary>
        /// <returns>Una lista con todos los correos de la cuenta <paramref name="pCuenta"/>.</returns>
        public IList<CorreoDTO> ListarCorreos(string pCuenta)
        {
            try
            {
                factory = DAOFactory.Instancia;
                factory.IniciarConexion();

                //Se devuelven los correos.
                return factory.CorreoDAO.ObtenerCorreos(pCuenta);
            }
            finally
            {
                //Haya o no un error, se cierra la transacción.
                factory.FinalizarConexion();
            }
        }

        /// <summary>
        /// Método para eliminar un correo.
        /// </summary>
        /// <param name="pCorreo">Clase DTO con los datos del correo a eliminar.</param>
        public void EliminarCorreo(CorreoDTO pCorreo)
        {
            try
            {
                factory = DAOFactory.Instancia;
                factory.IniciarConexion();
                factory.ComenzarTransaccion();
                factory.CorreoDAO.EliminarCorreo(pCorreo);
                factory.Commit();
            }
            catch (Exception e)
            {
                factory.RollBack();

                //Se relanza la excepción porque en este punto no se puede tratar
                throw e;
            }
            finally
            {
                // Haya o no un error, se cierra la transacción.
                factory.FinalizarConexion();
            }
        }

        /// <summary>
        /// Propiedad utilizada para lograr mantener una únca instancia de la clase.
        /// </summary>
        public static FachadaCorreo Instancia
        {
            get
            {
                if (cInstancia == null)
                {
                    cInstancia = new FachadaCorreo();
                }
                return cInstancia;
            }
        }
    }
}
