using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppFotos.Models
{

    /// <summary>
    /// Fotografias disponíveis na aplicação
    /// </summary>
    public class Fotografias
    {

        /// <summary>
        /// Identificados de Fotografia
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Título da fotografia
        /// </summary>
        public string Titulo { get; set; }

        /// <summary>
        /// Descrição da fotografia
        /// </summary>

        public string Descricao { get; set; }

        /// <summary>
        /// Nome do Ficheiro da fotograafia no disco rigido do servidor
        /// </summary>

        public string Ficheiro { get; set; }

        /// <summary>
        /// Data em que a fotografia foi tirada
        /// </summary>
        [Display(Name = "Data")]
        [DataType(DataType.Date)] // Transforma o atributo, na BD, em 'Date'
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "A {0} é de preenchimento obrigatório")]

        public DateTime Data { get; set; }

        /// <summary>
        /// Preço de venda da fotografia
        /// </summary>
        [Display(Name = "Preço")]

        public decimal Preco { get; set; }


        /// <summary>
        /// atributo auxiliar para recolher o valor de Preço da fotografia
        /// será usado no 'create' e no 'edit'
        /// </summary>
        [NotMapped] // este atributo não será replicado na BD
        [Display(Name = "Preço")]
        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório")]
        [StringLength(10)]
        [RegularExpression("[0 - 9]{1, 7} ([.,][0 - 9]{1,2})?", ErrorMessage ="Pode escrever suas casas decimais separadas por . ou ,")]
        public string PrecoAux { get; set; }



        /* *******************************
         * Definição dos Relacionamentos *
         * *******************************
         */


        //Relacionamentos 1 - N

        /// <summary>
        /// Como atribuir FK
        /// </summary>

        [ForeignKey(nameof(Categoria))]
        [Display(Name = "Categoria")]
         public int CategoriaFK { get; set; }
        /// <summary>
        /// FK para categorias
        /// </summary>
        public Categorias Categoria { get; set; }

        /// <summary>
        /// Referência o dono da fotografia
        /// </summary>

        [ForeignKey(nameof(Dono))]
        [Display(Name = "Dono")]
        public int DonoFK { get; set; }

        /// <summary>
        /// FK para referenciar o Dono da Fotografia
        /// </summary>
        public Utilizadores Dono { get; set; }

        // N-N

        /// <summary>
        /// Lista de gostos de uma fotografia
        /// </summary>
        public ICollection<Gostos> ListaGostos { get; set; }

        /// <summary>
        /// Lista de compras que compraram a fotografia
        /// </summary>
        public ICollection<Compras> ListaCompras { get; set; }
    }
}
