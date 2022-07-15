using DIO_Bank.Classes;
using DIO_Bank.Enum;
using System;
using System.Collections.Generic;

namespace DIO_Bank
{
    class Program
    {
        static List<Conta> listaContas = new List<Conta>();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();
            while (opcaoUsuario != "X")
            {
                if (opcaoUsuario.Equals("1"))
                {
                    ListarContas();
                }
                else if (opcaoUsuario.Equals("2"))
                {
                    InserirConta();
                }
                else if (opcaoUsuario.Equals("3"))
                {
                    Transferir();
                }
                else if (opcaoUsuario.Equals("4"))
                {
                    Sacar();
                }
                else if (opcaoUsuario.Equals("5"))
                {
                    Depositar();
                }
                else if (opcaoUsuario.Equals("C"))
                {
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine(new ArgumentOutOfRangeException(null, "OPÇÃO INVÁLIDA!").Message);
                }

                opcaoUsuario = ObterOpcaoUsuario();
            }

            Console.WriteLine("Obrigado por utilizar nossos serviços.");
            Console.Read();
        }

        public static void InserirConta()
        {
            Console.WriteLine("Inserir nova conta");

            Console.Write("Digite 1 para Conta Física ou 2 para Conta Jurídica: ");
            int entradaTipoConta = int.Parse(Console.ReadLine());

            if (!ValidaTipoConta(entradaTipoConta))
            {
                Console.WriteLine("OPÇÃO INVÁLIDA!");
                return;
            }

            Console.Write("Digite o nome  do cliente: ");
            string entradaNomeCliente = Console.ReadLine();
            Console.Write("Digite o saldo inicial: ");
            double entraSaldo = double.Parse(Console.ReadLine());
            Console.Write("Digite o crédito: ");
            double entradaCredito = double.Parse(Console.ReadLine());
            Conta novaConta = new((TipoConta)entradaTipoConta, entradaNomeCliente, entraSaldo, entradaCredito);
            listaContas.Add(novaConta);
        }

        public static void ListarContas()
        {
            Console.WriteLine("Listar Contas");
            if (!VerificaListaConta())
            {
                return;
            }
            for (int i = 0; i < listaContas.Count; i++)
            {
                Console.Write("#{0} - ", i);
                Console.WriteLine(listaContas[i]);
            }

        }

        public static void Transferir()
        {
            if (!VerificaListaConta())
            {
                return;
            }

            Console.Write("Digite o número da conta de origem: ");
            int indiceContaOrigem = int.Parse(Console.ReadLine());

            Console.Write("Digite o número da conta de destino: ");
            int indiceContaDestino = int.Parse(Console.ReadLine());
            if (ValidaTransferencia(indiceContaOrigem, indiceContaDestino))
            {
                Console.Write("Digite o valo a ser transferido: ");
                double valorTransferencia = double.Parse(Console.ReadLine());

                listaContas[indiceContaOrigem].TrasferirDinheiro(valorTransferencia, listaContas[indiceContaDestino]);
            }
            return;
        }

        public static void Depositar()
        {
            if (!VerificaListaConta())
            {
                return;
            }
            Console.WriteLine("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());
            if (VerificaConta(indiceConta))
            {
                Console.WriteLine("Digite o valor a ser depositado:");
                double valorDeposito = double.Parse(Console.ReadLine());
                listaContas[indiceConta].Depositar(valorDeposito);
            }
            return;
        }

        public static void Sacar()
        {
            if (!VerificaListaConta())
            {
                return;
            }
            Console.WriteLine("Digite o número da Conta:");
            int indiceConta = int.Parse(Console.ReadLine());
            if (VerificaConta(indiceConta))
            {
                Console.WriteLine("Digite o valor a ser sacado:");
                double valorSaque = double.Parse(Console.ReadLine());
                listaContas[indiceConta].Sacar(valorSaque);
            }
            return;
        }

        public static bool ValidaTransferencia(int indiceOrigem, int indiceDestino)
        {
            if (VerificaConta(indiceOrigem))
            {
                if (VerificaConta(indiceDestino))
                {
                    return true;
                }
                else
                {
                    Console.WriteLine("A conta de destino digitada não existe!");
                    return false;
                }
            }
            else
            {
                Console.WriteLine("A conta de origem digitada não existe!");
                return false;
            }
        }

        public static bool VerificaListaConta()
        {
            if (listaContas.Count == 0)
            {
                Console.WriteLine("Nenhuma conta cadastrada!");
                return false;
            }
            else
            {
                return true;
            }
        }
        public static bool VerificaConta(int indiceConta)
        {
            if (indiceConta > listaContas.Count - 1)
            {
                Console.WriteLine("Conta inexistente!");
                return false;
            }
            return true;
        }
        public static bool ValidaTipoConta(int tipoConta)
        {
            if (tipoConta != 1 && tipoConta != 2)
            {
                return false;
            }
            return true;
        }
        public static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Bank ao seu dispor!!!");
            Console.WriteLine("Informe a opção desejada!");

            Console.WriteLine("1 - Listar Contas");
            Console.WriteLine("2 - Inserir no Conta");
            Console.WriteLine("3 - Transferir");
            Console.WriteLine("4 - Sacar");
            Console.WriteLine("5 - Depositar");
            Console.WriteLine("C - Limpar Tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
