using ByteBank.Modelos.Sistemas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Modelos.Funcionarios
{
    public abstract class FuncionarioAutenticavel : Funcionario,  IAutenticavel
    {
        public string Senha { get; set; }

        private AutenticacaoHelper _autenticacaoHelper = new AutenticacaoHelper();

        public FuncionarioAutenticavel (double salario, string cpf) : base (salario, cpf)
        {

        }
                
        public bool Autenticar(string senha)
        {
            return _autenticacaoHelper.CompararSenha(Senha, senha);
        }

        internal protected override double GetBonificacao()
        {
            throw new NotImplementedException();
        }

        public override void AumentarSalario()
        {
            throw new NotImplementedException();
        }
    }
}
