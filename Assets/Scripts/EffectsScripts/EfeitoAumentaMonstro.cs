using UnityEngine;

[CreateAssetMenu(fileName = "EfeitoAumentaMonstro", menuName = "Scriptable Objects/EfeitoAumentaMonstro")]
public class EfeitoAumentaMonstro : Efeito
{
    public EfeitoAumentaMonstro(string titulo, dynamic[] descricao) : base(titulo, descricao) {}
    public override void Apply() {
        //throw new System.NotImplementedException();
    }
}
