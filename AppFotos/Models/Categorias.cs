﻿using System.ComponentModel.DataAnnotations;

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
        public string Categoria { get; set; }


        /* *******************************
       * Definição dos Relacionamentos *
       * *******************************
       */

        public ICollection<Fotografias> ListaFotografias { get; set; }
    }
}
