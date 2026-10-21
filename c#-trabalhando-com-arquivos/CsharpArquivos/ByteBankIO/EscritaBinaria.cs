namespace ByteBankIO;

partial class Program
{
    static void EscritaBinaria()
    {
        using var fs = new FileStream("contaCorrente.txt", FileMode.OpenOrCreate);
        using var escritor = new BinaryWriter(fs);
        escritor.Write(456);
        escritor.Write(546544);
        escritor.Write(4000.05);
        escritor.Write("Gustavo Braga");
    }

    static void LeituraBinaria()
    {
        using var fs = new FileStream("contaCorrente.txt", FileMode.Open);
        using var leitor = new BinaryReader(fs);
        var agencia = leitor.ReadInt32();
        var numeroConta = leitor.ReadInt32();
        var saldo = leitor.ReadDouble();
        var titular = leitor.ReadString();

        Console.WriteLine($"Agencia: {agencia}/{numeroConta} {titular} {saldo}");
    }
}