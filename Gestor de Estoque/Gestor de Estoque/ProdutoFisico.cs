using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestor_de_Estoque
{
    [System.Serializable]
    class ProdutoFisico : Produto, IEstoque
    {
        public float frete;
        private int estoque;

        public ProdutoFisico(string nome, float preco, float frete)
        {
            this.nome = nome;
            this.preco = preco;
            this.frete = frete;
            
        }

        public void AdicionarEntrada()
        {
            Console.WriteLine($"Realizar a entrada no estoque do produto: {nome}");
            Console.WriteLine("Digite a quantidade de produtos que deseja adicionar ao estoque: ");
            int entrada = int.Parse(Console.ReadLine());
            estoque += entrada;
            Console.WriteLine("Entrada registrada com sucesso!");
            Console.ReadLine();
        }

        public void AdicionarSaida()
        {
            Console.WriteLine($"Realizar a saída no estoque do produto: {nome}");
            Console.WriteLine("Digite a quantidade de produtos que deseja remover do estoque: ");
            int saida = int.Parse(Console.ReadLine());
            estoque -= saida;
            Console.WriteLine("Saída registrada com sucesso!");
            Console.ReadLine();
        }

        public void Exibir()
        {
            Console.WriteLine($"Nome: {nome} \nFrete: {frete} \nPreço: {preco} \nEstoque: {estoque} ");
            Console.WriteLine("--------------------------------------------------");
        }
    }
}
