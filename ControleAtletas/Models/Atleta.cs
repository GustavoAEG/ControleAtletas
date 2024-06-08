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
        public float Altura { get; set; }

        [Required(ErrorMessage = "Informe o Peso")]
        [Display(Name = "Peso")]
        public float Peso { get; set; }

        [Required(ErrorMessage = "Informe a Posição")]
        [Display(Name = "Posicao")]
        public string Posicao { get; set; }

        [Required(ErrorMessage = "Informe o número da camisa")]
        [Display(Name = "NumeroCamisa")]
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
