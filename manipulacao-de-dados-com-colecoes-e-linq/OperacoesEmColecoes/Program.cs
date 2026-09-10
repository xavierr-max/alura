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
    Titulo = "Do I Wanna Know?",
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

void ExibirPlaylist(Playlist playlist)
{
    System.Console.WriteLine($"\n Tocando as músicas de {playlist.Nome}");
    foreach (var musica in playlist)
    {
        System.Console.WriteLine($"\t - {musica.Titulo}");
    }
}

class Musica
{
    public string? Titulo { get; set; }
    public string? Artista { get; set; }
    public int Duracao { get; set; }
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