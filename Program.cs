
// elegir metodo para cargar datos
bool b; int opcion;
Console.WriteLine("\n~~ CARGA DE DATOS ~~");
Console.WriteLine("1. Cargar via Json");
Console.WriteLine("2. Cargar via CSV\n");
do
{
    b = int.TryParse(Console.ReadLine(), out opcion);
    if (opcion < 1 || opcion > 2 || !b)
    {
        Console.WriteLine("opcion no valida, intentar nuevamente");
        b = false;
    }
} while (!b);

AccesoADatos datos;
if (opcion == 1)
{
    datos = new AccesoJson();
} else
{
    datos = new AccesoCSV();
}
Cadeteria cadeteria = datos.CargarDatos();

// numero usado para los id de los pedidos
int nro = 0;

do
{
    Console.WriteLine("\n~~ MENU ~~");
    Console.WriteLine("1. Dar de alta un pedido");
    Console.WriteLine("2. Asignar pedido");
    Console.WriteLine("3. Cambiar estado de pedido");
    Console.WriteLine("4. Reasignar pedido");
    Console.WriteLine("5. Terminar jornada\n");
    do
    {
        b = int.TryParse(Console.ReadLine(), out opcion);
        if (opcion < 1 || opcion > 5 || !b)
        {
            Console.WriteLine("opcion no valida, intentar nuevamente");
            b = false;
        }
    } while (!b);

    switch (opcion)
    {
        case 1:
            cadeteria.ListaPedidos.Add(GestionPedidos.AltaDePedido(nro));
            nro++;
            break;
        
        case 2:
            if (cadeteria.ListaPedidos.Count() != 0)
                GestionPedidos.AsignarPedido(cadeteria, cadeteria.ListaPedidos);
            else
                Console.WriteLine("No se puede asignar un pedido porque no hay ningun pedido pendiente");
            break;
        
        case 3:
            if (cadeteria.ListaPedidos.Count() != 0)
                GestionPedidos.CambiarEstadoDePedido(cadeteria.ListaPedidos);
            else
                Console.WriteLine("No se puede cambiar el estado de un pedido porque no hay ningun pedido pendiente");
            break;
        
        case 4:
            if (cadeteria.ListaPedidos.Count() != 0)
                GestionPedidos.ReasignarPedido(cadeteria, cadeteria.ListaPedidos);
            else
                Console.WriteLine("No se puede reasignar un pedido porque no hay ningun pedido pendiente");
            break;

        default:
            break;
    }
} while (opcion != 5);

int totalEnvios = 0;
Console.WriteLine("\n~~ INFORME JORNADA ~~\n");
foreach (var cadete in cadeteria.ListaCadetes)
{
    Console.WriteLine($"\nCadete: {cadete.Nombre}");
    int envios = cadeteria.ListaPedidos.Where(x => x.Cadete.Id == cadete.Id && x.Estado == Estado.Entregado).Count();
    totalEnvios += envios;
    Console.WriteLine($"Envios: {envios}");
    Console.WriteLine($"Monto ganado: {cadeteria.JornalACobrar(cadete.Id)}");
}
Console.WriteLine($"\n\nTotal de envios: {totalEnvios}");
double promedio = totalEnvios / cadeteria.ListaCadetes.Count();
Console.WriteLine($"Promedio de envios por cadete: {promedio}");
