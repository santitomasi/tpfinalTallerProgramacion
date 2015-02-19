using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Persistencia.SQLServer
{
    /// <summary>
    /// Clase que mantiene los datos e implementa los metodos basicos para la conexion con 
    /// la base de datos SQLServer.
    /// </summary>
    public class SQLServerDAOFactory : DAOFactory
    {
        /// <summary>
        /// Atributo de la clase SQLConnection.
        /// </summary>
        private SqlConnection iConexion;

        /// <summary>
        /// Atributo de la clase SQLTransaction instanciado en null.
        /// </summary>
        private SqlTransaction iTransaccion = null;

        /// <summary>
        /// Atributo que mantiene la cadena de conexion con la Base de Datos SQLServer.
        /// </summary>
       // private string STRING_CONEXION = "Data Source=USER-PC; Initial Catalog = BBDDTaller;Integrated Security=True;Pooling=False";
       // private string STRING_CONEXION = @"Data Source=DANILO-PC\SQLEXPRESS; Initial Catalog = BBDDTaller;Integrated Security=True;Pooling=False";
        private string STRING_CONEXION = @"Data Source=ACER-V3-571; Initial Catalog = BBDDTaller;Integrated Security=True;Pooling=False";
       
        // POR   FABOR  ACTIVE  SU  CADENA  DE  CONEXION  PERO  NO  BORRE  LA  DE  LOS  DEMAS!!!!!!!!  GRACIAS :)

        /// <summary>
        /// Propiedad de solo lectura que devuelve una instancia de la clase CorreoDAO.
        /// </summary>
        public override ICorreoDAO CorreoDAO
        {
            get { return new SQLServerCorreoDAO(iConexion, iTransaccion); }
        }

        /// <summary>
        /// Propiedad de solo lectura que devuelve una instancia de la clase CuentaCorreoDAO.
        /// </summary>
        public override ICuentaDAO CuentaDAO
        {
            get { return new SQLServerCuentaDAO(iConexion, iTransaccion); }
        }

        /// <summary>
        /// Método que inicia una conexion con la Base de Datos.
        /// </summary>
        public override void IniciarConexion()
        {
            this.iConexion = new SqlConnection(STRING_CONEXION);
            iConexion.Open();
        }

        /// <summary>
        /// Método que inicia una transaccion en la Base de Datos.
        /// </summary>
        public override void ComenzarTransaccion()
        {
            if (this.iConexion == null)
            {
                throw new DAOException("No se puede iniciar una transacción sin una conexión abierta.");
            }
            this.iTransaccion = this.iConexion.BeginTransaction();
        }

        /// <summary>
        /// Método que finaliza la conexion con la Base de Datos.
        /// </summary>
        public override void FinalizarConexion()
        {
            if (this.iConexion != null)
            {
                this.iConexion.Close();
            }
        }

        /// <summary>
        /// Método que confirma los cambios en la Base de Datos.
        /// </summary>
        public override void Commit()
        {
            if (this.iTransaccion != null)
            {
                this.iTransaccion.Commit();
            }
        }

        /// <summary>
        /// Método que deshace los cambios en la Base de Datos.
        /// </summary>
        public override void RollBack()
        {
            if (this.iTransaccion != null)
            {
                this.iTransaccion.Rollback();
            }
        }
    }
}
