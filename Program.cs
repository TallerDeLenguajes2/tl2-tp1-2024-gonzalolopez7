// carga de datos de cadeteria y cadetes
var linea = File.ReadAllText("cadeteria.csv");
string[] datos = linea.Split(",");
var cadeteria = new Cadeteria(datos[0], datos[1]);

// numero usado para los id de los pedidos
int nro = 0;

// lista de todos los pedidos realizados
var listaPedidos = new List<Pedido>();

bool b; int opcion;
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
            listaPedidos.Add(GestionPedidos.AltaDePedido(nro));
            nro++;
            break;
        
        case 2:
            if (listaPedidos.Count() != 0)
                GestionPedidos.AsignarPedido(cadeteria, listaPedidos);
            else
                Console.WriteLine("No se puede asignar un pedido porque no hay ningun pedido pendiente");
            break;
        
        case 3:
            if (listaPedidos.Count() != 0)
                GestionPedidos.CambiarEstadoDePedido(listaPedidos);
            else
                Console.WriteLine("No se puede cambiar el estado de un pedido porque no hay ningun pedido pendiente");
            break;
        
        case 4:
            if (listaPedidos.Count() != 0)
                GestionPedidos.ReasignarPedido(cadeteria, listaPedidos);
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
    int envios = cadete.ListaPedidos.Where(x => x.Estado == Estado.Entregado).Count();
    totalEnvios += envios;
    Console.WriteLine($"Envios: {envios}");
    Console.WriteLine($"Monto ganado: {cadete.JornadaACobrar()}");
}
Console.WriteLine($"\n\nTotal de envios: {totalEnvios}");
double promedio = totalEnvios / cadeteria.ListaCadetes.Count();
Console.WriteLine($"Promedio de envios por cadete: {promedio}");
