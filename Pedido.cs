public class Pedido
{
    int nro;
    string obs;
    Cliente cliente;
    Estado estado;
    Cadete cadete;

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
    public Cadete Cadete { get => cadete; set => cadete = value; }

    public string VerDireccionCliente()
    {
        return $"Direccion: {cliente.Direccion} - Datos de referencia: {cliente.DatosReferenciaDireccion}";
    }

    public string VerDatosCliente()
    {
        return $"Cliente: {cliente.Nombre} - Telefono: {cliente.Telefono}";
    }
}

public enum Estado
{
    Pendiente,
    Entregado
}