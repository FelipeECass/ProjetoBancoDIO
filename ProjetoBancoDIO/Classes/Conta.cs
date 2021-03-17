using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoBancoDIO.Classes
{
    class Conta
    {
        private TipoConta TipoConta { get; set; }
        private double Saldo { get; set; }
        private double Credito { get; set; }
        private string Nome { get; set; }

        public Conta(TipoConta P_TipoConta, double P_Saldo, double P_Credito, string P_Nome)
        {
            this.TipoConta = P_TipoConta;
            this.Saldo = P_Saldo;
            this.Credito = P_Credito;
            this.Nome = P_Nome;
        }
        public void Depositar(double P_SaldoDeposito) => this.Saldo += P_SaldoDeposito;
        public void Transferir(double P_SaldoTransf, Conta P_ContaDestino)
        {
            if(this.Sacar(P_SaldoTransf))
            {
                P_ContaDestino.Depositar(P_SaldoTransf);
            }
        }
        public bool Sacar(double P_SaldoSaque)
        {
            if (this.Saldo - P_SaldoSaque < (this.Credito *-1))
            {
                Console.WriteLine("Saldo insuficiente!");
                return false;
            }
            this.Saldo -= P_SaldoSaque;
            return true;
        }
        public string MostrarContar()
        {
            string Conta = "Tipo da Conta: " + this.TipoConta +
                " | Nome: " + this.Nome + " | Saldo: " +
                this.Saldo + " | Crédito: " + this.Credito;
            return Conta;
        }
    }
}
