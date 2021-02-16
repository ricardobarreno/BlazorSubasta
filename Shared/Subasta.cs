namespace BlazorSubasta.Shared
{
    public class Subasta
    {
        /// <summary>
        /// Identificador único de la subasta.
        /// </summary>
        public string Id { get; set; }
        
        /// <summary>
        /// Nombre de la subasta.
        /// </summary>
        public string Nombre { get; set; }
        
        /// <summary>
        /// Dirección url de la imagen de la subasta.
        /// </summary>
        public string UrlImagen { get; set; }

        /// <summary>
        /// Estado de la subasta.
        /// </summary>
        /// <value></value>
        public SubastaEstado Estado { get; set; } = SubastaEstado.Pendiente;
    }

    public enum SubastaEstado
    {
        Pendiente,
        EnProceso,
        Finalizada
    }
}
