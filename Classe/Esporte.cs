namespace ClubeDosEsportes
{
    public class Esporte
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public int Ano { get; set; }
        public string Descricao { get; set; }

        public Esporte(int id, string titulo, int ano, string descricao)
        {
            Id = id;
            Titulo = titulo ?? "";
            Ano = ano;
            Descricao = descricao ?? "";
        }

        public override string ToString()
        {
            return $"{Id} - {Titulo} ({Ano})\nDescrição: {Descricao}";
        }
    }
}
