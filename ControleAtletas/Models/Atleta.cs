namespace ControleAtletas.Models
{
    public class Atleta
    {
        public int AtletaID { get; set; }

        public string NomeCompleto { get; set; }

        public string Apelido { get; set; }

        public DateTime DataNascimento { get; set; }

        public double Altura { get; set; }

        public double Peso { get; set; }

        public string Posicao { get; set; }

        public int NumeroCamisa { get; set; }
    }
}
