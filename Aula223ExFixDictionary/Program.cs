using System.Globalization;
using System.IO;

namespace Aula223ExFixDictionary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter file full path: ");
            string path = Console.ReadLine(); //Caminho do arquivo digitado pelo usuário


            try //Bloco try-catch para tratamento de erro
            {

                using (StreamReader sr = File.OpenText(path)) //Bloco using para abrir e ler as linhas do arquivo 
                {
                    Dictionary<string, int> dictionary = new Dictionary<string, int>(); //Instanciando o Dictionary candidato com key = string e value = int

                    while (!sr.EndOfStream) //Enquanto não chegar na leitura final do arquivo
                    {
                        string[] line = sr.ReadLine().Split(','); //vetor de string pegando a linha do aqruivo e separando através da virgula ','
                        string candidate = line[0]; //Salvando o nome do candidato da primeira posição do vetor 
                        int votes = int.Parse(line[1]); //Salvador os votos da segunda posição do vetor e convertendo para inteiro


                        if (dictionary.ContainsKey(candidate)) //Condicional para verificar se o Dictionary contém a key candidate
                        { //Caso sim
                            dictionary[candidate] += votes; //A dictionary candidate atual recebe os votos + os novos votos lidos
                        }
                        else
                        { //Caso não
                            dictionary[candidate] = votes; //Recebe apenas os votos atuais
                        }
                    }


                    foreach (var item in dictionary) //Para cada var (KeyValuePair<string, string>) item no dictionary, faça
                    {
                        Console.WriteLine(item.Key + ": " + item.Value); //Imprime a key do dictionary item + o value
                    }
                }
            }
            catch (IOException e) 
            {
                Console.WriteLine("An error occurred");
                Console.WriteLine(e.Message);
            }


        }
    }
}