public class Pedido
{
    public int PedidoId { get; set; }
    public DateTime Fecha { get; set; }
    public string Cliente { get; set; }
    public ICollection<DetallePedido> Detalles { get; set; } = new List<DetallePedido>();
}