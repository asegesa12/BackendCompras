namespace BackendCompras.Models
{
    public class Articulo
    {
        public int Id { get; set; }
        public string descripcion { get; set; }
        public string marca { get; set; }

        public string UnidadMedida { get; set; }
        public string existencia { get; set; }
        public string estado { get; set; }  

    }
}
