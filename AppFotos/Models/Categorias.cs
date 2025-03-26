using System.ComponentModel.DataAnnotations;

namespace AppFotos.Models
{

    /// <summary>
    /// categorias a que as fotogrtafias podem ser associadas
    /// </summary>
    public class Categorias
    {
        /// <summary>
        /// Identificador das categorias
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Nome da categoria que será associada às fotografias
        /// </summary>
        [Required(ErrorMessage ="A {0} é de preenchimento obrigatório")] //Obrigatoriedade de preencher e a mensagem de erro
        [StringLength(20)] // Os caracteres de prenchimento limite
        [Display(Name ="Categoria")]
        public string Categoria { get; set; }


        /* *******************************
       * Definição dos Relacionamentos *
       * *******************************
       */

        public ICollection<Fotografias> ListaFotografias { get; set; }
    }
}
