using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppFotos.Models
{

    /// <summary>
    /// regista os 'gostos' que um utilizador da app tem pelas fotografias existentes
    /// </summary>
    [PrimaryKey(nameof(UtilizadorFK),nameof(FotografiaFK))]
    public class Gostos
    {

        /// <summary>
        /// data em que o utilizador marcou que gosta de uma fotografia
        /// </summary>
        public DateTime Data { get; set; }


        /* *******************************
       * Definição dos Relacionamentos *
       * *******************************
       */


        //Relacionamentos 1 - N


        /// <summary>
        /// Referência o Utilizador
        /// </summary>

        [ForeignKey(nameof(Utilizador))]
        public int UtilizadorFK { get; set; }

        /// <summary>
        /// FK para referenciar o que o utlizador gosta da Fotografia
        /// </summary>
        public Utilizadores Utilizador { get; set; }

        /// <summary>
        /// FK para a fotografia que o utilizador gostou
        /// </summary>

        [ForeignKey(nameof(Fotografia))]
        public int FotografiaFK { get; set; }
        public Fotografias Fotografia { get; set; }


    }
}
