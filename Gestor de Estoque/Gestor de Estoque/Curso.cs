using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestor_de_Estoque
{
    [System.Serializable]
    class Curso : Produto, IEstoque
    {
        public string autor;
        private int vagas;
        public Curso(string nome, float preco, string autor)
        {
            this.nome = nome;
            this.preco = preco;
            this.autor = autor;
            
        }

        public void AdicionarEntrada()
        {
            Console.WriteLine($"Adicionar vagas no curso: {nome}");
            Console.WriteLine("Digite a quantidade de vagas que deseja adicionar: ");
            int entrada = int.Parse(Console.ReadLine());
            vagas += entrada;
            Console.WriteLine("Entrada registrada com sucesso!");
            Console.ReadLine();
        }

        public void AdicionarSaida()
        {
            Console.WriteLine($"Consumir vagas no curso: {nome}");
            Console.WriteLine("Digite a quantidade de vagas que deseja consumir: ");
            int saida = int.Parse(Console.ReadLine());
            vagas -= saida;
            Console.WriteLine("Saída registrada com sucesso!");
            Console.ReadLine();
        }

        public void Exibir()
        {
            Console.WriteLine($"Nome: {nome} \nAutor: {autor} \nPreço: {preco} \nVagas restantes: {vagas} ");
            Console.WriteLine("--------------------------------------------------");
        }
    }
}
