public class Cadeteria
{
    string nombre;
    string telefono;
    List<Cadete> listaCadetes;

    public Cadeteria(string nombre, string telefono)
    {
        this.nombre = nombre;
        this.telefono = telefono;
        CargarCadetes();
    }

    public string Nombre { get => nombre; set => nombre = value; }
    public string Telefono { get => telefono; set => telefono = value; }
    public List<Cadete> ListaCadetes { get => listaCadetes; set => listaCadetes = value; }

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
}