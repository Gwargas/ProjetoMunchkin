using UnityEngine;

[CreateAssetMenu(fileName = "EfeitoPerdeItemPequeno", menuName = "Scriptable Objects/EfeitoPerdeItemPequeno")]
public class EfeitoPerdeItemPequeno : Efeito
{
    public EfeitoPerdeItemPequeno(string titulo, object[] valores) : base(titulo, valores)
    {
    }

    public override void Apply()
    {
        //throw new System.NotImplementedException();
    }

}
