using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTransferObject;

namespace CorreoServicio
{
    public interface IServicio
    {
        List<CorreoDTO> ObtenerCorreos();

        void EnviarCorreo(CorreoDTO pCorreo);
    }
}
