using System;

namespace BlazorSubasta.Shared
{
    public sealed class Puja
    {
        /// <summary>
        /// Identificador único de la puja.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Identificador de la subasta.
        /// </summary>
        public string SubastaId { get; set; }
        
        /// <summary>
        /// Nombre del usuario.
        /// </summary>
        public string Usuario { get; set; }
        
        /// <summary>
        /// Monto de la puja.
        /// </summary>
        public decimal Monto { get; set; }

        /// <summary>
        /// Fecha en que se ofertó la Puja.
        /// </summary>
        public DateTime Fecha { get; set; }
    }
}
