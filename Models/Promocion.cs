namespace Spa.Models
{
    public class Promocion
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = string.Empty;

        public string Descripcion { get; set; } = string.Empty;

        public decimal Precio { get; set; }

        public string Imagen { get; set; } = string.Empty;

        public bool Activa { get; set; } = true;
    }
}