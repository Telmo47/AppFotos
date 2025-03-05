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


    }
}
