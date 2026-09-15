using System.Collections;

var musica1 = new Musica
{
    Titulo = "Que País é Esse?",
    Artista = "Legião Urbana",
    Duracao = 350
};

var musica2 = new Musica
{
    Titulo = "Tempo Perdido",
    Artista = "Legião Urbana",
    Duracao = 302
};

var musica3 = new Musica
{
    Titulo = "Bohemian Rhapsody",
    Artista = "Queen",
    Duracao = 354
};

var musica4 = new Musica
{
    Titulo = "Smells Like Teen Spirit",
    Artista = "Nirvana",
    Duracao = 301
};

var musica5 = new Musica
{
    Titulo = "Numb",
    Artista = "Linkin Park",
    Duracao = 185
};

var musica6 = new Musica
{
    Titulo = "Do I Wanna now?",
    Artista = "Arctic Monkeys",
    Duracao = 272
};

var rockNacional = new Playlist { Nome = "Rock Nacional" };
rockNacional.Add(musica1);
rockNacional.Add(musica2);
rockNacional.Add(musica3);
rockNacional.Add(musica4);
rockNacional.Add(musica5);
rockNacional.Add(musica6);

ExibirPlaylist(rockNacional);

rockNacional.OrdenarPorDuracao();

ExibirPlaylist(rockNacional);

rockNacional.OrdenarPorArtista();

ExibirPlaylist(rockNacional);

// Métodos:

void ExibirPlaylist(Playlist playlist)
{
    System.Console.WriteLine($"\n Tocando as músicas de {playlist.Nome}");
    foreach (var musica in playlist)
    {
        System.Console.WriteLine($"\t - {musica.Titulo} ({musica.Artista})- {musica.Duracao} segundos");
    }
}

void RemoverMusicaPeloTitulo(Playlist playlist, string titulo)
{
    var musicaEncontrada = rockNacional.ObterPeloTitulo(titulo);
    if (musicaEncontrada is not null)
    {
        Console.WriteLine("\nRemovendo música...");
        rockNacional.Remove(musicaEncontrada);
    }
    else
    {
        Console.WriteLine("\nMúsica não encontrada!");
    }

    ExibirPlaylist(rockNacional);
}

void ExibirMusicaAleatoria(Playlist playlist)
{
    var musicaAleatoria = playlist.ObterAleatoria();
    if (musicaAleatoria is not null)
    {
        Console.WriteLine($"\nA música aleatória é {musicaAleatoria.Titulo}");
    }
    else
    {
        Console.WriteLine("Playlist vazia!");
    }
}

// Classes:

class PorArtista : IComparer<Musica>
{
    public int Compare(Musica? x, Musica? y)
    {
        if (x is null || y is null) return 0;
        if (x is null) return 1;
        if (y is null) return -1;
        return x.Artista.CompareTo(y.Artista);
    }
}

class PorTitulo : IComparer<Musica>
{
    public int Compare(Musica? x, Musica? y)
    {
        if (x is null || y is null) return 0;
        if (x is null) return 1;
        if (y is null) return -1;
        return x.Titulo.CompareTo(y.Titulo);
    }
}

class Musica : IComparable
{
    public string? Titulo { get; set; }
    public string? Artista { get; set; }
    public int Duracao { get; set; }

    public int CompareTo(object? other) // iguais: 0; menor: -1; maior: 1
    {
        if (other is null) return -1;
        if (other is Musica otherMusica)
            return this.Duracao.CompareTo(otherMusica.Duracao);
        return -1;
    }
}

class Playlist : ICollection<Musica>
{
    private List<Musica> lista = [];
    public string? Nome { get; set; }

    public int Count => lista.Count;

    public bool IsReadOnly => false;

    public void Add(Musica musica)
    {
        lista.Add(musica);
    }

    public Musica? ObterPeloTitulo(string titulo)
    {
        foreach (var musica in lista)
        {
            if (musica.Titulo == titulo)
            {
                return musica;
            }
        }

        return null;
    }

    public Musica? ObterAleatoria()
    {
        if (lista.Count == 0) return null;

        var random = new Random();
        var indiceAleatorio = random.Next(0, lista.Count - 1);
        return lista[indiceAleatorio];
    }

    public void OrdenarPorDuracao()
    {
        lista.Sort();
    }

    public void OrdenarPorArtista()
    {
        lista.Sort(new PorArtista());
    }

    public void Clear()
    {
        lista.Clear();
    }

    public bool Contains(Musica item)
    {
        return lista.Contains(item);
    }

    public void CopyTo(Musica[] array, int arrayIndex)
    {
        lista.CopyTo(array, arrayIndex);
    }

    public IEnumerator<Musica> GetEnumerator()
    {
        return lista.GetEnumerator();
    }

    public bool Remove(Musica item)
    {
        return lista.Remove(item);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}