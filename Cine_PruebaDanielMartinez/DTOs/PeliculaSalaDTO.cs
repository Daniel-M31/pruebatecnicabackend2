namespace Cine_PruebaDanielMartinez.DTOs
{
    public class PeliculaSalaDTO
    {
        public int id_pelicula_sala { get; set; }
        public int id_pelicula { get; set; }
        public int id_sala { get; set; }
        public string fecha_publicacion { get; set; } = string.Empty;
        public string fecha_fin { get; set; } = string.Empty;
        public bool estado { get; set; }
    }
}
