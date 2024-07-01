using InsertarPersonasCapTemp;
using System.Data.Common;
using System.Text;

public class Program
{
    private static Datos _datos = new Datos();
    private static UtilMail _utilMail = new UtilMail();

    //[PF - 07/2024] si vas a debuggear este proceso porfis abrilo con vs 2022 antes xq sino vas a tener errores de sdk .net
    private static void Main()
    {
        try
        {
            Console.WriteLine("Iniciando proceso " + DateTime.Now + "\n");
            List<InfoMail> procesosAndTiempos = new List<InfoMail>();

            #region Actores Capitulo
            Console.WriteLine("Obteniendo actores capitulo..." + "\n");
            DateTime fechaInicioProceso = DateTime.Now;
            List<Persona> actoresCapitulo = _datos.ObtenerPersonasCapitulo(1);

            bool procesarPersonas = true;
            int cantPersonasAprocesar = actoresCapitulo.Count;
            Console.WriteLine("Procesando " + cantPersonasAprocesar + " actores capitulo..." + "\n");

            while (procesarPersonas)
            {
                //busco la cantidad de personas correspondientes al primer id capitulo en la lista
                int cantPersonas = DevolverCantidadPersonasCapituloEnIndexCero(actoresCapitulo);

                StringBuilder sb = new StringBuilder();

                for (int j = 0; j < cantPersonas; j++)
                {
                    //armo el string
                    sb.Append(actoresCapitulo[j].Nombre + "," + actoresCapitulo[j].Apellido + "|");
                }

                //escribo los datos de las personas en el id capitulo
                _datos.InsertarActoresCapitulo(actoresCapitulo[0].IdProgramaCapitulo, sb.ToString());

                //elimino las personas ya procesadas de la lista
                actoresCapitulo.RemoveRange(0, cantPersonas);

                if (actoresCapitulo.Count == 0)
                {
                    procesarPersonas = false;
                }
            }

            DateTime fechaFinalizacionProceso = DateTime.Now;
            TimeSpan duracionProceso = fechaFinalizacionProceso - fechaInicioProceso;
            procesosAndTiempos.Add(new InfoMail("Actores Capitulo", cantPersonasAprocesar, fechaInicioProceso, fechaFinalizacionProceso, duracionProceso));
            Console.WriteLine("Se terminaron de procesar todos los actores capitulo en: " + duracionProceso + "\n");
            #endregion

            #region Directores Capitulo
            Console.WriteLine("Obteniendo directores capitulo..." + "\n");
            fechaInicioProceso = DateTime.Now;
            List<Persona> directoresCapitulo = _datos.ObtenerPersonasCapitulo(2);

            procesarPersonas = true;
            cantPersonasAprocesar = directoresCapitulo.Count;
            Console.WriteLine("Procesando " + cantPersonasAprocesar + " directores capitulo..." + "\n");

            while (procesarPersonas)
            {
                //busco la cantidad de personas correspondientes al primer id capitulo en la lista
                int cantPersonas = DevolverCantidadPersonasCapituloEnIndexCero(directoresCapitulo);

                StringBuilder sb = new StringBuilder();

                for (int j = 0; j < cantPersonas; j++)
                {
                    //armo el string
                    sb.Append(directoresCapitulo[j].Nombre + "," + directoresCapitulo[j].Apellido + "|");
                }

                //escribo los datos de las personas en el id capitulo
                _datos.InsertarDirectoresCapitulo(directoresCapitulo[0].IdProgramaCapitulo, sb.ToString());

                //elimino las personas ya procesadas de la lista
                directoresCapitulo.RemoveRange(0, cantPersonas);

                if (directoresCapitulo.Count == 0)
                {
                    procesarPersonas = false;
                }
            }

            fechaFinalizacionProceso = DateTime.Now;
            duracionProceso = fechaFinalizacionProceso - fechaInicioProceso;
            procesosAndTiempos.Add(new InfoMail("Directores Capitulo", cantPersonasAprocesar, fechaInicioProceso, fechaFinalizacionProceso, duracionProceso));
            Console.WriteLine("Se terminaron de procesar todos los directores capitulo en: " + duracionProceso + "\n");
            #endregion

            #region Actores Temporada
            Console.WriteLine("Obteniendo actores temporada..." + "\n");
            fechaInicioProceso = DateTime.Now;
            List<Persona> actoresTemporada = _datos.ObtenerPersonasTemporada(1);

            procesarPersonas = true;
            cantPersonasAprocesar = actoresTemporada.Count;
            Console.WriteLine("Procesando " + cantPersonasAprocesar + " actores temporada..." + "\n");

            while (procesarPersonas)
            {
                //busco la cantidad de personas correspondientes al primer id capitulo en la lista
                int cantPersonas = DevolverCantidadPersonasTemporadaEnIndexCero(actoresTemporada);

                StringBuilder sb = new StringBuilder();

                for (int j = 0; j < cantPersonas; j++)
                {
                    //armo el string
                    sb.Append(actoresTemporada[j].Nombre + "," + actoresTemporada[j].Apellido + "|");
                }

                //escribo los datos de las personas en el id capitulo
                _datos.InsertarActoresTemporada(actoresTemporada[0].IdProgramaTemporada, sb.ToString());

                //elimino las personas ya procesadas de la lista
                actoresTemporada.RemoveRange(0, cantPersonas);

                if (actoresTemporada.Count == 0)
                {
                    procesarPersonas = false;
                }
            }

            fechaFinalizacionProceso = DateTime.Now;
            duracionProceso = fechaFinalizacionProceso - fechaInicioProceso;
            procesosAndTiempos.Add(new InfoMail("Actores Temporada", cantPersonasAprocesar, fechaInicioProceso, fechaFinalizacionProceso, duracionProceso));
            Console.WriteLine("Se terminaron de procesar todos los actores temporada en: " + duracionProceso + "\n");
            #endregion

            #region Directores Temporada
            Console.WriteLine("Obteniendo directores temporada..." + "\n");
            fechaInicioProceso = DateTime.Now;
            List<Persona> directoresTemporada = _datos.ObtenerPersonasTemporada(2);

            procesarPersonas = true;
            cantPersonasAprocesar = directoresTemporada.Count;
            Console.WriteLine("Procesando " + cantPersonasAprocesar + " directores temporada..." + "\n");

            while (procesarPersonas)
            {
                //busco la cantidad de personas correspondientes al primer id capitulo en la lista
                int cantPersonas = DevolverCantidadPersonasTemporadaEnIndexCero(directoresTemporada);

                StringBuilder sb = new StringBuilder();

                for (int j = 0; j < cantPersonas; j++)
                {
                    //armo el string
                    sb.Append(directoresTemporada[j].Nombre + "," + directoresTemporada[j].Apellido + "|");
                }

                //escribo los datos de las personas en el id capitulo
                _datos.InsertarDirectoresTemporada(directoresTemporada[0].IdProgramaTemporada, sb.ToString());

                //elimino las personas ya procesadas de la lista
                directoresTemporada.RemoveRange(0, cantPersonas);

                if (directoresTemporada.Count == 0)
                {
                    procesarPersonas = false;
                }
            }

            fechaFinalizacionProceso = DateTime.Now;
            duracionProceso = fechaFinalizacionProceso - fechaInicioProceso;
            procesosAndTiempos.Add(new InfoMail("Directores Temporada", cantPersonasAprocesar, fechaInicioProceso, fechaFinalizacionProceso, duracionProceso));
            Console.WriteLine("Se terminaron de procesar todos los directores temporada en: " + duracionProceso + "\n");
            #endregion

            _utilMail.EnviarMail(procesosAndTiempos);
        }
        catch (Exception ex)
        {
            _utilMail.EnviarMail(ex);
        }
    }

    private static int DevolverCantidadPersonasCapituloEnIndexCero (List<Persona> personasCapitulo)
    {
        int cantPersonas = 1;
        int idCapituloaProcesar = 1;

        for (int i = 0; i < personasCapitulo.Count; i++)
        {
            //tomo el id capitulo de la primer corrida
            if (i == 0)
            {
                idCapituloaProcesar = personasCapitulo[i].IdProgramaCapitulo;
            }
            else
            {
                //si llego a otro id capitulo ya tengo el nro de personas relacionadas al id cap actual
                if (personasCapitulo[i].IdProgramaCapitulo != idCapituloaProcesar)
                {
                    cantPersonas = i;
                    break;
                }
                else
                {
                    //si entra aca es xq ya es la ultima corrida y no hay mas personas con otros id cap
                    if (i == personasCapitulo.Count - 1)
                    {
                        cantPersonas = personasCapitulo.Count;
                        break;
                    }
                }                
            }
        }

        return cantPersonas;
    }

    private static int DevolverCantidadPersonasTemporadaEnIndexCero(List<Persona> personasTemporada)
    {
        int cantPersonas = 1;
        int idTemporadaaProcesar = 1;

        for (int i = 0; i < personasTemporada.Count; i++)
        {
            //tomo el id capitulo de la primer corrida
            if (i == 0)
            {
                idTemporadaaProcesar = personasTemporada[i].IdProgramaTemporada;
            }
            else
            {
                //si llego a otro id capitulo ya tengo el nro de personas relacionadas al id cap actual
                if (personasTemporada[i].IdProgramaTemporada != idTemporadaaProcesar)
                {
                    cantPersonas = i;
                    break;
                }
                else
                {
                    //si entra aca es xq ya es la ultima corrida y no hay mas personas con otros id cap
                    if (i == personasTemporada.Count - 1)
                    {
                        cantPersonas = personasTemporada.Count;
                        break;
                    }
                }
            }
        }

        return cantPersonas;
    }





}