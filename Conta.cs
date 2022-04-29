using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBanco
{
    public class ContasRepository
    {
        public static List<Conta> CriarContas = new List<Conta>();
    }
    public class Conta
    {
        private string Nome { get; set; }
        private string TipoConta { get; set; }
        private double Saldo { get; set; }
        private bool Status { get; set; }
        

        public Conta()
        {

        }
        public Conta(string nome, string tipoConta, double saldo, bool status)
        {
            Nome = nome;
            TipoConta = tipoConta;
            Saldo = saldo;
            Status = status;
        }

        public override string ToString()
        {
            return $"Nome: {Nome}, Tipo de conta: {TipoConta}, Saldo: {Saldo}";
        }

        public void CriarConta()
        {
            Console.WriteLine("Digite o seu nome: ");
            string nome = Console.ReadLine();
            Console.WriteLine("Digite o número do tipo da conta: \n1 - Conta Corrente \n2 - Conta Poupança");
            int tipo = int.Parse(Console.ReadLine());
            string tipoConta = "";
            if(tipo == 1)
            {
                tipoConta = "Corrente";

            }else if(tipo == 2)
            {
                tipoConta = "Poupança";
            }
            Console.WriteLine("Deseja depositar algum valor de início? (S/n)");
            char deposito = char.Parse(Console.ReadLine().ToLower());
            double saldo = 0;
            if(deposito == 's')
            {
                Console.WriteLine("Digite o valor do depósito: ");
                saldo = double.Parse(Console.ReadLine());
            }else if(deposito == 'n')
            {
                saldo = 0;               
            }
            ContasRepository.CriarContas.Add(new Conta(nome, tipoConta, saldo, true));

        }

        public void ExibirContas()
        {
            foreach(Conta conta in ContasRepository.CriarContas)
            {
                if(conta.Status == true)
                {
                    Console.WriteLine(conta);
                }        
            }
        }

        public void Depositar()
        {
            Console.WriteLine("Digite o nome do titular: ");
            string nome = Console.ReadLine();
            Conta result = ContasRepository.CriarContas.Find(c => c.Nome == nome);
            double saldo = 0;
            if(result != null && result.Status == true)
            {
                Console.WriteLine("Digite o valor do depósito: ");
                saldo = double.Parse(Console.ReadLine());
                if(saldo > 0)
                {
                    result.Saldo += saldo;
                    Console.WriteLine("Depósito realizado com sucesso!");
                }
                else if(saldo <= 0)
                {
                    Console.WriteLine("Não é possível depositar este valor");
                }
            }
            else
            {
                Console.WriteLine("Esta conta não existe");
            }
            
        }
        public void Sacar()
        {
            Console.WriteLine("Digite o nome do titular: ");
            string nome = Console.ReadLine();
            Conta result = ContasRepository.CriarContas.Find(c => c.Nome == nome);
            double saldo = 0;
            if(result != null && result.Status == true)
            {
                Console.WriteLine("Digite o valor do saque: ");
                saldo = double.Parse(Console.ReadLine());
                if(saldo <= result.Saldo)
                {
                    result.Saldo -= saldo;
                    Console.WriteLine("Saque realizado com sucesso!");
                }else if(saldo > result.Saldo)
                {
                    Console.WriteLine("Saldo insuficiente!");
                }
            }
            else
            {
                Console.WriteLine("Este valor não é permitido");
            }
        }

        public void Excluir()
        {
            Console.WriteLine("Digite o nome do titular: ");
            string nome = Console.ReadLine();
            Conta result = ContasRepository.CriarContas.Find(c => c.Nome == nome);
            if(result != null && result.Status == true)
            {
                if(result.Saldo == 0)
                {
                    result.Status = false;
                    Console.WriteLine("Conta excluída com sucesso!");
                }
                else
                {
                    Console.WriteLine("Ainda possui dinheiro na conta! Saque para poder excluir.");
                }            
            }
            else
            {
                Console.WriteLine("Esta conta não existe!");
            }
        }

    }
}
