using UnityEngine;

[CreateAssetMenu(fileName = "EfeitoPerdeCalcado", menuName = "Scriptable Objects/EfeitoPerdeCalcado")]
public class EfeitoPerdeCalcado : Efeito
{
    public EfeitoPerdeCalcado(string titulo, dynamic[] descricao) : base(titulo, descricao)
    {
    }
    public override void Apply()
    {
        //throw new System.NotImplementedException();
    }
}
