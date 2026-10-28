using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;

namespace Gestor_de_Estoque
{
    internal class Program
    {

        static List<IEstoque> produtos = new List<IEstoque>();
        enum Menu { Listar = 1, Adicionar, Remover, Entrada, Saida, Sair}
        static void Main(string[] args)
        {
            Carregar();
            bool EscolheuSair = false;
            while (EscolheuSair == false)
            {
                Console.WriteLine("Sistema de estoque: ");
                Console.WriteLine(" 1 - Listar produtos\n 2 - Adicionar produto\n 3 - Remover produto\n 4 - Registrar entrada\n 5 - Registrar saída\n 6 - Sair");
                string OpcaoEsc = Console.ReadLine();
                int OpcaoEscolhida = int.Parse(OpcaoEsc);
                Menu escolha = (Menu)OpcaoEscolhida;
                if (OpcaoEscolhida > 0 && OpcaoEscolhida <= 6)
                {
                    switch (escolha)
                    {
                        case Menu.Listar:
                            Listar();
                            Console.ReadLine();
                            break;
                        case Menu.Adicionar:
                            Cadastro();
                            break;
                        case Menu.Remover:
                            Remover();
                            break;
                        case Menu.Entrada:
                            Entrada();
                            break;
                        case Menu.Saida:
                            Saida();
                            break;
                        case Menu.Sair:
                            EscolheuSair = true;
                            break;

                    }
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    Console.WriteLine("Pressione qualquer tecla para continuar...");
                    Console.ReadLine();
                    Console.Clear();
                    continue;
                }
            }
                
            static void Listar()
            {
                 Console.WriteLine("Lista de produtos:");
                int i = 0;
                foreach (IEstoque produto in produtos)
                 {
                    Console.WriteLine($"ID do produto: {i}");
                    produto.Exibir();
                    i ++;
                }
    
            }

            static void Remover()
            {
                Listar();
                Console.WriteLine("Digite o ID do produto que deseja remover: ");
                int id = int.Parse(Console.ReadLine());
                if (id >= 0 && id < produtos.Count)
                {
                    produtos.RemoveAt(id);
                    Salvar();
                }
                else
                {
                    Console.WriteLine("ID inválido. Pressione qualquer tecla para continuar...");
                    Console.ReadLine();
                    Console.Clear();
                }
            }

            static void Entrada()
            {
                Listar();
                Console.WriteLine("Digite o ID do produto que deseja registrar a entrada: ");
                int id = int.Parse(Console.ReadLine());
                if (id >= 0 && id < produtos.Count)
                {
                    produtos[id].AdicionarEntrada();
                    Salvar();
                }
                else
                {
                    Console.WriteLine("ID inválido. Pressione qualquer tecla para continuar...");
                    Console.ReadLine();
                    Console.Clear();
                }
            }

            static void Saida()
            {
                Listar();
                Console.WriteLine("Digite o ID do produto que deseja registrar a saída: ");
                int id = int.Parse(Console.ReadLine());
                if (id >= 0 && id < produtos.Count)
                {
                    produtos[id].AdicionarSaida();
                    Salvar();
                }
                else
                {
                    Console.WriteLine("ID inválido. Pressione qualquer tecla para continuar...");
                    Console.ReadLine();
                    Console.Clear();
                }
            }

            static void Cadastro()
            {
                Console.WriteLine("Cadastro de produtos...");
                Console.WriteLine("Escolha o tipo de produto: ");
                Console.WriteLine("1 - Produto Físico\n2 - Ebook\n3 - Curso");
                string OpcaoString = Console.ReadLine();
                int OpcaoInt = int.Parse(OpcaoString);
                switch (OpcaoInt)
                {
                     case 1:
                     CadastrarProdutoFisico();
                     break;
                     case 2:
                     CadastrarEbook();
                     break;
                     case 3:
                     CadastrarCurso();
                     break;
                     default:
                         Console.WriteLine("Opção inválida.");
                         Console.WriteLine("Pressione qualquer tecla para continuar...");
                         Console.ReadLine();
                         Console.Clear();
                     break;
                }
            }
                

            static void CadastrarProdutoFisico()
            {
                Console.WriteLine("Cadastro de Produto Físico");
                Console.WriteLine("Digite o nome do produto: ");
                string nome = Console.ReadLine();
                Console.WriteLine("Digite o preço do produto: ");
                float preco = float.Parse(Console.ReadLine());
                Console.WriteLine("Digite o frete do produto: ");
                float frete = float.Parse(Console.ReadLine());
                ProdutoFisico produtoFisico = new ProdutoFisico(nome, preco, frete);
                produtos.Add(produtoFisico);
                Salvar();   
            }

            static void CadastrarEbook()
            {
                Console.WriteLine("Cadastro de Ebook");
                Console.WriteLine("Digite o nome do ebook: ");
                string nome = Console.ReadLine();
                Console.WriteLine("Digite o preço do ebook: ");
                float preco = float.Parse(Console.ReadLine());
                Console.WriteLine("Digite o autor do ebook: ");
                string autor = Console.ReadLine();
                Ebook ebook = new Ebook(nome, preco, autor);
                produtos.Add(ebook);
                Salvar();
            }

            static void CadastrarCurso()
            {
                Console.WriteLine("Cadastro de Curso");
                Console.WriteLine("Digite o nome do curso: ");
                string nome = Console.ReadLine();
                Console.WriteLine("Digite o preço do curso: ");
                float preco = float.Parse(Console.ReadLine());
                Console.WriteLine("Digite o autor do curso: ");
                string autor = Console.ReadLine();
                Curso curso = new Curso(nome, preco, autor);
                produtos.Add(curso);
                Salvar();        
            }

            static void Salvar()
            {
                FileStream stream = new FileStream("produtos.dat", FileMode.OpenOrCreate);
                BinaryFormatter encoder = new BinaryFormatter();
                encoder.Serialize(stream, produtos);
                stream.Close();
            }

            static void Carregar()
            {
                FileStream stream = new FileStream("produtos.dat", FileMode.OpenOrCreate);
                BinaryFormatter encoder = new BinaryFormatter();
                try
                {
                    produtos = (List<IEstoque>)encoder.Deserialize(stream);
                    if (produtos == null)
                    {
                    produtos = new List<IEstoque>();
                    }
                }
                catch(Exception e)
                {
                produtos = new List<IEstoque>();
                }
                stream.Close();
            }

        }
    }
}
