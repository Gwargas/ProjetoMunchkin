using UnityEngine;

[CreateAssetMenu(fileName = "EfeitoPerdeCalca", menuName = "Scriptable Objects/EfeitoPerdeCalca")]
public class EfeitoPerdeCalca : Efeito
{
    public EfeitoPerdeCalca(string titulo, object[] descricao) : base(titulo, descricao)
    {
    }
    
    public override void Apply()
    {
        //throw new System.NotImplementedException();
    }
}
