using UnityEngine;

[CreateAssetMenu(fileName = "EfeitoPerdeClasse", menuName = "Scriptable Objects/EfeitoPerdeClasse")]
public class EfeitoPerdeClasse : Efeito
{
    public EfeitoPerdeClasse(string titulo, object[] descricao) : base(titulo, descricao)
    {
    }
    public override void Apply()
    {
        //throw new System.NotImplementedException();
    }
}
