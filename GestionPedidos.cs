public static class GestionPedidos
{
    public static void AsignarPedido(Cadeteria cadeteria, List<Pedido> listaPedidos)
    {
        var pedido = ObtenerPedido(listaPedidos);
        var cadete = ObtenerCadete(cadeteria.ListaCadetes);
        pedido.Cadete = cadete;
    }

    public static void ReasignarPedido(Cadeteria cadeteria, List<Pedido> listaPedidos)
    {
        var pedido = ObtenerPedido(listaPedidos);
        var cadete = ObtenerCadete(cadeteria.ListaCadetes);
        pedido.Cadete = cadete;
    }

    public static Pedido AltaDePedido(int nro)
    {
        Console.WriteLine("\n~~ NUEVO PEDIDO ~~");
        Console.WriteLine("Ingresar observaciones: ");
        string obs = Console.ReadLine();
        var cliente = new Cliente();

        return new Pedido(nro, obs, cliente);
    }

    public static void CambiarEstadoDePedido(List<Pedido> listaPedidos)
    {
        ObtenerPedido(listaPedidos).Estado = Estado.Entregado;
    }

    private static Cadete ObtenerCadete(List<Cadete> listaCadetes)
    {
        int idCadete; bool b;

        Console.WriteLine("Id del cadete: ");
        do
        {
            b = int.TryParse(Console.ReadLine(), out idCadete);
            if (idCadete < 1 || idCadete > listaCadetes.Count() || !b)
            {
                Console.WriteLine("opcion no valida, intentar nuevamente");
                b = false;
            }
        } while (!b);

        return listaCadetes.Where(x => x.Id == idCadete).First();
    }

    private static Pedido ObtenerPedido(List<Pedido> listaPedidos)
    {
        int nroPedido; bool b;

        Console.WriteLine("Numero de pedido: ");
        do
        {
            b = int.TryParse(Console.ReadLine(), out nroPedido);
            if (nroPedido < 0 || nroPedido > listaPedidos.Count()-1 || !b)
            {
                Console.WriteLine("opcion no valida, intentar nuevamente");
                b = false;
            }
        } while (!b);
        
        return listaPedidos.Where(x => x.Nro == nroPedido).First();
    }
}