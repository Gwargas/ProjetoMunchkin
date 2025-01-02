using UnityEngine;

[CreateAssetMenu(fileName = "EfeitoPerdeArmadura", menuName = "Scriptable Objects/EfeitoPerdeArmadura")]
public class EfeitoPerdeArmadura : Efeito
{
    public EfeitoPerdeArmadura(string titulo, dynamic[] descricao) : base(titulo, descricao)
    {
    }

    public override void Apply()
    {
        //throw new System.NotImplementedException();
    }
}
