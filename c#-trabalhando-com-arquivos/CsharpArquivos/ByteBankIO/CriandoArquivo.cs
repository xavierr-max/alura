using System.Text;

namespace ByteBankIO;

partial class Program
{
    public static void CriarArquivo()
    {
        var caminhoNovoArquivo = "contasExportadas.csv";

        using (var fluxoDeArquivo = new FileStream(caminhoNovoArquivo, FileMode.Create))
        {
            var contaComoString = "456, 7895, 4785.40, Gustavo Santos";

            var encoding = Encoding.UTF8;
            
            var data = encoding.GetBytes(contaComoString);
            
            fluxoDeArquivo.Write(data, 0, data.Length);
        }
    }

    static void CriarArquivoComWriter()
    {
        var caminhoNovoArquivo = "contasExportadas.csv";

        using var fluxoDeArquivo = new FileStream(caminhoNovoArquivo, FileMode.CreateNew);
        using var escritor = new StreamWriter(fluxoDeArquivo);
        escritor.Write("456, 7895, 4785.40, Pedro");
    }

    static void TestaEscrita()
    {
        var caminhoNovoArquivo = "contasExportadas.csv";

        using var fluxoDeArquivo = new FileStream(caminhoNovoArquivo, FileMode.Create);
        using var escritor = new StreamWriter(fluxoDeArquivo);
        for (int i = 0; i < 1000000; i++)
        {
            escritor.WriteLine($"Linha {i}");
            escritor.Flush(); // Despeja o buffer para o Stream
            
            Console.WriteLine($"Linha {i} foi escrita no arquivo. Tecle enter...");
            Console.ReadLine();
        }

    }
}

