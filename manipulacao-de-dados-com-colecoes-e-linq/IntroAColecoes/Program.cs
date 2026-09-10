using System.Collections;

var diasDaSemana = new DiasDaSemana();

PercorrendoComEnumerator();

void PercorrendoComEnumerator()
{
    var enumerator = diasDaSemana.GetEnumerator();
    while (enumerator.MoveNext())
    {
        var dia = enumerator.Current;
        Console.WriteLine(dia);
    }
}

void PercorrendoDiasDaSemana()
{
    foreach (var dia in diasDaSemana)
    {
        Console.WriteLine(dia);
    }
}

// yield: utiliza do gerenciamento de memória do .NET para criar essa classe abaixo
//
// class DiasDaSemanaEnumerator : IEnumerator<string>
// {
//     private int posicao = -1;
//
//     private string[] dias =
//     {
//         "Domingo", "Segunda", "Terça", "Quarta", "Quinta", "Sexta", "Sábado"
//     };
//
//     public string Current => dias[posicao];
//
//     object IEnumerator.Current => Current;
//
//     public void Dispose()
//     {
//     }
//
//     public bool MoveNext()
//     {
//         posicao++;
//         return posicao < dias.Length;
//     }
//
//     public void Reset()
//     {
//         posicao = -1;
//     }
// }

class DiasDaSemana : IEnumerable<string>
{
    public IEnumerator<string> GetEnumerator()
    {
        yield return "Domingo";
        yield return "Segunda";
        yield return "Terça";
        yield return "Quarta";
        yield return "Quinta";
        yield return "Sexta";
        yield return "Sábado";
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}