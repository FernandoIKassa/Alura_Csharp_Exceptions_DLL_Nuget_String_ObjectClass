using System;

namespace ByteBank.Modelos
{
    public class ContaCorrente
    {
        public Cliente Titular { get; set; }

        public static int TotalDeContasCriadas { get; private set; }
        public static double TaxaOperacao { get; private set; }

        public int ContadorSaquesNaoPermitidos { get; private set; }
        public int ContadorTransferenciasNaoPermitidas { get; private set; }


        public int Agencia { get; }
        public int Numero { get; }

        private double _saldo = 100;

        public double Saldo
        {
            get
            {
                return _saldo;
            }
            set
            {
                if (value < 0)
                {
                    return;
                }

                _saldo = value;
            }
        }

        /// <summary>
        /// Classe para representar uma Conta Corrente do banco ByteBank
        ///
        /// </summary>
        /// <param name="agencia">Representa o valor da propriedade <see cref="Agencia"/> e
        /// deve possuir um valor maior que zero</param>
        /// <param name="numero">Representa o valor da propriedade <see cref="Numero"/> e
        /// deve possuir um valor maior que zero</param>
        public ContaCorrente(int agencia, int numero)
        {

            if (agencia <= 0)
            {
                throw new ArgumentException("O argumento agencia deve ser maior que zero.", nameof(agencia));
            }

            if (numero <= 0)
            {
                throw new ArgumentException("O argumento numero deve ser maior que zero", nameof(numero));
            }
            
            Agencia = agencia;
            Numero = numero;

            TotalDeContasCriadas++;
            TaxaOperacao = 30 / TotalDeContasCriadas;

            
        }

        /// <summary>
        /// Realiza o saque e atualiza o valor da propriedade <see cref="Saldo"/>.
        /// </summary>
        /// <param name="valor">Representa o valor do saque, deve ser maior que 0 e menor que o <see cref="Saldo"/>.</param>
        /// <exception cref="SaldoInsuficienteException">Exceção lançada quando o valor de <paramref name="valor"/> é maior que
        /// o maior valor da propriedade <see cref="Saldo"/> </exception>
        public void Sacar(double valor)
        {
            if(valor < 0)
            {
                throw new ArgumentException("Valor para saque não pode ser negativo", nameof(valor));
            }
            
            if (_saldo < valor)
            {
                ContadorSaquesNaoPermitidos++;
                throw new SaldoInsuficienteException(Saldo, valor);
            }

            _saldo -= valor;
            
        }

        public void Depositar(double valor)
        {
            _saldo += valor;
        }

        /// <summary>
        /// Realiza <see cref="Sacar(double)"/> da origem, diminuindo-se <see cref="ContaCorrente.Saldo"/> da conta origem
        /// de acordo com o argumento <paramref name="valor"/> para aumento da propriedade <see cref="Saldo"/>
        /// da conta correte indicada no argumento <paramref name="contaDestino"/> através do
        /// método <see cref="Depositar(double)"/>
        /// </summary>
        /// <param name="valor">Argumento que indica quanto será retirada da conta origem para ser enviado a <paramref name="contaDestino"/>"/></param>
        /// <param name="contaDestino">Argumento indicando qual <see cref="ContaCorrente"/> será destino do envio do <paramref name="valor"/></param>
        /// <exception cref="ArgumentException">Exceção lançada quando <paramref name="valor"></paramref> contém um valor menor que zero></exception>
        /// <exception cref="SaldoInsuficienteException">Exceção lançada quando <paramref name="valor"/>
        /// supera <see cref="ContaCorrente.Saldo"></see> da conta origem/></exception>

        public void Transferir(double valor, ContaCorrente contaDestino)
        {
            if (valor < 0)
            {
                throw new ArgumentException("Valor inválido para transferencia.");
            }

            try
            {
                Sacar(valor);
            }
            catch (SaldoInsuficienteException ex)
            {
                ContadorTransferenciasNaoPermitidas++;
                throw new OperacaoFinanceiraException("OPERACAO NAO REALIZADA.", ex);
            }

            //Sacar(valor);
            contaDestino.Depositar(valor);
            
        }
    }
}
