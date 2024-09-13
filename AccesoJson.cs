using System.Text.Json;

public class AccesoJson : AccesoADatos
{
    private string rutaCadeteria;
    private string rutaCadetes;

    public AccesoJson()
    {
        rutaCadeteria = "cadeteria.json";
        rutaCadetes = "cadete.json";
    }

    public override Cadeteria CargarDatos()
    {
        Cadeteria cadeteria = CargarCadeteria();
        if(cadeteria != null)
            CargarCadetes(cadeteria.ListaCadetes);
        
        return cadeteria;
    }

    public override Cadeteria CargarCadeteria()
    {
        if(File.Exists(rutaCadeteria))
        {
            var stringJson = File.ReadAllText(rutaCadeteria);
            Cadeteria cadeteria = JsonSerializer.Deserialize<Cadeteria>(stringJson);
            return cadeteria;
        }
        return null;

    }

    public override void CargarCadetes(List<Cadete> listaCadetes)
    {
        if(File.Exists(rutaCadetes))
        {
            var stringJson = File.ReadAllText(rutaCadetes);
            listaCadetes = JsonSerializer.Deserialize<List<Cadete>>(stringJson);
        }
    }
}