namespace ControleAtletas.Models
{
    public class Atleta
    {
        public int AtletaID { get; set; }

        public string NomeCompleto { get; set; }

        public string Apelido { get; set; }

        public DateTime DataNascimento { get; set; }

        public float Altura { get; set; }

        public float Peso { get; set; }

        public string Posicao { get; set; }

        public int NumeroCamisa { get; set; }

        public float CalcularIMC()
        {
            return Peso / (Altura * Altura);
        }
        public string ClassificarIMC()
        {
            float imc = CalcularIMC();

            if (imc < 18.5)

                return "Abaixo do peso normal";

            else if (imc >= 18.5 && imc <= 24.9)

                return "Peso normal";

            else if (imc >= 25.0 && imc <= 29.9)

                return "Excesso de peso";

            else if (imc >= 30 && imc <= 34.9)

                return "Obesidade Classe I";

            else if (imc >= 35.0 && imc <= 39.9)

                return "Obesidade Classe II";

            else

                return "Obesidade Classe III";
        }
    }
}
