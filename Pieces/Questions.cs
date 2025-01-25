namespace ProjectLogic;
public enum QuestionsName
{
    Prueba,
}
public class Question
{
    public static Dictionary<QuestionsName, string> QuesionsTexts = new Dictionary<QuestionsName, string>()
    {
    {QuestionsName.Prueba,"Teeeeeee"}
    };
    public static Dictionary<QuestionsName, string> QuestionAnswer = new Dictionary<QuestionsName, string>()
    {
     {QuestionsName.Prueba,"y"}
    };
    public static Dictionary<QuestionsName, string[]> Elections = new Dictionary<QuestionsName, string[]>()
    {
    {QuestionsName.Prueba,["y","n","scs"]}
    };
    public static List<QuestionsName> QuestionsInGame = new List<QuestionsName>()
    {
    QuestionsName.Prueba
    };
}