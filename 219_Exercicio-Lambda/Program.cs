using _219_Exercicio_Lambda.Entidades;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _219_Exercicio_Lambda
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Entre com o caminho do arquivo: ");
            string arquivo = Console.ReadLine();

            List<Produto> lista = new List<Produto>();
            using (StreamReader sr = File.OpenText(arquivo)) //arquivo para a leitura.
            {
                while (!sr.EndOfStream) //enquanto arquivo não terminar de ser lido
                {
                    string[] campos = sr.ReadLine().Split(','); //vetor campo recebe valor sr até chegar a virgula
                    string nome = campos[0]; 
                    double preco = double.Parse(campos[1], CultureInfo.InvariantCulture);
                    lista.Add(new Produto(nome, preco)); //adiciona um novo produto na lista

                }
                var media = lista.Select(p => p.Preco).DefaultIfEmpty(0.0).Average(); // var recebe a media dos preços contidos em lista.
                Console.WriteLine("Media dos Preços: " + media.ToString("F2", CultureInfo.InvariantCulture));

                var nomes = lista.Where(p => p.Preco < media).OrderByDescending(p => p.Nome).Select(p => p.Nome);
                //var recebe da lista os nomes que possuirem os preços  menores que a media em orderm 

                foreach (string lista_nome in nomes)
                {
                    Console.WriteLine(lista_nome);
                }//exibindo lista dos nomes que atendam condição da var nomes.
            }

        }
    }
}
