public class Cadete
{
    int id;
    string nombre;
    string direccion;
    string telefono;
    List<Pedido> listaPedidos;

    public Cadete(int id, string nombre, string direccion, string telefono)
    {
        this.id = id;
        this.nombre = nombre;
        this.direccion = direccion;
        this.telefono = telefono;
        listaPedidos = new List<Pedido>();
    }

    public int Id { get => id; set => id = value; }
    public string Nombre { get => nombre; set => nombre = value; }
    public string Direccion { get => direccion; set => direccion = value; }
    public string Telefono { get => telefono; set => telefono = value; }
    public List<Pedido> ListaPedidos { get => listaPedidos; set => listaPedidos = value; }

    public double JornadaACobrar()
    {
        return ListaPedidos
                .Where(x => x.Estado == Estado.Entregado)
                .Count() * 500;
    }
}