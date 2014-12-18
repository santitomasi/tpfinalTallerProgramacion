using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public interface IServicio
    {
        public abstract List<Correo> ObtenerCorreos();

        public abstract void EnviarCorreo(Correo pCorreo);
    }
}
