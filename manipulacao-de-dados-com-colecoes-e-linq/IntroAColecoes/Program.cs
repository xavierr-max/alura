using System.Collections;

var diasDaSemana = new DiasDaSemana();

var carrinho = new List<Produto>()
{
    new() { Nome = "Leite", Preco = 7.89 },
    new() { Nome = "Manteiga", Preco = 3.45 }
};

// diasDaSemana[0];
// carrinho[0];

foreach (var dia in diasDaSemana) // IEnumerable<string> 
{
    Console.WriteLine(dia);
}

void PercorrendoComFor()
{
    for (int i = 0; i < carrinho.Count; i++)
    {
        var produto = carrinho[i];
        Console.WriteLine($"Produto: {produto.Nome}");
    }
}

void PercorrendoComForEach()
{
    foreach (var produto in carrinho)
    {
        Console.WriteLine($"Produto: {produto.Nome}");
    }
}

class Produto
{
    public string Nome { get; set; }
    public double Preco { get; set; }
}

class DiasDaSemanaEnumerator : IEnumerator<string>
{
    private int posicao = -1;
    private string[] dias =
    {
        "Domingo", "Segunda", "Terça", "Quarta", "Quinta", "Sexta", "Sábado"
    };
    public string Current => dias[posicao];
    object? IEnumerator.Current => Current;
    
    public bool MoveNext()
    {
        posicao++;
        return posicao < dias.Length;
    }

    public void Reset()
    {
        posicao = -1;
    }


    public void Dispose()
    {
    }
}

class DiasDaSemana : IEnumerable<string>
{
    public IEnumerator<string> GetEnumerator()
    {
        return new DiasDaSemanaEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}