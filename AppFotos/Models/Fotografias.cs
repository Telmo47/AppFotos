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
        
        public int id { get; set; }

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

        public DateTime Data { get; set; }

        /// <summary>
        /// Preço de venda da fotografia
        /// </summary>

        public decimal Preco { get; set; }



        /* *******************************
         * Definição dos Relacionamentos *
         * *******************************
         */


        //Relacionamentos 1 - N

        /// <summary>
        /// Como atribuir FK
        /// </summary>

        [ForeignKey(nameof(Categoria))]
         public int CategoriaFK { get; set; }
        /// <summary>
        /// FK para categorias
        /// </summary>
        public Categorias Categoria { get; set; }

        /// <summary>
        /// Referência o dono da fotografia
        /// </summary>

        [ForeignKey(nameof(Dono))]
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
