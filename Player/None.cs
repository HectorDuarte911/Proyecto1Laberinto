namespace ProjectLogic;
public class NonePlayer:PlayerBasic
{
public override  Player player=>Player.None;
public override bool IsInGame=>false;
}