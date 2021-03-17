using System;
using ProjetoBancoDIO.Classes;
using System.Collections.Generic;

namespace ProjetoBancoDIO
{
    class Program
    {
        static List<Conta> ListContas = new List<Conta>();
        private static string OpcaoUsuario()
        {
            Console.WriteLine("DIO Bank a seu dispor!!!\r\n" +
                            "Digite o correto para a opção desejada:\r\n" +
                            "1 - Listar contas\r\n" +
                            "2 - Inserir nova conta\r\n" +
                            "3 - Sacar\r\n" +
                            "4 - Depositar\r\n" +
                            "5 - Transferir\r\n" +
                            "X - Sair");
            string var = Console.ReadLine().ToUpper();
            Console.Clear();
            return var;
        }
        static void LeituradeDados(out int S_NumConta, out double S_Valor)
        {
            Console.WriteLine("Digite o número da conta: ");
            S_NumConta = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Digite a quantia: ");
            S_Valor = Convert.ToDouble(Console.ReadLine());
        }
        static void Main(string[] args)
        {
            string Opcao = OpcaoUsuario();
            while (Opcao != "X")
            {
                switch (Opcao)
                {
                    case "1":
                        if (ListContas.Count == 0)
                        {
                            Console.WriteLine("Nenhuma conta cadastrada.");
                            Console.WriteLine("\r\nPrecione enter para continuar.");
                            Console.ReadKey();
                            break;
                        }
                        Console.WriteLine("Contas: ");
                        for (int i = 0; i < ListContas.Count; i++)
                        {
                            Conta conta = ListContas[i];
                            Console.WriteLine("#" + i + " | " + conta.MostrarContar());
                            
                        }
                        Console.WriteLine("\r\nPrecione enter para continuar.");
                        Console.ReadKey();
                        break;
                    case "2":
                        Console.WriteLine("Inserir nova Conta\n\n" +
                            "Digite 1 para Conta Física ou 2 para Jurídica:");
                        int P_TipoConta = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("\r\nDigite o Nome do Cliente: ");
                        string P_Nome = Console.ReadLine();

                        Console.WriteLine("\r\nDigite o Saldo Incial: ");
                        double P_SaldoInicial = Convert.ToDouble(Console.ReadLine());

                        Console.WriteLine("\r\nDigite o Crédito Incial: ");
                        double P_CreditoInicial = Convert.ToDouble(Console.ReadLine());

                        Conta NovaConta = new Conta((TipoConta)P_TipoConta, P_SaldoInicial, P_CreditoInicial, P_Nome);

                        ListContas.Add(NovaConta);
                        break;
                    case "3":
                        int Num;
                        double Quant;
                        LeituradeDados(out Num,out Quant);
                        ListContas[Num].Sacar(Quant);
                        Console.Clear();
                        break;
                    case "4":
                        LeituradeDados(out Num, out Quant);

                        ListContas[Num].Depositar(Quant);
                        Console.Clear();
                        break;
                    case "5":
                        Console.WriteLine("Digite o número da conta origem: ");
                        int Num_Origem = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Digite o número da conta destino: ");
                        int Num_Destin = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Digite a quantia a ser tranferida: ");
                        double Valor_Transf = Convert.ToDouble(Console.ReadLine());

                        ListContas[Num_Origem].Transferir(Valor_Transf,ListContas[Num_Destin]);

                        Console.Clear();
                        break;
                }
                Console.Clear();
                Opcao = OpcaoUsuario();
            }
        }
    }
}
