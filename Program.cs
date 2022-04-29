using System;
using System.Collections.Generic;

namespace SistemaBanco
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool escolheuSair = false;
            while (!escolheuSair)
            {
                Conta c = new Conta();
                Console.WriteLine("1 - Abrir Conta \n2 - Depositar \n3 - Sacar \n4 - Exibir Contas \n5 - Excluir Conta \n6 - Sair");
                int escolha = int.Parse(Console.ReadLine());

                switch (escolha)
                {
                    case 1:
                        c.CriarConta();
                        break;
                    case 2:
                        c.Depositar();
                        break;
                    case 3:
                        c.Sacar();
                        break;
                    case 4:
                        c.ExibirContas();
                        break;
                    case 5:
                        c.Excluir();
                        break;
                    case 6:
                        escolheuSair |= true;
                        break;
                }
                Console.WriteLine("ENTER para continuar...");
                Console.ReadLine();
                Console.Clear();
            }
        }
    }
}
