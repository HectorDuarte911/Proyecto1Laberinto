namespace  ProjectLogic;
using Spectre.Console;
public enum NombrePreguntas
{
Prueba,
}
public class Preguntas
{
    public static  Dictionary<NombrePreguntas,string> TextoPregunta = new Dictionary<NombrePreguntas,string>()
    {
    {NombrePreguntas.Prueba,"Teeeeeee"}
    };
    public static Dictionary<NombrePreguntas,string> PreguntasYRespuestas = new Dictionary<NombrePreguntas,string>()
    {
     {NombrePreguntas.Prueba,"y"}
    };
    public static  Dictionary<NombrePreguntas,string[]> Elecciones = new Dictionary<NombrePreguntas,string[]>()
    {
    {NombrePreguntas.Prueba,["y","n","scs"]}
    };
    public static List<NombrePreguntas> PreguntasDisponibles = new List<NombrePreguntas>()
    {
    NombrePreguntas.Prueba
    };
     

}