using System.Collections;

var diasDaSemana = new DiasDaSemana();

var pares = NumerosParesComYield();
var contador = 0;
foreach (var par in pares)
{
    contador++;
    Console.WriteLine(par);
    if (contador > 200) break;
}

IEnumerable<int> NumerosParesSemYield(int limite)
{
    var lista = new List<int>();
    for (var i = 0; i < limite; i++)
    {
        System.Console.WriteLine($"Processando elemento {i}...");
        lista.Add(i * 2);
    }
    return lista;
}

IEnumerable<int> NumerosParesComYield()
{
    var i = 0;
    while (true)
    {
        Console.WriteLine($"Processando elemento {i}...");
        yield return i * 2;
        if (i > 100)
        {
            System.Console.WriteLine("Saindo do Enumerator...");
            yield break;
        }
        i++;
    }
}


// class DiasDaSemanaEnumerator : IEnumerator<string>
// {
//     private int posicao = -1;
//     private string[] dias =
//     {
//         "Domingo", "Segunda", "Terça", "Quarta", "Quinta", "Sexta", "Sábado"
//     };

//     public string Current => dias[posicao];

//     object IEnumerator.Current => Current;

//     public void Dispose()
//     {
//     }

//     public bool MoveNext()
//     {
//         posicao++;
//         return posicao < dias.Length;
//     }

//     public void Reset()
//     {
//         posicao = -1;
//     }
// }

class DiasDaSemana : IEnumerable<string>
{
    public IEnumerator<string> GetEnumerator()
    {
        // posicao = -1
        //MoveNext(): posicao = 0
        yield return "Domingo"; // Current: array[posicao]
        //MoveNext(): posicao = 1
        yield return "Segunda-feira"; // Current
        //MoveNext(): posicao = 2
        yield return "Terça-feira"; // Current
        yield return "Quarta-feira";
        yield return "Quinta-feira";
        yield return "Sexta-feira";
        yield return "Sábado";
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

public class Produto
{
    public required string Id { get; set; }
    public required string Nome { get; set; }
    public decimal? Preco { get; set; }
}
