using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestor_de_Estoque
{
    [System.Serializable]
    class Ebook : Produto, IEstoque
    {
        public string autor;
        private int vendas;

        public Ebook(string nome, float preco, string autor)
        {
            this.nome = nome;
            this.preco = preco;
            this.autor = autor;
        }

        public void AdicionarEntrada()
        {
            Console.WriteLine("Não é possível dar entrada no estoque de um Ebook, pois é um produto digital.");
            Console.ReadLine();
        }

        public void AdicionarSaida()
        {
            Console.WriteLine($"Sinalizar as vendas do ebook: {nome}");
            Console.WriteLine("Digite a quantidade de vendas desse ebook: ");
            int saida = int.Parse(Console.ReadLine());
            vendas += saida;
            Console.WriteLine("Vendas registradas com sucesso!");
            Console.ReadLine();
        }

        public void Exibir()
        {
            Console.WriteLine($"Nome: {nome} \nAutor: {autor} \nPreço: {preco} \nVendas: {vendas} ");
            Console.WriteLine("--------------------------------------------------");
        }
    }
}
