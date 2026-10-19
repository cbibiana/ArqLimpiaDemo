using System.ComponentModel.DataAnnotations;

namespace TiendaProductos.WebAPI.DTOs
{
    public class CrearProductoDTO
    {
        [Required]
        [MaxLength(200)]
        public required string Nombre { get; set; }
        public string? Descripcion { get; set; }
        public decimal Precio { get; set; }
        public required string Moneda { get; set; }
        public int InventarioInicial { get; set; }
    }
}
