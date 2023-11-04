namespace BackendCompras.Models
{
    public class OrdenesCompra
    {
        public int Id { get; set; }
        public int? OrderNumber { get; set; }
        public string estado { get; set; }
        public string Articulo { get; set; }

        public int stock { get; set; }
        public string medida { get; set; }

        public int CostoUnitario { get; set; }

        public DateTime FechaOrden {  get; set; }
    }

}
