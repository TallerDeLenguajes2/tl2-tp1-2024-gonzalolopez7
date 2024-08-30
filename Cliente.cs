public class Cliente
{
    string nombre;
    string direccion;
    string telefono;
    string datosReferenciaDireccion;

    public Cliente()
    {
        Console.WriteLine("\n~~ DATOS CLIENTE ~~");
        Console.WriteLine("Nombre: ");
        nombre = Console.ReadLine();
        Console.WriteLine("Direccion: ");
        direccion = Console.ReadLine();
        Console.WriteLine("Telefono: ");
        telefono = Console.ReadLine();
        Console.WriteLine("Datos de referencia de direccion: ");
        datosReferenciaDireccion = Console.ReadLine();
    }

    public string Nombre { get => nombre; set => nombre = value; }
    public string Direccion { get => direccion; set => direccion = value; }
    public string Telefono { get => telefono; set => telefono = value; }
    public string DatosReferenciaDireccion { get => datosReferenciaDireccion; set => datosReferenciaDireccion = value; }
}
