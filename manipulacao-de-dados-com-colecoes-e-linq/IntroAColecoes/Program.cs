using System.Collections;

var diasDaSemana = new DiasDaSemana();

foreach (var dia in diasDaSemana)
{
    System.Console.WriteLine(dia);
}



class DiasDaSemanaEnumerator : IEnumerator<string>
{
    private int posicao = -1;
    private string[] dias =
    {
        "Domingo", "Segunda", "Terça", "Quarta", "Quinta", "Sexta", "Sábado"
    };

    public string Current => dias[posicao];

    object IEnumerator.Current => Current;

    public void Dispose()
    {
    }

    public bool MoveNext()
    {
        posicao++;
        return posicao < dias.Length;
    }

    public void Reset()
    {
        posicao = -1;
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