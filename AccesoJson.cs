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
        CargarCadetes(cadeteria.ListaCadetes);
        return cadeteria;
    }

    public override Cadeteria CargarCadeteria()
    {
        var stringJson = File.ReadAllText(rutaCadeteria);
        Cadeteria cadeteria = JsonSerializer.Deserialize<Cadeteria>(stringJson);

        return cadeteria;
    }

    public override void CargarCadetes(List<Cadete> listaCadetes)
    {
        var stringJson = File.ReadAllText(rutaCadetes);
        listaCadetes = JsonSerializer.Deserialize<List<Cadete>>(stringJson);
    }
}