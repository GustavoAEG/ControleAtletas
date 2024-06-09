using System.ComponentModel.DataAnnotations;

namespace ControleAtletas.Models
{
    public class Atleta
    {
        [Key]
        public int AtletaID { get; set; }

        [Required(ErrorMessage = "Informe o nome do Atleta")]
        [StringLength(200,ErrorMessage ="O tamanho máximo são 200 caracteres")]
        [Display(Name ="NomeCompleto")]
        public string NomeCompleto { get; set; }

        [Required(ErrorMessage = "Informe o campo: Apelido")]
        [StringLength(100, ErrorMessage ="O tamanho máximo são de 100 caracteres")]
        [Display(Name ="Apelido")]
        public string Apelido { get; set; }

        [Required(ErrorMessage = "Informe a Data de Nascimento")]
        [Display(Name = "DataNascimento")]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "Informe a Altura")]
        [Display(Name = "Altura")]
        public double Altura { get; set; }

        [Required(ErrorMessage = "Informe o Peso")]
        [Display(Name = "Peso")]
        public double Peso { get; set; }

        [Required(ErrorMessage = "Informe a Posição")]
        [Display(Name = "Posicao")]
        public string Posicao { get; set; }

        [Required(ErrorMessage = "Informe o número da camisa")]
        [Display(Name = "NumeroCamisa")]
        public int NumeroCamisa { get; set; }

        public double IMC { get; set; }

        public string ?Classificacao { get; set; }

        public double CalcularIMC()
        {
            return Peso / (Altura * Altura) * 10000;
        }

        public string ClassificarIMC(string classificacao)
        {
            if (IMC < 18.5)

                Classificacao = "Abaixo do peso normal";

            else if (IMC >= 18.5 && IMC <= 24.9)

                Classificacao = "Peso normal";

            else if (IMC >= 25.0 && IMC <= 29.9)

                Classificacao = "Excesso de peso";

            else if (IMC >= 30 && IMC <= 34.9)

                Classificacao = "Obesidade Classe I";

            else if (IMC >= 35.0 && IMC <= 39.9)

                Classificacao = "Obesidade Classe II";

            else

                Classificacao = "Obesidade Classe III";

             classificacao = Classificacao;

            return classificacao;
        }
    }
}
