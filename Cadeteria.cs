public class Cadeteria
{
    string nombre;
    string telefono;
    List<Cadete> listaCadetes;
    List<Pedido> listaPedidos;

    public Cadeteria(string nombre, string telefono)
    {
        this.nombre = nombre;
        this.telefono = telefono;
        listaPedidos = new List<Pedido>();
        listaCadetes = new List<Cadete>();
    }

    public string Nombre { get => nombre; set => nombre = value; }
    public string Telefono { get => telefono; set => telefono = value; }
    public List<Cadete> ListaCadetes { get => listaCadetes; set => listaCadetes = value; }
    public List<Pedido> ListaPedidos { get => listaPedidos; set => listaPedidos = value; }

    public double? JornalACobrar(int idCadete)
    {
        if (listaCadetes.Find(x => x.Id == idCadete) != null)
            return listaPedidos.Where(x => x.Cadete.Id == idCadete && x.Estado == Estado.Entregado).Count() * 500;
        else
            return null;
    }

    public bool AsignarCadeteAPedido(int idCadete, int nroPedido)
    {
        if (listaCadetes.Find(x => x.Id == idCadete) != null && listaPedidos.Find(x => x.Nro == nroPedido) != null)
        {
            listaPedidos.Find(x => x.Nro == nroPedido).Cadete = listaCadetes.Find(x => x.Id == idCadete);
            return true;
        } else
            return false;
    }
}