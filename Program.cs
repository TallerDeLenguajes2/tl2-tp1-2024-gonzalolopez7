
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
var gestion = new GestionPedidos();

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

    int nroPedido, idCadete; bool estado;
    switch (opcion)
    {
        case 1:
            Console.WriteLine("Observacion:");
            string obs = Console.ReadLine();
            Console.WriteLine("Nombre del cliente:");
            string nombre = Console.ReadLine();
            Console.WriteLine("Telefono:");
            string telefono = Console.ReadLine();
            Console.WriteLine("Direccion:");
            string direccion = Console.ReadLine();
            Console.WriteLine("Datos de referencia:");
            string datosRef = Console.ReadLine();
            var nuevoPedido = gestion.AltaDePedido(cadeteria.ListaPedidos, nro, obs, nombre, telefono, direccion, datosRef);
            if (nuevoPedido != null)
            {
                cadeteria.ListaPedidos.Add(nuevoPedido);
                Console.WriteLine("\naccion completada\n");
                nro++;
            }
            else
                Console.WriteLine("\nerror\n");
            break;
        
        case 2:
            Console.WriteLine("Numero de pedido:");
            do
            {
                b = int.TryParse(Console.ReadLine(), out nroPedido);
                if (!b)
                {
                    Console.WriteLine("opcion no valida, intentar nuevamente");
                    b = false;
                }
            } while (!b);
            Console.WriteLine("Id cadete:");
            do
            {
                b = int.TryParse(Console.ReadLine(), out idCadete);
                if (!b)
                {
                    Console.WriteLine("opcion no valida, intentar nuevamente");
                    b = false;
                }
            } while (!b);
            estado = gestion.AsignarPedido(cadeteria, nroPedido, idCadete);
            if (estado)
                Console.WriteLine("\naccion completada\n");
            else
                Console.WriteLine("\nerror\n");
            break;
        
        case 3:
            Console.WriteLine("Numero de pedido:");
            do
            {
                b = int.TryParse(Console.ReadLine(), out nroPedido);
                if (!b)
                {
                    Console.WriteLine("opcion no valida, intentar nuevamente");
                    b = false;
                }
            } while (!b);
            estado = gestion.CambiarEstadoDePedido(cadeteria.ListaPedidos, nroPedido);
            if (estado)
                Console.WriteLine("\naccion completada\n");
            else
                Console.WriteLine("\nerror\n");
            break;
        
        case 4:
            Console.WriteLine("Numero de pedido:");
            do
            {
                b = int.TryParse(Console.ReadLine(), out nroPedido);
                if (!b)
                {
                    Console.WriteLine("opcion no valida, intentar nuevamente");
                    b = false;
                }
            } while (!b);
            Console.WriteLine("Id cadete:");
            do
            {
                b = int.TryParse(Console.ReadLine(), out idCadete);
                if (!b)
                {
                    Console.WriteLine("opcion no valida, intentar nuevamente");
                    b = false;
                }
            } while (!b);
            estado = gestion.ReasignarPedido(cadeteria, nroPedido, idCadete);
            if (estado)
                Console.WriteLine("\naccion completada\n");
            else
                Console.WriteLine("\nerror\n");
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