using UnityEngine;

[CreateAssetMenu(fileName = "EfeitoPerdeElmo", menuName = "Scriptable Objects/EfeitoPerdeElmo")]
public class EfeitoPerdeElmo : Efeito
{
    public EfeitoPerdeElmo(string titulo, object[] descricao) : base(titulo, descricao)
    {
    }
    public override void Apply()
    {
        //throw new System.NotImplementedException();
    }
}
