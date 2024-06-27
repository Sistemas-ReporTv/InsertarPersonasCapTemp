


using InsertarPersonasCapTemp;
using System.Data.Common;

public class Program
{





    private static void Main()
    {
        Console.WriteLine("Iniciando proceso");

        Datos datos = new Datos();

        List<Persona> actoresCapitulo = datos.ObtenerPersonasCapitulo(1);
        List<Persona> directoresCapitulo = datos.ObtenerPersonasCapitulo(2);

        List<Persona> actoresTemporada = datos.ObtenerPersonasTemporada(1);
        List<Persona> directoresTemporada = datos.ObtenerPersonasTemporada(2);



    }






}