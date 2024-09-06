using System.Text.Json;

public class AccesoJson : AccesoADatos
{
    public override Cadeteria CargarDatos()
    {
        Cadeteria cadeteria = CargarCadeteria();
        CargarCadetes(cadeteria.ListaCadetes);
        return cadeteria;
    }

    public override Cadeteria CargarCadeteria()
    {
        var stringJson = File.ReadAllText("cadeteria.json");
        Cadeteria cadeteria = JsonSerializer.Deserialize<Cadeteria>(stringJson);
        return cadeteria;
    }

    public override void CargarCadetes(List<Cadete> listaCadetes)
    {
        var stringJson = File.ReadAllText("cadetes.json");
        listaCadetes = JsonSerializer.Deserialize<List<Cadete>>(stringJson);
    }
}