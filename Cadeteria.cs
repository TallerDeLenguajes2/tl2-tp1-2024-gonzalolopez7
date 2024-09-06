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
        CargarCadetes();
    }

    public string Nombre { get => nombre; set => nombre = value; }
    public string Telefono { get => telefono; set => telefono = value; }
    public List<Cadete> ListaCadetes { get => listaCadetes; set => listaCadetes = value; }
    public List<Pedido> ListaPedidos { get => listaPedidos; set => listaPedidos = value; }

    private void CargarCadetes()
    {
        ListaCadetes = new List<Cadete>();
        var lineas = File.ReadLines("cadetes.csv").ToList();
        for (int i = 0; i < lineas.Count(); i++)
        {
            string[] datos = lineas[i].Split(",");
            ListaCadetes.Add(new Cadete(Convert.ToInt32(datos[0]), datos[1], datos[2], datos[3]));
        }
    }

    public double JornalACobrar(int idCadete)
    {
        return listaPedidos.Where(x => x.Cadete.Id == idCadete && x.Estado == Estado.Entregado).Count() * 500;
    }

    public void AsignarCadeteAPedido(int idCadete, int nroPedido)
    {
        listaPedidos.Where(x => x.Nro == nroPedido).First().Cadete = listaCadetes.Where(x => x.Id == idCadete).First();
    }
}