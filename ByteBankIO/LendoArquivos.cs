namespace ByteBankIO;

partial class Program
{
    static void LendoArquivos()
    {
        var enderecoDoArquivo = Path.Combine(AppContext.BaseDirectory, "contas.txt");

        using (var fluxoDeArquivo = new FileStream(enderecoDoArquivo, FileMode.Open))
        {
            var leitor = new StreamReader(fluxoDeArquivo);

            // var linha = leitor.ReadLine();

            // var texto = leitor.ReadToEnd();

            // var numero = leitor.Read();

            while (!leitor.EndOfStream)
            {
                var linha = leitor.ReadLine();
                if (linha is null)
                {
                    continue;
                }

                var contaCorrente = ConverterStringParaContaCorrente(linha);

                var msg =
                    $"{contaCorrente.Titular.Nome}: Conta número: {contaCorrente.Numero}, ag {contaCorrente.Agencia}, Saldo: {contaCorrente.Saldo}";

                Console.WriteLine(msg);
            }

            Console.WriteLine();
        }

        static ContaCorrente ConverterStringParaContaCorrente(string linha)
        {
            var campos = linha.Split(',');

            var agencia = int.Parse(campos[0]);
            var numero = int.Parse(campos[1]);
            var saldo = double.Parse(campos[2]);
            var nomeTitular = new Cliente(campos[3]);

            var resultado = new ContaCorrente(agencia, numero);
            resultado.Depositar(saldo);
            resultado.Titular = nomeTitular;

            return resultado;
        }
    }
}

