public class AccesoCSV : AccesoADatos
{

    private string rutaCadeteria;
    private string rutaCadetes;

    public AccesoCSV()
    {
        rutaCadeteria = "cadeteria.csv";
        rutaCadetes = "cadetes.csv";
    }

    public override Cadeteria CargarDatos()
    {
        var cadeteria = CargarCadeteria();
        CargarCadetes(cadeteria.ListaCadetes);
        return cadeteria;
    }

    public override Cadeteria CargarCadeteria()
    {
        if(File.Exists(rutaCadeteria))
        {
            var linea = File.ReadAllText(rutaCadeteria);
            string[] datos = linea.Split(",");
            var cadeteria = new Cadeteria(datos[0], datos[1]);

            return cadeteria;
        }
        return null;

    }

    public override void CargarCadetes(List<Cadete> listaCadetes)
    {
        if(File.Exists(rutaCadetes))
        {
            var lineas = File.ReadLines(rutaCadetes).ToList();
            
            for (int i = 0; i < lineas.Count(); i++)
            {
                string[] datos = lineas[i].Split(",");
                var nuevoCadete = new Cadete(Convert.ToInt32(datos[0]), datos[1], datos[2], datos[3]);
                listaCadetes.Add(nuevoCadete);
            }
        }
    }
}