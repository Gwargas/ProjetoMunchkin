using UnityEngine;

[CreateAssetMenu(fileName = "EfeitoPerdeNivel", menuName = "Scriptable Objects/EfeitoPerdeNivel")]
public class EfeitoPerdeNivel : Efeito
{
    public EfeitoPerdeNivel(string titulo, object[] atributos) : base(titulo, atributos)
    {
    }
    public override void Apply()
    {
        //throw new System.NotImplementedException();
    }
}
