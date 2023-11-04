namespace BackendCompras.Models
{
    public class Proveedor
    {
        public int Id { get; set; }
        public string? Cedula { get; set; }

        public string? NombreComercial { get; set; }

        public string? Estado { get; set; }

        public DateTime FechaCreacion { get; set; }

    }
}
