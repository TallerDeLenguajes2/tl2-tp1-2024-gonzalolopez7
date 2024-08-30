public class Pedido
{
    int nro;
    string obs;
    Cliente cliente;
    Estado estado;

    public Pedido(int nro, string obs, Cliente cliente)
    {
        this.nro = nro;
        this.obs = obs;
        this.cliente = cliente;
        estado = Estado.Pendiente;
    }

    public int Nro { get => nro; set => nro = value; }
    public string Obs { get => obs; set => obs = value; }
    public Cliente Cliente { get => cliente; set => cliente = value; }
    public Estado Estado { get => estado; set => estado = value; }

    public void VerDireccionCliente()
    {
        Console.WriteLine($"~~ PEDIDO {nro} ~~");
        Console.WriteLine($"Direccion: {cliente.Direccion}");
        Console.WriteLine($"Datos de referencia de direccion: {cliente.DatosReferenciaDireccion}");
    }

    public void VerDatosCliente()
    {
        Console.WriteLine($"~~ PEDIDO {nro} ~~");
        Console.WriteLine($"Cliente: {cliente.Nombre}");
        Console.WriteLine($"Telefono: {cliente.Telefono}");
    }
}

public enum Estado
{
    Pendiente,
    Entregado
}