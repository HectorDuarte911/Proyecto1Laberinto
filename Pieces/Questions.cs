namespace ProjectLogic;
public enum QuestionsName//All the question name
{
    NumeroCruzadas,
    NumeroAbraham,
    GuerraSieteAños,
    TruhanesCaballeros,
    Partición,
    BatallasNapoleón,
    EmperadoresRomanos,
    Qadesh,
    GeneralMuerte,
    Samurais,
    Corsarios,
    SucesiónAustriaca,
    Galos,
    TemplariosAsesino,
    BatallasRoma,
    Demeter,
    FechasSuma,
    Reformistas,
    Coseno,
    LeySeca,
    EsposasTudor,
    ClasesSociales,
    MuerteRasputín,
    Peloponeso,
    NombresBarcos,
    Boers,
    Banderas,
    Stalin,
    Cargador,
    TruhanesCaballerosNormales,
    Spartaco,
    CaballoBlanco,
    Francés,
    Yugoslavia,
    TripleAlianza,
    Religiones,
    ArmasNapoleón,
    Prusia,
    PresidenteGM,
    Ejércitonegro,
}
public class Question
{
    //Dictinarys to the text,anwser and posible choices of the questions ;and the list of questions left 
    public static Dictionary<QuestionsName, string> QuesionsTexts = new Dictionary<QuestionsName, string>()
    {
    {QuestionsName.NumeroCruzadas,"Cuántas cruzadas se llevaron a cabo ?"},
    {QuestionsName.NumeroAbraham,"Qué número de presidente fue Abraham Lincoln ?"},
    {QuestionsName.GuerraSieteAños,"Cuál de  esta personalidades no participó en la Guerra de los Siete Años ?"},
    {QuestionsName.TruhanesCaballeros,"En la isla de truhanes y caballeros A dice ¨Si B es Truhán yo soy Truhán¨ y B dice ¨Soy un caballero y si A es caballero yo soy Un unicornio volador¨ .Cuál es la respuesta correcta?"},
    {QuestionsName.Partición,"Una partición de un conjunto debe cumplir siertas propiedades .Cuál de estas no cumple ?"},
    {QuestionsName.BatallasNapoleón,"Cuál de estas batallas ocurrió en el año ln e^5 + 2^7 + (Año de natalicio de Antonio Maceo) - 70 - Tercer número natural - 5*(2025 - 2006)?"},
    {QuestionsName.EmperadoresRomanos,"Cuál no fue un emperador romano ?"},
    {QuestionsName.Qadesh,"En qué año fue la batalla de Qadesh?"},
    {QuestionsName.GeneralMuerte,"Qué general murió el 18 de noviembre de 1897 ?"},
    {QuestionsName.Samurais,"Cuál de estos no es un espadachín japonés famoso ?"},
    {QuestionsName.Corsarios,"De qué imperio fue el primer corsario ?"},
    {QuestionsName.SucesiónAustriaca,"Quiénes se enfrentaron en la Guerra de Sucesión Austriaca?"},
    {QuestionsName.Galos,"Cómo se llamó la batalla que desidió la derrota de los galos ?"},
    {QuestionsName.TemplariosAsesino,"Qué prefieres Templarios o Asesinos?"},
    {QuestionsName.BatallasRoma,"Cuál de estas batallas perdió Roma?"},
    {QuestionsName.Demeter,"Cómo se le conocía a Demeter en la mitología romana ?"},
    {QuestionsName.FechasSuma,"En cuál de estas personalidades los dígitos de su natalicio no suman 17 ?"},
    {QuestionsName.Reformistas,"Quíen no era Reformista ?"},
    {QuestionsName.Coseno,"cos 21pi/18 ?"},
    {QuestionsName.LeySeca,"Cuándo comensó la Ley Seca en Estados Unidos ?"},
    {QuestionsName.EsposasTudor,"Cuál de estas no fue una esposa de Enrique VIII?"},
    {QuestionsName.ClasesSociales,"Cuál de estos términos no pertenece al de una clase social ?"},
    {QuestionsName.MuerteRasputín,"Cómo murió Rasputín?"},
    {QuestionsName.Peloponeso,"Quíen venció en la Guerra del Peloponeso ?"},
    {QuestionsName.NombresBarcos,"Cuál de estos no es un nombre de un tipo de barco?"},
    {QuestionsName.Boers,"Dónde se llevó a cabo la Guerra de los Boers ?"},
    {QuestionsName.Banderas,"Cuál de estas banderas no lleva rojo ?"},
    {QuestionsName.Stalin,"Cuándo murió Stalin ?"},
    {QuestionsName.Cargador,"De cuánto es el cargador de una Magnum?"},
    {QuestionsName.TruhanesCaballerosNormales,"En la isla de Truhanes , Caballeros y Normales(Los caballeros dicen la verdad , los truhanes mentira y los normales pueden decir ambas) se tiene que A dijo ¨Que yo diga la verdad implica que B sea un normal que diga la verdad¨ , B dijo¨Todos desimos la verdad¨ ,  C dijo¨A es caballero¨ y luego A dijo¨C no es normal¨.Qué es cada cual?"},
    {QuestionsName.Spartaco,"En qué siglo vivió Spartaco?"},
    {QuestionsName.CaballoBlanco,"De qué color es el caballo blanco de Maceo?"},
    {QuestionsName.Francés,"Cúal de estos no era francés?"},
    {QuestionsName.Yugoslavia,"Qué país no formó parte de Yugoslavia?"},
    {QuestionsName.TripleAlianza,"Quíenes formaban la triple alianza?"},
    {QuestionsName.Religiones,"Cuál era la religión de Rasputín?"},
    {QuestionsName.ArmasNapoleón,"Antes de alcanzar el poder que papel ocupaba Napoleón en el ejército?"},
    {QuestionsName.Prusia,"Dónde se ubicaba Prusia ?"},
    {QuestionsName.PresidenteGM,"Quíen era presidente de Cuba durante la Primera Guerra Mundial?"},
    {QuestionsName.Ejércitonegro,"De qué país era el Ejército Negro?"},
    };
    public static Dictionary<QuestionsName, string> QuestionAnswer = new Dictionary<QuestionsName, string>()
    {
    {QuestionsName.NumeroCruzadas,"8"},
    {QuestionsName.NumeroAbraham,"16"},
    {QuestionsName.GuerraSieteAños,"Charles Monroe"},
    {QuestionsName.TruhanesCaballeros,"A truhán y B caballero"},
    {QuestionsName.Partición,"Debe contener la misma cantidad de elementos que el conjunto"},
    {QuestionsName.BatallasNapoleón,"Trafalgar"},
    {QuestionsName.EmperadoresRomanos,"Julio César"},
    {QuestionsName.Qadesh,"1259 AC"},
    {QuestionsName.GeneralMuerte,"Serafín Sánchez"},
    {QuestionsName.Samurais,"Toshida Yamamoto"},
    {QuestionsName.Corsarios,"Inglaterra"},
    {QuestionsName.SucesiónAustriaca,"Francia,España,Prusia,Suecia vs Sacro Imperio Romano Germánico,Austria,Reino Unido,Rusia"},
    {QuestionsName.Galos,"Alesia"},
    {QuestionsName.TemplariosAsesino,"Templarios"},
    {QuestionsName.BatallasRoma,"Canas"},
    {QuestionsName.Demeter,"Ceres"},
    {QuestionsName.FechasSuma,"Vladimir ll'ish Lenin"},
    {QuestionsName.Reformistas,"José Mártinez Agüero"},
    {QuestionsName.Coseno,"-Math.Square(3)/2"},
    {QuestionsName.LeySeca,"1920"},
    {QuestionsName.EsposasTudor,"Isabel de Cléveris"},
    {QuestionsName.ClasesSociales,"Empresarios"},
    {QuestionsName.MuerteRasputín,"A balasos"},
    {QuestionsName.Peloponeso,"Sparta"},
    {QuestionsName.NombresBarcos,"Calabera"},
    {QuestionsName.Boers,"Sudáfrica"},
    {QuestionsName.Banderas,"Estonia"},
    {QuestionsName.Stalin,"1953"},
    {QuestionsName.Cargador,"6"},
    {QuestionsName.TruhanesCaballerosNormales,"A es caballero , B es normal y C es caballero"},
    {QuestionsName.CaballoBlanco,"Blanco"},
    {QuestionsName.Francés,"Toussaint Louverture"},
    {QuestionsName.Yugoslavia,"Eslovaquia"},
    {QuestionsName.TripleAlianza,"Argentina,Uruguay,Brasil"},
    {QuestionsName.Religiones,"Ninguna"},
    {QuestionsName.ArmasNapoleón,"Artilleria"},
    {QuestionsName.Prusia,"Por Alemania"},
    {QuestionsName.PresidenteGM,"Mario García Menocal"},
    {QuestionsName.Ejércitonegro,"Hungría"},
    };
    public static Dictionary<QuestionsName, string[]> Elections = new Dictionary<QuestionsName, string[]>()
    {
     {QuestionsName.NumeroCruzadas,["5","8","7","4"]},
     {QuestionsName.TruhanesCaballeros,["A truhán y B caballero","A caballero y B truhán","A caballero y B caballero","A truhán y B truhán"]},
     {QuestionsName.TruhanesCaballerosNormales,["A es caballero , B es truhán y C es normal","A es caballero , B es normal y C es caballero","A es truhán , B es normal y C es caballero","A es caballero , B es normal y C es normal"]},
     {QuestionsName.MuerteRasputín,["Envenenado","Ahorcado","Desangrado por Emofilia","A balasos"]},
     {QuestionsName.Coseno,["Math.Square(3)/2","-Math.Square(3)/2","1/2","-1/2"]},
     {QuestionsName.GeneralMuerte,["Antonio Maceo","Serafín Sánchez","José Agüero","Miguel Jerónimo Gutierrez"]},
     {QuestionsName.TemplariosAsesino,["Templarios","Asesinos"]},
     {QuestionsName.Corsarios,["España","Francia","Inglaterra","Holanda"]},
     {QuestionsName.FechasSuma,["José Martí","Enrique VIII","Vladimir ll'ish Lenin","Gerardo Machado"]},
     {QuestionsName.Peloponeso,["Milenas","Illos","Atenas","Sparta"]},
     {QuestionsName.Reformistas,["Miguel Aldama","José Antonio Saco","Claudio Mártinez de Pinillos","José Mártinez Agüero"]},
     {QuestionsName.NombresBarcos,["Fragata","Goleta","Galeón","Calabera"]},
     {QuestionsName.Boers,["Nigeria","Sudáfrica","Zimbabue","Congo"]},
     {QuestionsName.Cargador,["7","8","6","5"]},
     {QuestionsName.CaballoBlanco,["Obviamente Negro","Blanco","Gris","Rosado"]},
     {QuestionsName.TripleAlianza,["Argentina,Uruguay,Brasil","Venezuela,Cuba,Bolivia","Alemania,Italia,Japón","Inglaterra,Francia,Rusia"]},
     {QuestionsName.ArmasNapoleón,["Fusilería","Artillería","Infantería","Mesero"]},
     {QuestionsName.Religiones,["Cristianismo Ortodoxo","Catolisismo","Taoísmo","Musulmana","Ninguna"]},
     {QuestionsName.Ejércitonegro,["Angola","Hungría","Bélgica","Austria","Francia"]},
     {QuestionsName.GuerraSieteAños,["Jorge Washington","James Cook","Pepe Antonio","Charles Monroe"]},
     {QuestionsName.NumeroAbraham,["16","17","18","20"]},
     {QuestionsName.EsposasTudor,["Ana Bolena","Catalina Parr","Juana Seymour","Isabel de Cléveris"]},
     {QuestionsName.Partición,["No debe tener elementos con intersección distinta al vacio","La unión de sus elementos debe ser el mismo conjunto","Debe contener la misma cantidad de elementos que el conjunto","El vació no debe pertenecer"]},
     {QuestionsName.BatallasNapoleón,["Saradino","Trafalgar","Waterloo","Austerlich"]},
     {QuestionsName.EmperadoresRomanos,["Augustus","Carinio","Claudio","Julio César"]},
     {QuestionsName.Qadesh,["434 AC","1259 AC","1211 DC","3492 AC"]},
     {QuestionsName.Samurais,["Miyamoto Mushashi","Muso Gonosuke","Toshida Yamamoto","Sasaki Kojiro"]},
     {QuestionsName.Stalin,["1965","1960","1953","1958"]},
     {QuestionsName.Banderas,["Belice","Ecuador","Liechtenstein","Estonia"]},
     {QuestionsName.ClasesSociales,["Patricio","Clero","Equites","Empresarios"]},
     {QuestionsName.PresidenteGM,["Ramón Grau San Martín","Mario García Menocal","José Miguel Gómez","Gerardo Machado"]},
     {QuestionsName.Prusia,["Por Francia","Por Rusia","Por Alemania","Por Repúbica Checa"]},
     {QuestionsName.Galos,["Armeda","Alesia","Aledea","Aludena"]},
     {QuestionsName.Yugoslavia,["Monte Negro","Kosovo","Eslovenia","Eslovaquia"]},
     {QuestionsName.SucesiónAustriaca,["Francia,Reino Unido,Prusia,Suecia vs Sacro Imperio Romano Germánico,Austria,Fracia,Rusia","Francia,España,Prusia,,Sacro Imperio Romano Germánico vs Hungría,Austria,Italia,Reino Unido,Rusia","Francia,Prusia,Rusia,Suecia,España vs Sacro Imperio Romano Germánico,Austria,Reino Unido,Noruega","Francia,España,Prusia,Suecia vs Sacro Imperio Romano Germánico,Austria,Reino Unido,Rusia",]},
     {QuestionsName.BatallasRoma,["ALia","Canas","Cartago","Monte Gauro"]},
     {QuestionsName.Demeter,["Minfis","Darnes","Ceres","Serme"]},
     {QuestionsName.LeySeca,["1929","1921","1919","1920"]},
    };
    public static List<QuestionsName> QuestionsInGame = new List<QuestionsName>()
    {
    QuestionsName.NumeroCruzadas,
    QuestionsName.NumeroAbraham,
    QuestionsName.GuerraSieteAños,
    QuestionsName.TruhanesCaballeros,
    QuestionsName.Partición,
    QuestionsName.BatallasNapoleón,
    QuestionsName.EmperadoresRomanos,
    QuestionsName.Qadesh,
    QuestionsName.GeneralMuerte,
    QuestionsName.Samurais,
    QuestionsName.Corsarios,
    QuestionsName.SucesiónAustriaca,
    QuestionsName.Galos,
    QuestionsName.TemplariosAsesino,
    QuestionsName.BatallasRoma,
    QuestionsName.Demeter,
    QuestionsName.FechasSuma,
    QuestionsName.Reformistas,
    QuestionsName.Coseno,
    QuestionsName.LeySeca,
    QuestionsName.EsposasTudor,
    QuestionsName.ClasesSociales,
    QuestionsName.MuerteRasputín,
    QuestionsName.Peloponeso,
    QuestionsName.NombresBarcos,
    QuestionsName.Boers,
    QuestionsName.Banderas,
    QuestionsName.Stalin,
    QuestionsName.Cargador,
    QuestionsName.TruhanesCaballerosNormales,
    QuestionsName.Spartaco,
    QuestionsName.CaballoBlanco,
    QuestionsName.Francés,
    QuestionsName.Yugoslavia,
    QuestionsName.TripleAlianza,
    QuestionsName.Religiones,
    QuestionsName.ArmasNapoleón,
    QuestionsName.Prusia,
    QuestionsName.PresidenteGM,
    QuestionsName.Ejércitonegro,
    };
}