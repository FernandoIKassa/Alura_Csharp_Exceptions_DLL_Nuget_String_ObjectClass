using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Modelos.Sistemas 
{
    public interface IAutenticavel
    {
        bool Autenticar(string senha);

    }
}
