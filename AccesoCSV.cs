public class AccesoCSV : AccesoADatos
{
    public override Cadeteria CargarDatos()
    {
        var cadeteria = CargarCadeteria();
        CargarCadetes(cadeteria.ListaCadetes);
        return cadeteria;
    }

    public override Cadeteria CargarCadeteria()
    {
        var linea = File.ReadAllText("cadeteria.csv");
        string[] datos = linea.Split(",");
        var cadeteria = new Cadeteria(datos[0], datos[1]);

        return cadeteria;
    }

    public override void CargarCadetes(List<Cadete> listaCadetes)
    {
        var lineas = File.ReadLines("cadetes.csv").ToList();
        for (int i = 0; i < lineas.Count(); i++)
        {
            string[] datos = lineas[i].Split(",");
            listaCadetes.Add(new Cadete(Convert.ToInt32(datos[0]), datos[1], datos[2], datos[3]));
        }
    }
}