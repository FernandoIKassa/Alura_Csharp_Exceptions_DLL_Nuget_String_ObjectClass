using ByteBank.Modelos.Sistemas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Modelos.Funcionarios
{
    public class FuncionarioAutenticavel : Funcionario,  IAutenticavel
    {
        public string Senha { get; set; }

        public FuncionarioAutenticavel (double salario, string cpf) : base (salario, cpf)
        {

        }
                
        public bool Autenticar(string senha)
        {
            return Senha == senha;
        }

        public override double GetBonificacao()
        {
            throw new NotImplementedException();
        }

        public override void AumentarSalario()
        {
            throw new NotImplementedException();
        }
    }
}
