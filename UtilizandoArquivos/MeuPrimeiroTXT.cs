using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace AulasCSharp.UtilizandoArquivos
{
    internal class MeuPrimeiroTXT
    {
        // Defino o meu nome e diretório.
        const string MEU_ARQUIVO = @"C:\Users\marco\Downloads\CursoProgramacaoCSharp (2)\AulasCSharp\UtilizandoArquivos\MeusArquivos\Primeiro.txt";

        public static void CriarArquivo()
        {
            File.Create(MEU_ARQUIVO);
            Console.WriteLine("Arquivo criado");
        }

        public static void EscreverNoArquivo(string texto)
        {
            if (!File.Exists(MEU_ARQUIVO))
            {
                CriarArquivo();
            }

            var sw = new StreamWriter(MEU_ARQUIVO, true);
            sw.WriteLine($"Esse usuário adicionou o texto: {texto}");
            sw.Close();
        }

        public static void LerArquivo()
        {
            string textoArquivo = new StreamReader(MEU_ARQUIVO).ReadToEnd();
            Console.WriteLine(textoArquivo);
        }
    }
}
