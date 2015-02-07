using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DataTransferObject;

namespace Persistencia.SQLServer
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
                        mCorreos.Add(new CorreoDTO()
                        {
                            Id = Convert.ToInt32(fila["correoId"]),
                            Fecha = Convert.ToDateTime(fila["fecha"]),
                            TipoCorreo = Convert.ToString(fila["tipocorreo"]),
                            Texto = Convert.ToString(fila["texto"]),
                            CuentaOrigen = Convert.ToString(fila["cuentaOrigen"]),
                            CuentaDestino = Convert.ToString(fila["cuentaDestino"]),
                            Asunto = Convert.ToString(fila["Asunto"]),
                            Leido = Convert.ToInt32(fila["leido"])
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
        /// Metodo para obtener los correos de la cuenta <paramref name="pCuenta"/>.
        /// </summary>
        /// <returns>Retorna una lista de correos con los correos de la cuenta <paramref name="pCuenta"/>.</returns>
        public IList<CorreoDTO> ObtenerCorreos(string pCuenta)
        {
            List<CorreoDTO> mCorreos = new List<CorreoDTO>();
            try
            {
                SqlCommand comando = this.iConexion.CreateCommand();
                comando.CommandText = "select * from Correo where (cuentaOrigen = @Cuenta and tipoCorreo = 'Enviado') or (cuentaDestino = @Cuenta and tipoCorreo = 'Recibido')";
                comando.Parameters.AddWithValue("@Cuenta", pCuenta);
                DataTable tabla = new DataTable();
                using (SqlDataAdapter adaptador = new SqlDataAdapter(comando))
                {
                    adaptador.Fill(tabla);
                    foreach (DataRow fila in tabla.Rows)
                    {
                       mCorreos.Add(new CorreoDTO
                       {
                           Id = Convert.ToInt32(fila["correoId"]),
                           Fecha = Convert.ToDateTime(fila["fecha"]),
                           TipoCorreo = Convert.ToString(fila["tipocorreo"]),
                           Texto = Convert.ToString(fila["texto"]),
                           CuentaOrigen = Convert.ToString(fila["cuentaOrigen"]),
                           CuentaDestino = Convert.ToString(fila["cuentaDestino"]),
                           Asunto = Convert.ToString(fila["Asunto"]),
                           Leido = Convert.ToInt32(fila["leido"])
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
                comando.CommandText = @"insert into Correo(fecha,tipocorreo,texto,cuentaOrigen,cuentaDestino,asunto,leido)
                                                   values(@Fecha,@TipoCorreo,@Texto,@Origen,@Destino,@Asunto,@Leido)";
                comando.Parameters.AddWithValue("@Fecha", pCorreo.Fecha);
                comando.Parameters.AddWithValue("@TipoCorreo", pCorreo.TipoCorreo);
                comando.Parameters.AddWithValue("@Texto", pCorreo.Texto);
                comando.Parameters.AddWithValue("@Origen", pCorreo.CuentaOrigen);
                comando.Parameters.AddWithValue("@Destino", pCorreo.CuentaDestino);
                comando.Parameters.AddWithValue("@Asunto", pCorreo.Asunto);
                comando.Parameters.AddWithValue("@Leido", pCorreo.Leido);
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
                comando.CommandText = @"delete from adjunto where correoId = @Id;
                                            delete from Correo where correoId = @Id;";
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
