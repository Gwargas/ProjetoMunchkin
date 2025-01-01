using UnityEngine;

[CreateAssetMenu(fileName = "EfeitoPerdeItemGrande", menuName = "Scriptable Objects/EfeitoPerdeItemGrande")]
public class EfeitoPerdeItemGrande : Efeito
{
    public EfeitoPerdeItemGrande(string titulo, object[] descricao) : base(titulo, descricao)
    {
    }
    public override void Apply()
    {
        //throw new System.NotImplementedException();
    }
}
