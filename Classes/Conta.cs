using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DIO_Bank.Enum;

namespace DIO_Bank.Classes
{
    class Conta
    {
        public Conta(TipoConta tipoConta, string nome, double saldo,double credito)
        {
            this.TipoConta = tipoConta;
            this.Nome = nome;
            this.Saldo = saldo;
            this.Credito = credito;
        }

        private TipoConta TipoConta { get; set; }
        private string Nome { get; set; }
        private double Saldo { get; set; }
        private double Credito { get; set; }


        public bool Sacar(double valorSaque)
        {
            //Verificando se o cliente possue saldo suficiente para efetuar o saque
            if(this.Saldo - valorSaque < (this.Credito * -1))
            {
                Console.WriteLine("Saldo Insuficiente!");
                return false;
            }
            this.Saldo -= valorSaque;
            Console.WriteLine($"Saldo atual da conta de {this.Nome} é de {this.Saldo}");
            return true;
        }

        public void Depositar(double valorDeposito)
        {
            this.Saldo+= valorDeposito;
            Console.WriteLine($"Saldo atual da conta de {this.Nome} é de {this.Saldo}");
        }

        public void TrasferirDinheiro(double valorTransferencia, Conta contaDestino)
        {
            if (this.Sacar(valorTransferencia))
            {
                contaDestino.Depositar(valorTransferencia);
            }
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "Tipo de Conta: "+this.TipoConta + " | ";
            retorno += "Nome: " + this.Nome + " | ";
            retorno += "Saldo: " + this.Saldo + " |";
            retorno += "Crédito: " + this.Credito;
            return retorno;
        }
    }
}
