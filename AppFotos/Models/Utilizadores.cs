using System.ComponentModel.DataAnnotations;

namespace AppFotos.Models
{

    /// <summary>
    /// utilizadores não anónimos da aplicação
    /// </summary>
    public class Utilizadores
    {
        /// <summary>
        /// Id do utilizador
        /// </summary>
        [Key]
        
        public int id { get; set; }
        /// <summary>
        /// Nome do utilizador
        /// </summary>
        public string Nome { get; set; }
        /// <summary>
        /// Morada do utilizador
        /// </summary>
        public string Morada { get; set; }
        /// <summary>
        /// Código Postal do utilizador
        /// </summary>
        public string CodPostal { get; set; }
        /// <summary>
        /// País do utilizador
        /// </summary>
        public string Pais { get; set; }
        /// <summary>
        /// NIF do utilizador
        /// </summary>
        public string NIF { get; set; }
        /// <summary>
        /// Número de telemóvel do utilizador
        /// </summary>
        public string Telemovel { get; set; }


        /* *******************************
       * Definição dos Relacionamentos *
       * *******************************
       */

        /// <summary>
        /// Lista das Fotografias que são propriedade do utilizador
        /// </summary>
        public ICollection<Fotografias> ListaFotos { get; set; }

        /// <summary>
        /// Lista dos gostos das fotografias do utilizador
        /// </summary>
        public ICollection<Gostos> ListaGostos { get; set; }

        /// <summary>
        /// Lista das fotografias compradas pelo utilizador
        /// </summary>
        public ICollection<Compras> ListaCompras { get; set; }
    }
}
