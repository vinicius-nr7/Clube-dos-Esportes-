using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Linq;
using ClubeDosEsportes.Interfaces;

namespace ClubeDosEsportes.Classes
{
    public class SerieRepositorio : IRepositorio<Serie>
    {
        private List<Serie> listaSerie = new List<Serie>();
        private readonly string caminhoArquivo = "series.json";

        public SerieRepositorio() => CarregarDados();

        private void CarregarDados()
        {
            if (File.Exists(caminhoArquivo))
            {
                string json = File.ReadAllText(caminhoArquivo);
                listaSerie = JsonSerializer.Deserialize<List<Serie>>(json) ?? new List<Serie>();
            }
        }

        private void SalvarDados() => 
            File.WriteAllText(caminhoArquivo, JsonSerializer.Serialize(listaSerie, new JsonSerializerOptions { WriteIndented = true }));

        public List<Serie> Lista() => listaSerie;

        public Serie? RetornaPorId(int id) => listaSerie.FirstOrDefault(s => s.retornaId() == id);

        public void Insere(Serie objeto) { listaSerie.Add(objeto); SalvarDados(); }

        public void Exclui(int id) {
            var serie = RetornaPorId(id);
            if (serie != null) { serie.Excluir(); SalvarDados(); }
        }

        public void Atualiza(int id, Serie objeto) {
            int indice = listaSerie.FindIndex(s => s.retornaId() == id);
            if (indice != -1) { listaSerie[indice] = objeto; SalvarDados(); }
        }

        public int ProximoId() => listaSerie.Count > 0 ? listaSerie.Max(s => s.retornaId()) + 1 : 1;
    }
}