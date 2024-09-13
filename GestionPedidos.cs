public class GestionPedidos
{
    public bool AsignarPedido(Cadeteria cadeteria, int nroPedido, int idCadete)
    {
        if(cadeteria.ListaPedidos.Count() != 0)
            if (cadeteria.ListaPedidos.Find(x => x.Nro == nroPedido) != null && cadeteria.ListaCadetes.Find(x => x.Id == idCadete) != null)
            {
                var pedido = ObtenerPedido(cadeteria.ListaPedidos, nroPedido);
                var cadete = ObtenerCadete(cadeteria.ListaCadetes, idCadete);
                pedido.Cadete = cadete;
                return true;
            } else
                return false;
        else
            return false;
    }

    public bool ReasignarPedido(Cadeteria cadeteria, int nroPedido, int idCadete)
    {
        if (cadeteria.ListaPedidos.Count() != 0)
        {
            Pedido pedido = cadeteria.ListaPedidos.Find(x => x.Nro == nroPedido);
            Cadete cadete = cadeteria.ListaCadetes.Find(x => x.Id == idCadete);
            if (pedido != null && cadete != null && pedido.Estado == Estado.Pendiente && pedido.Cadete != null)
                if (pedido.Cadete != cadete)
                {
                    pedido.Cadete = cadete;
                    return true;
                } else
                    return false;
            else
                return false;
        } else
            return false;
    }

    public Pedido DarAltaDePedido(List<Pedido> listaPedidos, int nro, string obs, string nombre, string telefono, string direccion, string datosReferenciaDireccion)
    {
        if (listaPedidos.Find(x => x.Nro == nro) != null)
            return null;
        else
        {
            var cliente = new Cliente(nombre, telefono, direccion, datosReferenciaDireccion);
            return new Pedido(nro, obs, cliente);
        }
    }

    public bool CambiarEstadoDePedido(List<Pedido> listaPedidos, int nroPedido)
    {
        if (listaPedidos.Count() != 0)
        {
            Pedido pedido = ObtenerPedido(listaPedidos, nroPedido);
            if (pedido != null && pedido.Estado == Estado.Pendiente)
            {
                ObtenerPedido(listaPedidos, nroPedido).Estado = Estado.Entregado;
                return true;
            } else
                return false;
        } else
            return false;
    }

    private Cadete ObtenerCadete(List<Cadete> listaCadetes, int idCadete)
    {
        return listaCadetes.Find(x => x.Id == idCadete);
        // devuelve null si no encuentra un cadete con el id ingresado
    }

    private Pedido ObtenerPedido(List<Pedido> listaPedidos, int nroPedido)
    {
        return listaPedidos.Find(x => x.Nro == nroPedido);
        // devuelve null si no encuentra un pedido con el numero ingresado
    }
}