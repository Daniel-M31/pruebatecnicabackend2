namespace Cine_PruebaDanielMartinez.DTOs
{
    public class PeliculaDTO
    {
        public int id_pelicula { get; set; } 
        public string Nombre { get; set; } = null!;
        public int Duracion { get; set; }
        public bool Estado { get; set; }
    }

    public class PeliculaConFechasDTO
    {
        public int id_pelicula { get; set; } 
        public string Nombre { get; set; } = null!;
        public int Duracion { get; set; }
        public List<FechaSalaDTO> Fechas { get; set; } = new List<FechaSalaDTO>();
    }

    public class FechaSalaDTO
    {
        public DateOnly Fecha { get; set; }
        public int IdSala { get; set; }
    }
}

namespace Cine_PruebaDanielMartinez.DTOs
{
    public class EstadoSalaDTO
    {
        public string Sala { get; set; } = null!;
        public int TotalPeliculas { get; set; }
        public string Estado { get; set; } = null!;
    }
}