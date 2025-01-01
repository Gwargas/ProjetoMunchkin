using UnityEngine;

[CreateAssetMenu(fileName = "EfeitoPerdeRaça", menuName = "Scriptable Objects/EfeitoPerdeRaça")]
public class EfeitoPerdeRaça : Efeito
{
    public EfeitoPerdeRaça(string titulo, object[] atributos) : base(titulo, atributos)
    {
    }
    public override void Apply()
    {
        //throw new System.NotImplementedException();
    }
}
