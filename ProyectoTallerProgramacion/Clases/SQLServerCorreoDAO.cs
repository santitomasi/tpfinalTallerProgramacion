using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Clases.DTO;

namespace Clases.Persistencia.SQLServer
{
    /// <summary>
    /// Clase para interactuar con la informacion de la Base de Datos.
    /// </summary>
    public class SQLServerCorreoDAO : ICorreoDAO
    {
        /// <summary>
        /// Instancia de la clase SqlConnection.
        /// </summary>
        private SqlConnection iConexion;

        /// <summary>
        /// Instancia de la clase SqlTransaction.
        /// </summary>
        private SqlTransaction iTransaccion;

        /// <summary>
        /// Constructor de la clase SQLServerCorreoDAO.
        /// </summary>
        /// <param name="pConexion">Conexión a utilizar.</param>
        /// <param name="pTransaccion">Transacción a utilizar.</param>
        public SQLServerCorreoDAO(SqlConnection pConexion, SqlTransaction pTransaccion)
        {
            this.iConexion = pConexion;
            this.iTransaccion = pTransaccion;
        }

        /// <summary>
        /// Metodo para obtener la lista de correos de la Base de Datos.
        /// </summary>
        /// <returns></returns>
        public IList<CorreoDTO> ObtenerCorreos()
        {
            List<CorreoDTO> mCorreos = new List<CorreoDTO>();
            try
            {
                SqlCommand comando = this.iConexion.CreateCommand();
                comando.CommandText = "select * from Correo";
                DataTable tabla = new DataTable();
                using (SqlDataAdapter adaptador = new SqlDataAdapter(comando))
                {
                    adaptador.Fill(tabla);
                    foreach (DataRow fila in tabla.Rows)
                    {
                        mCorreos.Add(new CorreoDTO
                        {
                            Id = Convert.ToInt32(fila["Id"]),
                            Fecha = Convert.ToDateTime(fila["Fecha"]),
                            Hora = Convert.ToDateTime(fila["Hora"]),
                            Texto = Convert.ToString(fila["Texto"]),
                            OrigenID = Convert.ToInt32(fila["Origen"]),
                            DestinoID = Convert.ToInt32(fila["Destino"]),
                        });
                    }
                }
                return mCorreos;
            }
            catch (SqlException pSqlException)
            {
                throw new DAOException("Error en la obtención de datos de correo", pSqlException);
            }
        }

        /// <summary>
        /// Metodo para insertar la informacion de un correo en la Base de Datos.
        /// </summary>
        /// <param name="pCorreo"></param>
        public void AgregarCorreo(CorreoDTO pCorreo)
        {
            try
            {
                SqlCommand comando = this.iConexion.CreateCommand();
                comando.CommandText = @"insert into Correo(Id,Fecha,Hora,Texto,Origen,Destino)
                                                   values(@Id,@Fecha,@Hora,@Texto,@Origen,@Destino)";
                comando.Parameters.AddWithValue("@Id", pCorreo.Id);
                comando.Parameters.AddWithValue("@Fecha", pCorreo.Fecha);
                comando.Parameters.AddWithValue("@Hora", pCorreo.Hora);
                comando.Parameters.AddWithValue("@Texto", pCorreo.Texto);
                comando.Parameters.AddWithValue("@OrigenID", pCorreo.OrigenID);
                comando.Parameters.AddWithValue("@DestinoID", pCorreo.DestinoID);
                comando.Transaction = iTransaccion;
                comando.ExecuteNonQuery();
            }
            catch (SqlException pSqlException)
            {
                new DAOException("Error en la inserción de datos de correo", pSqlException);
            }
        }

        /// <summary>
        /// Metodo para eliminar los datos de un Correo en la Base de Datos.
        /// </summary>
        /// <param name="pCorreo"></param>
        public void EliminarCorreo(CorreoDTO pCorreo)
        {
            try
            {
                SqlCommand comando = this.iConexion.CreateCommand();
                comando.CommandText = @"delete from Correo where Id = @Id";
                comando.Parameters.AddWithValue("@ID", pCorreo.Id);
                comando.Transaction = iTransaccion;
                comando.ExecuteNonQuery();
            }
            catch (SqlException pSqlException)
            {
                throw new DAOException("Error en la eliminacion de un correo", pSqlException);
            }
        }
    }
}
