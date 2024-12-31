using UnityEngine;

[CreateAssetMenu(fileName = "EfeitoAumentaMonstro", menuName = "Scriptable Objects/EfeitoAumentaMonstro")]
public class EfeitoAumentaMonstro : Efeito
{
    public override void Apply() {
        int nivel = int.Parse(descricao[0]);
        int tesouro = int.Parse(descricao[1]);
        //throw new System.NotImplementedException();
    }
}
